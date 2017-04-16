; Initialize the stack pointer
MOV XL, 00000000b
MOV XH, 11111111b
MOV SP, X
XOR XH, XH

MOV D, 00001111b
XOR D, D

; Write register D to the Output Port
OUTB D

HLT