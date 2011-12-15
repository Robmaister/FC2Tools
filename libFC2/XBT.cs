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

namespace FC2Tools.libFC2
{
	public class XBT
	{
		private byte[] header;
		private byte[] ddsFile;

		public byte[] Header { get { return header; } }

		public byte[] Texture { get { return ddsFile; } }

		public XBTMetadata Metadata
		{
			get
			{
				//DDS header, excluding bytes 0-7 (magic number and header length)
				BinaryReader reader = new BinaryReader(new MemoryStream(ddsFile, 8, 24));
				XBTMetadata data;
				data.Flags = reader.ReadInt32(); //DDS flags
				data.Height = reader.ReadInt32(); //Tex0 Height
				data.Width = reader.ReadInt32(); //Tex0 Width
				data.Tex0Bytes = reader.ReadInt32(); //Tex0 byte count
				data.ColorDepth = reader.ReadInt32(); //Color Depth
				data.MipmapsCount = reader.ReadInt32(); //Number of mipmaps

				return data;
			}
		}

		public XBT(string path)
			: this(new FileStream(path, FileMode.Open))
		{

		}

		public XBT(Stream stream)
			: this(ReadBufferToEnd(stream))
		{
		}

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
		}

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

	public struct XBTMetadata
	{
		public int Flags;
		public int Height;
		public int Width;
		public int Tex0Bytes;
		public int ColorDepth;
		public int MipmapsCount;
	}
}
