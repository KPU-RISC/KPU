; Initialize the register "Y"
MOV XL, 0x00
MOV XH, 0xFF
MOV Y, X

; =============================
; Write some values to the RAM
; =============================

; Initial counter value - 0d
MOV D, 0

; End value - 5d
MOV E, 5

:FOR_LOOP_WRITE
MOV [Y + D], D
INC D

; Test if we have already reached the end value
CMP D, E

; Conditional Jump to the beginning for the FOR loop
; based on the Zero flag
JNZ :FOR_LOOP_WRITE

; =====================================
; Read the written values from the RAM
; =====================================

; Initial counter value - 0d
MOV D, 0

:FOR_LOOP_READ
MOV F, [Y + D]

; Write register F to the Output Port
OUTB F

INC D

; Test if we have already reached the end value
CMP D, E

; Conditional Jump to the beginning for the FOR loop
; based on the Zero flag
JNZ :FOR_LOOP_READ

; Stops the CPU execution
HLT