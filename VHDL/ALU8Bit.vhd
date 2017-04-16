----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/20/2015 06:10:42 PM
-- Design Name: 
-- Module Name: ALU8Bit - Behavioral
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

entity ALU8Bit is
    Port
    (
        InputA :      in  BIT_VECTOR(7 downto 0); -- 1st 8-bit input value
        InputB :      in  BIT_VECTOR(7 downto 0); -- 2nd 8-bit input value
        FunctionCode: in  BIT_VECTOR(3 downto 0); -- 4-bit function code
        CarryIn:      in BIT;                     -- Carry-Bit
        Output :      out BIT_VECTOR(7 downto 0); -- 8-bit output value
        Sign :        out BIT;                    -- Do we have a negative number? FLAGS(0)
        Zero :        out BIT;                    -- Do we have a zero value?      FLAGS(1)
        Carry :       out BIT;                    -- Do we have a carry?           FLAGS(2)
        Overflow:     out BIT                     -- Do we have an overflow?       FLAGS(3)
    );
end ALU8Bit;

architecture Behavioral of ALU8Bit is

component RippleCarryAdder8Bit is
    Port
    (
        InputA : in  BIT_VECTOR(7 downto 0); -- 1st 8-bit input value
        InputB : in  BIT_VECTOR(7 downto 0); -- 2nd 8-bit input value
        Cin    : in  BIT;                    -- Carry-in flag
        Output : out BIT_VECTOR(7 downto 0); -- 8-bit output value
        Cout   : out BIT                     -- Carry-out flag
    );
end component RippleCarryAdder8Bit;

component And8Bit is
    Port
    (
        InputA : in  BIT_VECTOR(7 downto 0); -- 1st 8-bit input value
        InputB : in  BIT_VECTOR(7 downto 0); -- 2nd 8-bit input value
        Output : out BIT_VECTOR(7 downto 0)  -- 8-bit output value
    );
end component And8Bit;

component Or8Bit is
    Port
    (
        InputA : in  BIT_VECTOR(7 downto 0); -- 1st 8-bit input value
        InputB : in  BIT_VECTOR(7 downto 0); -- 2nd 8-bit input value
        Output : out BIT_VECTOR(7 downto 0)  -- 8-bit output value
    );
end component Or8Bit;

component Xor8Bit is
    Port
    (
        InputA : in  BIT_VECTOR(7 downto 0); -- 1st 8-bit input value
        InputB : in  BIT_VECTOR(7 downto 0); -- 2nd 8-bit input value
        Output : out BIT_VECTOR(7 downto 0)  -- 8-bit output value
    );
end component Xor8Bit;

component Not8Bit is
    Port
    (
        Input : in  BIT_VECTOR(7 downto 0); -- 1st 8-bit input value
        Output : out BIT_VECTOR(7 downto 0)  -- 8-bit output value
    );
end component Not8Bit;

component SHL8Bit is
    Port
    (
        Input  : in  BIT_VECTOR(7 downto 0);  -- 8-bit input value
        Output : out BIT_VECTOR(7 downto 0);  -- 8-bit output value
        Cout   : out BIT                      -- Carry-out flag
    );
end component SHL8Bit;

component RCL8Bit is
    Port
    (
        Input  : in  BIT_VECTOR(7 downto 0);  -- 8-bit input value
        Cin    : in BIT;                      -- Carry-in flag
        Output : out BIT_VECTOR(7 downto 0);  -- 8-bit output value
        Cout   : out BIT                      -- Carry-out flag
    );
end component RCL8Bit;

component SHR8Bit is
    Port
    (
        Input  : in  BIT_VECTOR(7 downto 0);  -- 8-bit input value
        Output : out BIT_VECTOR(7 downto 0);  -- 8-bit output value
        Cout   : out BIT                      -- Carry-out flag
    );
end component SHR8Bit;

component SAR8Bit is
    Port
    (
        Input  : in  BIT_VECTOR(7 downto 0);  -- 8-bit input value
        Output : out BIT_VECTOR(7 downto 0);  -- 8-bit output value
        Cout   : out BIT                      -- Carry-out flag
    );
end component SAR8Bit;

component RCR8Bit is
    Port
    (
        Input  : in  BIT_VECTOR(7 downto 0);  -- 8-bit input value
        Cin    : in BIT;                      -- Carry-in flag
        Output : out BIT_VECTOR(7 downto 0);  -- 8-bit output value
        Cout   : out BIT                      -- Carry-out flag
    );
end component RCR8Bit;

component Neg8Bit is
    Port
    (
        Input : in  BIT_VECTOR(7 downto 0);  -- 8-bit input value
        Output : out BIT_VECTOR(7 downto 0)  -- 8-bit output value
    );
end component Neg8Bit;

component MOV8 is
    Port
    (
        InputA : in  BIT_VECTOR(7 downto 0); -- 1st 8-bit input value
        InputB : in  BIT_VECTOR(7 downto 0); -- 2nd 8-bit input value
        Output : out BIT_VECTOR(7 downto 0)  -- 8-bit output value
    );
end component MOV8;

component EnableCircuit is
    Port
    (
        Input  : in  BIT_VECTOR(7 downto 0); -- 8-bit input value
        Enable : in  BIT;                    -- Should be input value returned?
        Output : out BIT_VECTOR(7 downto 0)  -- 8-bit output value
    );
end component EnableCircuit;

component Decoder4To16 is
    Port
    (
        F : in BIT_VECTOR(3 downto 0);   -- 4-Bit Function Code (Input)
        X : out BIT_VECTOR(15 downto 0)  -- 16-Bit State (Output)
    );
end component Decoder4To16;

signal OutputADD : BIT_VECTOR(7 downto 0);
signal OutputAND : BIT_VECTOR(7 downto 0);
signal OutputOR  : BIT_VECTOR(7 downto 0);
signal OutputXOR : BIT_VECTOR(7 downto 0);
signal OutputNOT : BIT_VECTOR(7 downto 0);
signal OutputSHL : BIT_VECTOR(7 downto 0);
signal OutputADC : BIT_VECTOR(7 downto 0);
signal OutputSUB : BIT_VECTOR(7 downto 0);
signal OutputNEG : BIT_VECTOR(7 downto 0);
signal OutputSBB : BIT_VECTOR(7 downto 0);
signal OutputRCL : BIT_VECTOR(7 downto 0);
signal OutputSHR : BIT_VECTOR(7 downto 0);
signal OutputSAR : BIT_VECTOR(7 downto 0);
signal OutputRCR : BIT_VECTOR(7 downto 0);
signal OutputMOV8 : BIT_VECTOR(7 downto 0);
signal OutputEnabledADD : BIT_VECTOR(7 downto 0);
signal OutputEnabledAND : BIT_VECTOR(7 downto 0);
signal OutputEnabledOR  : BIT_VECTOR(7 downto 0);
signal OutputEnabledXOR : BIT_VECTOR(7 downto 0);
signal OutputEnabledNOT : BIT_VECTOR(7 downto 0);
signal OutputEnabledSHL : BIT_VECTOR(7 downto 0);
signal OutputEnabledADC : BIT_VECTOR(7 downto 0);
signal OutputEnabledSUB : BIT_VECTOR(7 downto 0);
signal OutputEnabledNEG : BIT_VECTOR(7 downto 0);
signal OutputEnabledSBB : BIT_VECTOR(7 downto 0);
signal OutputEnabledRCL : BIT_VECTOR(7 downto 0);
signal OutputEnabledSHR : BIT_VECTOR(7 downto 0);
signal OutputEnabledSAR : BIT_VECTOR(7 downto 0);
signal OutputEnabledRCR : BIT_VECTOR(7 downto 0);
signal OutputEnabledMOV8 : BIT_VECTOR(7 downto 0);
signal OutputLocal: BIT_VECTOR(7 downto 0);
signal ControlLines: BIT_VECTOR(15 downto 0);
signal CarryLocalADD: BIT;
signal CarryLocalADC: BIT;
signal CarryLocalSUB: BIT;
signal CarryLocalSBB: BIT;
signal CarryLocalSHL: BIT;
signal CarryLocalRCL: BIT;
signal CarryLocalSHR: BIT;
signal CarryLocalSAR: BIT;
signal CarryLocalRCR: BIT;
signal CarrySUB: BIT;
signal Overflow_ADD: BIT;
signal Overflow_ADC: BIT;
signal Overflow_SUB: BIT;
signal Overflow_SBB: BIT;

signal TwoComplementForSBB : BIT_VECTOR(7 downto 0);
signal InputBPlusCarryForSBB : BIT_VECTOR(7 downto 0);
signal CarryForSBB : BIT_VECTOR(7 downto 0);

begin
    -- Decide which ALU operation is currently running
    Decoder: Decoder4to16 port map(FunctionCode, ControlLines);

    -- Perform the individual ALU operations concurrently
    XOR_Impl: Xor8Bit port map(InputA, InputB, OutputXOR);
    OR_Impl: Or8Bit port map(InputA, InputB, OutputOR);
    AND_Impl: And8Bit port map(InputA, InputB, OutputAND);
    ADD_Impl: RippleCarryAdder8Bit port map (InputA, InputB, '0', OutputADD, CarryLocalADD);
    NOT_Impl: Not8Bit port map(InputA, OutputNOT);
    SHL_Impl: SHL8Bit port map(InputA, OutputSHL, CarryLocalSHL);
    ADC_Impl: RippleCarryAdder8Bit port map (InputA, InputB, CarryIn, OutputADC, CarryLocalADC);
    SUB_Impl: RippleCarryAdder8Bit port map (InputA, not(InputB), '1', OutputSUB, CarryLocalSUB);
    NEG_Impl: Neg8Bit port map(InputA, OutputNEG);
    RCL_Impl: RCL8Bit port map(InputA, CarryIn, OutputRCL, CarryLocalRCL);
    SHR_Impl: SHR8Bit port map(InputA, OutputSHR, CarryLocalSHR);
    SAR_Impl: SAR8Bit port map(InputA, OutputSAR, CarryLocalSAR);
    RCR_Impl: RCR8Bit port map(InputA, CarryIn, OutputRCR, CarryLocalRCR);
    MOV8_Impl: MOV8 port map(InputA, InputB, OutputMOV8);
    
    -- SBB implementation:
    -- => In the 1st step the Carry flag is added to InputB
    -- => In the 2nd step the RippleCarryAdder performs the SUB operation by converting InputB to the Two-Complement (NOT + 1)
    CarryForSBB(0) <= CarryIn;
    CarryForSBB(7 downto 1) <= "0000000";
    ADD_For_SBB_Impl: RippleCarryAdder8Bit port map (InputB, CarryForSBB, '0', InputBPlusCarryForSBB);
    SBB_Impl: RippleCarryAdder8Bit port map (InputA, not(InputBPlusCarryForSBB), '1', OutputSBB, CarryLocalSBB);

    -- Output only the ALU operation that is currently running
    EnableXOR: EnableCircuit port map(OutputXOR, ControlLines(1), OutputEnabledXOR);
    EnableOR:  EnableCircuit port map(OutputOR,  ControlLines(2), OutputEnabledOR);
    EnableAND: EnableCircuit port map(OutputAND, ControlLines(3), OutputEnabledAND);
    EnableADD: EnableCircuit port map(OutputADD, ControlLines(4), OutputEnabledADD);
    EnableNOT: EnableCircuit port map(OutputNOT, ControlLines(5), OutputEnabledNOT);
    EnableSHL: EnableCircuit port map(OutputSHL, ControlLines(6), OutputEnabledSHL);
    EnableADC: EnableCircuit port map(OutputADC, ControlLines(7), OutputEnabledADC);
    EnableSUB: EnableCircuit port map(OutputSUB, ControlLines(8), OutputEnabledSUB);
    EnableNEG: EnableCircuit port map(OutputNEG, ControlLines(9), OutputEnabledNEG);
    EnableSBB: EnableCircuit port map(OutputSBB, ControlLines(10), OutputEnabledSBB);
    EnableRCL: EnableCircuit port map(OutputRCL, ControlLines(11), OutputEnabledRCL);
    EnableSHR: EnableCircuit port map(OutputSHR, ControlLines(12), OutputEnabledSHR);
    EnableSAR: EnableCircuit port map(OutputSAR, ControlLines(13), OutputEnabledSAR);
    EnableRCR: EnableCircuit port map(OutputRCR, ControlLines(14), OutputEnabledRCR);
    EnableMOV8: EnableCircuit port map(OutputMOV8, ControlLines(15), OutputEnabledMOV8);
    
    -- Returns the final output of the ALU
    OutputLocal <= OutputEnabledXOR or 
                   OutputEnabledOR or 
                   OutputEnabledAND or 
                   OutputEnabledADD or 
                   OutputEnabledNOT or 
                   OutputEnabledSHL or
                   OutputEnabledADC or
                   OutputEnabledSUB or
                   OutputEnabledNEG or
                   OutputEnabledSBB or
                   OutputEnabledRCL or
                   OutputEnabledSHR or
                   OutputEnabledSAR or
                   OutputEnabledRCR or
                   OutputEnabledMOV8;
    Output <= OutputLocal;
    
    -- Returns the Sign flag
    Sign <= OutputLocal(7) and not(ControlLines(0));
    
    -- Returns the Zero flag
    Zero <= not(
                OutputLocal(0) or 
                OutputLocal(1) or 
                OutputLocal(2) or 
                OutputLocal(3) or 
                OutputLocal(4) or 
                OutputLocal(5) or 
                OutputLocal(6) or 
                OutputLocal(7)
             ) and not(ControlLines(0));
    
    -- Returns the Carry flag
    Carry <= (CarryLocalADD and ControlLines(4)) or         -- ADD
             (CarryLocalADC and ControlLines(7)) or         -- ADC
             (not(CarryLocalSUB) and ControlLines(8)) or    -- SUB
             (not(CarryLocalSBB) and ControlLines(10))or    -- SBB
             (CarryLocalSHL and ControlLines(6)) or         -- SHL
             (CarryLocalRCL and ControlLines(11)) or        -- RCL
             (CarryLocalSHR and ControlLines(12)) or        -- SHR
             (CarryLocalSAR and ControlLines(13)) or        -- SAR
             (CarryLocalRCR and ControlLines(14));          -- RCR
     
    -- Calculates the overflow flag for the ADD operation
    Overflow_ADD <= (Not(InputA(7)) and not(InputB(7)) and OutputADD(7)) or
                    (InputA(7) and InputB(7) and not(OutputADD(7)));
     
    -- Calculates the overflow flag for the ADC operation
    Overflow_ADC <= (Not(InputA(7)) and not(InputB(7)) and OutputADC(7)) or
                    (InputA(7) and InputB(7) and not(OutputADC(7)));
     
    -- Calculates the overflow flag for the SUB operation
    Overflow_SUB <= (Not(InputA(7)) and InputB(7) and OutputSUB(7)) or
                    (InputA(7) and not(InputB(7)) and not(OutputSUB(7)));
                    
    -- Calculates the overflow flag for the SBB operation
    Overflow_SBB <= (Not(InputA(7)) and InputB(7) and OutputSBB(7)) or
                    (InputA(7) and not(InputB(7)) and not(OutputSBB(7)));
     
    -- Returns the Overflow flag                
    Overflow <= (Overflow_ADD and ControlLines(4)) or
                (Overflow_ADC and ControlLines(7)) or
                (Overflow_SUB and ControlLines(8)) or
                (Overflow_SBB and ControlLines(10));
end Behavioral;
