----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/18/2015 08:51:04 PM
-- Design Name: 
-- Module Name: FullAdder - Behavioral
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

entity FullAdder is
    Port 
    (
           A    : in  BIT;  -- 1st bit to sum up
           B    : in  BIT;  -- 2nd bit to sum up
           Cin  : in  BIT;  -- Carry-in for sum up
           S    : out BIT;  -- Sum of both bits
           Cout : out BIT   -- Carry-out for sum up
     );
end FullAdder;

architecture Behavioral of FullAdder is

component HalfAdder is
    Port
    (
        A : in BIT;     -- 1st bit to sum up
        B : in BIT;     -- 2nd bit to sum up
        S : out BIT;    -- Sum of both bits
        C : out BIT     -- Carry flag
     );
end component HalfAdder;

signal SumHalfAdder1 : BIT;
signal CarryHalfAdder1 : BIT;
signal CarryHalfAdder2 : BIT;

begin
    HalfAdder1: HalfAdder port map (A, B, SumHalfAdder1, CarryHalfAdder1);
    HalfAdder2: HalfAdder port map (SumHalfAdder1, Cin, S, CarryHalfAdder2);
    Cout <= CarryHalfAdder2 or CarryHalfAdder1;
end Behavioral;
