----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/28/2015 07:11:32 PM
-- Design Name: 
-- Module Name: FlipFlop1Bit2WayInput - Behavioral
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

entity FlipFlop1Bit2WayInput is
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
end FlipFlop1Bit2WayInput;

architecture Behavioral of FlipFlop1Bit2WayInput is
    signal Nand1 : BIT;
    signal Nand2 : BIT;
    signal Not1 : BIT;
    signal F1 : BIT;
    signal F2 : BIT;
    
    signal Load: BIT;
    signal Input: BIT;
    
begin
    -- We accept input from 2 inputs 
    Load <= Load1 or Load2;
    Input <= Input1 or Input2;
    
    Nand1 <= not(Load and Input);
    Not1 <= not Input;
    Nand2 <= not(Not1 and Load);
    
    F1 <= not (F2 and Nand1);
    F2 <= not (Nand2 and F1) after 1 ns;
    
    -- Return the internal state for debugging/monitoring purposes
    State <= F1;
    
    Output <= F1 and Sel;
end Behavioral;
