;; BEGIN INT 00000001
SET A, "0001"
SET B, "0000"
MOV8
MOV_ALU_OUT XL
INT
;; END INT 00000001
;; BEGIN MOV XL, 10000000b (MOV_CONST_BINARY)
SET A, "0000"
SET B, "1000"
MOV8
MOV_ALU_OUT XL
;; END MOV XL, 10000000b (MOV_CONST_BINARY)
;; BEGIN MOV XH, 0x00 (MOV_CONST_HEX1)
SET A, "0000"
SET B, "0000"
MOV8
MOV_ALU_OUT XH
;; END MOV XH, 0x00 (MOV_CONST_HEX1)
;; BEGIN MOV16 J, X (MOV16)
MOV16 J, X
;; END MOV16 J, X (MOV16)
;; BEGIN MOV D, [J] (MOV_I_R8_16)
MOV16 M, J
LOAD D
;; END MOV D, [J] (MOV_I_R8_16)
;; BEGIN MOV XL, D (MOV_R8_R8)
MOV XL, D
;; END MOV XL, D (MOV_R8_R8)
OUT C
;; BEGIN MOV XL, 10000001b (MOV_CONST_BINARY)
SET A, "0001"
SET B, "1000"
MOV8
MOV_ALU_OUT XL
;; END MOV XL, 10000001b (MOV_CONST_BINARY)
;; BEGIN MOV XH, 0x00 (MOV_CONST_HEX1)
SET A, "0000"
SET B, "0000"
MOV8
MOV_ALU_OUT XH
;; END MOV XH, 0x00 (MOV_CONST_HEX1)
;; BEGIN MOV16 J, X (MOV16)
MOV16 J, X
;; END MOV16 J, X (MOV16)
;; BEGIN MOV D, [J] (MOV_I_R8_16)
MOV16 M, J
LOAD D
;; END MOV D, [J] (MOV_I_R8_16)
;; BEGIN MOV XL, D (MOV_R8_R8)
MOV XL, D
;; END MOV XL, D (MOV_R8_R8)
OUT C
;; BEGIN MOV XL, 10000010b (MOV_CONST_BINARY)
SET A, "0010"
SET B, "1000"
MOV8
MOV_ALU_OUT XL
;; END MOV XL, 10000010b (MOV_CONST_BINARY)
;; BEGIN MOV XH, 0x00 (MOV_CONST_HEX1)
SET A, "0000"
SET B, "0000"
MOV8
MOV_ALU_OUT XH
;; END MOV XH, 0x00 (MOV_CONST_HEX1)
;; BEGIN MOV16 J, X (MOV16)
MOV16 J, X
;; END MOV16 J, X (MOV16)
;; BEGIN MOV D, [J] (MOV_I_R8_16)
MOV16 M, J
LOAD D
;; END MOV D, [J] (MOV_I_R8_16)
;; BEGIN MOV XL, D (MOV_R8_R8)
MOV XL, D
;; END MOV XL, D (MOV_R8_R8)
OUT C
HLT