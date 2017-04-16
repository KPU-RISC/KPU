----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 07/14/2015 04:50:10 PM
-- Design Name: 
-- Module Name: Decoder4To16 - Behavioral
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

entity Decoder4To16 is
    Port
    (
        F : in BIT_VECTOR(3 downto 0);   -- 4-Bit Function Code (Input)
        X : out BIT_VECTOR(15 downto 0)  -- 16-Bit State (Output)
    );
end Decoder4To16;

architecture Behavioral of Decoder4To16 is

begin
    -- 0000
    X(0) <= not(F(0)) and not(F(1)) and not (F(2)) and not(F(3)) after 1 ns;
    
    -- 0001
    X(1) <= F(0) and not (F(1)) and not (F(2)) and not(F(3)) after 1 ns;
    
    -- 0010
    X(2) <= not(F(0)) and F(1) and not (F(2)) and not(F(3)) after 1 ns;
    
    -- 0011
    X(3) <= F(0) and F(1) and not (F(2)) and not(F(3)) after 1 ns;
   
    -- 0100
    X(4) <= not(F(0)) and not(F(1)) and F(2) and not(F(3)) after 1 ns;
    
    -- 0101
    X(5) <= F(0) and not(F(1)) and F(2) and not(F(3)) after 1 ns;
    
    -- 0110
    X(6) <= not(F(0)) and F(1) and F(2) and not(F(3)) after 1 ns;
    
    -- 0111
    X(7) <= F(0) and F(1) and F(2) and not(F(3)) after 1 ns;
    
    -- 1000
    X(8) <= not(F(0)) and not(F(1)) and not(F(2)) and F(3) after 1 ns;
    
    -- 1001
    X(9) <= F(0) and not(F(1)) and not(F(2)) and F(3) after 1 ns;
    
    -- 1010
    X(10) <= not(F(0)) and F(1) and not(F(2)) and F(3) after 1 ns;
    
    -- 1011
    X(11) <= F(0) and F(1) and not(F(2)) and F(3) after 1 ns;
    
    -- 1100
    X(12) <= not(F(0)) and not(F(1)) and F(2) and F(3) after 1 ns;
    
    -- 1101
    X(13) <= F(0) and not(F(1)) and F(2) and F(3) after 1 ns;
    
    -- 1110
    X(14) <= not(F(0)) and F(1) and F(2) and F(3) after 1 ns;
    
    -- 1111
    X(15) <= F(0) and F(1) and F(2) and F(3) after 1 ns;
end Behavioral;
