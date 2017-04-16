; Initialize the stack pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X

MOV F, 1
MOV G, 00010000b

; Call a subroutine...
CALL :SUBROUTINE

; Do something else after the recursive function call...
INC G

; Write register G to the Output Port
OUTB G

; Stops program execution
HLT

:SUBROUTINE
INC F
CMP F, G
JZ :SUBROUTINE_RETURN

; Recursive call...
CALL :SUBROUTINE

:SUBROUTINE_RETURN
RET