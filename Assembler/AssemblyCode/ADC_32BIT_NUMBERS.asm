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

; Initialize the D and E register with the 1st byte
MOV D, [Y]
MOV E, [Y + 4]
ADD D, E
PUSHF

; Write register D to the Output Port
OUTB D

; Initialize the D and E register with the 2nd byte
MOV D, [Y + 1]
MOV E, [Y + 5]
POPF
ADC D, E
PUSHF

; Write register D to the Output Port
OUTB D

; Initialize the D and E register with the 3rd byte
MOV D, [Y + 2]
MOV E, [Y + 6]
POPF
ADC D, E
PUSHF

; Write register D to the Output Port
OUTB D

; Initialize the D and E register with the 4th byte
MOV D, [Y + 3]
MOV E, [Y + 7]
POPF
ADC D, E

; Write register D to the Output Port
OUTB D

; Stops the CPU execution
HLT

; 1 094 967 296d
DATA 1111111100000000b, 00000000b	; 1st Byte
DATA 1111111100000001b, 11100000b	; 2nd Byte
DATA 1111111100000010b, 01000011b	; 3rd Byte
DATA 1111111100000011b, 01000001b	; 4th Byte

; 3 100 000 000d
DATA 1111111100000100b, 00000000b	; 1st Byte
DATA 1111111100000101b, 00111111b	; 2nd Byte
DATA 1111111100000110b, 11000110b	; 3rd Byte
DATA 1111111100000111b, 10111000b	; 4th Byte