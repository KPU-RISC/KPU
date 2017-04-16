MOV XL, 10111110b
MOV XH, 0x00
MOV J, X

; Initialize the D and E register
MOV D, [J]
MOV E, [J]

:START

; LOAD the E register
MOV XL, 10111111b
MOV XH, 0x00
MOV J, X
MOV E, [J]

; Perform the ADD
ADD E, D

; STORE the E register
MOV XL, 10111111b
MOV XH, 0x00
MOV J, X
MOV [J], E

; Jump back to the beginning of the program
JMP :START

DATA 0000000010111110b, 00000001b
DATA 0000000010111111b, 00000001b