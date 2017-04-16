; Initialize the stack pointer and the base pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X
MOV XL, 0
MOV XH, 0
MOV BP, X

CALL :MAIN

; Write the stack pointer into the Output Port C
MOV X, SP
OUTB XL
MOV X, SP
OUTB XH

HLT

:MAIN

; ===============
; BEGIN Prologue
; ===============
PUSH BP
MOV BP, SP
SUB SP, 5

; =============
; END Prologue
; =============

; Push the function arguments onto the stack
MOV D, 4
PUSH D
MOV D, 3
PUSH D

; int result = ADDER(3, 4);
CALL :ADDER

; Remove the arguments from the stack frame
ADD SP, 2

; Write the result into the Output Port C
OUTB D		; Access the result of the function call from register "D"

; =============
; BEGIN Epilog
; =============
MOV SP, BP
POP BP

; =============
; END Epilog
; =============

; Return from the function MAIN...
RET

:ADDER

; ===============
; BEGIN Prologue
; ===============
PUSH BP
MOV BP, SP

; Make some space on the stack for local variables
MOV X, SP
DEC XL
MOV SP, X

; =============
; END Prologue
; =============

; Access the input parameter values that were pushed onto the stack
MOV E, [BP + 4]		; Value 3
MOV F, [BP + 5]		; Value 4
ADD E, F

; Store the result as a local variable on the stack
MOV [BP - 1], E

; Store the return value in the register "D"
MOV D, E

; =============
; BEGIN Epilog
; =============
MOV SP, BP
POP BP

; =============
; END Epilog
; =============

; Return from the function ADDER...
RET