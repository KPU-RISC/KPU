----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/18/2015 03:48:13 PM
-- Design Name: 
-- Module Name: Register8Bit - Behavioral
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

entity Register8Bit is
    Port
    (
        Load   : in  BIT;                    -- Load Line
        Sel    : in  BIT;                    -- Select Line
        Input  : in  BIT_VECTOR(7 downto 0); -- 8-bit input value
        Output : out BIT_VECTOR(7 downto 0); -- 8-bit output value
        State  : out BIT_VECTOR(7 downto 0)  -- Current state of the Flip Flop
    ); 
end Register8Bit;

architecture Behavioral of Register8Bit is

component FlipFlop1Bit is
    Port
    (
        Load :   in BIT;     -- Load Line
        Sel :    in BIT;     -- Select Line
        Input :  in BIT;     -- Input Data
        Output : out BIT;    -- Output Data
        State  : out BIT     -- Current state of the Flip Flop
    );
end component FlipFlop1Bit;

begin
    b0: FlipFlop1Bit port map (Load, Sel, Input(0), Output(0), State(0));
    b1: FlipFlop1Bit port map (Load, Sel, Input(1), Output(1), State(1));
    b2: FlipFlop1Bit port map (Load, Sel, Input(2), Output(2), State(2));
    b3: FlipFlop1Bit port map (Load, Sel, Input(3), Output(3), State(3));
    b4: FlipFlop1Bit port map (Load, Sel, Input(4), Output(4), State(4));
    b5: FlipFlop1Bit port map (Load, Sel, Input(5), Output(5), State(5));
    b6: FlipFlop1Bit port map (Load, Sel, Input(6), Output(6), State(6));
    b7: FlipFlop1Bit port map (Load, Sel, Input(7), Output(7), State(7));

end Behavioral;
