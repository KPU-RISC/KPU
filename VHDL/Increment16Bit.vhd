----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 06/07/2015 10:17:42 PM
-- Design Name: 
-- Module Name: Increment16Bit - Behavioral
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

entity Increment16Bit is
    Port
    (
        Input  : in  BIT_VECTOR(15 downto 0); -- 8-bit input value
        Cin    : in  BIT;                     -- Carry-in flag
        Output : out BIT_VECTOR(15 downto 0); -- 8-bit output value
        Cout   : out BIT                      -- Carry-out flag
    );
end Increment16Bit;

architecture Behavioral of Increment16Bit is

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

signal Carry1 : BIT;

begin
    INC_Impl1: RippleCarryAdder8Bit port map (Input(7 downto 0), "00000001", '0', Output(7 downto 0), Carry1);
    INC_Impl2: RippleCarryAdder8Bit port map (Input(15 downto 8), "00000000", Carry1, Output(15 downto 8), Cout);    
end Behavioral;
