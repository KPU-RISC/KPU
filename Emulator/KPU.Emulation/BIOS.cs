using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU.Emulation
{
    /// <summary>
    /// This class implements simple BIOS functions, like reading and writing Disk Sectors of 512 bytes.
    /// </summary>
    public class BIOS
    {
        private string virtualDisk;
        public static int SECTOR_SIZE = 512;

        /// <summary>
        /// Initializes the BIOS with the physical path to the virtual disk.
        /// </summary>
        /// <param name="VirtualDisk"></param>
        public BIOS(string VirtualDisk)
        {
            this.virtualDisk = VirtualDisk;
        }

        /// <summary>
        /// Reads specific disk sectors from the virtual disk.
        /// </summary>
        /// <param name="StartSector">On which sector should the Read operation start?</param>
        /// <param name="SectorsToRead">How many sectors should be read?</param>
        /// <returns></returns>
        public byte[] ReadDiskSector(int StartSector, int SectorsToRead)
        {
            using (FileStream stream = new FileStream(virtualDisk, FileMode.Open))
            {
                byte[] buffer = new byte[SectorsToRead * SECTOR_SIZE];
                stream.Seek(StartSector * SECTOR_SIZE, SeekOrigin.Begin);
                
                for (int i = 0; i < SECTOR_SIZE; i++)
                {
                    buffer[i] = (byte)stream.ReadByte();
                }

                return buffer;
            }
        }

        /// <summary>
        /// Writes a specific disk sector to the virtual disk.
        /// </summary>
        /// <param name="Sector">Which sector should we write?</param>
        /// <param name="Data">The new data of the disk sector</param>
        public void WriteDiskSector(int Sector, byte[] Data)
        {
            using (FileStream stream = new FileStream(virtualDisk, FileMode.Open))
            {
                stream.Write(Data, Sector * SECTOR_SIZE, SECTOR_SIZE);
            }
        }
    }
}