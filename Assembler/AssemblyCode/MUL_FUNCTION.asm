; Initialize the stack pointer and the base pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X
MOV XL, 0
MOV XH, 0
MOV BP, X

CALL :MAIN
HLT

:MAIN
ENTER 4

; ========================
; Begin 1st function call
; ========================

; Push the function arguments onto the stack
PUSH 00010010b	; 18d
PUSH 00001101b	; 13d

CALL :MUL

; Store the result of the multiplication in a local variable
MOV [BP - 1], D

; Remove the arguments from the stack frame
ADD SP, 2

; ========================
; End 1st function call
; ========================

; ========================
; Begin 2nd function call
; ========================

; Push the function arguments onto the stack
PUSH 00010100b	; 20d
PUSH 00001001b	; 9d

CALL :MUL

; Store the result of the multiplication in a local variable
MOV [BP - 2], D

; Remove the arguments from the stack frame
ADD SP, 2

; ========================
; End 2nd function call
; ========================

; ========================
; Begin 3rd function call
; ========================

; Push the function arguments onto the stack
PUSH 00100011b	; 35d
PUSH 00000111b	; 7d

CALL :MUL

; Store the result of the multiplication in a local variable
MOV [BP - 3], D

; Remove the arguments from the stack frame
ADD SP, 2

; ========================
; End 3rd function call
; ========================

; ========================
; Begin 4th function call
; ========================

; Push the function arguments onto the stack
PUSH 00100011b	; 35d
PUSH 00000111b	; 7d

CALL :MUL

; Store the result of the multiplication in a local variable
MOV [BP - 4], D

; Remove the arguments from the stack frame
ADD SP, 2

; ========================
; End 4th function call
; ========================

; Write the result of the multiplication to the Output Port C
MOV D, [BP - 1]
OUTB D

; Write the result of the multiplication to the Output Port C
MOV D, [BP - 2]
OUTB D

; Write the result of the multiplication to the Output Port C
MOV D, [BP - 3]
OUTB D

; Write the result of the multiplication to the Output Port C
MOV D, [BP - 4]
OUTB D

; Return from MAIN...
LEAVE
RET

:MUL
; We need 1 local variable for the bit mask
ENTER 1

; Initial counter value - 0d
MOV G, 0

; End value - 8d
MOV H, 8

; ; Bit Mask for the current bit to multiply
MOV [BP - 1], 00000001b

; Push the intermediate result of the addition onto the stack
; The initial value is just a zero.
MOV D, 0
PUSH D

; 1. This loop is performed 8 times - for every bit once
:AND_LOOP

; 2. Load the values from the RAM into the registers (input parameter value)
MOV D, [BP + 4]

; Load the register "E" (input parameter value)
MOV E, [BP + 5]

; Load the register "F" with the bit mask (local variable)
MOV F, [BP - 1]

; 3. Extract the current bit to be multiplied
AND F, E

; 4. Check if we have a "0" or "1" in the current bit
MOV E, 0
CMP F, E

JZ :ZERO_VALUE

MOV E, 11111111b

:ZERO_VALUE

; 5. Perform the AND for the multiplication
AND D, E

; 6. Shift the bit mask in register "F" 1 bit to the left
MOV F, [BP - 1]
SHL F
MOV [BP - 1], F

; 7. SHL Loop
; This loop performs a SHL operation multiple times, based on which bit position
; is currently processed.
; The current bit position is based on the register G, which is the loop counter
; of the outer loop "AND_LOOP".
MOV E, 0

:SHL_LOOP
CMP E, G
JZ :EXIT_SHL_LOOP

SHL D
INC E
JMP :SHL_LOOP

:EXIT_SHL_LOOP

; 8. Perform the addition to the intermediate result that is currently stored
; on the stack. The result of the addition is pushed back onto the stack.
; Therefore we can use it as a base for the next loop iteration.
POP F
ADD F, D
PUSH F

; 9. Test if we have already reached the end value of the outer loop "AND_LOOP"
INC G
CMP G, H

; 10. Conditional Jump to the beginning of the loop "AND_LOOP"
; based on the Zero flag
JNZ :AND_LOOP

; The result of the multiplication is finally stored in the register "D"
POP D

; Return from MUL...
LEAVE
RET