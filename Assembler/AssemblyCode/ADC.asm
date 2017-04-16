; Initialize the stack pointer and the base pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X
MOV XL, 0
MOV XH, 0
MOV BP, X

; Initialize the D and E registers
MOV D, 11111101b	; 253d
MOV E, 01100100b	; 100d
ADD D, E
PUSHF

; Write register D to the Output Port
OUTB D

MOV D, 00000000b
MOV E, D
POPF
ADC D, E

; Write register D to the Output Port
OUTB D

; Stops the CPU execution
HLT