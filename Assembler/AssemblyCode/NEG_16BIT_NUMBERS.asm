; Initialize the stack pointer and the base pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X
MOV XL, 0
MOV XH, 0
MOV BP, X

; Initialize an address register
MOV XL, 0x00
MOV XH, 0xFF
MOV Y, X

; Invert the 1st byte
MOV D, [Y]
NOT D

; Invert the 2nd byte
MOV E, [Y + 1]
NOT E

; Add 1 to the 2 bytes
MOV F, 1
MOV G, 0
ADD D, F
ADC E, G

; Write register D to the Output Port
OUTB D

; Write register E to the Output Port
OUTB E

; Stops the CPU execution
HLT

; 31768d
DATA 1111111100000000b, 00011000b	; Low-Byte
DATA 1111111100000001b, 01111100b	; High-Byte