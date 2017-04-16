MOV XL, 11111110b
MOV XH, 0x00
MOV J, X

; Initialize the D and E register
MOV E, [J]
MOV D, 00000001b

; Add both values
ADD E, D

DATA 0000000011111110b, 00000001b