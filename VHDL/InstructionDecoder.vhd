----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/23/2015 03:41:27 PM
-- Design Name: 
-- Module Name: InstructionDecoder - Behavioral
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

entity InstructionDecoder is
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
end InstructionDecoder;

architecture Behavioral of InstructionDecoder is

component Decoder3to8 is
    Port
    (
        F : in BIT_VECTOR(2 downto 0);   -- 3-Bit Function Code (Input)
        X : out BIT_VECTOR(7 downto 0);  -- 8-Bit State (Output)
        Started: in BIT                  -- Is the CPU already running?
    );  
end component Decoder3to8;

signal NegatedInstruction : BIT_VECTOR(7 downto 0);
signal NegatedFlags       : BIT_VECTOR(7 downto 0);

signal instruction_SETAB:                   BIT;
signal instruction_ALU:                     BIT;
signal instruction_MOV:                     BIT;
signal instruction_MOV16:                   BIT;
signal instruction_LOAD:                    BIT;
signal instruction_STORE:                   BIT;
signal instruction_JMP:                     BIT;
signal instruction_HLT:                     BIT;
signal instruction_JZ:                      BIT;
signal instruction_JNZ:                     BIT;
signal instruction_JNS:                     BIT;
signal instruction_JNC:                     BIT;
signal instruction_SAVE_FLAGS:              BIT;
signal instruction_RESTORE_FLAGS:           BIT;
signal instruction_NOP:                     BIT;
signal instruction_FLAGS_TO_OUTBUFFER:      BIT;
signal instruction_INBUFFER_TO_FLAGS:       BIT;
signal instruction_ADDER_16BIT:             BIT;
signal instruction_STORE_FLAGS:             BIT;
signal instruction_LOAD_FLAGS:              BIT;
signal instruction_IN:                      BIT;
signal instruction_OUT:                     BIT;

-- Internal ALU instructions
signal instruction_MOV_ALU_IN:      BIT;
signal instruction_MOV_ALU_OUT:     BIT;
signal instruction_MOV_ALU_C_TO_AB: BIT;

signal MOV_DestinationRegister:     BIT_VECTOR(7 downto 0);
signal MOV_SourceRegister:          BIT_VECTOR(7 downto 0);
signal MOV16_DestinationRegister:   BIT_VECTOR(7 downto 0);
signal MOV16_SourceRegister:        BIT_VECTOR(7 downto 0);

-- Used by the Fetch/Increment cycle
signal Select_SRAM_FETCH:         BIT;
signal Load_PC_FETCH:             BIT;
signal Select_PC_FETCH:           BIT;
signal Return_SRAM_FETCH:         BIT;

-- Used by the SETAB opcode
signal Load_A_From_DataBus_SETAB: BIT;
signal Load_B_From_DataBus_SETAB: BIT;

-- Used by the ALU opcode
signal Load_C_From_DataBus_ALU:   BIT;
signal Load_Flags_From_ALU:       BIT;

-- Used by the MOV opcode
signal Select_D_To_DataBus_MOV:   BIT;
signal Select_E_To_DataBus_MOV:   BIT;
signal Select_F_To_DataBus_MOV:   BIT;
signal Select_G_To_DataBus_MOV:   BIT;
signal Select_H_To_DataBus_MOV:   BIT;
signal Select_SP_To_DataBus_MOV:  BIT;
signal Select_XL_To_DataBus_MOV:  BIT;
signal Select_XH_To_DataBus_MOV:  BIT;
signal Load_D_From_DataBus_MOV:   BIT;
signal Load_E_From_DataBus_MOV:   BIT;
signal Load_F_From_DataBus_MOV:   BIT;
signal Load_G_From_DataBus_MOV:   BIT;
signal Load_H_From_DataBus_MOV:   BIT;
signal Load_SP_From_DataBus_MOV:  BIT;
signal Load_XL_From_DataBus_MOV:  BIT;
signal Load_XH_From_DataBus_MOV:  BIT;
signal Load_J_From_DataBus_MOV:   BIT;

-- Used by the MOV16 opcode
signal Select_M_To_AddressBus_MOV16:    BIT;
signal Select_X_To_AddressBus_MOV16:    BIT;
signal Load_M_From_AddressBus_MOV16:    BIT;
signal Load_X_From_AddressBus_MOV16:    BIT;
signal Select_J_To_AddressBus_MOV16:    BIT;
signal Load_J_From_AddressBus_MOV16:    BIT;
signal Select_SP_To_AddressBus_MOV16:   BIT;
signal Load_SP_From_AddressBus_MOV16:   BIT;
signal Select_PC_To_AddressBus_MOV16:   BIT;
signal Load_PC_From_AddressBus_MOV16:   BIT;
signal Select_BP_To_AddressBus_MOV16:   BIT;
signal Load_BP_From_AddressBus_MOV16:   BIT;
signal Select_Y_To_AddressBus_MOV16:   BIT;
signal Load_Y_From_AddressBus_MOV16:   BIT;
signal Select_Z_To_AddressBus_MOV16:   BIT;
signal Load_Z_From_AddressBus_MOV16:   BIT;

-- Used by the LOAD opcode
signal Select_SRAM_LOAD:            BIT;
signal Return_SRAM_LOAD:            BIT;
signal Load_D_From_DataBus_LOAD:    BIT;
signal Load_E_From_DataBus_LOAD:    BIT;
signal Load_F_From_DataBus_LOAD:    BIT;
signal Load_G_From_DataBus_LOAD:    BIT;
signal Load_H_From_DataBus_LOAD:    BIT;
signal Load_XL_From_DataBus_LOAD:   BIT;
signal Load_XH_From_DataBus_LOAD:   BIT;
signal Select_M_To_AddressBus_LOAD: BIT;

-- Used by the STORE opcode
signal Load_SRAM_LOAD:               BIT;
signal Select_D_To_DataBus_STORE:    BIT;
signal Select_E_To_DataBus_STORE:    BIT;
signal Select_F_To_DataBus_STORE:    BIT;
signal Select_G_To_DataBus_STORE:    BIT;
signal Select_H_To_DataBus_STORE:    BIT;
signal Select_XL_To_DataBus_STORE:   BIT;
signal Select_XH_To_DataBus_STORE:   BIT;
signal Select_M_To_AddressBus_STORE: BIT;
signal Load_SRAM_STORE:              BIT;

-- Used by the LOAD_FLAGS opcode
signal Load_SRAM_STORE_FLAGS:               BIT;
signal Select_M_To_AddressBus_STORE_FLAGS:  BIT;

-- Used by the STORE_FLAGS opcode
signal Select_SRAM_LOAD_FLAGS:              BIT;
signal Select_M_To_AddressBus_LOAD_FLAGS:   BIT;
signal Return_SRAM_LOAD_FLAGS:              BIT;

-- Used by the JMP opcode
signal Load_PC_JMP:                  BIT;
signal Select_J_To_AddressBus_JMP:   BIT;

-- Used by the JZ opcode
signal Load_PC_JZ:                   BIT;
signal Select_J_To_AddressBus_JZ:    BIT;
signal Select_Flags_JZ:              BIT;

-- Used by the JNS opcode
signal Load_PC_JNS:                  BIT;
signal Select_J_To_AddressBus_JNS:   BIT;
signal Select_Flags_JNS:             BIT;

-- Used by the JNC opcode
signal Load_PC_JNC:                  BIT;
signal Select_J_To_AddressBus_JNC:   BIT;
signal Select_Flags_JNC:             BIT;

-- Used by the JNZ opcode
signal Load_PC_JNZ:                  BIT;
signal Select_J_To_AddressBus_JNZ:   BIT;
signal Select_Flags_JNZ:             BIT;

-- Used by the SAVE_FLAGS opcode
signal Select_Flags_SAVE_FLAGS:      BIT;

-- Used by the RESTORE_FLAGS opcode
signal Load_Flags_SAVE_FLAGS:        BIT;

-- Used by the INBUFFER_TO_FLAGS opcode
signal Load_Flags_INBUFFER_TO_FLAGS:    BIT;

-- Used by the FLAGS_TO_DATABUS opcode
signal Select_Flags_FLAGS_TO_OUTBUFFER: BIT;

-- Used by the MOV_ALU_IN opcode
signal Select_D_To_DataBus_MOV_ALU_IN:  BIT;
signal Select_E_To_DataBus_MOV_ALU_IN:  BIT;
signal Select_F_To_DataBus_MOV_ALU_IN:  BIT;
signal Select_G_To_DataBus_MOV_ALU_IN:  BIT;
signal Select_H_To_DataBus_MOV_ALU_IN:  BIT;
signal Select_XL_To_DataBus_MOV_ALU_IN:  BIT;
signal Select_XH_To_DataBus_MOV_ALU_IN:  BIT;
signal Select_SP_To_DataBus_MOV_ALU_IN: BIT;
signal Load_A_From_DataBus_MOV_ALU_IN:  BIT;
signal Load_B_From_DataBus_MOV_ALU_IN:  BIT;
signal MOV_ALU_IN_SourceRegister:       BIT_VECTOR(7 downto 0);

-- Used by the MOV_ALU_OUT opcode
signal Load_D_From_DataBus_MOV_ALU_OUT:     BIT;
signal Load_E_From_DataBus_MOV_ALU_OUT:     BIT;
signal Load_F_From_DataBus_MOV_ALU_OUT:     BIT;
signal Load_G_From_DataBus_MOV_ALU_OUT:     BIT;
signal Load_H_From_DataBus_MOV_ALU_OUT:     BIT;
signal Load_XL_From_DataBus_MOV_ALU_OUT:    BIT;
signal Load_XH_From_DataBus_MOV_ALU_OUT:    BIT;
signal Load_SP_From_DataBus_MOV_ALU_OUT:    BIT;
signal Load_J_From_DataBus_MOV_ALU_OUT:     BIT;
signal Select_C_To_DataBus_MOV_ALU_OUT:     BIT;
signal MOV_ALU_OUT_DestinationRegister:     BIT_VECTOR(7 downto 0);

-- Used by the MOV_ALU_C_TO_AB opcode
signal Load_A_From_DataBus_MOV_ALU_C_TO_AB: BIT;
signal Load_B_From_DataBus_MOV_ALU_C_TO_AB: BIT;
signal Select_C_To_DataBus_MOV_ALU_C_TO_AB: BIT;

-- Used by the ADDER_16BIT opcode
signal Select_D_To_DataBus_ADDER_16BIT:     BIT;
signal Select_X_To_AddressBus_ADDER_16BIT:  BIT;
signal Load_X_From_AddressBus_ADDER_16BIT:  BIT;
signal Select_J_To_AddressBus_ADDER_16BIT:  BIT;

-- Used by the IN opcode
signal Load_XL_From_DataBus_IN:             BIT;

-- Used by the OUT opcode
signal Select_XL_To_DataBus_OUT:            BIT;

begin
    -- Negate the instruction, so that we can afterwards probe
    -- for a specific instruction
    NegatedInstruction <= not(Instruction);
    
    -- Negate the FLAGS
    NegatedFlags <= not(Flags);
    
    -- ================================================================
    -- The following section implements the Fetch/Increment operations
    -- ================================================================

    Load_PC_FETCH <= TimingSignals(2);        -- State #3
    
    Select_PC_FETCH <= TimingSignals(0) or    -- State #1
                       TimingSignals(1);      -- State #2
    
    -- We request the data from the RAM in the states #1 and #2             
    Select_SRAM_FETCH <= TimingSignals(0) or  -- State #1
                         TimingSignals(1);    -- State #2
    
    -- Because the RAM has a latency of 1 clock cycle, we only return the
    -- requested data from the RAM in state #2 (data in state #1 is still unstable!!!)                     
    Return_SRAM_FETCH <= TimingSignals(1);    -- State #2
                 
    Load_INC <= TimingSignals(0);             -- State #1
                        
    Select_INC <= TimingSignals(2);           -- State #3
                  
    Load_INSTR <= TimingSignals(1);           -- State #2
    
    -- ============================================================
    -- Now we have to decode the instruction to enable the correct
    -- Control Lines based on the provided timing signal
    -- ============================================================
    
    -- ---------------------------------------
    -- Instruction "SETAB" - Format: 111DVVVV
    -- ---------------------------------------
    -- 111:   OpCode
    -- D:     Destination ('0' = Register A, '1' = Register B)
    -- VVVV:  4-bit value
    
    -- Check if we execute the "SETAB" instruction - OpCode "111"
    instruction_SETAB <= Instruction(7) and Instruction(6) and Instruction(5);
    
    -- The "Select_INSTR" control line goes high, when we execute the
    -- instruction "SETAB" and the time state is #4
    -- This gates the instruction from the instruction register onto the data bus
    Select_INSTR_To_DataBus <= instruction_SETAB and TimingSignals(3);
    
    -- The instruction from the data bus is loaded into the register "Internal A"
    Load_InternalA_From_DataBus <= instruction_SETAB and TimingSignals(3);
    
    -- The first 4 bits from the register "Internal A" are gated back to the data bus
    Select_InternalA_To_DataBus <= instruction_SETAB and TimingSignals(4);
    
    -- The "Load_A" control line goes high, when we execute the
    -- instruction "SETAB" and the time state is #4
    -- This loads the data currently stored on the data bus into the Register "A"
    Load_A_From_DataBus_SETAB <= instruction_SETAB and TimingSignals(4) and NegatedInstruction(4);
    
    -- The "Load_B" control line goes high, when we execute the
    -- instruction "SETAB" and the time state is #4
    -- This loads the data currently stored on the data bus into the Register "B" 
    Load_B_From_DataBus_SETAB <= instruction_SETAB and TimingSignals(4) and Instruction(4);
    
    -- ---------------------------------------
    -- Instruction "ALU" - Format: 1000FFFF
    -- ---------------------------------------
    -- 1000: OpCode
    -- FFFF:  4-bit function code
    
    -- Check if we execute the "ALU" instruction - OpoCode "1000"
    instruction_ALU <= Instruction(7) and NegatedInstruction(6) and NegatedInstruction(5) and NegatedInstruction(4);
    instruction_NOP <= NegatedInstruction(3) and NegatedInstruction(2) and NegatedInstruction(1) and NegatedInstruction(0);
    
    -- The "Select_A_To_ALU" and "Select_B_To_ALU" control lines are going high, when we execute
    -- the instruction "ALU" and the time state is #4 or #5.
    -- This transfers the content of the Register A and Register B into the ALU
    -- for execution.
    Select_A_To_ALU <= instruction_ALU and (TimingSignals(3) or TimingSignals(4));
    Select_B_To_ALU <= instruction_ALU and (TimingSignals(3) or TimingSignals(4));
    
    -- The "SELECT_INSTR" control line goes high, when we execute the instruction "ALU"
    -- and the time state is #4 or #5.
    -- This transfers the 4-bit function code of the Instruction Register into the ALU
    -- for execution.
    Select_INSTR_To_ALU <= instruction_ALU and (TimingSignals(3) or TimingSignals(4));
    
    -- The "Select C" control line goes high, when we execute the instruction
    -- "ALU" and the time state is #5.
    -- This transfers the result of the ALU into the Register C.
    Load_C_From_DataBus_ALU <= instruction_ALU and TimingSignals(4);
    
    -- This transfers the result of the ALU Flags into the register FLAGS
    Load_Flags_From_ALU <= instruction_ALU and TimingSignals(4) and not(instruction_NOP);
    
    -- -------------------------------------------------
    -- Instruction "MOV_ALU_C_TO_AB" - Format: 1010111D
    -- -------------------------------------------------
    -- 1010111: OpCode
    -- D:       Destination Register
    --          => "0": Register A
    --          => "1": Register B
    
    -- Check if we execute the "MOV_ALU_OUT" instruction - OpCode "1010111"
    instruction_MOV_ALU_C_TO_AB <= Instruction(7) and
                                   NegatedInstruction(6) and
                                   Instruction(5) and
                                   NegatedInstruction(4) and
                                   Instruction(3) and
                                   Instruction(2) and
                                   Instruction(1);
                                   
    Load_A_From_DataBus_MOV_ALU_C_TO_AB <= instruction_MOV_ALU_C_TO_AB and NegatedInstruction(0) and (TimingSignals(4) or TimingSignals(5));
    Load_B_From_DataBus_MOV_ALU_C_TO_AB <= instruction_MOV_ALU_C_TO_AB and Instruction(0) and (TimingSignals(4) or TimingSignals(5));
    
    -- Select the register C of the ALU to the data bus
    Select_C_To_DataBus_MOV_ALU_C_TO_AB <= instruction_MOV_ALU_C_TO_AB and (TimingSignals(4) or TimingSignals(5));
    
    -- --------------------------------------------
    -- Instruction "MOV_ALU_OUT" - Format: 11011DDD
    -- --------------------------------------------
    -- 11011:   OpCode
    -- DDD:  Destination Register
    --     => "000": Register D
    --     => "001": Register E
    --     => "010": Register F
    --     => "011": Register G
    --     => "100": Register H
    --     => "101": <Not yet used>
    --     => "110": Register XL
    --     => "111": Register XH
    
    -- Check if we execute the "MOV_ALU_OUT" instruction - OpCode "11011"
    instruction_MOV_ALU_OUT <= Instruction(7) and
                               Instruction(6) and
                               NegatedInstruction(5) and
                               Instruction(4) and
                               Instruction(3);
                                               
    -- Decode the destination and source register from the provided instruction
    DestinationRegisterDecoder_MOV_ALU_OUT: Decoder3to8 port map(Instruction(2 downto 0), MOV_ALU_OUT_DestinationRegister, '1');
    
    -- Load the specified register from the data bus
    Load_D_From_DataBus_MOV_ALU_OUT   <= instruction_MOV_ALU_OUT and MOV_ALU_OUT_DestinationRegister(0) and (TimingSignals(4) or TimingSignals(5));
    Load_E_From_DataBus_MOV_ALU_OUT   <= instruction_MOV_ALU_OUT and MOV_ALU_OUT_DestinationRegister(1) and (TimingSignals(4) or TimingSignals(5));
    Load_F_From_DataBus_MOV_ALU_OUT   <= instruction_MOV_ALU_OUT and MOV_ALU_OUT_DestinationRegister(2) and (TimingSignals(4) or TimingSignals(5));
    Load_G_From_DataBus_MOV_ALU_OUT   <= instruction_MOV_ALU_OUT and MOV_ALU_OUT_DestinationRegister(3) and (TimingSignals(4) or TimingSignals(5));
    Load_H_From_DataBus_MOV_ALU_OUT  <= instruction_MOV_ALU_OUT and MOV_ALU_OUT_DestinationRegister(4) and (TimingSignals(4) or TimingSignals(5));
    Load_XL_From_DataBus_MOV_ALU_OUT  <= instruction_MOV_ALU_OUT and MOV_ALU_OUT_DestinationRegister(6) and (TimingSignals(4) or TimingSignals(5));
    Load_XH_From_DataBus_MOV_ALU_OUT  <= instruction_MOV_ALU_OUT and MOV_ALU_OUT_DestinationRegister(7) and (TimingSignals(4) or TimingSignals(5));
    
    -- Select the register C of the ALU to the data bus
    Select_C_To_DataBus_MOV_ALU_OUT <= instruction_MOV_ALU_OUT and (TimingSignals(4) or TimingSignals(5));
    
    -- --------------------------------------------
    -- Instruction "MOV_ALU_IN" - Format: 1011DSSS
    -- --------------------------------------------
    -- 1011:   OpCode
    -- D:  Destination Register
    --     => "0": Register A
    --     => "1": Register B
    -- SSS:  Source Register
    --     => "000": Register D
    --     => "001": Register E
    --     => "010": Register F
    --     => "011": Register G
    --     => "100": Register H
    --     => "101": <Not yet used>
    --     => "110": Register XL
    --     => "111": Register XH
                              
    -- Check if we execute the "MOV_ALU_IN" instruction - OpCode "1011"
    instruction_MOV_ALU_IN <= Instruction(7) and
                              NegatedInstruction(6) and
                              Instruction(5) and
                              Instruction(4);
                                             
    -- Decode the destination and source register from the provided instruction
    SourceRegisterDecoder_MOV_ALU_IN: Decoder3to8 port map(Instruction(2 downto 0), MOV_ALU_IN_SourceRegister, '1');
  
    -- Latch the specified register onto the data bus
    Select_D_To_DataBus_MOV_ALU_IN   <= instruction_MOV_ALU_IN and MOV_ALU_IN_SourceRegister(0) and (TimingSignals(4) or TimingSignals(5));
    Select_E_To_DataBus_MOV_ALU_IN   <= instruction_MOV_ALU_IN and MOV_ALU_IN_SourceRegister(1) and (TimingSignals(4) or TimingSignals(5));
    Select_F_To_DataBus_MOV_ALU_IN   <= instruction_MOV_ALU_IN and MOV_ALU_IN_SourceRegister(2) and (TimingSignals(4) or TimingSignals(5));
    Select_G_To_DataBus_MOV_ALU_IN   <= instruction_MOV_ALU_IN and MOV_ALU_IN_SourceRegister(3) and (TimingSignals(4) or TimingSignals(5));
    Select_H_To_DataBus_MOV_ALU_IN   <= instruction_MOV_ALU_IN and MOV_ALU_IN_SourceRegister(4) and (TimingSignals(4) or TimingSignals(5));
    Select_XL_To_DataBus_MOV_ALU_IN  <= instruction_MOV_ALU_IN and MOV_ALU_IN_SourceRegister(6) and (TimingSignals(4) or TimingSignals(5));
    Select_XH_To_DataBus_MOV_ALU_IN  <= instruction_MOV_ALU_IN and MOV_ALU_IN_SourceRegister(7) and (TimingSignals(4) or TimingSignals(5));
    
    -- Load the specified register from the data bus
    Load_A_From_DataBus_MOV_ALU_IN  <= instruction_MOV_ALU_IN and NegatedInstruction(3) and TimingSignals(4);
    Load_B_From_DataBus_MOV_ALU_IN  <= instruction_MOV_ALU_IN and Instruction(3) and TimingSignals(4);
    
    -- ---------------------------------------
    -- Instruction "MOV" - Format: 00DDDSSS
    -- ---------------------------------------
    -- 00:   OpCode
    -- DDD:  Destination Register
    --     => "000": Register D
    --     => "001": Register E
    --     => "010": Register F
    --     => "011": Register G
    --     => "100": Register H
    --     => "101": <Not yet used>
    --     => "110": Register XL
    --     => "111": Register XH
    -- SSS:  Source Register
    --     => "000": Register D
    --     => "001": Register E
    --     => "010": Register F
    --     => "011": Register G
    --     => "100": Register H
    --     => "101": <Not yet used>
    --     => "110": Register XL
    --     => "111": Register XH
    
    -- Check if we execute the "MOV" instruction - OpCode "00"
    instruction_MOV <= NegatedInstruction(7) and NegatedInstruction(6);
    
    -- Decode the destination and source register from the provided instruction
    DestinationRegisterDecoder: Decoder3to8 port map(Instruction(5 downto 3), MOV_DestinationRegister, '1');
    SourceRegisterDecoder: Decoder3to8 port map(Instruction(2 downto 0), MOV_SourceRegister, '1');
    
    -- Gate the specified register onto the data bus
    Select_D_To_DataBus_MOV  <= instruction_MOV and MOV_SourceRegister(0) and (TimingSignals(4) or TimingSignals(5));
    Select_E_To_DataBus_MOV  <= instruction_MOV and MOV_SourceRegister(1) and (TimingSignals(4) or TimingSignals(5));
    Select_F_To_DataBus_MOV  <= instruction_MOV and MOV_SourceRegister(2) and (TimingSignals(4) or TimingSignals(5));
    Select_G_To_DataBus_MOV  <= instruction_MOV and MOV_SourceRegister(3) and (TimingSignals(4) or TimingSignals(5));
    Select_H_To_DataBus_MOV  <= instruction_MOV and MOV_SourceRegister(4) and (TimingSignals(4) or TimingSignals(5));
    Select_XL_To_DataBus_MOV <= instruction_MOV and MOV_SourceRegister(6) and (TimingSignals(4) or TimingSignals(5));
    Select_XH_To_DataBus_MOV <= instruction_MOV and MOV_SourceRegister(7) and (TimingSignals(4) or TimingSignals(5));
    
    -- Load the specified register from the data bus
    Load_D_From_DataBus_MOV  <= instruction_MOV and MOV_DestinationRegister(0) and TimingSignals(4);
    Load_E_From_DataBus_MOV  <= instruction_MOV and MOV_DestinationRegister(1) and TimingSignals(4);
    Load_F_From_DataBus_MOV  <= instruction_MOV and MOV_DestinationRegister(2) and TimingSignals(4);
    Load_G_From_DataBus_MOV  <= instruction_MOV and MOV_DestinationRegister(3) and TimingSignals(4);
    Load_H_From_DataBus_MOV  <= instruction_MOV and MOV_DestinationRegister(4) and TimingSignals(4);
    Load_XL_From_DataBus_MOV <= instruction_MOV and MOV_DestinationRegister(6) and TimingSignals(4);
    Load_XH_From_DataBus_MOV <= instruction_MOV and MOV_DestinationRegister(7) and TimingSignals(4);
    
    -- ---------------------------------------
    -- Instruction "MOV16" - Format: 01DDDSSS
    -- ---------------------------------------
    -- 01:   OpCode
    -- DDD:  Destination Register
    --     => "000": Register M
    --     => "001": Register X
    --     => "010": Register J
    --     => "011": Register SP
    --     => "100": Register PC
    --     => "101": Register BP
    --     => "110": Register Y
    --     => "111": Register Z
    -- SSS:  Source Register
    --     => "000": Register M
    --     => "001": Register X
    --     => "010": Register J
    --     => "011": Register SP
    --     => "100": Register PC
    --     => "101": Register BP
    --     => "110": Register Y
    --     => "111": Register Z
    
    -- Check if we execute the "MOV16" instruction - OpCode "01"
    instruction_MOV16 <= NegatedInstruction(7) and Instruction(6);
    
    -- Decode the destination and source register from the provided instruction
    DestinationRegisterDecoderMOV16: Decoder3to8 port map(Instruction(5 downto 3), MOV16_DestinationRegister, '1');
    SourceRegisterDecoderMOV16: Decoder3to8 port map(Instruction(2 downto 0), MOV16_SourceRegister, '1');
    
    -- Gate the specified register onto the data bus
    Select_M_To_AddressBus_MOV16  <= instruction_MOV16 and MOV16_SourceRegister(0) and (TimingSignals(4) or TimingSignals(5));
    Select_X_To_AddressBus_MOV16  <= instruction_MOV16 and MOV16_SourceRegister(1) and (TimingSignals(4) or TimingSignals(5));
    Select_J_To_AddressBus_MOV16  <= instruction_MOV16 and MOV16_SourceRegister(2) and (TimingSignals(4) or TimingSignals(5));
    Select_SP_To_AddressBus_MOV16 <= instruction_MOV16 and MOV16_SourceRegister(3) and (TimingSignals(4) or TimingSignals(5));
    Select_PC_To_AddressBus_MOV16 <= instruction_MOV16 and MOV16_SourceRegister(4) and (TimingSignals(4) or TimingSignals(5));
    Select_BP_To_AddressBus_MOV16 <= instruction_MOV16 and MOV16_SourceRegister(5) and (TimingSignals(4) or TimingSignals(5));
    Select_Y_To_AddressBus_MOV16  <= instruction_MOV16 and MOV16_SourceRegister(6) and (TimingSignals(4) or TimingSignals(5));
    Select_Z_To_AddressBus_MOV16  <= instruction_MOV16 and MOV16_SourceRegister(7) and (TimingSignals(4) or TimingSignals(5));
    
    -- Load the specified register from the data bus
    Load_M_From_AddressBus_MOV16  <= instruction_MOV16 and MOV16_DestinationRegister(0) and TimingSignals(4);
    Load_X_From_AddressBus_MOV16  <= instruction_MOV16 and MOV16_DestinationRegister(1) and TimingSignals(4);
    Load_J_From_AddressBus_MOV16  <= instruction_MOV16 and MOV16_DestinationRegister(2) and TimingSignals(4);
    Load_SP_From_AddressBus_MOV16 <= instruction_MOV16 and MOV16_DestinationRegister(3) and TimingSignals(4);
    Load_PC_From_AddressBus_MOV16 <= instruction_MOV16 and MOV16_DestinationRegister(4) and TimingSignals(4);
    Load_BP_From_AddressBus_MOV16 <= instruction_MOV16 and MOV16_DestinationRegister(5) and TimingSignals(4);
    Load_Y_From_AddressBus_MOV16  <= instruction_MOV16 and MOV16_DestinationRegister(6) and TimingSignals(4);
    Load_Z_From_AddressBus_MOV16  <= instruction_MOV16 and MOV16_DestinationRegister(7) and TimingSignals(4);
    
    -- -------------------------------------
    -- Instruction "HLT" - Format: 11000011
    -- -------------------------------------
    -- Stops the execution of the CPU.
    -- 11010011:  OpCode
    
    -- Check if we execute the "HLT" instruction - OpCode "11010011"
    instruction_HLT <= Instruction(7) and
                       Instruction(6) and
                       NegatedInstruction(5) and
                       NegatedInstruction(4) and
                       NegatedInstruction(3) and
                       NegatedInstruction(2) and
                       Instruction(1) and    
                       Instruction(0);
                 
    -- Stops the CPU execution
    StopCPU <= instruction_HLT;
    
    -- ---------------------------------------
    -- Instruction "LOAD" - Format: 10010DDD
    -- ---------------------------------------
    -- Loads a 8-bit value from SRAM memory into the specified register.
    -- The SRAM memory address is stored in the register "M".
    -- The transfer of the data to the register from the SRAM memory is done through the data bus.
    -- 10010:   OpCode
    -- DDD:     Destination Register
    --          => "000": Register D
    --          => "001": Register E
    --          => "010": Register F
    --          => "011": Register G
    --          => "100": Register H
    --          => "101": <Not used...>
    --          => "110": Register XL
    --          => "111": Register XH
    
    -- Check if we execute the "LOAD" instruction - OpCode "10010"
    instruction_LOAD <= Instruction(7) and
                        NegatedInstruction(6) and
                        NegatedInstruction(5) and
                        Instruction(4) and
                        NegatedInstruction(3);
    
    -- Latch the SRAM memory address from register M onto the address bus                    
    Select_M_To_AddressBus_LOAD <= instruction_LOAD and (TimingSignals(4) or TimingSignals(5));
    
    -- Request the 8-bit from the RAM memory in the states #5, #6, and #7
    Select_SRAM_LOAD <= instruction_LOAD and (TimingSignals(4) or TimingSignals(5) or TimingSignals(6));
    
    -- Because the RAM has a latency of 1 clock cycle, we only return the
    -- requested data from the RAM in state #7 (data in state #5, #6 is still unstable!!!) 
    -- This finally places the requested RAM data onto the data bus   
    Return_SRAM_LOAD <= TimingSignals(6);    -- State #7
    
    -- Load the Register D from the data bus
    Load_D_From_DataBus_LOAD <= instruction_LOAD and
                                TimingSignals(6) and
                                NegatedInstruction(2) and
                                NegatedInstruction(1) and
                                NegatedInstruction(0);
    
    -- Load the Register E from the data bus                            
    Load_E_From_DataBus_LOAD <= instruction_LOAD and
                                TimingSignals(6) and
                                NegatedInstruction(2) and
                                NegatedInstruction(1) and
                                Instruction(0);

    -- Load the Register F from the data bus                                
    Load_F_From_DataBus_LOAD <= instruction_LOAD and
                                TimingSignals(6) and
                                NegatedInstruction(2) and
                                Instruction(1) and
                                NegatedInstruction(0);

    -- Load the Register G from the data bus
    Load_G_From_DataBus_LOAD <= instruction_LOAD and
                                TimingSignals(6) and
                                NegatedInstruction(2) and
                                Instruction(1) and
                                Instruction(0);
                                
    -- Load the Register H from the data bus
    Load_H_From_DataBus_LOAD <= instruction_LOAD and
                                TimingSignals(6) and
                                Instruction(2) and
                                NegatedInstruction(1) and
                                NegatedInstruction(0);
                                 
    -- Load the Register XL from the data bus
    Load_XL_From_DataBus_LOAD <= instruction_LOAD and
                                 TimingSignals(6) and
                                 Instruction(2) and
                                 Instruction(1) and
                                 NegatedInstruction(0);
                                  
    -- Load the Register XL from the data bus
    Load_XH_From_DataBus_LOAD <= instruction_LOAD and
                                 TimingSignals(6) and
                                 Instruction(2) and
                                 Instruction(1) and
                                 Instruction(0);
                                
    -- ---------------------------------------
    -- Instruction "STORE" - Format: 10011SSS
    -- ---------------------------------------
    -- Save a 8-bit value to SRAM memory from the specified register.
    -- The SRAM memory address is stored in the register "M".
    -- The transfer of the data from the register into the SRAM memory is done through the data bus.
    -- 10011:   OpCode
    -- SSS:     Source Register
    --          => "000": Register D
    --          => "001": Register E
    --          => "010": Register F
    --          => "011": Register G
    --          => "100": Register H
    --          => "101": <Not used...>
    --          => "110": Register XL
    --          => "111": Register XH
    
    -- Check if we execute the "STORE" instruction - OpCode "10011"
    instruction_STORE <= Instruction(7) and
                         NegatedInstruction(6) and
                         NegatedInstruction(5) and
                         Instruction(4) and
                         Instruction(3);
    
    -- Selects the content of the register "M" onto the address bus                     
    Select_M_To_AddressBus_STORE <= instruction_STORE and
                                    (TimingSignals(4) or TimingSignals(5));
                         
    -- Select the Register D to the data bus
    Select_D_To_DataBus_STORE <= instruction_STORE and
                                 NegatedInstruction(2) and
                                 NegatedInstruction(1) and
                                 NegatedInstruction(0) and
                                 (TimingSignals(4) or TimingSignals(5));
     
    -- Select the Register E to the data bus                            
    Select_E_To_DataBus_STORE <= instruction_STORE and
                                 NegatedInstruction(2) and
                                 NegatedInstruction(1) and
                                 Instruction(0) and
                                 (TimingSignals(4) or TimingSignals(5));
 
    -- Select the Register F to the data bus                                
    Select_F_To_DataBus_STORE <= instruction_STORE and
                                 NegatedInstruction(2) and
                                 Instruction(1) and
                                 NegatedInstruction(0) and
                                 (TimingSignals(4) or TimingSignals(5));
 
    -- Select the Register G to the data bus
    Select_G_To_DataBus_STORE <= instruction_STORE and
                                 NegatedInstruction(2) and
                                 Instruction(1) and
                                 Instruction(0) and
                                 (TimingSignals(4) or TimingSignals(5));
                                 
    -- Select the Register H to the data bus
    Select_H_To_DataBus_STORE <= instruction_STORE and
                                 Instruction(2) and
                                 NegatedInstruction(1) and
                                 NegatedInstruction(0) and
                                 (TimingSignals(4) or TimingSignals(5));
                                 
    -- Select the Register XL to the data bus
    Select_XL_To_DataBus_STORE <= instruction_STORE and
                                  Instruction(2) and
                                  Instruction(1) and
                                  NegatedInstruction(0) and
                                  (TimingSignals(4) or TimingSignals(5));
                                  
    -- Select the Register XH to the data bus
    Select_XH_To_DataBus_STORE <= instruction_STORE and
                                  Instruction(2) and
                                  Instruction(1) and
                                  Instruction(0) and
                                  (TimingSignals(4) or TimingSignals(5));

    -- Enables the Load Line of the RAM memory and transfers the data from the data bus into
    -- the memory address provided in register M                             
    Load_SRAM_STORE <= instruction_STORE and 
                       TimingSignals(5);

    -- ---------------------------------------------
    -- Instruction "STORE_FLAGS" - Format: 11001001
    -- ---------------------------------------------
    -- Selects the flags from the "FlagsOutBuffer" register onto the data bus
    -- and stores it in the RAM.
    -- 11001001: OpCode
    
    -- Check if we execute the "STORE_FLAGS" instruction - OpCode "11001001"
    instruction_STORE_FLAGS <= Instruction(7) and
                               Instruction(6) and
                               NegatedInstruction(5) and
                               NegatedInstruction(4) and
                               Instruction(3) and
                               NegatedInstruction(2) and
                               NegatedInstruction(1) and
                               Instruction(0);
    
    -- Selects the content of the register "M" onto the address bus                           
    Select_M_To_AddressBus_STORE_FLAGS <= instruction_STORE_FLAGS and
                                          (TimingSignals(4) or TimingSignals(5));
    
    -- Selects the flags from the "FlagsOutBuffer" onto the data bus                           
    Select_FlagsToDataBus <= instruction_STORE_FLAGS and
                             (TimingSignals(4) or TimingSignals(5));
                             
    -- Enables the Load Line of the RAM memory and transfers the data from the data bus into
    -- the memory address provided in register M                             
    Load_SRAM_STORE_FLAGS <= instruction_STORE_FLAGS and 
                             TimingSignals(5);
                             
    -- ---------------------------------------------
    -- Instruction "LOAD_FLAGS" - Format: 11001010
    -- ---------------------------------------------
    -- Loads the flags from the RAM and writes them into the "FlagsInBuffer" register.
    -- and stores it onto the stack
    -- 11001010: OpCode
     
    -- Check if we execute the "STORE_FLAGS" instruction - OpCode "11001010"
    instruction_LOAD_FLAGS <= Instruction(7) and
                              Instruction(6) and
                              NegatedInstruction(5) and
                              NegatedInstruction(4) and
                              Instruction(3) and
                              NegatedInstruction(2) and
                              Instruction(1) and
                              NegatedInstruction(0);
                              
    -- Latch the SRAM memory address from register M onto the address bus                    
    Select_M_To_AddressBus_LOAD_FLAGS <= instruction_LOAD_FLAGS and
                                         (TimingSignals(4) or TimingSignals(5));
  
    -- Request the 8-bit from the RAM memory in the states #5, #6, and #7
    Select_SRAM_LOAD_FLAGS <= instruction_LOAD_FLAGS and
                              (TimingSignals(4) or TimingSignals(5) or TimingSignals(6));
  
    -- Because the RAM has a latency of 1 clock cycle, we only return the
    -- requested data from the RAM in state #7 (data in state #5, #6 is still unstable!!!) 
    -- This finally places the requested RAM data onto the data bus   
    Return_SRAM_LOAD_FLAGS <= TimingSignals(6);    -- State #7
                              
    -- Selects the flags from the "FlagsOutBuffer" onto the data bus                           
    Load_FlagsFromDataBus <= instruction_LOAD_FLAGS and
                             TimingSignals(6);
                      
    -- ---------------------------------------
    -- Instruction "JMP" - Format: 11000010
    -- ---------------------------------------
    -- Unconditional jump to the address in the program code that is stored in the register "J".
    -- The memory address from register "J" is loaded into the program counter.
    -- In the next machine cycle the execution continues at the new program counter position.
    -- 11000010:  OpCode   
    
    -- Check if we execute the "JMP" instruction - OpCode "11000010"
    instruction_JMP <= Instruction(7) and
                       Instruction(6) and 
                       NegatedInstruction(5) and
                       NegatedInstruction(4) and
                       NegatedInstruction(3) and
                       NegatedInstruction(2) and
                       Instruction(1) and
                       NegatedInstruction(0);
    
    -- Select the target jump address to the address bus
    Select_J_To_AddressBus_JMP <= instruction_JMP and
                                  (TimingSignals(4) or TimingSignals(5));
                      
    -- Load the Program Counter from the address bus
    Load_PC_JMP <= instruction_JMP and
                   TimingSignals(5);
                   
    -- --------------------------------------------
    -- Instruction "SAVE_FLAGS" - Format: 11000100
    -- --------------------------------------------
    -- Saves the current content of the flags register into the "SavedFlags" register
    -- 11000100:  OpCode
    
    -- Check if we execute the "SAVE_FLAGS" instruction - OpCode "11000100"
    instruction_SAVE_FLAGS <= Instruction(7) and
                              Instruction(6) and 
                              NegatedInstruction(5) and
                              NegatedInstruction(4) and
                              NegatedInstruction(3) and
                              Instruction(2) and
                              NegatedInstruction(1) and
                              NegatedInstruction(0);
    
    -- Enables the Select Line of the flags register to load the flags into the "SavedFlags" register                          
    Select_Flags_SAVE_FLAGS <= instruction_SAVE_FLAGS and
                               TimingSignals(4);
    
    -- Enables the Load Line of the "SavedFlags" register to load the flags into the "SavedFlags" register                          
    Load_FlagsSaved_From_FlagsRegister <= instruction_SAVE_FLAGS and
                                          TimingSignals(4);
                                          
    -- -----------------------------------------------
    -- Instruction "RESTORE_FLAGS" - Format: 11000101
    -- -----------------------------------------------
    -- Saves the current content of the flags register into the "SavedFlags" register
    -- 11000101:  OpCode
  
    -- Check if we execute the "RESTORE_FLAGS" instruction - OpCode "11000101"
    instruction_RESTORE_FLAGS <= Instruction(7) and
                                 Instruction(6) and 
                                 NegatedInstruction(5) and
                                 NegatedInstruction(4) and
                                 NegatedInstruction(3) and
                                 Instruction(2) and
                                 NegatedInstruction(1) and
                                 Instruction(0);
                            
    -- Enables the Load Line of the flags register to load the "SavedFlags" register into the flags register                          
    Load_Flags_SAVE_FLAGS <= instruction_RESTORE_FLAGS and
                             TimingSignals(4);
  
    -- Enables the Select Line of the "SavedFlags" register to load the "SavedFlags" register into the flags register                          
    Load_FlagsSaved_To_FlagsRegister <= instruction_RESTORE_FLAGS and
                                        TimingSignals(4);
                                        
    -- ----------------------------------------------------
    -- Instruction "FLAGS_TO_OUTBUFFER" - Format: 11000110
    -- ----------------------------------------------------
    -- Writes the current content of the flags register onto the data bus
    -- 11000110:  OpCode
    
    -- Check if we execute the "FLAGS_TO_OUTBUFFER" instruction - OpCode "11000110"
    instruction_FLAGS_TO_OUTBUFFER <= Instruction(7) and
                                      Instruction(6) and 
                                      NegatedInstruction(5) and
                                      NegatedInstruction(4) and
                                      NegatedInstruction(3) and
                                      Instruction(2) and
                                      Instruction(1) and
                                      NegatedInstruction(0);
    
    -- Selects the content from the Flags register onto the Flags Bus                        
    Select_Flags_FLAGS_TO_OUTBUFFER <= instruction_FLAGS_TO_OUTBUFFER and
                                       TimingSignals(4);
                                    
    -- Loads the content from the Flags Bus into the "FlagsOutBuffer" register 
    Load_FlagsFromFlagsBus <= instruction_FLAGS_TO_OUTBUFFER and
                              TimingSignals(4);
                              
    -- ---------------------------------------------------
    -- Instruction "INBUFFER_TO_FLAGS" - Format: 11000111
    -- ---------------------------------------------------
    -- Writes the current content of the flags register onto the data bus
    -- 11000111:  OpCode
  
    -- Check if we execute the "FLAGS_TO_INBUFFER" instruction - OpCode "11000111"
    instruction_INBUFFER_TO_FLAGS <= Instruction(7) and
                                     Instruction(6) and 
                                     NegatedInstruction(5) and
                                     NegatedInstruction(4) and
                                     NegatedInstruction(3) and
                                     Instruction(2) and
                                     Instruction(1) and
                                     Instruction(0);
  
    -- Selects the content from the "FlagsInBuffer" register to the Flags Bus                        
    Select_FlagsToFlagsBus <= instruction_INBUFFER_TO_FLAGS and
                              TimingSignals(4);
    
    -- Loads the content from the Flags Bus into the Flags register                         
    Load_Flags_INBUFFER_TO_FLAGS <= instruction_INBUFFER_TO_FLAGS and
                                    TimingSignals(4);
                   
    -- ---------------------------------------
    -- Instruction "JZ" - Format: 11000000
    -- ---------------------------------------
    -- Conditional jump to the address in the program code that is stored in the register "J".
    -- The jump is only executed if the Zero-Flag in the FLAGS register is set to "1".
    -- The memory address from register "J" is loaded into the program counter.
    -- In the next machine cycle the execution continues at the new program counter position.
    -- 11000000:  OpCode
    
    -- Check if we execute the "JZ" instruction - OpCode "11000000"
    instruction_JZ <= Instruction(7) and
                      Instruction(6) and 
                      NegatedInstruction(5) and
                      NegatedInstruction(4) and
                      NegatedInstruction(3) and
                      NegatedInstruction(2) and
                      NegatedInstruction(1) and
                      NegatedInstruction(0);
                      
    Select_Flags_JZ <= instruction_JZ and
                       (TimingSignals(5) or TimingSignals(6) or TimingSignals(7));
                  
    -- Select the target jump address to the address bus
    Select_J_To_AddressBus_JZ <= instruction_JZ and
                                 Flags(1) and
                                 (TimingSignals(6) or TimingSignals(7));

    -- Load the Program Counter from the address bus
    Load_PC_JZ <= instruction_JZ and
                  Flags(1) and
                  TimingSignals(7);
                  
    -- ---------------------------------------
    -- Instruction "JNS" - Format: 11001011
    -- ---------------------------------------
    -- Conditional jump to the address in the program code that is stored in the register "J".
    -- The jump is only executed if the Sign-Flag in the FLAGS register is set to "0".
    -- The memory address from register "J" is loaded into the program counter.
    -- In the next machine cycle the execution continues at the new program counter position.
    -- 11001011:  OpCode
  
    -- Check if we execute the "JNS" instruction - OpCode "11001011"
    instruction_JNS <= Instruction(7) and
                       Instruction(6) and 
                       NegatedInstruction(5) and
                       NegatedInstruction(4) and
                       Instruction(3) and
                       NegatedInstruction(2) and
                       Instruction(1) and
                       Instruction(0);
                    
    Select_Flags_JNS <= instruction_JNS and
                        (TimingSignals(5) or TimingSignals(6) or TimingSignals(7));
                
    -- Select the target jump address to the address bus
    Select_J_To_AddressBus_JNS <= instruction_JNS and
                                  (not Flags(0)) and
                                  (TimingSignals(6) or TimingSignals(7));

    -- Load the Program Counter from the address bus
    Load_PC_JNS <= instruction_JNS and
                   (not Flags(0)) and
                   TimingSignals(7);
                   
    -- ---------------------------------------
    -- Instruction "JNC" - Format: 11010001
    -- ---------------------------------------
    -- Conditional jump to the address in the program code that is stored in the register "J".
    -- The jump is only executed if the Carry-Flag in the FLAGS register is set to "0".
    -- The memory address from register "J" is loaded into the program counter.
    -- In the next machine cycle the execution continues at the new program counter position.
    -- 11001011:  OpCode
 
    -- Check if we execute the "JNC" instruction - OpCode "11010001"
    instruction_JNC <= Instruction(7) and
                       Instruction(6) and 
                       NegatedInstruction(5) and
                       Instruction(4) and
                       NegatedInstruction(3) and
                       NegatedInstruction(2) and
                       NegatedInstruction(1) and
                       Instruction(0);
                   
    Select_Flags_JNC <= instruction_JNC and
                        (TimingSignals(5) or TimingSignals(6) or TimingSignals(7));
               
    -- Select the target jump address to the address bus
    Select_J_To_AddressBus_JNC <= instruction_JNC and
                                  (not Flags(2)) and
                                  (TimingSignals(6) or TimingSignals(7));

    -- Load the Program Counter from the address bus
    Load_PC_JNC <= instruction_JNC and
                   (not Flags(2)) and
                   TimingSignals(7);
              
    -- ---------------------------------------
    -- Instruction "JNZ" - Format: 11000001
    -- ---------------------------------------
    -- Conditional jump to the address in the program code that is stored in the register "J".
    -- The jump is only executed if the Zero-Flag in the FLAGS register is set to "0".
    -- The memory address from register "J" is loaded into the program counter.
    -- In the next machine cycle the execution continues at the new program counter position.
    -- 11000001:  OpCode
  
    -- Check if we execute the "JNZ" instruction - OpCode "11000001"
    instruction_JNZ <= Instruction(7) and
                       Instruction(6) and 
                       NegatedInstruction(5) and
                       NegatedInstruction(4) and
                       NegatedInstruction(3) and
                       NegatedInstruction(2) and
                       NegatedInstruction(1) and
                       Instruction(0);
                    
    Select_Flags_JNZ <= instruction_JNZ and
                        (TimingSignals(5) or TimingSignals(6) or TimingSignals(7));
                
    -- Select the target jump address to the address bus
    Select_J_To_AddressBus_JNZ <= instruction_JNZ and
                                  NegatedFlags(1) and
                                  (TimingSignals(6) or TimingSignals(7));

    -- Load the Program Counter from the address bus
    Load_PC_JNZ <= instruction_JNZ and
                   NegatedFlags(1) and
                   TimingSignals(7);
                   
    -- ---------------------------------------------
    -- Instruction "16BIT_ADDER" - Format: 11001000
    -- ---------------------------------------------
    -- Performs a 16-bit addition between the 16-bit value in register "X" and the 
    -- 8-bit value in register "D".
    -- The result of the addition is put back into register "X".
    -- 11001000:  OpCode
    
    -- Check if we execute the "16BIT_ADDER" instruction - OpCode "11001000"
    instruction_ADDER_16BIT <= Instruction(7) and
                               Instruction(6) and 
                               NegatedInstruction(5) and
                               NegatedInstruction(4) and
                               Instruction(3) and
                               NegatedInstruction(2) and
                               NegatedInstruction(1) and
                               NegatedInstruction(0);
      
      -- Select the content of register "X" to the address bus                         
      Select_X_To_AddressBus_ADDER_16BIT <= instruction_ADDER_16BIT and
                                            TimingSignals(3);
      
      -- Load the A input of the 16-bit Adder from the address bus                         
      Load_Adder16Bit_InputA <= instruction_ADDER_16BIT and
                                TimingSignals(3);
                                
      -- Select the content of register "J" to the address bus                         
      Select_J_To_AddressBus_ADDER_16BIT <= instruction_ADDER_16BIT and
                                            TimingSignals(4);
      
      -- Load the B input of the 16-bit Adder from the address bus                         
      Load_Adder16Bit_InputB <= instruction_ADDER_16BIT and
                                TimingSignals(4);
      
      -- Select the A input into the 16-bit Adder                            
      Select_Adder16Bit_InputA <= instruction_ADDER_16BIT and
                                  (TimingSignals(5) or TimingSignals(6));
      
      -- Select the B input into the 16-bit Adder                            
      Select_Adder16Bit_InputB <= instruction_ADDER_16BIT and
                                  (TimingSignals(5) or TimingSignals(6));
      
      -- Load the output from the 16-bit adder into the C output                            
      Load_Adder16Bit_OutputC <= instruction_ADDER_16BIT and
                                 TimingSignals(6);

      -- Select the output from the C output onto the address bus                                 
      Select_Adder16Bit_OutputC <= instruction_ADDER_16BIT and
                                   TimingSignals(7);
                                   
      -- Load the content from the address bus into the register "X"                     
      Load_X_From_AddressBus_ADDER_16BIT <= instruction_ADDER_16BIT and
                                            TimingSignals(7);
                                            
      -- ---------------------------------------------
      -- Instruction "IN" - Format: 1100110P
      -- ---------------------------------------------
      -- Reads from the specified input port and places the read value into the specified register.
      -- 1100110P: OpCode
      --        P: Port - "0" -> Input Port A, "1" -> Input Port B
      
      -- Check if we execute the "IN" instruction - OpCode "1101"
      instruction_IN <= Instruction(7) and
                        Instruction(6) and 
                        NegatedInstruction(5) and
                        NegatedInstruction(4) and
                        Instruction(3) and
                        Instruction(2) and
                        NegatedInstruction(1);
      
      -- Select the input value from Input Port A to the data bus                  
      Select_PortA_To_DataBus <= instruction_IN and
                                 NegatedInstruction(0) and
                                 (TimingSignals(3) or TimingSignals(4));   
                                 
      -- Select the input value from Input Port B to the data bus                  
      Select_PortB_To_DataBus <= instruction_IN and
                                 Instruction(0) and
                                 (TimingSignals(3) or TimingSignals(4));
                                 
      -- Load the Register XL from the data bus
      Load_XL_From_DataBus_IN <= instruction_IN and
                                 TimingSignals(4);
                                 
      -- ---------------------------------------------
      -- Instruction "OUT" - Format: 1100111P
      -- ---------------------------------------------
      -- Reads from the specified input port and places the read value into the specified register.
      -- 1100111P: OpCode
      --        P: Port - "0" -> Output Port C, "1" -> Output Port D
       
      -- Check if we execute the "IN" instruction - OpCode "1100111"
      instruction_OUT <= Instruction(7) and
                         Instruction(6) and 
                         NegatedInstruction(5) and
                         NegatedInstruction(4) and
                         Instruction(3) and
                         Instruction(2) and
                         Instruction(1);
                         
      -- Select the register XL to the data bus
      Select_XL_To_DataBus_OUT <= instruction_OUT and
                                  (TimingSignals(3) or TimingSignals(4));
      
      -- Select the output value from the data bus into the Output Port C                            
      Load_PortC_From_DataBus <= instruction_OUT and
                                 NegatedInstruction(0) and
                                 TimingSignals(4);
                                 
      -- Select the output value from the data bus into the Output Port D                            
      Load_PortD_From_DataBus <= instruction_OUT and
                                 Instruction(0) and
                                 TimingSignals(4);
      
    -- ================================================================
    -- The following section enables the final CPU control lines
    -- ================================================================
    
    -- Enable/Disable Load Line of register A
    Load_A_From_DataBus <= Load_A_From_DataBus_SETAB or
                           Load_A_From_DataBus_MOV_ALU_IN or
                           Load_A_From_DataBus_MOV_ALU_C_TO_AB;
    
    -- Enable/Disable Load Line of register B                       
    Load_B_From_DataBus <= Load_B_From_DataBus_SETAB or
                           Load_B_From_DataBus_MOV_ALU_IN or
                           Load_B_From_DataBus_MOV_ALU_C_TO_AB;
    
    -- Enable/Disable Load Line of register C                       
    Load_C_From_DataBus <= Load_C_From_DataBus_ALU;
    
    -- Enable/Disable Load Line of register D                       
    Load_D_From_DataBus <= Load_D_From_DataBus_MOV_ALU_OUT or
                           Load_D_From_DataBus_MOV or
                           Load_D_From_DataBus_LOAD;

    -- Enable/Disable Load Line of register E                           
    Load_E_From_DataBus <= Load_E_From_DataBus_MOV_ALU_OUT or
                           Load_E_From_DataBus_MOV or
                           Load_E_From_DataBus_LOAD;
    
    -- Enable/Disable Load Line of register F
    Load_F_From_DataBus <= Load_F_From_DataBus_MOV_ALU_OUT or
                           Load_F_From_DataBus_MOV or
                           Load_F_From_DataBus_LOAD;
    
    -- Enable/Disable Load Line of register G
    Load_G_From_DataBus <= Load_G_From_DataBus_MOV_ALU_OUT or
                           Load_G_From_DataBus_MOV or
                           Load_G_From_DataBus_LOAD;

    -- Enable/Disable Load Line of register H
    Load_H_From_DataBus <= Load_H_From_DataBus_MOV_ALU_OUT or
                           Load_H_From_DataBus_MOV or
                           Load_H_From_DataBus_LOAD;
    
    -- Enable/Disable Load Line of register XL
    Load_XL_From_DataBus <= Load_XL_From_DataBus_MOV_ALU_OUT or
                            Load_XL_From_DataBus_MOV or
                            Load_XL_From_DataBus_LOAD or
                            Load_XL_From_DataBus_IN;
    
    -- Enable/Disable Load Line of register XH
    Load_XH_From_DataBus <= Load_XH_From_DataBus_MOV_ALU_OUT or
                            Load_XH_From_DataBus_MOV or
                            Load_XH_From_DataBus_LOAD;
                          
    -- Enable/Disable the Load Line of register M
    Load_M_From_AddressBus <= Load_M_From_AddressBus_MOV16;
    
    -- Enable/Disable the Load Line of register X
    Load_X_From_AddressBus <= Load_X_From_AddressBus_MOV16 or
                              Load_X_From_AddressBus_ADDER_16BIT;
                           
    -- Enable/Disable Load Line of register J
    Load_J_From_AddressBus <= Load_J_From_AddressBus_MOV16; 
    
    -- Enable/Disable Load Line of register SP
    Load_SP_From_AddressBus <= Load_SP_From_AddressBus_MOV16;
    
    -- Enable/Disable Load Line of register BP
    Load_BP_From_AddressBus <= Load_BP_From_AddressBus_MOV16;
    
    -- Enable/Disable Load Line of register Y
    Load_Y_From_AddressBus <= Load_Y_From_AddressBus_MOV16;
    
    -- Enable/Disable Load Line of register Z
    Load_Z_From_AddressBus <= Load_Z_From_AddressBus_MOV16;
    
    -- Enable/Disable Select Line of register C
    Select_C_To_DataBus <= Select_C_To_DataBus_MOV_ALU_OUT or
                           Select_C_To_DataBus_MOV_ALU_C_TO_AB;
    
    -- Enable/Disable Select Line of register D
    Select_D_To_DataBus <= Select_D_To_DataBus_MOV_ALU_IN or
                           Select_D_To_DataBus_MOV or                           
                           Select_D_To_DataBus_STORE or
                           Select_D_To_DataBus_ADDER_16BIT;
    
    -- Enable/Disable Select Line of register E                       
    Select_E_To_DataBus <= Select_E_To_DataBus_MOV_ALU_IN or
                           Select_E_To_DataBus_MOV or
                           Select_E_To_DataBus_STORE;
    
    -- Enable/Disable Select Line of register F                       
    Select_F_To_DataBus <= Select_F_To_DataBus_MOV_ALU_IN or
                           Select_F_To_DataBus_MOV or
                           Select_F_To_DataBus_STORE;
    
    -- Enable/Disable Select Line of register G                       
    Select_G_To_DataBus <= Select_G_To_DataBus_MOV_ALU_IN or
                           Select_G_To_DataBus_MOV or
                           Select_G_To_DataBus_STORE;  

    -- Enable/Disable Select Line of register H                       
    Select_H_To_DataBus <= Select_H_To_DataBus_MOV_ALU_IN or
                           Select_H_To_DataBus_MOV or
                           Select_H_To_DataBus_STORE;
    
    -- Enable/Disable Select Line of register XL
    Select_XL_To_DataBus <= Select_XL_To_DataBus_MOV_ALU_IN or
                            Select_XL_To_DataBus_MOV or
                            Select_XL_To_DataBus_STORE or
                            Select_XL_To_DataBus_OUT;
    
    -- Enable/Disable Select Line of register XH
    Select_XH_To_DataBus <= Select_XH_To_DataBus_MOV_ALU_IN or
                            Select_XH_To_DataBus_MOV or
                            Select_XH_To_DataBus_STORE;
                            
    -- Enable/Disable the Select Line of register M
    Select_M_To_AddressBus <= Select_M_To_AddressBus_MOV16 or
                              Select_M_To_AddressBus_LOAD or
                              Select_M_To_AddressBus_LOAD_FLAGS or
                              Select_M_To_AddressBus_STORE or
                              Select_M_To_AddressBus_STORE_FLAGS;
    
    -- Enable/Disable the Select Line of register X
    Select_X_To_AddressBus <= Select_X_To_AddressBus_MOV16 or
                              Select_X_To_AddressBus_ADDER_16BIT or
                              Select_X_To_AddressBus_ADDER_16BIT;
                           
    -- Enable/Disable Select Line of register SP
    Select_SP_To_AddressBus <= Select_SP_To_AddressBus_MOV16;
    
    -- Enable/Disable Select Line of register BP
    Select_BP_To_AddressBus <= Select_BP_To_AddressBus_MOV16;
    
    -- Enable/Disable Select Line of register Y
    Select_Y_To_AddressBus <= Select_Y_To_AddressBus_MOV16;
    
    -- Enable/Disable Select Line of register Z
    Select_Z_To_AddressBus <= Select_Z_To_AddressBus_MOV16;   
                            
    -- Enable/Disable Select Line of register J
    Select_J_To_AddressBus <= Select_J_To_AddressBus_MOV16 or
                              Select_J_To_AddressBus_JMP or
                              Select_J_To_AddressBus_JZ or
                              Select_J_To_AddressBus_JNS or
                              Select_J_To_AddressBus_JNZ or
                              Select_J_To_AddressBus_JNC or
                              Select_J_To_AddressBus_ADDER_16BIT;
    
    -- Enables the Select Line of the flags register                          
    Select_Flags <= Select_Flags_JZ or
                    Select_Flags_SAVE_FLAGS or
                    Select_Flags_JNZ or
                    Select_Flags_JNS or
                    Select_Flags_JNC or
                    Select_Flags_FLAGS_TO_OUTBUFFER;

    -- Enables the Load Line of the flags register
    Load_Flags <= Load_Flags_From_ALU or
                  Load_Flags_SAVE_FLAGS or
                  Load_Flags_INBUFFER_TO_FLAGS;
    
    -- Requests the data from the RAM to the data bus
    Select_SRAM <= Select_SRAM_FETCH or
                   Select_SRAM_LOAD or
                   Select_SRAM_LOAD_FLAGS;
    
    -- Loads the data from the data bus into the RAM               
    Load_SRAM <= Load_SRAM_STORE or
                 Load_SRAM_STORE_FLAGS;
    
    -- Returns the requested data from the RAM onto the data bus               
    Return_SRAM <= Return_SRAM_FETCH or
                   Return_SRAM_LOAD or
                   Return_SRAM_LOAD_FLAGS;
    
    -- Enable/Disable the Load Line of the Program Counter
    Load_PC <= Load_PC_FETCH or
               Load_PC_JMP or
               Load_PC_JZ or
               Load_PC_JNS or
               Load_PC_JNZ or
               Load_PC_JNC or
               Load_PC_From_AddressBus_MOV16;
    
    -- Enable/Disable the Load Line of the Program Counter           
    Select_PC <= Select_PC_FETCH or
                 Select_PC_To_AddressBus_MOV16;
end Behavioral;
