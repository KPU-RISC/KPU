; Initialize the stack pointer and the base pointer
MOV XL, 11111111b
MOV XH, 11011111b
MOV SP, X

MOV XL, 0
PUSH XL
PUSH XL
PUSH XL
PUSH XL

; Write the stack pointer into the Output Port C
MOV X, SP
OUTB XL
MOV X, SP
OUTB XH

HLT