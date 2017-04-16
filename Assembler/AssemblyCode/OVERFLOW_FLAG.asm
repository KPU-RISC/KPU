; Initialize the stack pointer and the base pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X
MOV XL, 0
MOV XH, 0
MOV BP, X

; Perform an addition
; Overflow-Flag is not set
MOV D, 01100100b	;100d
MOV E, 00010100b	;20d
ADD D, E
PUSHF

; Perform an addition
; Overflow-Flag is set
MOV D, 01010000b	; 80d
MOV E, 01010000b	; 80d
ADD D, E
PUSHF

; Perform a subtraction
; Overflow-Flag is not set
MOV D, 01010000b	; 80d
MOV E, 00110000b	; 48d
SUB D, E
PUSHF

; Perform a subtraction
; Overflow-Flag is set
MOV D, 01010000b	;  80d
MOV E, 10110000b	; -80d
SUB D, E
PUSHF

; Perform a subtraction
; Overflow-Flag is not set
MOV D, 11010000b	; -48d
MOV E, 10110000b	; -80d
SUB D, E
PUSHF

; Perform a subtraction
; Overflow-Flag is set
MOV D, 11010000b	; -48d
MOV E, 01110000b	; 112d
SUB D, E
PUSHF

; Write the register G to the Output Port C
POP G	; Overflow is set
OUTB G

; Write the register G to the Output Port C
POP G	; Overflow is not set
OUTB G

; Signal the listener that new data is available on Output Port C
POP G	; Overflow is set
OUTB G

; Write the register G to the Output Port C
POP G	; Overflow is not set
OUTB G

; Write the register G to the Output Port C
POP G	; Overflow is set
OUTB G

; Write the register G to the Output Port C
POP G	; Overflow is not set
OUTB G

HLT