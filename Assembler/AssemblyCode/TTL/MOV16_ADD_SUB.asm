; Increment and decrement the XL/XH register
MOV D, 00000001b
ADD XL, D
SUB XH, D

; Move the content of the X register into the M register
MOV M, X