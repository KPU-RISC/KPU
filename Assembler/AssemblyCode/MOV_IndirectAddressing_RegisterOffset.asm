; Initialize the stack pointer
MOV XL, 0xFF
MOV XH, 0xFA
MOV SP, X

; The offset value is stored in a register
MOV G, 1

; =================================================================
; Indirect Memory Addressing with a register based positive offset
; =================================================================

MOV E, 10101010b
MOV [SP + G], E
MOV F, [SP + G]

; Write register F to the Output Port
OUTB F

; =================================================================
; Indirect Memory Addressing with a register based negative offset
; =================================================================

MOV D, 01010101b
MOV [SP - G], D
MOV H, [SP - G]

; Write register H to the Output Port
OUTB H

HLT