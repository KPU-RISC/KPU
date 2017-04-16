#INCLUDE "FUNCTIONS.inc"

; Initialize the stack pointer and the base pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X
MOV XL, 0
MOV XH, 0
MOV BP, X

CALL :_MAIN

; Write register D to the Output Port
OUTB D

; Write register G to the Output Port
OUTB E

HLT

:_MAIN
ENTER 0

; ===============
; BEGIN CALL DIV
; ===============

; Performs a 127/24 division
PUSH 01111111b
PUSH 00011000b
CALL :_DIV

; Remove the arguments from the stack frame
ADD SP, 2

; =============
; END CALL DIV
; =============

LEAVE
RET