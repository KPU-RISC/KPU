----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 06/12/2015 08:52:54 PM
-- Design Name: 
-- Module Name: RAM_Wrapper - Behavioral
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

entity RAM_Wrapper is
    port
    (
        Clock:      IN BIT;
        Load:       IN BIT;
        Sel:        IN BIT;     -- Requests the data from the RAM
        Ret:        IN BIT;     -- Returns the data from the RAM and places it onto the data bus
        Address:    IN BIT_VECTOR(15 DOWNTO 0);
        Input:      IN BIT_VECTOR(7 DOWNTO 0);
        Output:     OUT BIT_VECTOR(7 DOWNTO 0)
    );
end RAM_Wrapper;

architecture Behavioral of RAM_Wrapper is

component RAM64K is
  port (
    clka : IN STD_LOGIC;
    ena : IN STD_LOGIC;
    wea : IN STD_LOGIC_VECTOR(0 DOWNTO 0);
    addra : IN STD_LOGIC_VECTOR(15 DOWNTO 0);
    dina : IN STD_LOGIC_VECTOR(7 DOWNTO 0);
    douta : OUT STD_LOGIC_VECTOR(7 DOWNTO 0)
  );
end component RAM64K;

signal Load_Vector:  STD_LOGIC_VECTOR(0 downto 0);
signal Output_Temp:  STD_LOGIC_VECTOR(7 DOWNTO 0);
signal Output_Local: BIT_VECTOR(7 DOWNTO 0);

function TO_STD_LOGIC(L: BIT) return STD_LOGIC is
begin
    if L = '1' then
        return('1');
    else
        return('0');
    end if;
end function To_Std_Logic;

begin
    Load_Vector(0) <= TO_STD_LOGIC(Load);
    Output_Local <= TO_BITVECTOR(Output_Temp);
    
    -- We only return the output if the Select-Line is high
    Output(0) <= Output_Local(0) and Sel and Ret;
    Output(1) <= Output_Local(1) and Sel and Ret;
    Output(2) <= Output_Local(2) and Sel and Ret;
    Output(3) <= Output_Local(3) and Sel and Ret;
    Output(4) <= Output_Local(4) and Sel and Ret;
    Output(5) <= Output_Local(5) and Sel and Ret;
    Output(6) <= Output_Local(6) and Sel and Ret;
    Output(7) <= Output_Local(7) and Sel and Ret;
    
    ram: RAM64K port map (
        TO_STD_LOGIC(Clock), 
        TO_STD_LOGIC(Load or Sel), 
        Load_Vector, 
        To_StdLogicVector(Address), 
        To_StdLogicVector(Input), 
        Output_Temp);
end Behavioral;
