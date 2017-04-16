----------------------------------------------------------------------------------
-- Company: 
-- Engineer: 
-- 
-- Create Date: 05/21/2015 12:17:45 PM
-- Design Name: 
-- Module Name: SRAM16Bytes - Behavioral
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

entity SRAM16Bytes is
    Port
    (
        Load    : in BIT; 
        Sel     : in BIT;
        Address : in BIT_VECTOR(3 downto 0);
        InData  : in BIT_VECTOR(7 downto 0);
        OutData : out BIT_VECTOR(7 downto 0)
    );
end SRAM16Bytes;

architecture Behavioral of SRAM16Bytes is

component Register8Bit is
    Port
    (
        Load   : in  BIT;                    -- Load Line
        Sel    : in  BIT;                    -- Select Line
        Input  : in  BIT_VECTOR(7 downto 0); -- 8-bit input value
        Output : out BIT_VECTOR(7 downto 0)  -- 8-bit output value
    );
end component Register8Bit;

component Decoder2to4 is
    Port
    (
        A : in BIT_VECTOR(1 downto 0); -- 2-Bit Memory Address (Input)
        X : out BIT_VECTOR(3 downto 0) -- 4-Bit Address Lines (Output)
    ); 
end component Decoder2to4;

signal AccessLines1: BIT_VECTOR(3 downto 0);
signal AccessLines2: BIT_VECTOR(3 downto 0);

signal OutData1 :  BIT_VECTOR(7 downto 0);
signal OutData2 :  BIT_VECTOR(7 downto 0);
signal OutData3 :  BIT_VECTOR(7 downto 0);
signal OutData4 :  BIT_VECTOR(7 downto 0);
signal OutData5 :  BIT_VECTOR(7 downto 0);
signal OutData6 :  BIT_VECTOR(7 downto 0);
signal OutData7 :  BIT_VECTOR(7 downto 0);
signal OutData8 :  BIT_VECTOR(7 downto 0);
signal OutData9 :  BIT_VECTOR(7 downto 0);
signal OutData10 : BIT_VECTOR(7 downto 0);
signal OutData11 : BIT_VECTOR(7 downto 0);
signal OutData12 : BIT_VECTOR(7 downto 0);
signal OutData13 : BIT_VECTOR(7 downto 0);
signal OutData14 : BIT_VECTOR(7 downto 0);
signal OutData15 : BIT_VECTOR(7 downto 0);
signal OutData16 : BIT_VECTOR(7 downto 0);

signal LoadLine1:  BIT;
signal LoadLine2:  BIT;
signal LoadLine3:  BIT;
signal LoadLine4:  BIT;
signal LoadLine5:  BIT;
signal LoadLine6:  BIT;
signal LoadLine7:  BIT;
signal LoadLine8:  BIT;
signal LoadLine9:  BIT;
signal LoadLine10: BIT;
signal LoadLine11: BIT;
signal LoadLine12: BIT;
signal LoadLine13: BIT;
signal LoadLine14: BIT;
signal LoadLine15: BIT;
signal LoadLine16: BIT;

signal SelectLine1:  BIT;
signal SelectLine2:  BIT;
signal SelectLine3:  BIT;
signal SelectLine4:  BIT;
signal SelectLine5:  BIT;
signal SelectLine6:  BIT;
signal SelectLine7:  BIT;
signal SelectLine8:  BIT;
signal SelectLine9:  BIT;
signal SelectLine10: BIT;
signal SelectLine11: BIT;
signal SelectLine12: BIT;
signal SelectLine13: BIT;
signal SelectLine14: BIT;
signal SelectLine15: BIT;
signal SelectLine16: BIT;

begin
    -- The 16 8-bit SRAM memory cells are logically arranged in a 4x4 matrix
    -- 1        2       3       4
    -- 5        6       7       8
    -- 9        10      11      12
    -- 13       14      14      16
    
    -- The 1st decoder takes the lower 2 bits of the address and provides the row offset into the 4x4 matrix
    Decoder1: Decoder2to4 port map(Address(1 downto 0), AccessLines1);
    
    -- The 2nd decoder takes the upper 2 bits of the address and provides the column offset into the 4x4 matrix
    Decoder2: Decoder2to4 port map(Address(3 downto 2), AccessLines2);
    
    -- Create a dedicate Load-Line for every 8-bit SRAM memory cell
    LoadLine1 <= Load and AccessLines1(0) and AccessLines2(0);
    LoadLine2 <= Load and AccessLines1(1) and AccessLines2(0);
    LoadLine3 <= Load and AccessLines1(2) and AccessLines2(0);
    LoadLine4 <= Load and AccessLines1(3) and AccessLines2(0);
    
    LoadLine5 <= Load and AccessLines1(0) and AccessLines2(1);
    LoadLine6 <= Load and AccessLines1(1) and AccessLines2(1);
    LoadLine7 <= Load and AccessLines1(2) and AccessLines2(1);
    LoadLine8 <= Load and AccessLines1(3) and AccessLines2(1);
    
    LoadLine9 <= Load and AccessLines1(0) and AccessLines2(2);
    LoadLine10 <= Load and AccessLines1(1) and AccessLines2(2);
    LoadLine11 <= Load and AccessLines1(2) and AccessLines2(2);
    LoadLine12 <= Load and AccessLines1(3) and AccessLines2(2);
    
    LoadLine13 <= Load and AccessLines1(0) and AccessLines2(3);
    LoadLine14 <= Load and AccessLines1(1) and AccessLines2(3);
    LoadLine15 <= Load and AccessLines1(2) and AccessLines2(3);
    LoadLine16 <= Load and AccessLines1(3) and AccessLines2(3);

    -- Create a dedicate Select-Line for every 8-bit SRAM memory cell
    SelectLine1 <= Sel and AccessLines1(0) and AccessLines2(0);
    SelectLine2 <= Sel and AccessLines1(1) and AccessLines2(0);
    SelectLine3 <= Sel and AccessLines1(2) and AccessLines2(0);
    SelectLine4 <= Sel and AccessLines1(3) and AccessLines2(0);

    SelectLine5 <= Sel and AccessLines1(0) and AccessLines2(1);
    SelectLine6 <= Sel and AccessLines1(1) and AccessLines2(1);
    SelectLine7 <= Sel and AccessLines1(2) and AccessLines2(1);
    SelectLine8 <= Sel and AccessLines1(3) and AccessLines2(1);
    
    SelectLine9 <= Sel and AccessLines1(0) and AccessLines2(2);
    SelectLine10 <= Sel and AccessLines1(1) and AccessLines2(2);
    SelectLine11 <= Sel and AccessLines1(2) and AccessLines2(2);
    SelectLine12 <= Sel and AccessLines1(3) and AccessLines2(2);
    
    SelectLine13 <= Sel and AccessLines1(0) and AccessLines2(3);
    SelectLine14 <= Sel and AccessLines1(1) and AccessLines2(3);
    SelectLine15 <= Sel and AccessLines1(2) and AccessLines2(3);
    SelectLine16 <= Sel and AccessLines1(3) and AccessLines2(3);
    
    -- Instantiate the 16 individual 8-bit SRAM memory cells
    ram1: Register8Bit port map (LoadLine1, SelectLine1, InData, OutData1);      
    ram2: Register8Bit port map (LoadLine2, SelectLine2, InData, OutData2);
    ram3: Register8Bit port map (LoadLine3, SelectLine3, InData, OutData3);
    ram4: Register8Bit port map (LoadLine4, SelectLine4, InData, OutData4);
    ram5: Register8Bit port map (LoadLine5, SelectLine5, InData, OutData5);
    ram6: Register8Bit port map (LoadLine6, SelectLine6, InData, OutData6);
    ram7: Register8Bit port map (LoadLine7, SelectLine7, InData, OutData7);
    ram8: Register8Bit port map (LoadLine8, SelectLine8, InData, OutData8);
    ram9: Register8Bit port map (LoadLine9, SelectLine9, InData, OutData9);
    ram10: Register8Bit port map (LoadLine10, SelectLine10, InData, OutData10);
    ram11: Register8Bit port map (LoadLine11, SelectLine11, InData, OutData11);
    ram12: Register8Bit port map (LoadLine12, SelectLine12, InData, OutData12);
    ram13: Register8Bit port map (LoadLine13, SelectLine13, InData, OutData13);
    ram14: Register8Bit port map (LoadLine14, SelectLine14, InData, OutData14);
    ram15: Register8Bit port map (LoadLine15, SelectLine15, InData, OutData15);
    ram16: Register8Bit port map (LoadLine16, SelectLine16, InData, OutData16);
    
    -- Return the read data
    OutData <= OutData1 or
               OutData2 or
               OutData3 or
               OutData4 or
               OutData5 or
               OutData6 or
               OutData7 or
               OutData8 or
               OutData9 or
               OutData10 or
               OutData11 or
               OutData12 or
               OutData13 or
               OutData14 or
               OutData15 or
               OutData16;
end Behavioral;
