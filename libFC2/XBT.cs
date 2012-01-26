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
using System.IO;
using System.Text;

namespace FC2Tools.libFC2
{
	public class XBT
	{
		const int MagicWord = /*('X' << 8 | 'B' << 16 | 'T' << 24)*/ 0x00584254;

		private int unknown0;
		private int headerLength;
		private int unknown2;
		private int unknown3;
		private int unknown4;
		private int unknown5;
		private string pathToMip0;

		private byte[] ddsFile;
		public byte[] Texture { get { return ddsFile; } }

		public XBT(string path)
			: this(new BinaryReader(File.Open(path, FileMode.Open)))
		{

		}

		public XBT(BinaryReader reader)
		{
			if (reader.ReadInt32() != MagicWord)
			{
				throw new ArgumentException("The file is not a properly formatted XBT file");
			}

			unknown0 = reader.ReadInt32();
			headerLength = reader.ReadInt32();
			unknown2 = reader.ReadInt32();
			unknown3 = reader.ReadInt32();
			unknown4 = reader.ReadInt32();
			unknown5 = reader.ReadInt32();

			StringBuilder builder = new StringBuilder("");

			char[] chars = new char[4];
			int fourChars;

			while (reader.BaseStream.Position < headerLength)
			{
				fourChars = reader.ReadInt32();

				chars[0] = (char)(fourChars & 0xFF);
				chars[1] = (char)(fourChars >> 8 & 0xFF);
				chars[2] = (char)(fourChars >> 16 & 0xFF);
				chars[3] = (char)(fourChars >> 24 & 0xFF);

				foreach (char c in chars)
				{
					if (c != '\0')
						builder.Append(c);
				}
			}

			ddsFile = ReadBufferToEnd(reader.BaseStream);
		}

		/*
		public XBT(byte[] data)
		{
			int i = 0;
			for (; i < data.Length - 4; i++)
			{
				if (data[i] == 0x44 && data[i + 1] == 0x44 && data[i + 2] == 0x53 && data[i + 3] == 0x20)
					break;
			}

			if (i == data.Length - 4)
				throw new ArgumentException("This file is not an XBT file.", "data");


			header = new byte[i];
			ddsFile = new byte[data.Length - i];

			Buffer.BlockCopy(data, 0, header, 0, header.Length);
			Buffer.BlockCopy(data, i - 1, ddsFile, 0, ddsFile.Length);
		}*/

		private static byte[] ReadBufferToEnd(Stream input)
		{
			byte[] buffer = new byte[16 * 1024];
			using (MemoryStream ms = new MemoryStream())
			{
				int read;
				while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
				{
					ms.Write(buffer, 0, read);
				}
				return ms.ToArray();
			}
		}
	}
}
