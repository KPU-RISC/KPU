; Initialize the stack pointer
MOV8 XL, "11111111"
MOV8 XH, "11111111"
MOV16 SP, X

; -----------------------------
; Begin CALL implementation...
; -----------------------------

; 1. Store the current PC in the J register and fix it
; to point to the address *after* the JMP instruction.
; The implementation of the CALL micro code takes 115 - 25 = 90 instructions.
; We have to subtract 25, because there are 25 instructions before we read
; the PC into the register X for the addition
; But we only add 89d (01011001b) to the current PC, because when we finally
; POP the PC during the RET opcode, the PC will be incremented to
; point to the next (correct) instruction.

; 1.1. Set the value of the register XL to "01011001"
; 12 bytes long
SET A, "0101"
SET B, "1001"
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

; 1.2. Set the value of the register XH to "00000000"
; 12 bytes long
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

; 1.3. Add the bytes to the value in the register PC
; 3 bytes long
MOV16 J, X
MOV16 X, PC
16BIT_ADDER

; 2. Push the 1st 8 bit of the PC onto the stack
; 3 bytes long
MOV16 M, SP
STORE XL
MOV16 M, X

; 3. Decrement the stack pointer by 1

; 3.1. Set the value of the register XL to "11111111"
; 12 bytes long
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

; 3.2. Set the value of the register XH to "11111111"
; 12 bytes long
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
; 4 bytes long
MOV16 J, X
MOV16 X, SP
16BIT_ADDER
MOV16 SP, X

; 4. Push the 2nd 8 bit of the PC onto the stack
; 3 bytes long
MOV16 X, M
MOV16 M, SP
STORE XH

; 5. Decrement the stack pointer by 1

; 5.1. Set the value of the register XL to "11111111"
; 12 bytes long
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

; 5.2. Set the value of the register XH to "11111111"
; 12 bytes long
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

; 5.3. Decrement the stack pointer
; 4 bytes long
MOV16 J, X
MOV16 X, SP
16BIT_ADDER
MOV16 SP, X

; 6. Perform the actual jump to the subroutine
; 26 bytes long
SET A, "1111":SUBROUTINE_LN2
SET B, "1111":SUBROUTINE_LN1
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
SET A, "1111":SUBROUTINE_HN2
SET B, "1111":SUBROUTINE_HN1
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
MOV16 J, X
CALL_JMP :SUBROUTINE

; -----------------------------
; End CALL implementation...
; -----------------------------

; Stops program execution
HLT

:SUBROUTINE
POP D
POP E
HLT