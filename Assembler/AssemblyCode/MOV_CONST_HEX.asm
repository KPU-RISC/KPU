MOV D, 0xAB
MOV E, FFh
MOV F, 0x10

; Write register D to the Output Port
OUTB D

; Write register E to the Output Port
OUTB E

; Write register F to the Output Port
OUTB F

HLT