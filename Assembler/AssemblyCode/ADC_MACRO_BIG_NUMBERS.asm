MOV XL, 0x00
MOV XH, 0xFF
MOV Y, X

; Initialize the D and E register with the lower byte
MOV D, [Y]			; Low-Byte
MOV E, [Y + 2]		; Low-Byte
ADD D, E

JNC :DONE
MOV F, D			; Store the partial sum (Low-Byte)
MOV D, [Y + 1]		; High-Byte
MOV E, 00000001b	; Carry Bit
ADD D, E
MOV E, [Y + 3]		; High-Byte
ADD D, E
MOV G, D			; Store the partial sum (High-Byte)

:DONE

; Write register F to the Output Port
OUTB F

; Write register G to the Output Port
OUTB G

; Stops the CPU execution
HLT

; 1234d
DATA 1111111100000000b, 11010010b	; Low-Byte
DATA 1111111100000001b, 00000100b	; High-Byte

; 4321d
DATA 1111111100000010b, 11100001b	; Low-Byte
DATA 1111111100000011b, 00010000b	; High-Byte