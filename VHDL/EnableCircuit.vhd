----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/20/2015 06:01:15 PM
-- Design Name: 
-- Module Name: EnableCircuit - Behavioral
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

entity EnableCircuit is
    Port
    (
        Input  : in  BIT_VECTOR(7 downto 0); -- 8-bit input value
        Enable : in  BIT;                    -- Should be input value returned?
        Output : out BIT_VECTOR(7 downto 0)  -- 8-bit output value
    );
end EnableCircuit;

architecture Behavioral of EnableCircuit is

begin
    Output(0) <= Input(0) and Enable;
    Output(1) <= Input(1) and Enable;
    Output(2) <= Input(2) and Enable;
    Output(3) <= Input(3) and Enable;
    Output(4) <= Input(4) and Enable;
    Output(5) <= Input(5) and Enable;
    Output(6) <= Input(6) and Enable;
    Output(7) <= Input(7) and Enable;
end Behavioral;
