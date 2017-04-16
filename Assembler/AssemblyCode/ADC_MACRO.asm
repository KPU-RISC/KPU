:START

MOV XL, 0xAB
MOV XH, 0xFF
MOV Y, X

; Initialize the D and E registers
MOV D, [Y]		; 253d
MOV E, 01100100b	; 100d
ADD D, E

; Write register D to the Output Port
OUTB D

JNC :DONE
MOV D, [Y + 1]
MOV E, 00000001b	; Carry Bit
ADD D, E

; Write register D to the Output Port
OUTB D

:DONE

; Stops the CPU execution
HLT

DATA 1111111110101011b, 11111101b	; 253d
DATA 1111111110101100b, 00000000b