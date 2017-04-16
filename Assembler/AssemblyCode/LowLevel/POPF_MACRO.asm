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

; Set register XH to "11111111"
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
MOV_ALU_OUT XH
MOV16 SP, X

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

; Perform a "SUB D, E" operation
; This sets the Zero flag to 1
MOV_ALU_IN A, E
NOT
MOV_ALU_C_TO_AB A
SET B, "0001"
ADD
MOV_ALU_C_TO_AB B
MOV_ALU_IN A, D
ADD
MOV_ALU_OUT D

; ====================
; PUSHF implementation
; ====================

; 1. Store the flags in the "FlagsOutBuffer"
FLAGS_TO_OUTBUFFER

; 2. Store the flags from the "FlagsOutBuffer" onto the stack
MOV16 M, SP
STORE_FLAGS

; 3. Decrement the stack pointer by 1

; 3.1. Set register XL to "11111111"
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

; 3.2. Set register XH to "11111111"
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
MOV_ALU_OUT XH

; 3.3. Decrement the stack pointer
MOV16 J, X
MOV16 X, SP
16BIT_ADDER
MOV16 SP, X

; =====================

; Set register D to "00000100"
SET A, "0000"
SET B, "0100"
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

; Perform a "SUB D, E" operation
; This sets the Zero flag to 1
MOV_ALU_IN A, E
NOT
MOV_ALU_C_TO_AB A
SET B, "0001"
ADD
MOV_ALU_C_TO_AB B
MOV_ALU_IN A, D
ADD
MOV_ALU_OUT D

; ====================
; POPF implementation
; ====================

; 1. Increment the stack pointer by 1

; 1.1. Set register XL to "00000001"
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
MOV_ALU_OUT XL

; 1.2. Set register XH to "00000000"
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

; 1.3. Increment the stack pointer
MOV16 J, X
MOV16 X, SP
16BIT_ADDER
MOV16 SP, X

; 2.1. Load the flags into the "FlagsInBuffer" register
MOV16 M, SP
LOAD_FLAGS

; 3.1. Move the content from the FlagsInBuffer" to the Flags register.
; The FLAGS register contains finally the value "110"
INBUFFER_TO_FLAGS

; =========================

HLT