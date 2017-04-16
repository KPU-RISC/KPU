#INCLUDE "FUNCTIONS.inc"

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
; Reserve space for 2 local variables on the stack
ENTER 2

; Initialize the Output Port D to 0
MOV XL, 0
OUT C
OUT D

; ====================
; BEGIN CALL SCANF...
; ====================

; Reads a complete string from Input Port A and store it at
; memory address 0xFF00
PUSH 0x00
PUSH 0xFF
CALL :_SCANF

; Store the number of read characters in a local variable
MOV [BP - 1], D

; Remove the arguments from the stack frame
ADD SP, 2

; ==================
; END CALL SCANF...
; ==================

; =====================
; BEGIN CALL PRINTF...
; =====================

; Write a null-terminated string from memory address 0xFF00 into the 
; Output Port C...
PUSH 0x00
PUSH 0xFF
CALL :_PRINTF

; Store the number of read characters in a local variable
MOV [BP - 2], D

; Remove the arguments from the stack frame
ADD SP, 2

; ===================
; END CALL PRINTF...
; ===================

; Return from the function MAIN...
LEAVE
RET