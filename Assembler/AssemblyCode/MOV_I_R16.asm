; Initialize the stack pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X

MOV D, 1
MOV [SP], D
MOV E, [SP]

MOV [SP], 2
MOV F, [SP]

MOV [SP], 00000011b
MOV G, [SP]

MOV [SP], 0xAA
MOV H, [SP]

MOV [SP], ABh
MOV H, [SP]

; Write register E to the Output Port
OUTB E

; Write register F to the Output Port
OUTB F

; Write register G to the Output Port
OUTB G

; Write register H to the Output Port
OUTB H

HLT