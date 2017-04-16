#INCLUDE "FUNCTIONS.inc"

; Initialize the stack pointer and the base pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X
MOV BP, X

; Initialize the Output Port D to 0
MOV XL, 0
OUT C
OUT D

; ==================
; BEGIN CALL PRINTF
; ==================

; Write a null-terminated string from memory address 0xFF00 into the 
; Output Port C...
PUSH 0x00
PUSH 0xFF
CALL :_PRINTF

; Remove the arguments from the stack frame
ADD SP, 2

; ================
; END CALL PRINTF
; ================

; Return from MAIN...
HLT

DATA 1111111100000000b, 01001000b ; 'H'
DATA 1111111100000001b, 01100101b ; 'e'
DATA 1111111100000010b, 01101100b ; 'l'
DATA 1111111100000011b, 01101100b ; 'l'
DATA 1111111100000100b, 01101111b ; 'o'
DATA 1111111100000101b, 00100000b ; ' '
DATA 1111111100000110b, 01010111b ; 'W'
DATA 1111111100000111b, 01101111b ; 'o'
DATA 1111111100001000b, 01110010b ; 'r'
DATA 1111111100001001b, 01101100b ; 'l'
DATA 1111111100001010b, 01100100b ; 'd'
DATA 1111111100001011b, 00100001b ; '!'
DATA 1111111100001100b, 00000000b ; CRLF