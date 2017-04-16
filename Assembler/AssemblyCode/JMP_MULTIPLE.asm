MOV D, 0
MOV E, 1

; Just jump over the next line
JMP :NEW
ADD D, E

:NEW
MOV E, 2

:ADD
ADD D, E

; Jump back
JMP :ADD

HLT