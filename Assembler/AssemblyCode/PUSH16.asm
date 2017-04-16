; Initialize the stack pointer
MOV XL, 11111111b
MOV XH, 11101111b
MOV SP, X

; Move some values onto the stack
MOV D, 00001111b
PUSH D
MOV D, 11110000b
PUSH D

; Write the current stack pointer into the BP register
MOV BP, SP

; Push the BP onto the stack
PUSH BP

; Pop the BP from the stack into register "Y"
POP Y

POP E
POP F

; Write register E to the Output Port
OUTB E

; Write register F to the Output Port
OUTB F

HLT