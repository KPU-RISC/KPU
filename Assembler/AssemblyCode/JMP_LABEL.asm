; Initialize the stack pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X

; Increment value
MOV E, 1

; Initial value
MOV D, 1
PUSH D

:LOOP
POP D

; Perform the ADD and store the result
; on the stack
ADD D, E
PUSH D

; Jump back to the "POP D" instruction
JMP :LOOP

HLT