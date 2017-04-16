; Load the initial values into register D and E
MOV E, 9
MOV D, 9

CMP E, D

PUSHF
POP G

; Write register G to the Output Port
OUTB G

HLT