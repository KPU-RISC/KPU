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

; SHR the high byte
MOV D, [Y + 1]
SHR D
PUSHF
MOV F, D

; Write register F to the Output Port
OUTB F

; RCR the low byte
MOV E, [Y]
POPF
RCR E
MOV F, E

; Write register F to the Output Port
OUTB F

; Stops CPU execution
HLT

DATA 1111111100000000b, 11010010b	; Low-Byte
DATA 1111111100000001b, 00000101b	; High-Byte

; High-Byte Low-Byte	Carry
; =======================================
; 00000101  11010010	0	Initial
; 00000010  11010010	1	After SHR
; 00000010  11101001	0	After RCR