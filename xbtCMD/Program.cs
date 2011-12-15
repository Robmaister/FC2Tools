/*Copyright (c) 2011 Robert Rouhani

This software is provided 'as-is', without any express or implied
warranty. In no event will the authors be held liable for any damages
arising from the use of this software.

Permission is granted to anyone to use this software for any purpose,
including commercial applications, and to alter it and redistribute it
freely, subject to the following restrictions:

   1. The origin of this software must not be misrepresented; you must not
   claim that you wrote the original software. If you use this software
   in a product, an acknowledgment in the product documentation would be
   appreciated but is not required.

   2. Altered source versions must be plainly marked as such, and must not be
   misrepresented as being the original software.

   3. This notice may not be removed or altered from any source
   distribution.
 
Robert Rouhani <robert.rouhani@gmail.com>*/

using System;
using System.Collections.Generic;
using System.IO;

using FC2Tools.libFC2;

namespace FC2Tools.xbtCMD
{
	class Program
	{
		private static string s_location = "";
		private static string s_location_last = "";
		private static string s_destination = "";
		private static string s_destination_last = "";
		private static List<string> files = new List<string>();

		private static void WriteHelp()
		{
			//Write the help message
			Console.WriteLine("");
			Console.WriteLine("USAGE:");
			Console.WriteLine("xbtCMD.exe [location] [destination]");
			Console.WriteLine("");
			Console.WriteLine("Example: xbtCMD.exe C:\\original C:\\converted");
		}
		private static void BuildConvertList(string location)
		{
			//Define the directory and search each item contained in it
			DirectoryInfo dir_info = new DirectoryInfo(@location);
			foreach (FileInfo f in dir_info.GetFiles("*.xbt"))
			{
				//only add .xbt files
				files.Add(f.FullName);
			}
			foreach (DirectoryInfo d in dir_info.GetDirectories())
			{
				//recursively search each directory in the root dir
				BuildConvertList(d.FullName);
			}
		}

		private static void BuildDestinationTree(string location)
		{
			//Set the root directory
			DirectoryInfo dir_root = new DirectoryInfo(location);
			foreach (DirectoryInfo d in dir_root.GetDirectories())
			{
				//Create a new folder in the destination directory
				Directory.CreateDirectory(d.FullName.Replace(s_location, s_destination));

				//Recursively search each directory
				BuildDestinationTree(d.FullName);
			}
		}

		private static int Main(string[] args)
		{
			Console.WriteLine("xbtCMD made by Robert Rouhani");
			Console.WriteLine("Version 0.1");
			System.Threading.Thread.Sleep(1000);

			//make sure there's only 2 args
			if (args.Length != 2)
			{
				Console.WriteLine("Error: Invalid Arguements.");
				WriteHelp();
				return 1;
			}

			//set the args to the location and the destination
			s_location = args[0].ToString();
			s_destination = args[1].ToString();

			//Set the last char for the / check
			s_location_last = s_location.Substring(s_location.Length - 1, 1);
			s_destination_last = s_destination.Substring(s_destination.Length - 1, 1);

			//check for ending with / and fix if it doesn't
			if (s_location_last != "\\" && s_location_last != "/")
			{
				s_location = s_location + "\\";
			}

			if (s_destination_last != "\\" && s_destination_last != "/")
			{
				s_destination = s_destination + "\\";
			}

			//If the location is a file, there are no containing files. Return an error.
			if (File.Exists(s_location))
			{
				Console.WriteLine("{0} is a file, not a directory.", s_location);
				WriteHelp();
				return 1;
			}

			//If the destination is a file, there is no place to put the converted textures. Return an error.
			if (File.Exists(s_destination))
			{
				Console.WriteLine("{0} is a file, not a directory.", s_destination);
				WriteHelp();
				return 1;
			}

			//If the location doesn't exist, there are no files. Return an error.
			if (!Directory.Exists(s_location))
			{
				Console.WriteLine("{0} does not exist.", s_location);
				WriteHelp();
				return 1;
			}

			//Create a destination directory if one doesn't exist.
			if (!Directory.Exists(s_destination))
			{
				Directory.CreateDirectory(s_destination);
			}

			//Build a list of files and generate the directory tree in the destination
			BuildDestinationTree(s_location);
			BuildConvertList(s_location);

			foreach (string file in files)
			{
				XBT XBT = new XBT(file);
				Console.WriteLine("Converting File: {0}", file);

				//Change the destination filename
				string file_dest = file.Replace(s_location, s_destination + "\\");
				file_dest = file_dest.Remove(file_dest.Length - 3, 3);
				file_dest = file_dest + "dds";

				//Write the converted texture to the new file
				FileStream fs_out = new FileStream(@file_dest, FileMode.Create, FileAccess.Write);
				BinaryWriter writer = new BinaryWriter(fs_out);
				writer.Write(XBT.Texture);

				//Cleaning up
				writer.Close();
				fs_out.Close();
			}

			Console.WriteLine("");
			Console.WriteLine("{0} files successfully converted!", files.Count);
			return 0;
		}
	}
}
