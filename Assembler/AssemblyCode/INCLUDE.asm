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
ENTER 4

; ========================
; Begin 1st function call
; ========================

; Push the function arguments onto the stack
PUSH 00010010b	; 18d
PUSH 00001101b	; 13d

CALL :_MUL

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

CALL :_MUL

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

CALL :_MUL

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
PUSH 00000111b	; 7d
PUSH 00100011b	; 35d

CALL :_MUL

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