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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FC2Tools.xbgCovnert
{
	public partial class FormXBG : Form
	{
		public FormXBG()
		{
			InitializeComponent();
		}


		private int convertToLittleEndian(int i)
		{
			uint uNum = (uint)i;
			uint swappedNum = ( (0x000000FF) & (uNum >> 24)
								|(0x0000FF00) & (uNum >> 8)
								|(0x00FF0000) & (uNum << 8) 
								|(0xFF000000) & (uNum << 24) );
			return (int)swappedNum;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			FileStream fs = new FileStream(@"D:\Projects\Far Cry 2 Extracted Content\starsphere.xbg", FileMode.Open, FileAccess.Read);
			byte[] byte_in = new byte[fs.Length];
			byte[] byte_out = new byte[fs.Length];
			byte[] byte_out_rev = new byte[fs.Length];

			int i_bytesLeft = (int)fs.Length;
			int i_bytesRead = 0;

			while (i_bytesLeft > 0)
			{
				//read filestream to byte array
				int i_read = fs.Read(byte_in, i_bytesRead, i_bytesLeft);

				//break from while loop when fs.Read reaches EOF
				if (i_read == 0)
				{
					break;
				}

				//adjust numbers to current read position
				i_bytesRead += i_read;
				i_bytesLeft -= i_read;
			}

			int loopnum = byte_in.Length / 4;
			for (int i = 0; i < loopnum; i++)
			{
				int pos = 4 * i;
				byte[] BigEndByte = new byte[4];

				BigEndByte[0] = byte_in[pos];
				BigEndByte[1] = byte_in[pos + 1];
				BigEndByte[2] = byte_in[pos + 2];
				BigEndByte[3] = byte_in[pos + 3];

				int bigEndInt = BitConverter.ToInt32(BigEndByte, 0);
				int LittleEndInt = convertToLittleEndian(bigEndInt);

				byte[] LittleEndByte = BitConverter.GetBytes(LittleEndInt);

				byte_out[pos] = LittleEndByte[0];
				byte_out[pos + 1] = LittleEndByte[1];
				byte_out[pos + 2] = LittleEndByte[2];
				byte_out[pos + 3] = LittleEndByte[3];
			}

			for (int i = 0; i < fs.Length; i++)
			{
				byte_out_rev[i] = byte_in[i];
			}
			Array.Reverse(byte_out_rev);

			FileStream fs_out = new FileStream(@"D:\Projects\Far Cry 2 Extracted Content\starsphere_ltend.xbg", FileMode.Create, FileAccess.Write);
			BinaryWriter writer = new BinaryWriter(fs_out);
			writer.Write(byte_out);
			writer.Close();
			fs_out.Close();

			FileStream fs_out_rev = new FileStream(@"D:\Projects\Far Cry 2 Extracted Content\starsphere_ltend_rev.xbg", FileMode.Create, FileAccess.Write);
			BinaryWriter writer_rev = new BinaryWriter(fs_out_rev);
			writer_rev.Write(byte_out_rev);
			writer_rev.Close();
			fs_out_rev.Close();

				
		}
	}
}
