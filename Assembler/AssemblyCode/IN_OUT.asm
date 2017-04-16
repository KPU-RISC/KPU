; ==================================================================
; The input file must contain 2 input entries.
; The input entries are finally stored in the registers "F" and "G"
; ==================================================================

; Initialize the Output Port C & D to 0
MOV XL, 0
OUT C
OUT D

; ====================================
; Read the 1st byte from Input Port A
; ====================================

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
OUT D
MOV XL, 00000000b
OUT D

; ====================================
; Read the 2nd byte from Input Port A
; ====================================

; Wait until the Ready-Bit is set at Input Port B
:WAIT_FOR_READY_BIT_TWO
IN B
MOV D, XL
MOV E, 00000001b
AND D, E
JZ :WAIT_FOR_READY_BIT_TWO

; Retrieve the input from Input Port A and process it
IN A
MOV G, XL

; Acknowledge the requested data by setting/resetting the ACK bit
MOV XL, 00000001b
OUT D
MOV XL, 00000000b
OUT D

HLT