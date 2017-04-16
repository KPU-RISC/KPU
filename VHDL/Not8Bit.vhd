----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/20/2015 05:45:05 PM
-- Design Name: 
-- Module Name: Not8Bit - Behavioral
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

entity Not8Bit is
    Port
    (
        Input : in  BIT_VECTOR(7 downto 0); -- 1st 8-bit input value
        Output : out BIT_VECTOR(7 downto 0)  -- 8-bit output value
    );
end Not8Bit;

architecture Behavioral of Not8Bit is

begin
    Output(0) <= not Input(0);
    Output(1) <= not Input(1);
    Output(2) <= not Input(2);
    Output(3) <= not Input(3);
    Output(4) <= not Input(4);
    Output(5) <= not Input(5);
    Output(6) <= not Input(6);
    Output(7) <= not Input(7);
end Behavioral;
