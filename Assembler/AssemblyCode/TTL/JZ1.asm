:START
MOV E, 10110111b
MOV D, 01001001b
ADD E, D

; Conditional Jump if the Zero-Flag from the ALU is 1
JMP :START