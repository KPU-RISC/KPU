; Set register D to "00000001"
SET A, "0000"
SET B, "0001"
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

; Set register E to "00000001"
SET A, "0000"
SET B, "0001"
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

; Perform the ADD operation
MOV_ALU_IN A, D
MOV_ALU_IN B, E
ADD
MOV_ALU_OUT D

HLT