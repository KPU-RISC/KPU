:START
MOV D, 11111111b
MOV E, 00000001b
ADD D, E

; Conditional Jump if the Carry-Flag from the ALU is 0
JNC :START

; Write register F to the Output Port
MOV F, 0
OUTB F

; Stops the CPU execution
HLT