----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 07/17/2015 05:17:03 PM
-- Design Name: 
-- Module Name: MOV8 - Behavioral
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

entity MOV8 is
    Port
    (
        InputA : in  BIT_VECTOR(7 downto 0); -- 1st 8-bit input value
        InputB : in  BIT_VECTOR(7 downto 0); -- 2nd 8-bit input value
        Output : out BIT_VECTOR(7 downto 0)  -- 8-bit output value
    );
end MOV8;

architecture Behavioral of MOV8 is

component SHL8Bit is
    Port
    (
        Input  : in  BIT_VECTOR(7 downto 0);  -- 8-bit input value
        Output : out BIT_VECTOR(7 downto 0);  -- 8-bit output value
        Cout   : out BIT                      -- Carry-out flag
    );
end component SHL8Bit;

signal OutputSHL1 : BIT_VECTOR(7 downto 0);
signal OutputSHL2 : BIT_VECTOR(7 downto 0);
signal OutputSHL3 : BIT_VECTOR(7 downto 0);
signal OutputSHL4 : BIT_VECTOR(7 downto 0);

begin
    -- Shift InputA 4 bits to the left
    SHL_Impl1: SHL8Bit port map(InputA, OutputSHL1);
    SHL_Impl2: SHL8Bit port map(OutputSHL1, OutputSHL2);
    SHL_Impl3: SHL8Bit port map(OutputSHL2, OutputSHL3);
    SHL_Impl4: SHL8Bit port map(OutputSHL3, OutputSHL4);
    
    Output <= OutputSHL4 or InputB;
end Behavioral;
