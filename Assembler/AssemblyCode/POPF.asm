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

; Sets the Zero flag to 0
MOV D, 2
MOV E, 1
SUB D, E

; Retrieve the flags from the stack
POPF

PUSHF
POP D

; Write register D to the Output Port
OUTB D

HLT