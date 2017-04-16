; Store a value in register "BP"
MOV XL, 0xFF
MOV XH, 0xFF
MOV BP, X

; Store a value in register "Y"
MOV XL, 00001111b
MOV XH, 11110000b
MOV Y, X

; Store a value in register "Z"
MOV XL, 10001111b
MOV XH, 11110001b
MOV Z, X

; Write the register BP into the Output Port C
MOV X, BP
OUTB XL

; Write the register BP into the Output Port C
MOV X, BP
OUTB XH

; Write the register Y into the Output Port C
MOV X, Y
OUTB XL

; Write the register Y into the Output Port C
MOV X, Y
OUTB XH

; Write the register Z into the Output Port C
MOV X, Z
OUTB XL

; Write the register Z into the Output Port C
MOV X, Z
OUTB XH

HLT