MOV D, 10100111b
MOV E, 10000101b

AND D, E

; Write register D to the Output Port
OUTB D

HLT