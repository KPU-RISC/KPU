MOV D, 00000100b
MOV E, 00000001b

:START
SUB D, E

; Conditional Jump if the Zero-Flag from the ALU is 1
JNZ :START

; Stops the CPU execution
HLT