; Initialize the stack pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X

; Push some value onto the stack
MOV D, 10101010b
PUSH D
MOV D, 11110000b
PUSH D
MOV D, 00001111b
PUSH D
MOV D, 11001111b
PUSH D

; Pop some value from the stack
POP E
POP F
POP G
POP H

; Write register E to the Output Port
OUTB E

; Write register F to the Output Port
OUTB F

; Write register G to the Output Port
OUTB G

; Write register H to the Output Port
OUTB H

HLT