using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KPU.Emulation;

namespace KPU.Emulator
{
    public partial class Memory : Form
    {
        private Processor cpu;

        public Processor CPU
        {
            get { return cpu; }
            set { cpu = value; }
        }

        public Memory()
        {
            InitializeComponent();
        }

        private void Memory_Load(object sender, EventArgs e)
        {
        }

        public void InitializeMemory()
        {
            int startAddress = 0;
            lstMemory.Items.Clear();

            for (int row = 0; row < 4096; row++)
            {
                string memoryAddress = "0x" + startAddress.ToString("X4");
                string[] memoryContent = cpu.DumpMemory(startAddress);

                lstMemory.Items.Add(new ListViewItem(memoryContent));

                startAddress += 16;
            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            InitializeMemory();
        }
    }
}
