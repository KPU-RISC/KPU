; Initialize the stack pointer and the base pointer
MOV XL, 0xFF
MOV XH, 0xFF
MOV SP, X
MOV XL, 0
MOV XH, 0
MOV BP, X

CALL :MAIN
HLT

:MAIN
; Emit the prologue and reserve 3 bytes for local variables on the stack
ENTER 1

; Push the function arguments onto the stack
MOV D, 5
PUSH D
MOV D, 4
PUSH D

; Call the funtion ADDER - the result is stored in register "D"
; int result = ADDER(4, 5);
CALL :ADDER

; Remove the arguments from the stack frame
ADD SP, 2

; Write register D to the Output Port
OUTB D

; Return from the function MAIN...
LEAVE
RET

:ADDER
; Emit the prologue and reserve 10 bytes for local variables on the stack
ENTER 10

; Access the input parameter values that were pushed onto the stack
MOV E, [BP + 4]		; 1st input parameter value "4"
MOV F, [BP + 5]		; 2nd input parameter value "5"
ADD E, F

; Store the result as a local variable on the stack
MOV [BP - 1], E

; Store the return value in the register "D"
MOV D, E

; Return from the function ADDER...
LEAVE
RET