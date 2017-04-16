----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 07/17/2015 12:51:34 PM
-- Design Name: 
-- Module Name: RCL8Bit - Behavioral
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

entity RCL8Bit is
    Port
    (
        Input  : in  BIT_VECTOR(7 downto 0);  -- 8-bit input value
        Cin    : in BIT;                      -- Carry-in flag
        Output : out BIT_VECTOR(7 downto 0);  -- 8-bit output value
        Cout   : out BIT                      -- Carry-out flag
    );
end RCL8Bit;

architecture Behavioral of RCL8Bit is

begin
    Cout <= Input(7);
    Output(0) <= Cin;
    Output(1) <= Input(0);
    Output(2) <= Input(1);
    Output(3) <= Input(2);
    Output(4) <= Input(3);
    Output(5) <= Input(4);
    Output(6) <= Input(5);
    Output(7) <= Input(6);
end Behavioral;
