; Initialize the stack pointer and the base pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X

; Make some space on the stack for local variables
SUB SP, 4

; Push the function arguments onto the stack
MOV [SP + 3], 4
MOV [SP + 2], 00000011b
MOV [SP + 1], 0xAB
MOV [SP + 0], 0xEE

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