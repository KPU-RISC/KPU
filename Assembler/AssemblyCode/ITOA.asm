#INCLUDE "FUNCTIONS.inc"

; Initialize the stack pointer and the base pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X
MOV XL, 0
MOV XH, 0
MOV BP, X

CALL :_MAIN
HLT

:_MAIN
ENTER 0

; ===================
; BEGIN CALL ITOA...
; ===================

PUSH 0x00	; Lower 8-bit of the string buffer memory address
PUSH 0xFA	; Higher 8-bit of the string buffer memory address
PUSH 01001110b	; 78d
CALL :_ITOA

; Remove the argument from the stack frame
ADD SP, 3

; ==================
; END CALL ITOA...
; ==================

; ==================
; BEGIN CALL PRINTF
; ==================

; Write a null-terminated string from memory address 0xFF00 into the 
; Output Port C...
PUSH 0x00
PUSH 0xFA
CALL :_PRINTF

; Remove the arguments from the stack frame
ADD SP, 2

; ================
; END CALL PRINTF
; ================

; Return from MAIN...
LEAVE
RET