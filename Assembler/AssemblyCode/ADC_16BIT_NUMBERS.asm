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

; Initialize the D and E register with the lower byte
MOV D, [Y]		; Low-Byte
MOV E, [Y + 2]		; Low-Byte
ADD D, E
PUSHF

; Write register D to the Output Port
OUTB D

; Initialize the D and E register with the higher byte
MOV D, [Y + 1]		; High-Byte
MOV E, [Y + 3]		; High-Byte
POPF
ADC D, E

; Write register D to the Output Port
OUTB D

; Stops the CPU execution
HLT

; 1234d
DATA 1111111100000000b, 11010010b	; Low-Byte
DATA 1111111100000001b, 00000100b	; High-Byte

; 4321d
DATA 1111111100000010b, 11100001b	; Low-Byte
DATA 1111111100000011b, 00010000b	; High-Byte