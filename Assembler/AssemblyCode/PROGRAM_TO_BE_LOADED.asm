; Write the character 'A' to the Output Port C
MOV D, 01000001b ; 'A'
MOV XL, D
OUT C
HLT