; Initialize the stack pointer and the base pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X
MOV XL, 0
MOV XH, 0
MOV BP, X

; Perform an addition
; Carry-Flag is not set
MOV D, 5
MOV E, 3
ADD D, E
PUSHF

; Perform an addition
; Carry-Flag is set
MOV D, 11111110b
MOV E, 3
ADD D, E
PUSHF

; Perform a subtraction
; Carry-Flag is not set
MOV D, 5
MOV E, 3
SUB D, E
PUSHF

; Perform a subtraction
; Carry-Flag is set
MOV D, 3
MOV E, 5
SUB D, E
PUSHF

; Pop the flags from the stack
POP G	; Carry is set

; Write register G to the Output Port
OUTB G

POP G	; Carry is not set

; Write register G to the Output Port
OUTB G

POP G	; Carry is set

; Write register G to the Output Port
OUTB G

POP G	; Carry is not set

; Write register G to the Output Port
OUTB G

HLT