; Initialize the stack pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X

MOV F, 1

; Write register F to the Output Port
OUTB F

; Call a subroutine...
CALL :SUB_FUNCTION

MOV F, 4

; Write register F to the Output Port
OUTB F

; Stops program execution
HLT

:SUB_FUNCTION
MOV F, 2

; Write register F to the Output Port
OUTB F

CALL :SUB_SUB_FUNCTION
RET

:SUB_SUB_FUNCTION
MOV F, 3

; Write register F to the Output Port
OUTB F

RET