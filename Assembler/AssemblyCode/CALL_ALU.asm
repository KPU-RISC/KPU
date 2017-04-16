; Initialize the stack pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X

; Call some subroutines...
CALL :ADD_FUNCTION

MOV G, 3

; Write register G to the Output Port
OUTB G

CALL :SUB_FUNCTION

MOV G, 4

; Write register G to the Output Port
OUTB G

; Stops program execution
HLT

:ADD_FUNCTION
MOV G, 1

; Write register G to the Output Port
OUTB G

RET

:SUB_FUNCTION
MOV G, 2

; Write register G to the Output Port
OUTB G

RET