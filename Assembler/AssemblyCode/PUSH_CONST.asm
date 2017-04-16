; Initialize the stack pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X

; Push some constant value onto the stack
PUSH 00001111b
PUSH 5
PUSH 0xAB
PUSH 1Ah

; Load the value from the top of the stack into register D
MOV XL, 0xFB
MOV XH, 0xFF
MOV D, [X]

; Load the value from the top of the stack into register E
MOV XL, 0xFC
MOV XH, 0xFF
MOV E, [X]

; Load the value from the top of the stack into register F
MOV XL, 0xFD
MOV XH, 0xFF
MOV F, [X]

; Load the value from the top of the stack into register G
MOV XL, 0xFE
MOV XH, 0xFF
MOV G, [X]

; Write register D to the Output Port
OUTB D

; Write register E to the Output Port
OUTB E

; Write register F to the Output Port
OUTB F

; Write register G to the Output Port
OUTB G

HLT