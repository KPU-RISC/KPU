----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/20/2015 05:14:55 PM
-- Design Name: 
-- Module Name: And8Bit - Behavioral
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

entity And8Bit is
    Port
    (
        InputA : in  BIT_VECTOR(7 downto 0); -- 1st 8-bit input value
        InputB : in  BIT_VECTOR(7 downto 0); -- 2nd 8-bit input value
        Output : out BIT_VECTOR(7 downto 0)  -- 8-bit output value
    );
end And8Bit;

architecture Behavioral of And8Bit is

begin
    Output(0) <= InputA(0) and InputB(0);
    Output(1) <= InputA(1) and InputB(1);
    Output(2) <= InputA(2) and InputB(2);
    Output(3) <= InputA(3) and InputB(3);
    Output(4) <= InputA(4) and InputB(4);
    Output(5) <= InputA(5) and InputB(5);
    Output(6) <= InputA(6) and InputB(6);
    Output(7) <= InputA(7) and InputB(7);
end Behavioral;
