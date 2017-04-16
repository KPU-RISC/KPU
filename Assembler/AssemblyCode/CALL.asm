; Initialize the stack pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X

; Call a subroutine...
CALL :SUBROUTINE

; Stops program execution
HLT

:SUBROUTINE
POP D
POP E

; Write registers E & D to the Output Port
OUTB E
OUTB D

; Stops program execution
HLT