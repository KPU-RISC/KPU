:START
MOV D, 10101010b
MOV E, 11110000b

NOT D
NOT E

; Jump back to the beginning of the pogram
JMP :START

; This code is never reached...
MOV D, 11111111b
MOV E, 11111111b