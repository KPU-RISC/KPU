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
ENTER 4

; ========================
; Begin 1st function call
; ========================

; Move some value into register "D" and store it temporarily on the stack
MOV D, 10101010b
PUSH D

; Push the function arguments onto the stack
PUSH 00010010b	; 18d
PUSH 00001101b	; 13d

CALL :_MUL

; Store the result of the multiplication in a local variable
MOV [BP - 1], D

; Remove the arguments from the stack frame
ADD SP, 2

; Restore the content of register "D"
POP D

; ========================
; End 1st function call
; ========================

; Write the result of the multiplication to the Output Port C
MOV D, [BP - 1]
OUTB D

; Return from MAIN...
LEAVE
RET