----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/22/2015 08:48:53 PM
-- Design Name: 
-- Module Name: Increment8Bit - Behavioral
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

entity Increment8Bit is
    Port
    (
        Input  : in  BIT_VECTOR(7 downto 0); -- 8-bit input value
        Cin    : in  BIT;                    -- Carry-in flag
        Output : out BIT_VECTOR(7 downto 0); -- 8-bit output value
        Cout   : out BIT                     -- Carry-out flag
    );
end Increment8Bit;

architecture Behavioral of Increment8Bit is

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

begin
    INC_Impl: RippleCarryAdder8Bit port map (Input, "00000001", '0', Output, Cout);
end Behavioral;
