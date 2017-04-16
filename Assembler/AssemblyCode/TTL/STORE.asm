MOV D, 00000000b
MOV E, 00000000b

:START
MOV XL, 10111111b
MOV XH, 0x00
MOV J, X

; Initialize the D and E register
MOV E, [J]
MOV D, 00000001b

; Add both values
ADD E, D

; Write the value back to the SRAM
MOV [J], E

; Jump back to the beginning of the pogram
JMP :START

DATA 0000000010111111b, 11001100b