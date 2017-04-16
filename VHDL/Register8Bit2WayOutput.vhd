----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/24/2015 01:10:26 PM
-- Design Name: 
-- Module Name: Register8Bit2WayOutput - Behavioral
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

entity Register8Bit2WayOutput is
    Port
    (
        Load    : in BIT;                     -- Load Line
        Sel1    : in BIT;                     -- Select Line #1
        Sel2    : in BIT;                     -- Select Line #2
        Input   : in  BIT_VECTOR(7 downto 0); -- 8-bit input value
        Output1 : out BIT_VECTOR(7 downto 0); -- 8-bit output value #1
        Output2 : out BIT_VECTOR(7 downto 0); -- 8-bit output value #2
        State   : out BIT_VECTOR(7 downto 0)  -- Current state of the Flip Flop
    );
end Register8Bit2WayOutput;

architecture Behavioral of Register8Bit2WayOutput is
    component FlipFlop1Bit2WayOutput is
    Port 
    (
        Load :    in BIT;     -- Load Line
        Sel1 :    in BIT;     -- Select Line #1
        Sel2 :    in BIT;     -- Select Line #2
        Input :   in BIT;     -- Input Data
        Output1 : out BIT;    -- Output Data #1
        Output2 : out BIT;    -- OUtput Data #2
        State  :  out BIT     -- Current state of the Flip Flop
    );
    end component FlipFlop1Bit2WayOutput;
begin
    b0: FlipFlop1Bit2WayOutput port map (Load, Sel1, Sel2, Input(0), Output1(0), Output2(0), State(0));
    b1: FlipFlop1Bit2WayOutput port map (Load, Sel1, Sel2, Input(1), Output1(1), Output2(1) ,State(1));
    b2: FlipFlop1Bit2WayOutput port map (Load, Sel1, Sel2, Input(2), Output1(2), Output2(2), State(2));
    b3: FlipFlop1Bit2WayOutput port map (Load, Sel1, Sel2, Input(3), Output1(3), Output2(3), State(3));
    b4: FlipFlop1Bit2WayOutput port map (Load, Sel1, Sel2, Input(4), Output1(4), Output2(4), State(4));
    b5: FlipFlop1Bit2WayOutput port map (Load, Sel1, Sel2, Input(5), Output1(5), Output2(5), State(5));
    b6: FlipFlop1Bit2WayOutput port map (Load, Sel1, Sel2, Input(6), Output1(6), Output2(6), State(6));
    b7: FlipFlop1Bit2WayOutput port map (Load, Sel1, Sel2, Input(7), Output1(7), Output2(7), State(7));
end Behavioral;
