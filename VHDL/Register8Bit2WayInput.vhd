----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/28/2015 07:47:14 PM
-- Design Name: 
-- Module Name: Register8Bit2WayInput - Behavioral
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

entity Register8Bit2WayInput is
    Port
    (
        Load1   : in BIT;                     -- Load Line #1
        Load2   : in BIT;                     -- Load Line #2
        Sel     : in BIT;                     -- Select Line
        Input1  : in  BIT_VECTOR(7 downto 0); -- 8-bit input value #1
        Input2  : in  BIT_VECTOR(7 downto 0); -- 8-bit input value #2
        Output  : out BIT_VECTOR(7 downto 0); -- 8-bit output value
        State   : out BIT_VECTOR(7 downto 0)  -- Current state of the Flip Flop
    );
end Register8Bit2WayInput;

architecture Behavioral of Register8Bit2WayInput is
    component FlipFlop1Bit2WayInput is
    Port 
        (
            Load1 :   in BIT;     -- Load Line #1
            Load2 :   in BIT;     -- Load Line #2
            Sel  :    in BIT;     -- Select Line
            Input1 :  in BIT;     -- Input Data #1
            Input2 :  in BIT;     -- Input Data #2
            Output : out BIT;     -- Output Data
            State  :  out BIT     -- Current state of the Flip Flop
        );
    end component FlipFlop1Bit2WayInput;
begin
    b0: FlipFlop1Bit2WayInput port map (Load1, Load2, Sel, Input1(0), Input2(0), Output(0), State(0));
    b1: FlipFlop1Bit2WayInput port map (Load1, Load2, Sel, Input1(1), Input2(1), Output(1) ,State(1));
    b2: FlipFlop1Bit2WayInput port map (Load1, Load2, Sel, Input1(2), Input2(2), Output(2), State(2));
    b3: FlipFlop1Bit2WayInput port map (Load1, Load2, Sel, Input1(3), Input2(3), Output(3), State(3));
    b4: FlipFlop1Bit2WayInput port map (Load1, Load2, Sel, Input1(4), Input2(4), Output(4), State(4));
    b5: FlipFlop1Bit2WayInput port map (Load1, Load2, Sel, Input1(5), Input2(5), Output(5), State(5));
    b6: FlipFlop1Bit2WayInput port map (Load1, Load2, Sel, Input1(6), Input2(6), Output(6), State(6));
    b7: FlipFlop1Bit2WayInput port map (Load1, Load2, Sel, Input1(7), Input2(7), Output(7), State(7));
end Behavioral;
