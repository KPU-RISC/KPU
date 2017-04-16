----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/18/2015 09:50:55 PM
-- Design Name: 
-- Module Name: RippleCarryAdder8Bit - Behavioral
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

entity RippleCarryAdder8Bit is
    Port
    (
        InputA : in  BIT_VECTOR(7 downto 0); -- 1st 8-bit input value
        InputB : in  BIT_VECTOR(7 downto 0); -- 2nd 8-bit input value
        Cin    : in  BIT;                    -- Carry-in flag
        Output : out BIT_VECTOR(7 downto 0); -- 8-bit output value
        Cout   : out BIT                     -- Carry-out flag
    ); 
end RippleCarryAdder8Bit;

architecture Behavioral of RippleCarryAdder8Bit is

component FullAdder is
    Port 
    (
           A    : in  BIT;  -- 1st bit to sum up
           B    : in  BIT;  -- 2nd bit to sum up
           Cin  : in  BIT;  -- Carry-in for sum up
           S    : out BIT;  -- Sum of both bits
           Cout : out BIT   -- Carry-out for sum up
     );
end component FullAdder;

signal CarryOut0 : BIT;
signal CarryOut1 : BIT;
signal CarryOut2 : BIT;
signal CarryOut3 : BIT;
signal CarryOut4 : BIT;
signal CarryOut5 : BIT;
signal CarryOut6 : BIT;
signal CarryOut7 : BIT;

begin
    adder0: FullAdder port map (InputA(0), InputB(0), Cin, Output(0), CarryOut0);
    adder1: FullAdder port map (InputA(1), InputB(1), CarryOut0, Output(1), CarryOut1);
    adder2: FullAdder port map (InputA(2), InputB(2), CarryOut1, Output(2), CarryOut2);
    adder3: FullAdder port map (InputA(3), InputB(3), CarryOut2, Output(3), CarryOut3);
    adder4: FullAdder port map (InputA(4), InputB(4), CarryOut3, Output(4), CarryOut4);
    adder5: FullAdder port map (InputA(5), InputB(5), CarryOut4, Output(5), CarryOut5);
    adder6: FullAdder port map (InputA(6), InputB(6), CarryOut5, Output(6), CarryOut6);
    adder7: FullAdder port map (InputA(7), InputB(7), CarryOut6, Output(7), CarryOut7);
    
    Cout <= CarryOut7;
end Behavioral;
