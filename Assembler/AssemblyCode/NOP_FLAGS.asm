; Nothing should be seen in the flags register...

; Do nothing...
NOP
NOP
NOP

PUSHF
POP D

; Write register D to the Output Port
OUTB D

; Stops the CPU execution
HLT