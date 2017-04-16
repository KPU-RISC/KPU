; =========================================================================
; This program performs a 16-bit addition between the following values:
; Input A: 00000000 11111111b (255d)
; Input B: 00000000 00111100b (60d)
;
; The result of the addition is placed into the register X:
; Output: 00000001 00111011b (315d)
;
; The 16-bit Adder uses the following registers:
; Input A: Register X
; Input B: Register D
; Output:  Register X
; =========================================================================

; Set register XL to "00111100"
SET A, "0011"
SET B, "1100"
SHL
MOV_ALU_C_TO_AB A
SHL
MOV_ALU_C_TO_AB A
SHL
MOV_ALU_C_TO_AB A
SHL
MOV_ALU_C_TO_AB A
OR
MOV_ALU_OUT XL

; Set register XH to "00000000"
SET A, "0000"
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
MOV_ALU_OUT XH

; Input Value B - 16-bit in regiser "J"
MOV16 J, X

; Input Value A - 16-bit in register "X"
; Set register XL to "11111111"
SET A, "1111"
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
MOV_ALU_OUT XL

; Set register XH to "00000000"
SET A, "0000"
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
MOV_ALU_OUT XH

; Execute the 16-bit Adder
16BIT_ADDER

; Move the result of the 16-bit addition into register "J"
MOV16 J, X

; Stops program execution
HLT