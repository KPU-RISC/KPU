; Initialize the stack pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X

; ===========================
; Indirect Memory Addressing
; ===========================

; Move the value in register "D" to the memory address that
; is stored in the register "SP"
MOV D, 11110000b
MOV [SP], D

; Move the value that is stored at the memory address of
; register "SP" into the register "E"
MOV E, [SP]

; Write register E to the Output Port
OUTB E

; ================================================
; Indirect Memory Addressing with positive offset
; ================================================

; Move the value in register "F" to the memory address that
; is stored in the register "SP" + 1
MOV F, 00001111b
MOV [SP + 1], F

; Load the value that is stored at the memory address of
; register "SP" + 1 into the register "G"
MOV G, [SP + 1]

; Write register G to the Output Port
OUTB G

; Move the value "10001111" through indirect addressing from
; register "F" into register "G"
MOV F, 10001111b
MOV [SP + 2], F
MOV G, [SP + 2]

; Move the value "11001111" through indirect addressing from
; register "F" into register "G"
MOV F, 11001111b
MOV [SP + 3], F
MOV G, [SP + 3]

; Write register G to the Output Port
OUTB G

; ================================================
; Indirect Memory Addressing with negative offset
; ================================================

; Move the value in register "D" to the memory address that
; is stored in the register "SP" - 4
MOV D, 11110011b
MOV [SP - 4], D

; Load the value that is stored at the memory address of
; register "SP" - 4 into the register "E"
MOV E, [SP - 4]

; Write register E to the Output Port
OUTB E

HLT