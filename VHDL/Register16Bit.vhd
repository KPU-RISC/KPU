----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/20/2015 09:38:41 PM
-- Design Name: 
-- Module Name: Register16Bit - Behavioral
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

entity Register16Bit is
    Port
    (
        Load   : in  BIT;                     -- Load Line
        Sel    : in  BIT;                     -- Select Line
        Input  : in  BIT_VECTOR(15 downto 0); -- 16-bit input value
        Output : out BIT_VECTOR(15 downto 0); -- 16-bit output value
        State  : out BIT_VECTOR(15 downto 0)  -- Current state of the Flip Flop
    );
end Register16Bit;

architecture Behavioral of Register16Bit is

component Register8Bit is
    Port
    (
        Load   : in  BIT;                    -- Load Line
        Sel    : in  BIT;                    -- Select Line
        Input  : in  BIT_VECTOR(7 downto 0); -- 8-bit input value
        Output : out BIT_VECTOR(7 downto 0); -- 8-bit output value
        State  : out BIT_VECTOR(7 downto 0)  -- Current state of the Flip Flop
    );
end component Register8Bit;

begin
    r0: Register8Bit port map (Load, Sel, Input(7 downto 0), Output(7 downto 0), State(7 downto 0));
    r1: Register8Bit port map (Load, Sel, Input(15 downto 8), Output(15 downto 8), State(15 downto 8));

end Behavioral;
