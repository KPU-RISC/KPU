MOV D, 11110000b
MOV E, 00000001b

:START
ADD D, E

; Jump back to the beginning of the program
JMP :START