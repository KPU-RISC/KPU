----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/20/2015 10:16:50 PM
-- Design Name: 
-- Module Name: Counter4Bit - Behavioral
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
use IEEE.STD_LOGIC_ARITH.ALL;

-- Uncomment the following library declaration if using
-- arithmetic functions with Signed or Unsigned values
--use IEEE.NUMERIC_STD.ALL;

-- Uncomment the following library declaration if instantiating
-- any Xilinx leaf cells in this code.
--library UNISIM;
--use UNISIM.VComponents.all;

entity Counter4Bit is
    port
    (
        Clock : in BIT;
        Reset : in BIT;
        Output: out STD_LOGIC_VECTOR(3 downto 0)
    );
end Counter4Bit;

architecture Behavioral of Counter4Bit is

signal temp: STD_LOGIC_VECTOR(3 downto 0) := "0000";

begin
     main: process (Clock, Reset)
     begin
         if (Reset = '1') then
            temp <= "0000";
         else if (Clock'event and Clock = '1') then
            temp <= UNSIGNED(temp) + 1;
         end if;
         end if;
         
         Output <= temp;
    end process;
end Behavioral;
