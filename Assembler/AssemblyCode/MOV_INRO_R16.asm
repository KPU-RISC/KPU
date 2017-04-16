; Initialize the stack pointer and the base pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X

; Push the function arguments onto the stack
MOV D, 1
MOV [SP - D], 4
MOV D, 2
MOV [SP - D], 00000011b
MOV D, 3
MOV [SP - D], 0xAB
MOV D, 4
MOV [SP - D], 0xEE

MOV E, [SP - 1]
MOV F, [SP - 2]
MOV G, [SP - 3]
MOV H, [SP - 4]

; Write register E to the Output Port
OUTB E

; Write register F to the Output Port
OUTB F

; Write register G to the Output Port
OUTB G

; Write register H to the Output Port
OUTB H

HLT