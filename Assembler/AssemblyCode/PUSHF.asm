; Initialize the stack pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X

; Sets the Zero flag to 1
MOV D, 1
MOV E, 1
SUB D, E

; Store the flags onto the stack
PUSHF

; Write register G to the Output Port
POP G
OUTB G

HLT