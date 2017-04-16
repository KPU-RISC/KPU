; Initialize the stack pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X

SUB SP, 7

; Write the stack pointer to the Output Port C
MOV X, SP
OUT C

; Signal the listener that new data is available on Output Port C
MOV XL, 00000010b
OUT D
MOV XL, 00000000b
OUT D

; Write the stack pointer to the Output Port C
MOV X, SP
MOV XH, XL
OUT C

; Signal the listener that new data is available on Output Port C
MOV XL, 00000010b
OUT D
MOV XL, 00000000b
OUT D

ADD SP, 7

; Write the stack pointer to the Output Port C
MOV X, SP
OUT C

; Signal the listener that new data is available on Output Port C
MOV XL, 00000010b
OUT D
MOV XL, 00000000b
OUT D

; Write the stack pointer to the Output Port C
MOV X, SP
MOV XH, XL
OUT C

; Signal the listener that new data is available on Output Port C
MOV XL, 00000010b
OUT D
MOV XL, 00000000b
OUT D

HLT