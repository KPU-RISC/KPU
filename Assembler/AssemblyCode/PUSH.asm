; Initialize the stack pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X

; Move some value into register D
MOV D, 00001111b
PUSH D
MOV D, 11110000b
PUSH D

; Load the value from the top of the stack into register E
MOV XL, 0xFD
MOV XH, 0xFF
MOV E, [X]

; Write register E to the Output Port
OUTB E

; Load the initial value from the new top of the stack into register F
MOV XL, 0xFE
MOV XH, 0xFF
MOV F, [X]

; Write register F to the Output Port
OUTB F

HLT