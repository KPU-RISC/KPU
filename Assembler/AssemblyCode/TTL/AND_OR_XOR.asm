MOV D, 10100111b
MOV E, 00000001b

; Test if Bit 0 is set
AND D, E

; Reset both registers
XOR D, D
XOR E, E

MOV D, 00000111b
MOV E, 01000000b

; Set Bit 7
OR D, E

; Reset both registers
XOR D, D
XOR E, E