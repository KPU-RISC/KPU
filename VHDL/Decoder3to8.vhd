----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/17/2015 08:25:09 PM
-- Design Name: 
-- Module Name: Decoder3to8 - Behavioral
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

entity Decoder3to8 is
    Port
    (
        F : in BIT_VECTOR(2 downto 0);   -- 3-Bit Function Code (Input)
        X : out BIT_VECTOR(7 downto 0);  -- 8-Bit State (Output)
        Started: in BIT                  -- Is the CPU already running?
    ); 
end Decoder3to8;

architecture Behavioral of Decoder3to8 is

begin
    -- 000
    X(0) <= not(F(0)) and not(F(1)) and not (F(2)) and Started after 1 ns;
    
    -- 001
    X(1) <= F(0) and not (F(1)) and not (F(2)) and Started after 1 ns;
    
    -- 010
    X(2) <= not(F(0)) and F(1) and not (F(2)) and Started after 1 ns;
    
    -- 011
    X(3) <= F(0) and F(1) and not (F(2)) and Started after 1 ns;
   
    -- 100
    X(4) <= not(F(0)) and not(F(1)) and F(2) and Started after 1 ns;
    
    -- 101
    X(5) <= F(0) and not(F(1)) and F(2) and Started after 1 ns;
    
    -- 110
    X(6) <= not(F(0)) and F(1) and F(2) and Started after 1 ns;
    
    -- 111
    X(7) <= F(0) and F(1) and F(2) and Started after 1 ns;
end Behavioral;