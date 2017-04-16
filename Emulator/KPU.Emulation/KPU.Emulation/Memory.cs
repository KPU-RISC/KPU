using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPU.Emulation
{
    public class Memory
    {
        private readonly byte[] memory;

        // <summary>
		/// Initializes a new RAM object.
		/// </summary>
		/// <param name="Size">The size of memory to be initialized</param>
		public Memory(int Size)
		{
			memory = new byte[Size];
			ClearMemory();
		}

		/// <summary>
		/// Clears the memory
		/// </summary>
		public void ClearMemory()
		{
			for (var i = 0; i < memory.Length; i++)
				memory[i] = 0x00;
		}

		/// <summary>
		/// Returns the byte at the given address.
		/// </summary>
		/// <param name="address">The address to return</param>
		/// <returns>the byte being returned</returns>
		public byte ReadValue(int address)
		{
			return memory[address];
		}

		/// <summary>
		/// Writes data to the given address.
		/// </summary>
		/// <param name="address"></param>
		/// <param name="data"></param>
		public void WriteValue(int address, byte data)
		{
			memory[address] = data;
		}

		/// <summary>
		/// Loads a new program into the memory
		/// </summary>
		/// <param name="offset">The offset at which to load the program</param>
		/// <param name="program">The program to be loaded</param>
		public void LoadProgram(int offset, byte[] program)
		{
			if (offset > memory.Length)
				throw new InvalidOperationException("Offset '{0}' is larger than memory size '{1}'");

			if (program.Length > memory.Length + offset)
				throw new InvalidOperationException(string.Format("Program Size '{0}' Cannot be Larger than Memory Size '{1}' plus offset '{2}'", program.Length, memory.Length, offset));

			for (var i = 0; i < program.Length; i++)
			{
				memory[i + offset] = program[i];
			}
		}

		/// <summary>
		/// Dumps the entire memory object. Used when saving the memory state
		/// </summary>
		/// <returns></returns>
		public byte[] DumpMemory()
		{
			return memory;
		}
    }
}
