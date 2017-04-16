; Initial value
MOV D, 4

; Decrement D
:LOOP
DEC D

; Conditional Jump if the Zero-Flag from the ALU is not 1
; The jump goes to the instruction "DEC D"
JNZ :LOOP

; Write register D to the Output Port
OUTB D

; Stops the CPU execution
HLT