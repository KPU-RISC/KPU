MOV D, 00001111b
MOV E, 00000001b

:START
SUB D, E

; Conditional Jump if the Zero-Flag from the ALU is 1
JNZ :START

; FINISH
MOV D, 10101010b
MOV E, 01010101b

; Stops the CPU execution
HLT