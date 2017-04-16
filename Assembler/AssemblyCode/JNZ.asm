:START
MOV D, 00000100b
MOV E, 00000100b
SUB D, E

; Conditional Jump if the Zero-Flag from the ALU is 0
JNZ :START

; Write register F to the Output Port
MOV F, 0
OUTB F

; Stops the CPU execution
HLT