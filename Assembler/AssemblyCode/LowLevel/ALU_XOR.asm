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

; Set register E to "10001111"
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
MOV_ALU_OUT E

; Perform the XOR operation
MOV_ALU_IN A, D
MOV_ALU_IN B, E
XOR
MOV_ALU_OUT F

HLT