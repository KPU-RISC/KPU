MOV D, 00000001b
MOV E, 00000001b

ADD D, E

; Write register D to the Output Port
OUTB D

HLT