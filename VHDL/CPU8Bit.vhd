----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/20/2015 10:41:46 PM
-- Design Name: 
-- Module Name: CPU8Bit - Behavioral
-- Project Name: 
-- Target Devices: 
-- Tool Versions: 
-- Description: 
-- 
-- Dependencies: 
-- 
-- Revision:
-- Revision 0.01 - File Created
-- Additional Comments:
-- 
----------------------------------------------------------------------------------


library IEEE;
use IEEE.STD_LOGIC_1164.ALL;

-- Uncomment the following library declaration if using
-- arithmetic functions with Signed or Unsigned values
--use IEEE.NUMERIC_STD.ALL;

-- Uncomment the following library declaration if instantiating
-- any Xilinx leaf cells in this code.
--library UNISIM;
--use UNISIM.VComponents.all;

entity CPU8Bit is
    port
    (
        Clock           : in BIT;
        Start           : in BIT;
        Reset           : in BIT;
        Load_RAM        : in BIT;
        Select_RAM      : in BIT;
        Address_RAM     : in BIT_VECTOR(15 downto 0);
        Input_RAM       : in BIT_VECTOR(7 downto 0);
        PC              : in BIT_VECTOR(15 downto 0);
        Load_PC         : in BIT;
        InputPort_A     : in BIT_VECTOR(7 downto 0);
        InputPort_B     : in BIT_VECTOR(7 downto 0);
        OutputPort_C    : out BIT_VECTOR(7 downto 0);
        OutputPort_D    : out BIT_VECTOR(7 downto 0);
        Instruction     : out BIT_VECTOR(7 downto 0)
    );
end CPU8Bit;

architecture Behavioral of CPU8Bit is

component Counter4Bit is
    port
    (
        Clock : in BIT;
        Reset : in BIT;
        Output: out STD_LOGIC_VECTOR(3 downto 0)
    );
end component Counter4Bit;

component Decoder3to8 is
    Port
    (
        F : in BIT_VECTOR(2 downto 0);   -- 3-Bit Function Code (Input)
        X : out BIT_VECTOR(7 downto 0);  -- 8-Bit State (Output)
        Started: in BIT                  -- Is the CPU already running?
    );  
end component Decoder3to8;

component RAM_Wrapper is
    port
    (
        Clock:      IN BIT;
        Load:       IN BIT;
        Sel:        IN BIT;     -- Requests the data from the RAM
        Ret:        IN BIT;     -- Returns the data from the RAM and places it onto the data bus
        Address:    IN BIT_VECTOR(15 DOWNTO 0);
        Input:      IN BIT_VECTOR(7 DOWNTO 0);
        Output:     OUT BIT_VECTOR(7 DOWNTO 0)
    );
end component RAM_Wrapper;

component Register8Bit is
    Port
    (
        Load   : in  BIT;                     -- Load Line
        Sel    : in  BIT;                     -- Select Line
        Input  : in  BIT_VECTOR(7 downto 0);  -- 8-bit input value
        Output : out BIT_VECTOR(7 downto 0);  -- 8-bit output value
        State  : out BIT_VECTOR(7 downto 0)   -- Current state of the Flip Flop
    );
end component Register8Bit;

component Register8Bit2WayOutput is
    Port
    (
        Load    : in BIT;                     -- Load Line
        Sel1    : in BIT;                     -- Select Line #1
        Sel2    : in BIT;                     -- Select Line #2
        Input   : in  BIT_VECTOR(7 downto 0); -- 8-bit input value
        Output1 : out BIT_VECTOR(7 downto 0); -- 8-bit output value #1
        Output2 : out BIT_VECTOR(7 downto 0); -- 8-bit output value #2
        State   : out BIT_VECTOR(7 downto 0)  -- Current state of the Flip Flop
    );
end component Register8Bit2WayOutput;

component Register8Bit2WayInput is
    Port
    (
        Load1   : in BIT;                     -- Load Line #1
        Load2   : in BIT;                     -- Load Line #2
        Sel     : in BIT;                     -- Select Line
        Input1  : in  BIT_VECTOR(7 downto 0); -- 8-bit input value #1
        Input2  : in  BIT_VECTOR(7 downto 0); -- 8-bit input value #2
        Output  : out BIT_VECTOR(7 downto 0); -- 8-bit output value
        State   : out BIT_VECTOR(7 downto 0)  -- Current state of the Flip Flop
    );
end component Register8Bit2WayInput;

component Register16Bit is
    Port
    (
        Load   : in  BIT;                     -- Load Line
        Sel    : in  BIT;                     -- Select Line
        Input  : in  BIT_VECTOR(15 downto 0); -- 16-bit input value
        Output : out BIT_VECTOR(15 downto 0); -- 16-bit output value
        State  : out BIT_VECTOR(15 downto 0)  -- Current state of the Flip Flop
    );
end component Register16Bit;

component RegisterExtended16Bit is
    Port
    (
        Load_8Bit_L:     in BIT;                        -- Load Line #1 (bits 0 - 7)
        Load_8Bit_H:     in BIT;                        -- Load Line #2 (bits 8 - 15)
        Load_16Bit:      in BIT;                        -- Load Line #3 (bits 0 - 15)
        Select_8Bit_L:   in BIT;                        -- Select Line #1 (bits 0 - 7)
        Select_8Bit_H:   in BIT;                        -- Select Line #2 (bits 8 - 15)
        Select_16Bit:    in BIT;                        -- Select Line #3 (bits 0 - 15)
        Input_8Bit_L:    in BIT_VECTOR(7 downto 0);     -- 8-bit input value (bits 0 - 7)
        Input_8Bit_H:    in BIT_VECTOR(7 downto 0);     -- 8-bit input value (bits 8 - 15)
        Input_16Bit:     in BIT_VECTOR(15 downto 0);    -- 16-bit input value (bits 0 - 15)
        Output_8Bit_L:   out BIT_VECTOR(7 downto 0);    -- 8-bit output value (bits 0 - 7)
        Output_8Bit_H:   out BIT_VECTOR(7 downto 0);    -- 8-bit output value (bits 8 - 15)
        Output_16Bit:    out BIT_VECTOR(15 downto 0);   -- 16-bit output value (bits 0 - 15)
        State_8Bit_L:    out BIT_VECTOR(7 downto 0);    -- Current state of the Flip Flop (bits 0 - 7)
        State_8Bit_H:    out BIT_VECTOR(7 downto 0);    -- Current state of the Flip Flop (bits 8 - 15)
        State_16Bit:     out BIT_VECTOR(15 downto 0)    -- Current state of the Flip Flop (bits 0 - 15)
    );
end component RegisterExtended16Bit;

component Increment8Bit is
    Port
    (
        Input  : in  BIT_VECTOR(7 downto 0); -- 8-bit input value
        Cin    : in  BIT;                    -- Carry-in flag
        Output : out BIT_VECTOR(7 downto 0); -- 8-bit output value
        Cout   : out BIT                     -- Carry-out flag
    );
end component Increment8Bit;

component Increment16Bit is
    Port
    (
        Input  : in  BIT_VECTOR(15 downto 0); -- 16-bit input value
        Cin    : in  BIT;                     -- Carry-in flag
        Output : out BIT_VECTOR(15 downto 0); -- 16-bit output value
        Cout   : out BIT                      -- Carry-out flag
    );
end component Increment16Bit;

component InstructionDecoder is
    port
    (
        TimingSignals : in BIT_VECTOR(7 downto 0);  -- The 8 different timing states
        Instruction   : in BIT_VECTOR(7 downto 0);  -- The instruction to execute
        Flags         : in BIT_VECTOR(7 downto 0);  -- Content of the FLAGS register - needed for conditional jumps
        
        -- ==============================================================
        -- The various control lines of the CPU which go low/high 
        -- depending on the timing state and the instruction to execute:
        -- ==============================================================
        Load_PC :                           out BIT;
        Select_PC :                         out BIT;
        Load_SRAM:                          out BIT;
        Select_SRAM:                        out BIT;
        Return_SRAM:                        out BIT;
        Load_INC:                           out BIT;
        Select_INC:                         out BIT;
        Load_INSTR:                         out BIT;
        Select_INSTR_To_DataBus:            out BIT;
        Select_INSTR_To_ALU:                out BIT;
        Load_A_From_DataBus:                out BIT;
        Select_A_To_ALU:                    out BIT;
        Load_B_From_DataBus:                out BIT;
        Select_B_To_ALU:                    out BIT;
        Load_C_From_DataBus:                out BIT;
        Load_InternalA_From_DataBus:        out BIT;
        Select_InternalA_To_DataBus:        out BIT;
        Load_Flags:                         out BIT;
        Select_A_To_DataBus:                out BIT;
        Select_B_To_DataBus:                out BIT;
        Select_C_To_DataBus:                out BIT;
        Load_D_From_DataBus:                out BIT;
        Select_D_To_DataBus:                out BIT;
        Load_E_From_DataBus:                out BIT;
        Select_E_To_DataBus:                out BIT;
        Load_F_From_DataBus:                out BIT;
        Select_F_To_DataBus:                out BIT;
        Load_G_From_DataBus:                out BIT;
        Select_G_To_DataBus:                out BIT;
        Load_H_From_DataBus:                out BIT;
        Select_H_To_DataBus:                out BIT;
        load_M_From_AddressBus:             out BIT;
        select_M_To_AddressBus:             out BIT;
        load_XL_From_DataBus:               out BIT;
        load_XH_From_DataBus:               out BIT;
        load_X_From_AddressBus:             out BIT;
        select_XL_To_DataBus:               out BIT;
        select_XH_To_DataBus:               out BIT;
        select_X_To_AddressBus:             out BIT;
        Load_J_From_AddressBus:             out BIT;
        Select_J_To_AddressBus:             out BIT;
        Load_SP_From_AddressBus:            out BIT;
        Select_SP_To_AddressBus:            out BIT;
        Load_BP_From_AddressBus:            out BIT;
        Select_BP_To_AddressBus:            out BIT;
        Load_Y_From_AddressBus:             out BIT;
        Select_Y_To_AddressBus:             out BIT;
        Load_Z_From_AddressBus:             out BIT;
        Select_Z_To_AddressBus:             out BIT;
        Load_Adder16Bit_InputA:             out BIT;
        Select_Adder16Bit_InputA:           out BIT;
        Load_Adder16Bit_InputB:             out BIT;
        Select_Adder16Bit_InputB:           out BIT;
        Load_Adder16Bit_OutputC:            out BIT;
        Select_Adder16Bit_OutputC:          out BIT;
        load_FlagsSaved_From_FlagsRegister: out BIT;
        load_FlagsSaved_To_FlagsRegister:   out BIT;
        Load_FlagsFromDataBus:              out BIT;
        Select_FlagsToFlagsBus:             out BIT;
        Load_FlagsFromFlagsBus:             out BIT;
        Select_FlagsToDataBus:              out BIT;
        Select_Flags:                       out BIT;
        Select_PortA_To_DataBus:            out BIT;
        Select_PortB_To_DataBus:            out BIT;
        Load_PortC_From_DataBus:            out BIT;
        Load_PortD_From_DataBus:            out BIT;
        StopCPU:                            out BIT
    );
end component InstructionDecoder;

component ALU8Bit is
    Port
    (
        InputA :      in  BIT_VECTOR(7 downto 0); -- 1st 8-bit input value
        InputB :      in  BIT_VECTOR(7 downto 0); -- 2nd 8-bit input value
        FunctionCode: in  BIT_VECTOR(3 downto 0); -- 4-bit function code
        CarryIn:      in BIT;                     -- Carry-Bit
        Output :      out BIT_VECTOR(7 downto 0); -- 8-bit output value
        Sign :        out BIT;                    -- Do we have a negative number?
        Zero :        out BIT;                    -- Do we have a zero value?
        Carry :       out BIT;                    -- Do we have a carry?
        Overflow:     out BIT                     -- Do we have an overflow?
    ); 
end component ALU8Bit;

component RippleCarryAdder16Bit is
    Port
    (
        InputA : in  BIT_VECTOR(15 downto 0);   -- 1st 8-bit input value
        InputB : in  BIT_VECTOR(15 downto 0);   -- 2nd 8-bit input value
        Cin    : in  BIT;                       -- Carry-in flag
        Output : out BIT_VECTOR(15 downto 0);   -- 8-bit output value
        Cout   : out BIT                        -- Carry-out flag
    );
end component RippleCarryAdder16Bit;

-- 4-bit binary counter & Control Lines
signal CounterOutput : STD_LOGIC_VECTOR(3 downto 0);
signal CounterOutputBitVector : BIT_VECTOR(3 downto 0);
signal TimingSignals : BIT_VECTOR(7 downto 0);

-- Signals needed for the RAM memory cell
signal loadRAM:         BIT;
signal selectRAM:       BIT;
signal returnRAM:       BIT;
signal addressRAM:      BIT_VECTOR(15 downto 0);
signal inputRAM:        BIT_VECTOR(7 downto 0);
signal outputRAM:       BIT_VECTOR(7 downto 0);

-- Signals needed for register "A"
signal load_A_From_DataBus : BIT;                   -- Load Line
signal select_A_To_DataBus : BIT;                   -- Select Line to Data Bus
signal select_A_To_ALU : BIT;                       -- Select Line to ALU
signal in_A_From_DataBus : BIT_VECTOR(7 downto 0);  -- Input Data
signal out_A_To_DataBus : BIT_VECTOR(7 downto 0);   -- Output Data
signal out_A_To_ALU : BIT_VECTOR(7 downto 0);       -- Output Data

-- Signals needed for register "B"
signal load_B_From_DataBus : BIT;                   -- Load Line
signal select_B_To_DataBus : BIT;                   -- Select Line to Data Bus
signal select_B_To_ALU : BIT;                       -- Select Line to ALU
signal in_B_From_DataBus : BIT_VECTOR(7 downto 0);  -- Input Data
signal out_B_To_DataBus : BIT_VECTOR(7 downto 0);   -- Output Data
signal out_B_To_ALU : BIT_VECTOR(7 downto 0);       -- Output Data

-- Signals needed for register "C"
signal load_C_From_DataBus : BIT;                   -- Load Line
signal select_C_To_DataBus : BIT;                   -- Select Line
signal in_C_From_DataBus : BIT_VECTOR(7 downto 0);  -- Input Data
signal out_C_To_DataBus : BIT_VECTOR(7 downto 0);   -- Output Data

-- Signals needed for register "D"
signal load_D_From_DataBus : BIT;                       -- Load Line
signal select_D_To_DataBus : BIT;                       -- Select Line
signal in_D_From_DataBus : BIT_VECTOR(7 downto 0);      -- Input Data
signal out_D_To_DataBus : BIT_VECTOR(7 downto 0);       -- Output Data

-- Signals needed for register "E"
signal load_E_From_DataBus : BIT;                       -- Load Line
signal select_E_To_DataBus : BIT;                       -- Select Line
signal in_E_From_DataBus : BIT_VECTOR(7 downto 0);      -- Input Data
signal out_E_To_DataBus : BIT_VECTOR(7 downto 0);       -- Output Data

-- Signals needed for register "F"
signal load_F_From_DataBus : BIT;                       -- Load Line
signal select_F_To_DataBus : BIT;                       -- Select Line
signal in_F_From_DataBus : BIT_VECTOR(7 downto 0);      -- Input Data
signal out_F_To_DataBus : BIT_VECTOR(7 downto 0);       -- Output Data

-- Signals needed for register "G"
signal load_G_From_DataBus : BIT;                       -- Load Line
signal select_G_To_DataBus : BIT;                       -- Select Line
signal in_G_From_DataBus : BIT_VECTOR(7 downto 0);      -- Input Data
signal out_G_To_DataBus : BIT_VECTOR(7 downto 0);       -- Output Data

-- Signals needed for register "H"
signal load_H_From_DataBus : BIT;                       -- Load Line
signal select_H_To_DataBus : BIT;                       -- Select Line
signal in_H_From_DataBus : BIT_VECTOR(7 downto 0);      -- Input Data
signal out_H_To_DataBus : BIT_VECTOR(7 downto 0);       -- Output Data

-- Signals needed for register "Flags"
signal load_Flags : BIT;                   -- Load Line
signal select_Flags : BIT;                          -- Select Line
signal in_Flags_From_ALU : BIT_VECTOR(7 downto 0);  -- Input Data
signal out_Flags : BIT_VECTOR(7 downto 0);          -- Output Data
signal in_Flags : BIT_VECTOR(7 downto 0);
signal state_Flags: BIT_VECTOR(7 downto 0);

-- Signals needed for register "FlagsSaved"
signal load_FlagsSaved_From_FlagsBus: BIT;
signal select_FlagsSaved_To_FlagsBus: BIT;
signal out_FlagsSaved_To_FlagsBus: BIT_VECTOR(7 downto 0);
signal in_FlagsSaved_From_FlagsBus : BIT_VECTOR(7 downto 0);

-- Signals needed for register "FlagsInBuffer"
signal load_FlagsFromDataBus: BIT;
signal select_FlagsToFlagsBus: BIT;
signal in_FlagsFromDataBus: BIT_VECTOR(7 downto 0);
signal out_FlagsToFlagsBus: BIT_VECTOR(7 downto 0);

-- Signals needed for register "FlagsOutBuffer"
signal load_FlagsFromFlagsBus: BIT;
signal select_FlagsToDataBus: BIT;
signal in_FlagsFromFlagsBus: BIT_VECTOR(7 downto 0);
signal out_FlagsToDataBus: BIT_VECTOR(7 downto 0);

-- Signals needed for register "Internal A"
signal load_InternalA_From_DataBus : BIT;                   -- Load Line
signal select_InternalA_To_DataBus : BIT;                   -- Select Line
signal in_InternalA_From_DataBus : BIT_VECTOR(7 downto 0);  -- Input Data
signal out_InternalA : BIT_VECTOR(7 downto 0);              -- Output Data

-- Signals needed for register "Program Counter"
signal l_PC : BIT;                          -- Load Line
signal select_PC : BIT;                     -- Select Line
signal in_PC  : BIT_VECTOR(15 downto 0);    -- Input Data
signal out_PC : BIT_VECTOR(15 downto 0);    -- Output Data

-- Signals needed for register "Increment Program Counter"
signal load_INC : BIT;                      -- Load Line
signal select_INC : BIT;                    -- Select Line
signal in_INC : BIT_VECTOR(15 downto 0);    -- Input Data
signal out_INC : BIT_VECTOR(15 downto 0);   -- Output Data

-- Signals needed for 16-bit register "M"
signal load_M_From_AddressBus:  BIT;
signal select_M_To_AddressBus:  BIT;
signal in_M_From_AddressBus:    BIT_VECTOR(15 downto 0);
signal out_M_To_AddressBus:     BIT_VECTOR(15 downto 0);

-- Signals needed for 16-bit register "X"
signal load_XL_From_DataBus:    BIT;
signal load_XH_From_DataBus:    BIT;
signal load_X_From_AddressBus:  BIT;
signal select_XL_To_DataBus:    BIT;
signal select_XH_To_DataBus:    BIT;
signal select_X_To_AddressBus:  BIT;
signal in_XL_From_DataBus:      BIT_VECTOR(7 downto 0);
signal in_XH_From_DataBus:      BIT_VECTOR(7 downto 0);
signal in_X_From_AddressBus:    BIT_VECTOR(15 downto 0);
signal out_XL_To_DataBus:       BIT_VECTOR(7 downto 0);
signal out_XH_To_DataBus:       BIT_VECTOR(7 downto 0);
signal out_X_To_AddressBus:     BIT_VECTOR(15 downto 0);

-- Signals needed for register "J"
signal load_J_From_AddressBus:  BIT;
signal select_J_To_AddressBus:  BIT;
signal in_J_From_AddressBus:    BIT_VECTOR(15 downto 0);
signal out_J_To_AddressBus:     BIT_VECTOR(15 downto 0);

-- Signals needed for register "SP"
signal load_SP_From_AddressBus: BIT;
signal select_SP_To_AddressBus: BIT;
signal in_SP_From_AddressBus:   BIT_VECTOR(15 downto 0);
signal out_SP_To_AddressBus:    BIT_VECTOR(15 downto 0);

-- Signals needed for register "BP"
signal load_BP_From_AddressBus: BIT;
signal select_BP_To_AddressBus: BIT;
signal in_BP_From_AddressBus:   BIT_VECTOR(15 downto 0);
signal out_BP_To_AddressBus:    BIT_VECTOR(15 downto 0);

-- Signals needed for register "Y"
signal load_Y_From_AddressBus: BIT;
signal select_Y_To_AddressBus: BIT;
signal in_Y_From_AddressBus:   BIT_VECTOR(15 downto 0);
signal out_Y_To_AddressBus:    BIT_VECTOR(15 downto 0);

-- Signals needed for register "Z"
signal load_Z_From_AddressBus: BIT;
signal select_Z_To_AddressBus: BIT;
signal in_Z_From_AddressBus:   BIT_VECTOR(15 downto 0);
signal out_Z_To_AddressBus:    BIT_VECTOR(15 downto 0);

-- Signals needed for the register "Instruction"
signal load_INSTR : BIT;                                -- Load Line
signal select_INSTR_To_DataBus : BIT;                   -- Select Line to Data Bus
signal select_INSTR_To_ALU: BIT;                        -- Select Line to ALU
signal in_INSTR : BIT_VECTOR(7 downto 0);               -- Input Data
signal out_INSTR_To_DataBus : BIT_VECTOR(7 downto 0);   -- Output Data to Data Bus
signal out_INSTR_To_ALU : BIT_VECTOR(7 downto 0);       -- Output Data to ALU
signal currentInstruction : BIT_VECTOR(7 downto 0);     -- The current instruction to be processed

-- Signals needed for the 16-bit Ripple Carry Adder
signal Output_Adder16Bit: BIT_VECTOR(15 downto 0);      -- 16-bit output value for the 16-bit adder

-- Signals needed for the register "Adder16Bit_OutputC"
signal load_Adder16Bit_OutputC: BIT;
signal select_Adder16Bit_OutputC: BIT;
signal Output_RegisterAdder16Bit: BIT_VECTOR(15 downto 0);

-- Signals needed for the register "Adder16Bit_InputA"
signal load_Adder16Bit_InputA: BIT;
signal select_Adder16Bit_InputA: BIT; 
signal in_Adder16Bit_InputA_From_AddressBus: BIT_VECTOR(15 downto 0);
signal out_Adder16Bit_InputA: BIT_VECTOR(15 downto 0);

-- Signals needed for the register "Adder16Bit_InputB"
signal load_Adder16Bit_InputB: BIT;
signal select_Adder16Bit_InputB: BIT; 
signal in_Adder16Bit_InputB_From_AddressBus: BIT_VECTOR(15 downto 0);
signal out_Adder16Bit_InputB: BIT_VECTOR(15 downto 0);

-- Signals needed for Input Port "A"
signal select_PortA_To_DataBus:     BIT; 
signal out_PortA_To_DataBus:        BIT_VECTOR(7 downto 0);

-- Signals needed for Output Port "C"
signal load_PortC_From_DataBus:     BIT; 
signal in_PortC_FromDataBus:        BIT_VECTOR(7 downto 0);

-- Signals needed for Output Port "D"
signal load_PortD_From_DataBus:     BIT; 
signal in_PortD_FromDataBus:        BIT_VECTOR(7 downto 0);

-- Signals needed for Input Port "B"
signal select_PortB_To_DataBus:     BIT; 
signal out_PortB_To_DataBus:        BIT_VECTOR(7 downto 0);

-- 16-bit Address Bus
signal AddressBus : BIT_VECTOR(15 downto 0);

-- 8-bit Data Bus
signal DataBus : BIT_VECTOR(7 downto 0);

-- 8-bit Flags Bus
signal FlagsBus : BIT_VECTOR(7 downto 0);
signal FlagsTemp: BIT_VECTOR(7 downto 0);

-- Incrementer for Program Counter
signal CarryOutIncrementer : BIT;

-- Signals needed to connect the TestBench to the CPU
signal load_SRAM : BIT;
signal select_SRAM : BIT;
signal load_PC1 : BIT;

-- ALU output flags
signal ALU_Sign: BIT := '0';
signal ALU_Zero: BIT := '0';
signal ALU_Carry: BIT := '0';
signal out_ALU: BIT_VECTOR(7 downto 0);

signal stopped: BIT := '0';

-- This line stores the first 5 bits from the Register "Internal A"
signal Truncated_InternalA : BIT_VECTOR(7 downto 0);

begin
     -- =============================================================
     -- The following section contains the definition of the various
     -- components of the CPU
     -- =============================================================
     
     -- That's the 4-bit binary counter
     Counter: Counter4Bit port map (Clock, Reset, CounterOutput);
     CounterOutputBitVector <= TO_BITVECTOR(CounterOutput);
     
     -- The decoder generates the signals along the 8 control lines out from the 4-bit binary counter
     Decoder: Decoder3to8 port map(CounterOutputBitVector(2 downto 0), TimingSignals, Start and not stopped);
     
     -- This is our main-memory - 64K
     ram: RAM_Wrapper port map(Clock, loadRAM, selectRAM, returnRAM, addressRAM, inputRAM, OutputRAM);
                             
     -- Connects the address bus to the SRAM address input              
     addressRAM <= AddressBus or
                   Address_RAM;  
 
     -- The Instruction Decoder - the brain within the brain.
     -- Based on the timing signal and the current instruction the
     -- various CPU control lines are going high/low.
     instrDecoder: InstructionDecoder port map(TimingSignals,
                                               currentInstruction,
                                               out_Flags,
                                               load_PC1,
                                               select_PC,
                                               load_SRAM,
                                               select_SRAM,
                                               returnRAM,
                                               load_INC,
                                               select_INC,
                                               load_INSTR,
                                               select_INSTR_To_DataBus,
                                               select_INSTR_To_ALU,
                                               load_A_From_DataBus,
                                               select_A_To_ALU,
                                               load_B_From_DataBus,
                                               select_B_To_ALU,
                                               load_C_From_DataBus,
                                               load_InternalA_From_DataBus,
                                               select_InternalA_To_DataBus,
                                               load_Flags,
                                               select_A_To_DataBus,
                                               select_B_To_DataBus,
                                               select_C_To_DataBus,
                                               load_D_From_DataBus,
                                               select_D_To_DataBus,
                                               load_E_From_DataBus,
                                               select_E_To_DataBus,
                                               load_F_From_DataBus,
                                               select_F_To_DataBus,
                                               load_G_From_DataBus,
                                               select_G_To_DataBus,  
                                               load_H_From_DataBus,
                                               select_H_To_DataBus,
                                               load_M_From_AddressBus,
                                               select_M_To_AddressBus,
                                               load_XL_From_DataBus,
                                               load_XH_From_DataBus,
                                               load_X_From_AddressBus,
                                               select_XL_To_DataBus,
                                               select_XH_To_DataBus,
                                               select_X_To_AddressBus,
                                               load_J_From_AddressBus,
                                               select_J_To_AddressBus,
                                               load_SP_From_AddressBus,
                                               select_SP_To_AddressBus,
                                               load_BP_From_AddressBus,
                                               select_BP_To_AddressBus,
                                               load_Y_From_AddressBus,
                                               select_Y_To_AddressBus,
                                               load_Z_From_AddressBus,
                                               select_Z_To_AddressBus,
                                               load_Adder16Bit_InputA,
                                               select_Adder16Bit_InputA,
                                               load_Adder16Bit_InputB,
                                               select_Adder16Bit_InputB,
                                               load_Adder16Bit_OutputC,
                                               select_Adder16Bit_OutputC,
                                               load_FlagsSaved_From_FlagsBus,
                                               select_FlagsSaved_To_FlagsBus,
                                               load_FlagsFromDataBus,
                                               select_FlagsToFlagsBus,
                                               load_FlagsFromFlagsBus,
                                               select_FlagsToDataBus,
                                               select_Flags,
                                               select_PortA_To_DataBus,
                                               select_PortB_To_DataBus,
                                               load_PortC_From_DataBus,
                                               load_PortD_From_DataBus,
                                               stopped);
                                                    
     -- 16-bit Register Definitions
     rPC:  Register16Bit port map(l_PC, select_PC, in_PC, out_PC);                                                                  -- Register "Program Counter" (PC)
     rINC: Register16Bit port map(load_INC, select_INC, in_INC, out_INC);                                                           -- Register "Program Counter Increment" (INC)
     rJ:   Register16Bit port map(load_J_From_AddressBus, select_J_To_AddressBus, in_J_From_AddressBus, out_J_To_AddressBus);       -- Register "Jump" - stores the JMP target address
     rM:   Register16Bit port map(load_M_From_AddressBus, select_M_To_AddressBus, in_M_From_AddressBus, out_M_To_AddressBus);       -- Register "M"
     rSP:  Register16Bit port map(load_SP_From_AddressBus, select_SP_To_AddressBus, in_SP_From_AddressBus, out_SP_To_AddressBus);   -- Register "SP"
     rBP:  Register16Bit port map(load_BP_From_AddressBus, select_BP_To_AddressBus, in_BP_From_AddressBus, out_BP_To_AddressBus);   -- Register "BP"
     rY:   Register16Bit port map(load_Y_From_AddressBus, select_Y_To_AddressBus, in_Y_From_AddressBus, out_Y_To_AddressBus);       -- Register "Y"
     rZ:   Register16Bit port map(load_Z_From_AddressBus, select_Z_To_AddressBus, in_Z_From_AddressBus, out_Z_To_AddressBus);       -- Register "Z"
     
     -- 16-bit Ripple Carry Adder
     adder16Bit: RippleCarryAdder16Bit port map(out_Adder16Bit_InputA, out_Adder16Bit_InputB, '0', Output_Adder16Bit);
     rAdder16Bit_InputA:  Register16Bit port map(load_Adder16Bit_InputA, select_Adder16Bit_InputA, in_Adder16Bit_InputA_From_AddressBus, out_Adder16Bit_InputA);
     rAdder16Bit_InputB:  Register16Bit port map(load_Adder16Bit_InputB, select_Adder16Bit_InputB, in_Adder16Bit_InputB_From_AddressBus, out_Adder16Bit_InputB);
     rAdder16Bit_OutputC: Register16Bit port map(load_Adder16Bit_OutputC, select_Adder16Bit_OutputC, Output_Adder16Bit, Output_RegisterAdder16Bit);
     
     -- Incrementer for Program Counter
     -- It takes the input from the AddressBus and writes
     -- the output into the input of the INC register (=> in_INC)
     inc: Increment16Bit port map(AddressBus, '0', in_INC, CarryOutIncrementer);
     
     -- 8-bit Instruction Register
     rINSTR: Register8Bit2WayOutput port map(load_INSTR, select_INSTR_To_DataBus, select_INSTR_To_ALU, in_INSTR, out_INSTR_To_DataBus, out_INSTR_To_ALU, currentInstruction);
     
     -- Internal ALU registers
     rA: Register8Bit2WayOutput port map(load_A_From_DataBus, select_A_To_DataBus, select_A_To_ALU, in_A_From_DataBus, out_A_To_DataBus, out_A_To_ALU);   -- Register "A": Input to ALU
     rB: Register8Bit2WayOutput port map(load_B_From_DataBus, select_B_To_DataBus, select_B_To_ALU, in_B_From_DataBus, out_B_To_DataBus, out_B_To_ALU);   -- Register "B": Input to ALU
     rC: Register8Bit port map(load_C_From_DataBus, select_C_To_DataBus, in_C_From_DataBus, out_C_To_DataBus);                                            -- Register "C": Output from ALU
     rInternalA: Register8Bit port map(load_InternalA_From_DataBus, select_InternalA_To_DataBus, in_InternalA_From_DataBus, out_InternalA);               -- Register "Internal A" for ALU
     
     -- General purpose 8-bit Register Definitions
     rD: Register8Bit port map(load_D_From_DataBus, select_D_To_DataBus, in_D_From_DataBus, out_D_To_DataBus);                                            -- Register "D"
     rE: Register8Bit port map(load_E_From_DataBus, select_E_To_DataBus, in_E_From_DataBus, out_E_To_DataBus);                                            -- Register "E"
     rF: Register8Bit port map(load_F_From_DataBus, select_F_To_DataBus, in_F_From_DataBus, out_F_To_DataBus);                                            -- Register "F"
     rG: Register8Bit port map(load_G_From_DataBus, select_G_To_DataBus, in_G_From_DataBus, out_G_To_DataBus);                                            -- Register "G"
     rH: Register8Bit port map(load_H_From_DataBus, select_H_To_DataBus, in_H_From_DataBus, out_H_To_DataBus);                                            -- Register "H"
                                
     -- 16-bit Extended Register "X"
     -- Consists of the 2 internal 8-bit wide registers "XL" and "XH"
     rX: RegisterExtended16Bit port map(load_XL_From_DataBus,
                                        load_XH_From_DataBus,
                                        load_X_From_AddressBus,
                                        select_XL_To_DataBus,
                                        select_XH_To_DataBus,
                                        select_X_To_AddressBus,
                                        in_XL_From_DataBus,
                                        in_XH_From_DataBus,
                                        in_X_From_AddressBus,
                                        out_XL_To_DataBus,
                                        out_XH_To_DataBus,
                                        out_X_To_AddressBus);
                                        
     -- Input/Output Ports
     pA: Register8Bit port map('1', select_PortA_To_DataBus, InputPort_A, out_PortA_To_DataBus);        -- Input Port "A"
     pB: Register8Bit port map('1', select_PortB_To_DataBus, InputPort_B, out_PortB_To_DataBus);        -- Input Port "B"
     p_outC: Register8Bit port map(load_PortC_From_DataBus, '1', in_PortC_FromDataBus, OutputPort_C);   -- Output Port "C"
     p_outD: Register8Bit port map(load_PortD_From_DataBus, '1', in_PortD_FromDataBus, OutputPort_D);   -- Output Port "D"
     
     -- Flags related registers
     rFlags : Register8Bit port map(load_Flags, select_Flags, in_Flags, out_Flags);
     rFlagsSaved : Register8Bit port map(load_FlagsSaved_From_FlagsBus, select_FlagsSaved_To_FlagsBus, in_FlagsSaved_From_FlagsBus, out_FlagsSaved_To_FlagsBus, state_Flags);   -- Stores a copy of the Flags register so that we can perform ALU operations without affecting the original content of the Flags register
     rFlagsInBuffer : Register8Bit port map(load_FlagsFromDataBus, select_FlagsToFlagsBus, in_FlagsFromDataBus, out_FlagsToFlagsBus);                                           -- Buffers the flags when read from the data bus (needed for the POPF operation)
     rFlagsOutBuffer : Register8Bit port map(load_FlagsFromFlagsBus, select_FlagsToDataBus, in_FlagsFromFlagsBus, out_FlagsToDataBus);                                          -- Buffers the flags when written to the data bus (needed for the PUSHF operation)
     
     -- This is our ALU
     -- The ALU receives the input from Register A and Register B.
     -- The output is written to Register C for further processing.
     -- state_Flags(2)
     alu: ALU8Bit port map(out_A_To_ALU, out_B_To_ALU, out_INSTR_To_ALU(3 downto 0), state_Flags(2), out_ALU, in_Flags_From_ALU(0), in_Flags_From_ALU(1), in_Flags_From_ALU(2), in_Flags_From_ALU(3));
     
     FlagsTemp(0) <= in_Flags_From_ALU(0);
     FlagsTemp(1) <= in_Flags_From_ALU(1);
     FlagsTemp(2) <= in_Flags_From_ALU(2);
     FlagsTemp(3) <= in_Flags_From_ALU(3);

     -- Writes the flags onto the Flags Bus
     FlagsBus <= FlagsTemp or
                 out_Flags or
                 out_FlagsSaved_To_FlagsBus or
                 out_FlagsToFlagsBus;
     
     -- Writes the content from the Flags Bus into the Flags register
     in_Flags <= FlagsBus;
   
     -- Writes the content from the Flags Bus into the FlagsSaved register
     in_FlagsSaved_From_FlagsBus <= FlagsBus;
     in_FlagsFromFlagsBus <= FlagsBus;
     
     -- =======================================================================
     -- The following section contains the wiring of the individual registers
     -- with the Address and Data Bus
     -- =======================================================================
     
     -- Connects the Address Bus to the Program Counter register    
     in_PC <= AddressBus or PC;
              
     -- Connects the 16-bit wide registers to the Address Bus
     in_M_From_AddressBus  <= AddressBus;
     in_X_From_AddressBus  <= AddressBus;
     in_J_From_AddressBus  <= AddressBus;
     in_SP_From_AddressBus <= AddressBus;
     in_BP_From_AddressBus <= AddressBus;
     in_Y_From_AddressBus <= AddressBus;
     in_Z_From_AddressBus <= AddressBus;
     in_Adder16Bit_InputA_From_AddressBus <= AddressBus;
     in_Adder16Bit_InputB_From_AddressBus <= AddressBus;
                        
     -- Connects the Program Counter register, the Increment register, and the 16-bit registers to the Address Bus
     AddressBus <= out_PC or
                   out_INC or
                   out_M_To_AddressBus or
                   out_X_To_AddressBus or
                   out_J_To_AddressBus or
                   out_SP_To_AddressBus or
                   out_BP_To_AddressBus or
                   out_Y_To_AddressBus or
                   out_Z_To_AddressBus or
                   Output_RegisterAdder16Bit;
              
     -- Connects the general purpose registers and the instruction 
     -- register to the data bus
     in_A_From_DataBus <= DataBus;
     in_B_From_DataBus <= DataBus;
     in_C_From_DataBus <= DataBus;
     in_D_From_DataBus <= DataBus;
     in_E_From_DataBus <= DataBus;
     in_F_From_DataBus <= DataBus;
     in_G_From_DataBus <= DataBus;
     in_H_From_DataBus <= DataBus;
     in_InternalA_From_DataBus <= DataBus;
     in_INSTR <= DataBus;
     in_XL_From_DataBus <= DataBus;
     in_XH_From_DataBus <= DataBus;
     in_FlagsFromDataBus <= DataBus;
     in_PortC_FromDataBus <= DataBus;
     in_PortD_FromDataBus <= DataBus;
     
     -- Just store the first 4 bits from the Register D.
     -- This eliminates the 4 bits from SETAB opcode and the destination register (A or B)
     Truncated_InternalA <= out_InternalA and "00001111";
     
     -- Connects the data bus to the general purpose registers, and the
     -- SRAM memory output.
     -- !!!!IT'S VERY IMPORTANT THAT ONLY *ONE* REGISTER CONCURRENTLY WRITES
     -- TO THE DATA BUS!!!!
     DataBus <= out_A_To_DataBus or
                out_B_To_DataBus or
                out_C_To_DataBus or
                out_INSTR_To_DataBus or
                outputRAM or
                Truncated_InternalA or
                out_ALU or
                out_D_To_DataBus or
                out_E_To_DataBus or
                out_F_To_DataBus or
                out_G_To_DataBus or
                out_H_To_DataBus or
                out_XL_To_DataBus or
                out_XH_To_DataBus or
                out_FlagsToDataBus or
                out_PortA_To_DataBus or
                out_PortB_To_DataBus;

     -- =======================================================================
     -- The following section contains a few additional connections
     -- that are needed to connect the TestBench to the CPU itself.
     -- These are the Control Lines that also accept inputs from the TestBench.
     -- They just take their input from the Instruction Decoder and ORed with the 
     -- input from the TestBench.
     -- ========================================================================
     loadRAM <= load_SRAM or Load_RAM;
     inputRAM <= Input_RAM or DataBus;
     l_PC <= load_PC1 or Load_PC;
     selectRAM <= select_SRAM or Select_RAM;
     
     -- Just provide from the CPU an output value, so that the implementation on the FPGA works
     Instruction <= currentInstruction;
end Behavioral;