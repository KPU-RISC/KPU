; =====================================================
; This subroutine performs a multiplication between
; 2 8-bit values and stores the result in register "D"
; =====================================================
:_MUL
; We need 1 local variable for the bit mask
ENTER 1

; Initial counter value - 0d
MOV G, 0

; End value - 8d
MOV H, 8

; ; Bit Mask for the current bit to multiply
MOV [BP - 1], 00000001b

; Push the intermediate result of the addition onto the stack
; The initial value is just a zero.
MOV D, 0
PUSH D

; 1. This loop is performed 8 times - for every bit once
:MUL_AND_LOOP

; 2. Load the values from the RAM into the registers (input parameter value)
MOV D, [BP + 4]

; Load the register "E" (input parameter value)
MOV E, [BP + 5]

; Load the register "F" with the bit mask (local variable)
MOV F, [BP - 1]

; 3. Extract the current bit to be multiplied
AND F, E

; 4. Check if we have a "0" or "1" in the current bit
MOV E, 0
CMP F, E

JZ :MUL_ZERO_VALUE

MOV E, 11111111b

:MUL_ZERO_VALUE

; 5. Perform the AND for the multiplication
AND D, E

; 6. Shift the bit mask in register "F" 1 bit to the left
MOV F, [BP - 1]
SHL F
MOV [BP - 1], F

; 7. SHL Loop
; This loop performs a SHL operation multiple times, based on which bit position
; is currently processed.
; The current bit position is based on the register G, which is the loop counter
; of the outer loop "MUL_AND_LOOP".
MOV E, 0

:MUL_SHL_LOOP
CMP E, G
JZ :MUL_EXIT_SHL_LOOP

SHL D
INC E
JMP :MUL_SHL_LOOP

:MUL_EXIT_SHL_LOOP

; 8. Perform the addition to the intermediate result that is currently stored
; on the stack. The result of the addition is pushed back onto the stack.
; Therefore we can use it as a base for the next loop iteration.
POP F
ADD F, D
PUSH F

; 9. Test if we have already reached the end value of the outer loop "MUL_AND_LOOP"
INC G
CMP G, H

; 10. Conditional Jump to the beginning of the loop "MUL_AND_LOOP"
; based on the Zero flag
JNZ :MUL_AND_LOOP

; The result of the multiplication is finally stored in the register "D"
POP D

; Return from MUL...
LEAVE
RET

; ==========================================================
; This function performs a division between 2 8-bit numbers.
; The Quotient is stored in register "D" and the remainder
; is stored in register "E".
; ==========================================================
:_DIV
ENTER 0

; Dividend
MOV E, [BP + 5]

; Divisor
MOV F, [BP + 4]

; Quotient
MOV D, 0

:DIV_LOOP
INC D

SUB E, F
JNS :DIV_LOOP

; Register "D" constains the Quotient
DEC D

; Register "E" contains the Remainder
ADD E, F

LEAVE
RET

; ====================================================
; This subroutine reads characters from Input Port A
; until we receive the ASCII code for CRLF...
; ====================================================
:_SCANF
ENTER 0

; Access the input parameter values - the memory address
; where the received string should be stored
MOV D, [BP + 4]
MOV E, [BP + 5]
MOV XH, D
MOV XL, E
MOV Y, X

; Character counter
MOV H, 0

:SCANF_READ_NEXT_CHAR
CALL :_GETCHAR

; The read character is stored in register "F"
MOV F, D
MOV [Y + H], F	; Store the read character in memory
INC H

MOV G, 00001101b ; Binary value for CRLF ASCII code
CMP G, F
JNZ :SCANF_READ_NEXT_CHAR

; Null-terminate the string in memory
MOV F, 00000000b
DEC H
MOV [Y + H], F

; Return the number of read characters in register "D"
INC H
MOV D, H

; Return from the SCANF subroutine
LEAVE
RET

; ====================================================
; This subroutine reads a character from Input Port A
; and stores the read value in register "D"
; ====================================================
:_GETCHAR
ENTER 0
; Wait until the Ready-Bit is set at Input Port B
:GETCHAR_WAIT_FOR_READY_BIT
IN B
MOV D, XL
MOV E, 00000001b
; OLD: AND D, E
CMP D, E
; OLD: JZ :GETCHAR_WAIT_FOR_READY_BIT
JNZ :GETCHAR_WAIT_FOR_READY_BIT

; Retrieve the input from Input Port A and process it
IN A

; Store the result of the function call in register "D"
MOV D, XL

; Acknowledge the requested data by setting/resetting the ACK bit
MOV XL, 00000001b
OUT D
MOV XL, 00000000b
OUT D

; Return from the GETCHAR subroutine
LEAVE
RET

; =======================================================
; This subroutine sends characters from the given memory 
; address into the Output Port C until
; we read the ASCII code for NUL...
; =======================================================
:_PRINTF
ENTER 0

; Access the input parameter values - the memory address
; from which the null-terminated string should be printed.
MOV D, [BP + 4]
MOV E, [BP + 5]
MOV XH, D
MOV XL, E
MOV Y, X

; Character counter
MOV H, 0

:PRINTF_GET_NEXT_CHAR
MOV D, [Y + H]

; Check if we have reached the end of the null-terminated string
MOV E, 00000000b ; Binary value for NUL ASCII code
CMP D, E
JNZ :PRINTF_VALUE

MOV XL, 00001101b	; ASCII code for CRLF
OUT C

; Signal the listener that new data is available on Output Port C
MOV XL, 00000010b
OUT D
MOV XL, 00000000b
OUT D

JMP :PRINTF_FINAL

:PRINTF_VALUE
MOV XL, D
OUT C	; Write the current character to the Output Port C

; Signal the listener that new data is available on Output Port C
MOV XH, XL ; Save the register XL in XH
MOV XL, 00000010b
OUT D
MOV XL, 00000000b
OUT D
MOV XL, XH ; Restore the register XL from XH

INC H

; Read the next character
JMP :PRINTF_GET_NEXT_CHAR

; Return the number of printed characters in register "D"
:PRINTF_FINAL
MOV D, H

; Return from the PRINTF subroutine
LEAVE
RET

; =======================================================
; This subroutine converts an ASCII number to an integer
; value.
; =======================================================
:_ATOI
ENTER 0

; Store the start address of the string in register "Y"
MOV D, [BP + 4]
MOV E, [BP + 5]
MOV XH, D
MOV XL, E
MOV Y, X

; Counter loop variable
MOV D, 0

; End value
MOV E, [BP + 6]
DEC E

; The following loop clears the 4th and 5th bit from the ASCII code
:ATOI_CLEAR_BITS_LOOP

; Clear the 4th and 5th bit from the ASCII code to get the integer value
MOV F, [Y + D]
MOV XL, 00110000b
XOR F, XL

; Store the changed ASCII code
MOV [Y + D], F

; Increment the loop counter
INC D

; Check if we have already reached the end of the loop
CMP D, E

; The following loop multiplies in each loop the value with 10 and
; adds the current integer value
JNZ :ATOI_CLEAR_BITS_LOOP

; Start value
MOV D, 0

; End value
MOV E, [BP + 6]
DEC E

; Accumulated value
MOV G, 0

:ATOI_MULTIPLY

; Store the current ASCII code in register "F"
MOV F, [Y + D]

; ==================
; BEGIN CALL MUL...
; G = G * 10
; ==================

; Save the registers onto the stack
PUSH D
PUSH E
PUSH F
PUSH H

; Push the function arguments onto the stack and call MUL
PUSH G
PUSH 00001010b	; 10d
CALL :_MUL

; Store the result of the multiplication in register "G"
MOV G, D

; Remove the arguments from the stack frame
ADD SP, 2

; Restore the registers from the stack
POP H
POP F
POP E
POP D

; ==================
; END CALL MUL...
; ==================

; Add the current integer value
ADD G, F

; Decrement the loop counter
INC D

; Check if we have already reached the end of the loop
CMP D, E

JNZ :ATOI_MULTIPLY

; Store the result of ATOI in register "D"
MOV D, G

; Return from ATOI
LEAVE
RET

; ====================================================================
; This function converts an integer into a ASCII encoded string and
; stores the string at the specified memory location null-terminated.
; ====================================================================
:_ITOA
ENTER 0

; Retrieve the input parameter value
MOV F, [BP + 4]		; Integer to convert
MOV D, [BP + 5]
MOV E, [BP + 6]
MOV XH, D
MOV XL, E
MOV Y, X		; Memory address of the string buffer

MOV H, 0

; Character counter
MOV E, 0

:ITOA_LOOP

; ==================
; BEGIN DIV CALL...
; ==================
; Save the registers onto the stack
PUSH E
PUSH F
PUSH G
PUSH H

PUSH F
PUSH 00001010b 	; 10d
CALL :_DIV

; Remove the argument from the stack frame
ADD SP, 2

; Restore the saved registers from the stack
POP H
POP G
POP F

; ================
; END DIV CALL...
; ================

; Move the remainder into register "G"
; and add 0x30 to get the ASCII code
MOV G, E
MOV E, 0x30
ADD G, E

; Restore the saved register from the stack and increment it
POP E
INC E

PUSH G

; Move the Quotient into register "F"
MOV F, D

CMP F, H
JNZ :ITOA_LOOP

MOV F, 0

; This loop returns the ASCII codes from the stack
:ITOA_GETCHARACTERS

POP G
MOV [Y + F], G

INC F
DEC E
CMP E, H
JNZ :ITOA_GETCHARACTERS

; Null-terminate the string
MOV [Y + F], 0

; Return from ITOA
LEAVE
RET