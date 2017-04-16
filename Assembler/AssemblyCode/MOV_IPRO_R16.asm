; Initialize the stack pointer and the base pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X

; Make some space on the stack for local variables
SUB SP, 4

; Push the function arguments onto the stack
MOV D, 3
MOV [SP + D], 4
MOV D, 2
MOV [SP + D], 00000011b
MOV D, 1
MOV [SP + D], 0xAB
MOV D, 0
MOV [SP + D], 0xEE

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