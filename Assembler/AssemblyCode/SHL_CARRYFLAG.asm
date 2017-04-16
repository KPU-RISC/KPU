; Initialize the stack pointer and the base pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X
MOV XL, 0
MOV XH, 0
MOV BP, X

MOV D, 10100000b

; Carry is 1
SHL D
PUSHF
POP E

; Write register E to the Output Port
OUTB E

; Carry is 0
SHL D
PUSHF
POP F

; Write register F to the Output Port
OUTB F

; Carry is 1
SHL D
PUSHF
POP G

; Write register G to the Output Port
OUTB G

HLT