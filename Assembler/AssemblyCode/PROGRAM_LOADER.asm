; Disk Service: 1 = Read
MOV D, 1

; Sector Index
MOV E, 0

; Number of Sectors to read
MOV F, 1

; Initialize the Destination Memory Address
MOV XL, 11000000b
MOV XH, 0x00
MOV Y, X

; Raise Interrupt 1 - we want to access the hard disk
INT 1

; Jump to the address where we have loaded the code.
; This destination address must be fixed in the generated code (=> 1100 0000)...
JMP :PLACEHOLDER

:PLACEHOLDER