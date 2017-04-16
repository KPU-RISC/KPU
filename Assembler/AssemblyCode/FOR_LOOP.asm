; Initial counter value - 0d
MOV D, 0

; End value - 5d
MOV E, 5

:FOR_LOOP
INC D

; Test if we have already reached the end value
CMP D, E

; Conditional Jump to the beginning for the FOR loop
; based on the Zero flag
JNZ :FOR_LOOP

; Write register D to the Output Port
OUTB D

; Stops the CPU execution
HLT