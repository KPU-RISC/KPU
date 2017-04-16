
MOV D, 00000000b
MOV E, 00000000b

MOV XL, 10111111b
MOV XH, 0x00
MOV J, X

; Initialize the D and E register
MOV E, [J]
MOV D, 00000001b

:START
; Add both values
ADD E, D

; Jump back to the beginning of the program
JMP :START

DATA 0000000010111111b, 11001100b