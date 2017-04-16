; Initialize the stack pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X

MOV F, 11110000b

; Call a subroutine...
CALL :SUBROUTINE

MOV F, 10101010b

; Write register F to the Output Port
OUTB F

; Stops program execution
HLT

:SUBROUTINE
MOV F, 01010101b
RET