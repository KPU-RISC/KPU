; Initialize the stack pointer
MOV8 XL, "11111111"
MOV8 XH, "11111111"
MOV16 SP, X

MOV8 F, "11110000"

; Call a subroutine...
CALL :SUBROUTINE

MOV8 F, "10101010"

; Stops program execution
HLT

:SUBROUTINE
MOV8 F, "01010101"

; ======================
; RET implementation...
; ======================

; 1. Increment the stack pointer by 1
MOV8 XL, "00000001"
MOV8 XH, "00000000"
MOV16 J, X
MOV16 X, SP
16BIT_ADDER
MOV16 SP, X

; 2. Load the bits 8 - 15 from the stack into the register XH, 
; and cache it in register M
MOV16 M, SP
LOAD XH
MOV16 M, X

; 3. Increment the stack pointer by 1
MOV8 XL, "00000001"
MOV8 XH, "00000000"
MOV16 J, X
MOV16 X, SP
16BIT_ADDER
MOV16 SP, X

; 4. Load the bits 0 - 7 from the stack into the register XL
MOV16 X, M
MOV16 M, SP
LOAD XL

; 5. Transfer the POPed PC into the PC register to
; jump back to the callee...
MOV16 PC, X

; ============================