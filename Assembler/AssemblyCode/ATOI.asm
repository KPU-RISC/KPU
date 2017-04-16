#INCLUDE "FUNCTIONS.inc"

; Initialize the stack pointer and the base pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X
MOV XL, 0
MOV XH, 0
MOV BP, X

; Initialize the Output Port C & D with 0
MOV XL, 0
OUT C
OUT D

CALL :_MAIN
HLT

:_MAIN
ENTER 1

; ====================
; BEGIN CALL SCANF...
; ====================

; Reads a complete string from Input Port A and store it at
; memory address 0xFA00
PUSH 0x00
PUSH 0xFA
CALL :_SCANF

; Store the number of read characters in a local variable
MOV [BP - 1], D

; Remove the arguments from the stack frame
ADD SP, 2

; ==================
; END CALL SCANF...
; ==================

; ===================
; BEGIN CALL ATOI...
; ===================

PUSH D		; Number of characters
PUSH 0x00	; 16-bit memory address
PUSH 0xFA	; 16-bit memory address
CALL :_ATOI

; Remove the arguments from the stack frame
ADD SP, 3

; ==================
; END CALL ATOI...
; ==================

; Move the result of ATOI to the memory location 0xFA00 and null-terminate it
MOV XH, 0xFA
MOV XL, 0x00
MOV Y, X
MOV [Y], D
MOV [Y + 1], 00000000b

; =====================
; BEGIN CALL PRINTF...
; =====================

; Write the null-terminated string from memory address 0xFF00 into the 
; Output Port C...
PUSH 0x00
PUSH 0xFA
CALL :_PRINTF

; Remove the arguments from the stack frame
ADD SP, 2

; ===================
; END CALL PRINTF...
; ===================

; Return from MAIN...
LEAVE
RET