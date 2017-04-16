#INCLUDE "FUNCTIONS.inc"

; Initialize the stack pointer and the base pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X
MOV XL, 0
MOV XH, 0
MOV BP, X

; Initialize the Output Port D to 0
MOV XL, 0
OUT C
OUT D

CALL :_MAIN
HLT

:_MAIN
ENTER 4

; ====================
; BEGIN CALL SCANF...
; ====================

; Read the first string from the Input Port A and store it at
; memory location 0xFA00
PUSH 0x00
PUSH 0xFA
CALL :_SCANF

; Store the number of read characters in a local variable
MOV [BP - 1], D

; Remove the arguments from the stack frame
ADD SP, 2

; Read the second string from the Input Port A and store it at
; memory location 0xFB00
PUSH 0x00
PUSH 0xFB
CALL :_SCANF

; Store the number of read characters in a local variable
MOV [BP - 2], D

; Remove the arguments from the stack frame
ADD SP, 2

; ==================
; END CALL SCANF...
; ==================

; ===================
; BEGIN CALL ATOI...
; ===================

MOV D, [BP - 1]
PUSH D		; Number of characters
PUSH 0x00	; 16-bit memory address
PUSH 0xFA	; 16-bit memory address
CALL :_ATOI

; Store the integer converted number in a local variable
MOV [BP - 3], D

; MOV XL, D
; OUT C

; Remove the arguments from the stack frame
ADD SP, 3

MOV D, [BP - 2]
PUSH D		; Number of characters
PUSH 0x00	; 16-bit memory address
PUSH 0xFB	; 16-bit memory address
CALL :_ATOI

; Store the integer converted number in a local variable
MOV [BP - 4], D

; Remove the arguments from the stack frame
ADD SP, 3

; ==================
; END CALL ATOI...
; ==================

; ==========================
; BEGIN PERFORM CALCULATION
; ==========================

MOV D, [BP - 3]
MOV E, [BP - 4]
ADD D, E

; ========================
; END PERFORM CALCULATION
; ========================

; ================
; BEGIN CALL ITOA
; ================

PUSH 0x00	; Lower 8-bit of the string buffer memory address
PUSH 0xFC	; Higher 8-bit of the string buffer memory address
PUSH D		; Result of the ADD Calculation
CALL :_ITOA

; Remove the argument from the stack frame
ADD SP, 3

; ==============
; END CALL ITOA
; ==============

; ==================
; BEGIN CALL PRINTF
; ==================

; Write a null-terminated string from memory address 0xFF00 into the 
; Output Port C...
PUSH 0x00
PUSH 0xFC
CALL :_PRINTF

; Remove the arguments from the stack frame
ADD SP, 2

; ================
; END CALL PRINTF
; ================

; Return from MAIN...
LEAVE
RET