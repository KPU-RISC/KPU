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

; SHL the 1st byte
MOV D, [Y]
SHL D
PUSHF
MOV F, D

; Write register F to the Output Port
OUTB F

; RCL the 2nd byte
MOV E, [Y + 1]
POPF
RCL E
MOV F, E

; Write register F to the Output Port
OUTB F

; Stops CPU execution
HLT

DATA 1111111100000000b, 11010010b	; Low-Byte
DATA 1111111100000001b, 00000100b	; High-Byte

; High-Byte Low-Byte	Carry
; =======================================
; 00000100  11010010	0	Initial
; 00000100  10100100	1	After SHL
; 00001001  10100100	0	After RCL