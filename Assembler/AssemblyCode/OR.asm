MOV D, 10001001b
MOV E, 00100001b

OR D, E

; Write register D to the Output Port
OUTB D

HLT