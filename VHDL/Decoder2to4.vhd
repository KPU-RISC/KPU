----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/21/2015 12:33:51 PM
-- Design Name: 
-- Module Name: Decoder2to4 - Behavioral
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

entity Decoder2to4 is
    Port
    (
        A : in BIT_VECTOR(1 downto 0); -- 2-Bit Memory Address (Input)
        X : out BIT_VECTOR(3 downto 0) -- 4-Bit Address Lines (Output)
    );
end Decoder2to4;

architecture Behavioral of Decoder2to4 is

begin
    -- 00
    X(0) <= not(A(0)) and not(A(1));
    
    -- 01
    X(1) <= A(0) and not (A(1));
    
    -- 10
    X(2) <= not(A(0)) and A(1);
    
    -- 11
    X(3) <= A(0) and A(1);

end Behavioral;
