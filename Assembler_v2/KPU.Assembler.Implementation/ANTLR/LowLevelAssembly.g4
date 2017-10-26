grammar LowLevelAssembly;

/* Entry Point */
program: (opcode | NEWLINE)+;

opcode:
	/* SET opcode */
	SET register_ab ',' '"' FourBitBinaryValue '"'								# SET					/* SET A, "1010" */
	| SET register_ab ',' '"' FourBitBinaryValue '"' JumpLabel int				# SET					/* SET A, "1010":JUMP_ADDRESS_MARKER */

	/* ALU IN/OUT opcodes */
	| MOV_ALU_IN register_ab ',' register_8bit									# MOV_ALU_IN			/* MOV_ALU_IN A, D */
	| MOV_ALU_OUT register_8bit													# MOV_ALU_OUT			/* MOV_ALU_OUT D */
	| MOV_ALU_C_TO_AB register_ab												# MOV_ALU_C_TO_AB		/* MOV_ALU_C_TO_AB A */

	/* ALU opcodes */
	| SHL																		# SHL					/* SHL */
	| SHR																		# SHR					/* SHR */
	| SAR																		# SAR					/* SAR */
	| RCL																		# RCL					/* RCL */
	| RCR																		# RCR					/* RCR */
	| OR																		# OR					/* OR */
	| ADD																		# ADD					/* ADD */
	| ADC																		# ADC					/* ADC */
	| SUB																		# SUB					/* SUB */
	| SBB																		# SBB					/* SBB */
	| XOR																		# XOR					/* XOR */
	| AND																		# AND					/* AND */
	| NOT																		# NOT					/* NOT */
	| NEG																		# NEG					/* NEG */
	| MOV8																		# MOV8					/* MOV8 */
	| NOP																		# NOP					/* NOP */
	| NOP JumpLabel																# NOP					/* NOP:JUMP_LABEL */

	/* MOV opcodes */
	| MOV register_8bit ',' register_8bit										# MOV					/* MOV D, E */
	| MOV16 register_16bit ',' register_16bit									# MOV16					/* MOV16 M, SP */

	/* LOAD/STORE opcodes */
	| LOAD register_8bit														# LOAD					/* LOAD D */
	| STORE register_8bit														# STORE					/* STORE D */

	/* FLAGS opcodes */
	| SAVE_FLAGS																# SAVE_FLAGS			/* SAVE_FLAGS */
	| RESTORE_FLAGS																# RESTORE_FLAGS			/* RESTORE_FLAGS */
	| FLAGS_TO_OUTBUFFER														# FLAGS_TO_OUTBUFFER	/* FLAGS_TO_OUTBUFFER */
	| STORE_FLAGS																# STORE_FLAGS			/* STORE_FLAGS */
	| INBUFFER_TO_FLAGS															# INBUFFER_TO_FLAGS		/* INBUFFER_TO_FLAGS */
	| LOAD_FLAGS																# LOAD_FLAGS			/* LOAD_FLAGS */

	/* 16-bit Adder opcodes */
	| BIT16_ADDER																# BIT16_ADDER			/* BIT16_ADDER */

	/* Jump opcodes */
	| 'NOP' JumpLabel															# JMP_LABEL				/* NOP:JUMPLABEL */
	| JMP JumpLabel																# JMP					/* JMP :JUMPLABEL */
	| JZ JumpLabel																# JZ					/* JZ :JUMPLABEL */
	| JNZ JumpLabel																# JNZ					/* JNZ :JUMPLABEL */
	| JNS JumpLabel																# JNS					/* JNS :JUMPLABEL */
	| JNC JumpLabel																# JNC					/* JNC :JUMPLABEL */
	| CALL JumpLabel															# CALL					/* CALL :JUMPLABEL */
	| RET																		# RET					/* RET */

	/* IN opcodes */
	| IN port_8bit																# IN					/* IN A */

	/* OUT opcodes */
	| OUT out_port_8bit															# OUT					/* OUT C */

	/* INT opcode */
	| INT																		# INT					/* INT */
	
	/* HLT opcode */
	| HLT																		# HLT					/* HLT */
	
	/* Data Section */
	| DATA SixteenBitBinaryValue ',' EightBitBinaryValue						# DATA					/* Data Section */
	
	/* BEGIN/END Macros... */
	| MACRO																		# MACRO					/* Macro */
	;

/* Opcode Token */
SET:				'SET';
HLT:				'HLT';
MOV_ALU_IN:			'MOV_ALU_IN';
MOV_ALU_OUT:		'MOV_ALU_OUT';
MOV_ALU_C_TO_AB:	'MOV_ALU_C_TO_AB';
SHL:				'SHL';
SHR:				'SHR';
SAR:				'SAR';
RCL:				'RCL';
RCR:				'RCR';
OR:					'OR';
ADD:				'ADD';
ADC:				'ADC';
SUB:				'SUB';
SBB:				'SBB';
XOR:				'XOR';
AND:				'AND';
NOT:				'NOT';
NEG:				'NEG';
MOV8:				'MOV8';
NOP:				'NOP';
MOV:				'MOV';
MOV16:				'MOV16';
LOAD:				'LOAD';
STORE:				'STORE';
SAVE_FLAGS:			'SAVE_FLAGS';
RESTORE_FLAGS:		'RESTORE_FLAGS';
FLAGS_TO_OUTBUFFER:	'FLAGS_TO_OUTBUFFER';
STORE_FLAGS:		'STORE_FLAGS';
BIT16_ADDER:		'16BIT_ADDER';
INBUFFER_TO_FLAGS:	'INBUFFER_TO_FLAGS';
LOAD_FLAGS:			'LOAD_FLAGS';
JMP:				'JMP';
JZ:					'JZ';
JNS:				'JNS';
JNZ:				'JNZ';
JNC:				'JNC';
CALL:				'CALL';
RET:				'RET';
IN:					'IN';
OUT:				'OUT';
INT:				'INT';
DATA:				'DATA';

/* Register Rules */
register_8bit:	REG_8BIT;
register_16bit: REG_16BIT;
register_ab:	REG_AB;
out_port_8bit:	OUT_PORT_8BIT;
port_8bit:		PORT_8BIT;
plus_sign:		PLUS_SIGN;
minus_sign:		MINUS_SIGN;
int:			NUMBER;

/* Register Token */
REG_8BIT  :			'D' | 'E' | 'F' | 'G' | 'H' | 'XL' | 'XH';
REG_16BIT :			'J' | 'M' | 'SP' | 'BP' | 'X' | 'Y' | 'Z' | 'PC';
REG_AB:				'A' | 'B';
PORT_8BIT:			'A' | 'B';
OUT_PORT_8BIT :		'C' | 'D';

/* Arithmetic Token */
PLUS_SIGN	: '+';
MINUS_SIGN	: '-';

/* Other Token */
FourBitBinaryValue: BinaryDigit BinaryDigit BinaryDigit BinaryDigit;
EightBitBinaryValue: BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit 'b';
SixteenBitBinaryValue: BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit 'b';
HexValue: HexDigit HexDigit;
JumpLabel: ':' String+;
fragment BinaryDigit:	[01];
fragment HexDigit:		[0-9a-fA-F];
fragment String:		[a-zA-Z_];
NUMBER: [0-9]+;
WS  : [\t\r\n' ']+ -> skip;
MACRO: ';;' ~[\r\n]*;