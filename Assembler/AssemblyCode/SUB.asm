; Load the initial values into register D and E
MOV D, 5
MOV E, 3

; Perform a subtraction
SUB D, E

MOV F, D

; Write register F to the Output Port
OUTB F

HLT