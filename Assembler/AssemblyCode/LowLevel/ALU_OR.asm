; Set register D to "10001111"
SET A, "1000"
SET B, "1111"
SHL
MOV_ALU_C_TO_AB A
SHL
MOV_ALU_C_TO_AB A
SHL
MOV_ALU_C_TO_AB A
SHL
MOV_ALU_C_TO_AB A
OR
MOV_ALU_OUT D

; Set register E to "01100000"
SET A, "0110"
SET B, "0000"
SHL
MOV_ALU_C_TO_AB A
SHL
MOV_ALU_C_TO_AB A
SHL
MOV_ALU_C_TO_AB A
SHL
MOV_ALU_C_TO_AB A
OR
MOV_ALU_OUT E

; Perform the OR operation
MOV_ALU_IN A, D
MOV_ALU_IN B, E
OR
MOV_ALU_OUT F

HLT