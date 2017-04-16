; ========================================================
; Calculates the sum of 9 + 8 + 7 + 6 + 5 + 4 + 3 + 2 + 1
; The result is stored in register E: 00101101b (45d)
; ========================================================

; The result is stored in register F
MOV E, 0

; Initial value
MOV D, 9

; Add the current value of register D to the result in register F
:LOOP
ADD E, D

; Decrement the value by one
DEC D

; Conditional Jump if the Zero-Flag from the ALU is not 1
JNZ :LOOP

; Write register F to the Output Port
; OUTB E

; Stops the CPU execution
; HLT