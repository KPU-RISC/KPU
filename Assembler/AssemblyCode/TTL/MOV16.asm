; Initialize the X register
; MOV XL, 11110000b
; MOV XH, 00001111b

MOV XL, 00001111b
MOV XH, 11110000b

; Move the content of the X register into the M register
MOV M, X