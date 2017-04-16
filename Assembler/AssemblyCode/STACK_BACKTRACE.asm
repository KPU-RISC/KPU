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
ENTER 0

CALL :_ADD

; Return from MAIN...
LEAVE
RET

:_ADD
ENTER 0

CALL :_ADD_A

LEAVE
RET

:_ADD_A
ENTER 0

CALL :_ADD_B

LEAVE
RET

:_ADD_B
ENTER 0

CALL :_ADD_C

LEAVE
RET

:_ADD_C
ENTER 0

CALL :_ADD_D

LEAVE
RET

:_ADD_D
ENTER 0

CALL :_STACKBACKTRACE

LEAVE
RET

:_STACKBACKTRACE
ENTER 0

MOV H, 0

; Initialize the registers with the current BP.
MOV X, BP
MOV D, XH
MOV E, XL

:BP_NOT_NULL
; Load the memory content of the current BP (pointer to 
; the previous stack frame) into the registers
MOV XH, D
MOV XL, E
MOV Y, X

; Load the BP of the previous stack frame into the registers
MOV D, [Y]
MOV E, [Y + 1]

; Write out the higher byte of the return address
MOV XL, [Y + 2]
OUTB XL

; Write out the lower byte of the return address
MOV XL, [Y + 3]
OUTB XL

; Check if the lower byte of the BP is NULL.
; We should also check here the higher byte of the BP if it is NULL...
CMP E, H

; We haven't yet reached the 1st stack frame, therefore we walk again
; down the stack
JNZ :BP_NOT_NULL

LEAVE
RET