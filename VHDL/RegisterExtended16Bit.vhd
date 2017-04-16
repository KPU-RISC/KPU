----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 06/13/2015 12:36:25 PM
-- Design Name: 
-- Module Name: RegisterExtended16Bit - Behavioral
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

entity RegisterExtended16Bit is
    Port
    (
        Load_8Bit_L:     in BIT;                        -- Load Line #1 (bits 0 - 7)
        Load_8Bit_H:     in BIT;                        -- Load Line #2 (bits 8 - 15)
        Load_16Bit:      in BIT;                        -- Load Line #3 (bits 0 - 15)
        Select_8Bit_L:   in BIT;                        -- Select Line #1 (bits 0 - 7)
        Select_8Bit_H:   in BIT;                        -- Select Line #2 (bits 8 - 15)
        Select_16Bit:    in BIT;                        -- Select Line #3 (bits 0 - 15)
        Input_8Bit_L:    in BIT_VECTOR(7 downto 0);     -- 8-bit input value (bits 0 - 7)
        Input_8Bit_H:    in BIT_VECTOR(7 downto 0);     -- 8-bit input value (bits 8 - 15)
        Input_16Bit:     in BIT_VECTOR(15 downto 0);    -- 16-bit input value (bits 0 - 15)
        Output_8Bit_L:   out BIT_VECTOR(7 downto 0);    -- 8-bit output value (bits 0 - 7)
        Output_8Bit_H:   out BIT_VECTOR(7 downto 0);    -- 8-bit output value (bits 8 - 15)
        Output_16Bit:    out BIT_VECTOR(15 downto 0);   -- 16-bit output value (bits 0 - 15)
        State_8Bit_L:    out BIT_VECTOR(7 downto 0);    -- Current state of the Flip Flop (bits 0 - 7)
        State_8Bit_H:    out BIT_VECTOR(7 downto 0);    -- Current state of the Flip Flop (bits 8 - 15)
        State_16Bit:     out BIT_VECTOR(15 downto 0)    -- Current state of the Flip Flop (bits 0 - 15)
    );
end RegisterExtended16Bit;

architecture Behavioral of RegisterExtended16Bit is

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

signal Load8Bit_Low: BIT;
signal Load8Bit_High: BIT;
signal Select8Bit_Low: BIT;
signal Select8Bit_High: BIT;
signal Input8Bit_Low: BIT_VECTOR(7 downto 0);
signal Input8Bit_High: BIT_VECTOR(7 downto 0);
signal Output8Bit_Low: BIT_VECTOR(7 downto 0);
signal Output8Bit_High: BIT_VECTOR(7 downto 0);
signal State8Bit_Low: BIT_VECTOR(7 downto 0);
signal State8Bit_High: BIT_VECTOR(7 downto 0);
   
begin
    registerLow:  Register8Bit port map (Load8Bit_Low, Select8Bit_Low, Input8Bit_Low, Output8Bit_Low, State8Bit_Low);
    registerHigh: Register8Bit port map (Load8Bit_High, Select8Bit_High, Input8Bit_High, Output8Bit_High, State8Bit_High);
    
    -- Provides the Load-Line flags
    Load8Bit_Low <= Load_16Bit or Load_8Bit_L;
    Load8Bit_High <= Load_16Bit or Load_8Bit_H;
    
    -- Provides the Select-Line flags
    Select8Bit_Low <= Select_16Bit or Select_8Bit_L;
    Select8Bit_High <= Select_16Bit or Select_8Bit_H;
    
    -- Provides the input for bits 0 - 7
    Input8Bit_Low(0) <= (Input_8Bit_L(0) and Load_8Bit_L) or
                        (Input_16Bit(0) and Load_16Bit);
    Input8Bit_Low(1) <= (Input_8Bit_L(1) and Load_8Bit_L) or
                        (Input_16Bit(1) and Load_16Bit);
    Input8Bit_Low(2) <= (Input_8Bit_L(2) and Load_8Bit_L) or
                        (Input_16Bit(2) and Load_16Bit);
    Input8Bit_Low(3) <= (Input_8Bit_L(3) and Load_8Bit_L) or
                        (Input_16Bit(3) and Load_16Bit);
    Input8Bit_Low(4) <= (Input_8Bit_L(4) and Load_8Bit_L) or
                        (Input_16Bit(4) and Load_16Bit);
    Input8Bit_Low(5) <= (Input_8Bit_L(5) and Load_8Bit_L) or
                        (Input_16Bit(5) and Load_16Bit);
    Input8Bit_Low(6) <= (Input_8Bit_L(6) and Load_8Bit_L) or
                        (Input_16Bit(6) and Load_16Bit);
    Input8Bit_Low(7) <= (Input_8Bit_L(7) and Load_8Bit_L) or
                        (Input_16Bit(7) and Load_16Bit);
                        
    -- Provides the input for bits 8 - 15
    Input8Bit_High(0) <= (Input_8Bit_H(0) and Load_8Bit_H) or
                         (Input_16Bit(8) and Load_16Bit);
    Input8Bit_High(1) <= (Input_8Bit_H(1) and Load_8Bit_H) or
                         (Input_16Bit(9) and Load_16Bit);
    Input8Bit_High(2) <= (Input_8Bit_H(2) and Load_8Bit_H) or
                         (Input_16Bit(10) and Load_16Bit);
    Input8Bit_High(3) <= (Input_8Bit_H(3) and Load_8Bit_H) or
                         (Input_16Bit(11) and Load_16Bit);
    Input8Bit_High(4) <= (Input_8Bit_H(4) and Load_8Bit_H) or
                         (Input_16Bit(12) and Load_16Bit);
    Input8Bit_High(5) <= (Input_8Bit_H(5) and Load_8Bit_H) or
                         (Input_16Bit(13) and Load_16Bit);
    Input8Bit_High(6) <= (Input_8Bit_H(6) and Load_8Bit_H) or
                         (Input_16Bit(14) and Load_16Bit);
    Input8Bit_High(7) <= (Input_8Bit_H(7) and Load_8Bit_H) or
                         (Input_16Bit(15) and Load_16Bit);
    
    -- Returns the output for bits 0 - 7 on the data bus
    Output_8Bit_L(0) <= Output8Bit_Low(0) and Select_8Bit_L;
    Output_8Bit_L(1) <= Output8Bit_Low(1) and Select_8Bit_L;
    Output_8Bit_L(2) <= Output8Bit_Low(2) and Select_8Bit_L;
    Output_8Bit_L(3) <= Output8Bit_Low(3) and Select_8Bit_L;
    Output_8Bit_L(4) <= Output8Bit_Low(4) and Select_8Bit_L;
    Output_8Bit_L(5) <= Output8Bit_Low(5) and Select_8Bit_L;
    Output_8Bit_L(6) <= Output8Bit_Low(6) and Select_8Bit_L;
    Output_8Bit_L(7) <= Output8Bit_Low(7) and Select_8Bit_L;
    
    -- Returns the output for bits 8 - 15 on the data bus
    Output_8Bit_H(0) <= Output8Bit_High(0) and Select_8Bit_H;
    Output_8Bit_H(1) <= Output8Bit_High(1) and Select_8Bit_H;
    Output_8Bit_H(2) <= Output8Bit_High(2) and Select_8Bit_H;
    Output_8Bit_H(3) <= Output8Bit_High(3) and Select_8Bit_H;
    Output_8Bit_H(4) <= Output8Bit_High(4) and Select_8Bit_H;
    Output_8Bit_H(5) <= Output8Bit_High(5) and Select_8Bit_H;
    Output_8Bit_H(6) <= Output8Bit_High(6) and Select_8Bit_H;
    Output_8Bit_H(7) <= Output8Bit_High(7) and Select_8Bit_H;
    
    -- Returns the output for bits 0 - 7 on the address bus
    Output_16Bit(0) <= Output8Bit_Low(0) and Select_16Bit;
    Output_16Bit(1) <= Output8Bit_Low(1) and Select_16Bit;
    Output_16Bit(2) <= Output8Bit_Low(2) and Select_16Bit;
    Output_16Bit(3) <= Output8Bit_Low(3) and Select_16Bit;
    Output_16Bit(4) <= Output8Bit_Low(4) and Select_16Bit;
    Output_16Bit(5) <= Output8Bit_Low(5) and Select_16Bit;
    Output_16Bit(6) <= Output8Bit_Low(6) and Select_16Bit;
    Output_16Bit(7) <= Output8Bit_Low(7) and Select_16Bit;
    
    -- Returns the output for bits 8 - 15 on the address bus
    Output_16Bit(8)  <= Output8Bit_High(0) and Select_16Bit;
    Output_16Bit(9)  <= Output8Bit_High(1) and Select_16Bit;
    Output_16Bit(10) <= Output8Bit_High(2) and Select_16Bit;
    Output_16Bit(11) <= Output8Bit_High(3) and Select_16Bit;
    Output_16Bit(12) <= Output8Bit_High(4) and Select_16Bit;
    Output_16Bit(13) <= Output8Bit_High(5) and Select_16Bit;
    Output_16Bit(14) <= Output8Bit_High(6) and Select_16Bit;
    Output_16Bit(15) <= Output8Bit_High(7) and Select_16Bit;
    
    -- Returns the current state
    State_8Bit_L <= State8Bit_Low;
    State_8Bit_H <= State8Bit_High;
    State_16Bit(7 downto 0) <= State8Bit_Low;
    State_16Bit(15 downto 8) <= State8Bit_High;
end Behavioral;