; Initialize the X register
MOV XL, 11110000b
MOV XH, 11111101b

; Move the content of the X register between the various registers
MOV M, X
MOV J, M
MOV SP, J
MOV BP, SP
MOV Y, BP
MOV Z, Y