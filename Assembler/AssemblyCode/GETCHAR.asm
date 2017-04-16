; ==================================================================
; The input file must contain 2 input entries.
; The input entries are finally stored in the registers "F" and "G"
; ==================================================================

; Initialize the stack pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X

; Initialize the Output Port C to 0
MOV XL, 0
OUT C

; Read 5 characters and store them onto the stack
CALL :GETCHAR
PUSH F
CALL :GETCHAR
PUSH F
CALL :GETCHAR
PUSH F
CALL :GETCHAR
PUSH F
CALL :GETCHAR
PUSH F

; Write the register H into the Output Port C
POP H
MOV XL, H
OUT C

; Signal the listener that new data is available on Output Port C
MOV XL, 00000010b
OUT D
MOV XL, 00000000b
OUT D

; Write the register H into the Output Port C
POP H
MOV XL, H
OUT C

; Signal the listener that new data is available on Output Port C
MOV XL, 00000010b
OUT D
MOV XL, 00000000b
OUT D

; Write the register H into the Output Port C
POP H
MOV XL, H
OUT C

; Signal the listener that new data is available on Output Port C
MOV XL, 00000010b
OUT D
MOV XL, 00000000b
OUT D

; Write the register H into the Output Port C
POP H
MOV XL, H
OUT C

; Signal the listener that new data is available on Output Port C
MOV XL, 00000010b
OUT D
MOV XL, 00000000b
OUT D

; Write the register H into the Output Port C
POP H
MOV XL, H
OUT C

; Signal the listener that new data is available on Output Port C
MOV XL, 00000010b
OUT D
MOV XL, 00000000b
OUT D

HLT

; ====================================================
; This subroutine reads a character from Input Port A
; and stores the read value in register "F"
; ====================================================
:GETCHAR
; Wait until the Ready-Bit is set at Input Port B
:WAIT_FOR_READY_BIT
IN B
MOV D, XL
MOV E, 00000001b
AND D, E
JZ :WAIT_FOR_READY_BIT

; Retrieve the input from Input Port A and process it
IN A
MOV F, XL

; Acknowledge the requested data by setting/resetting the ACK bit
MOV XL, 00000001b
OUT C
MOV XL, 00000000b
OUT C

; Return from the subroutine
RET