; ==================================================================
; The input file must contain 2 input entries.
; The input entries are finally stored in the registers "F" and "G"
; ==================================================================

; Initialize the stack pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X

; Initialize the Output Port D to 0
MOV XL, 0
OUT C
OUT D

; Reads a complete string from Input Port A and store it at
; address [Y] in memory
MOV XL, 0x00
MOV XH, 0xFF
MOV Y, X
CALL :SCANF

; Write a complete string from memory address [Y] into the 
; Output Port C...
MOV XL, 0x00
MOV XH, 0xFF
MOV Y, X
CALL :PRINTF

HLT

; =======================================================
; This subroutine sends characters from a given memory 
; address (register "Y") into the Output Port C until
; we read the ASCII code for NUL...
; =======================================================
:PRINTF
MOV H, 0 ; Character counter

:GET_NEXT_CHAR
MOV XL, [Y + H]
OUT C	; Write the current character to the Output Port C

; Signal the listener that new data is available on Output Port C
MOV XH, XL ; Save the register XL in XH
MOV XL, 00000010b
OUT D
MOV XL, 00000000b
OUT D
MOV XL, XH ; Restore the register XL from XH

INC H

; Check if we have reached the end of the null-terminated string
MOV D, 00000000b; Binary value for NUL ASCII code
CMP D, XL
JNZ :GET_NEXT_CHAR

; Return from the PRINTF subroutine
RET

; ====================================================
; This subroutine reads characters from Input Port A
; until we receive the ASCII code for CRLF...
; ====================================================
:SCANF
MOV H, 0 ; Character counter

:READ_NEXT_CHAR
CALL :GETCHAR 	; The read character is stored in register "F"
MOV [Y + H], F	; Store the read character in memory
INC H

MOV G, 00001101b ; Binary value for CRLF ASCII code
CMP G, F
JNZ :READ_NEXT_CHAR

; Null-terminate the string in memory
MOV F, 00000000b
DEC H
MOV [Y + H], F

; Return from the SCANF subroutine
RET

; ====================================================
; This subroutine reads a character from Input Port A
; and stores the read value in register "F"
; ====================================================
:GETCHAR
; Wait until the Ready-Bit is set at Input Port B
:GETCHAR_WAIT_FOR_READY_BIT
IN B
MOV D, XL
MOV E, 00000001b
; OLD: AND D, E
CMP D, E
; OLD: JZ :GETCHAR_WAIT_FOR_READY_BIT
JNZ :GETCHAR_WAIT_FOR_READY_BIT

; Retrieve the input from Input Port A and process it
IN A
MOV F, XL

; Acknowledge the requested data by setting/resetting the ACK bit
MOV XL, 00000001b
OUT D
MOV XL, 00000000b
OUT D

; Return from the GETCHAR subroutine
RET