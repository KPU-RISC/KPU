grammar HighLevelAssembly;

/* Entry Point */
program: (opcode | NEWLINE)+;

/* Opcode Rules */
/*	Naming convention:
	=> "I":		Indirect Addressing
	=> "IPO":	Indirect Addressing - positive Offset
	=> "IPRO":	Indirect Addressing - positive Register Offset
	=> "INO":	Indirect Addressing - negative Offset
	=> "INRO":	Indirect Addressing - negative Register Offset
*/

opcode: 
		/* MOV opcodes for 8-bit registers */
		  MOV register_8bit ',' register_8bit	  											# MOV_R8_R8						/* MOV D, E */
		| MOV register_8bit ','  '[' register_16bit ']'										# MOV_I_R8_R16					/* MOV D, [SP] */
		| MOV register_8bit ','  '[' register_16bit plus_sign int ']'						# MOV_IPO_R8_R16				/* MOV D, [SP + 1] */
		| MOV register_8bit ','  '[' register_16bit plus_sign register_8bit ']'				# MOV_IPRO_R8_R16				/* MOV D, [SP + G] */
		| MOV register_8bit ','  '[' register_16bit minus_sign int ']'						# MOV_INO_R8_R16				/* MOV D, [SP - 1] */
		| MOV register_8bit ','  '[' register_16bit minus_sign register_8bit ']'			# MOV_INRO_R8_R16				/* MOV D, [SP - G] */
		
		| MOV register_8bit ',' int															# MOV_CONST_DECIMAL				/* MOV D, 4 */		
		| MOV register_8bit ',' EightBitBinaryValue											# MOV_CONST_BINARY				/* MOV D, 10101010 */
		| MOV register_8bit ',' '0x' HexValue												# MOV_CONST_HEX1				/* MOV D, 0xAB */
		| MOV register_8bit ',' HexValue 'h'												# MOV_CONST_HEX2				/* MOV D, ABh */

		| MOV '[' register_16bit plus_sign int ']' ',' register_8bit						# MOV_IPO_R16_R8				/* MOV [SP + 1], D */
		| MOV '[' register_16bit plus_sign int ']' ',' int									# MOV_IPO_R16_CONST_DECIMAL		/* MOV [SP + 1], 3 */
		| MOV '[' register_16bit plus_sign int ']' ',' EightBitBinaryValue					# MOV_IPO_R16_CONST_BINARY		/* MOV [SP + 1], 10101010b */
		| MOV '[' register_16bit plus_sign int ']' ',' '0x' HexValue						# MOV_IPO_R16_CONST_HEX1		/* MOV [SP + 1], 0xAB */
		| MOV '[' register_16bit plus_sign int ']' ',' HexValue 'h'							# MOV_IPO_R16_CONST_HEX2		/* MOV [SP + 1], ABh */

		| MOV '[' register_16bit plus_sign register_8bit ']' ',' register_8bit				# MOV_IPRO_R16_R8				/* MOV [SP + G], D */
		| MOV '[' register_16bit plus_sign register_8bit ']' ',' int						# MOV_IPRO_R16_CONST_DECIMAL	/* MOV [SP + G], 3 */
		| MOV '[' register_16bit plus_sign register_8bit ']' ',' EightBitBinaryValue		# MOV_IPRO_R16_CONST_BINARY		/* MOV [SP + G], 10101010b */
		| MOV '[' register_16bit plus_sign register_8bit ']' ',' '0x' HexValue				# MOV_IPRO_R16_CONST_HEX1		/* MOV [SP + G], 0xAB */
		| MOV '[' register_16bit plus_sign register_8bit ']' ',' HexValue 'h'				# MOV_IPRO_R16_CONST_HEX2		/* MOV [SP + G], ABh */

		| MOV '[' register_16bit minus_sign int ']' ',' register_8bit						# MOV_INO_R16_R8				/* MOV [SP - 1], D */
		| MOV '[' register_16bit minus_sign int ']' ',' int									# MOV_INO_R16_CONST_DECIMAL		/* MOV [SP - 1], 3 */
		| MOV '[' register_16bit minus_sign int ']' ',' EightBitBinaryValue					# MOV_INO_R16_CONST_BINARY		/* MOV [SP - 1], 10101010b */
		| MOV '[' register_16bit minus_sign int ']' ',' '0x' HexValue						# MOV_INO_R16_CONST_HEX1		/* MOV [SP - 1], 0xAB */
		| MOV '[' register_16bit minus_sign int ']' ',' HexValue 'h'						# MOV_INO_R16_CONST_HEX2		/* MOV [SP - 1], ABh */

		| MOV '[' register_16bit minus_sign register_8bit ']' ',' register_8bit				# MOV_INRO_R16_R8				/* MOV [SP - G], D */
		| MOV '[' register_16bit minus_sign register_8bit ']' ',' int						# MOV_INRO_R16_CONST_DECIMAL	/* MOV [SP - G], 3 */
		| MOV '[' register_16bit minus_sign register_8bit ']' ',' EightBitBinaryValue		# MOV_INRO_R16_CONST_BINARY		/* MOV [SP - G], 10101010b */
		| MOV '[' register_16bit minus_sign register_8bit ']' ',' '0x' HexValue				# MOV_INRO_R16_CONST_HEX1		/* MOV [SP - G], 0xAB */
		| MOV '[' register_16bit minus_sign register_8bit ']' ',' HexValue 'h'				# MOV_INRO_R16_CONST_HEX2		/* MOV [SP - G], ABh */

		| MOV '[' register_16bit ']' ',' register_8bit										# MOV_I_R16_R8					/* MOV [SP], D */
		| MOV '[' register_16bit ']' ',' int												# MOV_I_R16_CONST_DECIMAL		/* MOV [SP], 3 */
		| MOV '[' register_16bit ']' ',' EightBitBinaryValue								# MOV_I_R16_CONST_BINARY		/* MOV [SP], 10101010b */
		| MOV '[' register_16bit ']' ',' '0x' HexValue										# MOV_I_R16_CONST_HEX1			/* MOV [SP], 0xAB */
		| MOV '[' register_16bit ']' ',' HexValue 'h'										# MOV_I_R16_CONST_HEX2			/* MOV [SP], ABh */
		
		/* MOV opcodes for 16-bit registers */
		| MOV register_16bit ',' register_16bit												# MOV16							/* MOV M, J */

		/* ADD opcodes */
		| ADD register_8bit ',' register_8bit												# ADD_R8_R8						/* ADD D, E */
		| ADD register_16bit ',' int														# ADD_R16_CONST					/* ADD SP, 3 *
		
		/* ADC opcodes */
		| ADC register_8bit ',' register_8bit												# ADC_R8_R8						/* ADC D, E *//

		/* AND opcodes */
		| AND register_8bit ',' register_8bit												# AND_R8_R8						/* AND D, E */

		/* OR opcodes */
		| OR register_8bit ',' register_8bit												# OR_R8_R8						/* OR D, E */

		/* XOR opcodes */
		| XOR register_8bit ',' register_8bit												# XOR_R8_R8						/* XOR D, E */

		/* SHL opcodes */
		| SHL register_8bit																	# SHL_R8						/* SHL D */

		/* SHR opcodes */
		| SHR register_8bit																	# SHR_R8						/* SHR D */

		/* SAR opcodes */
		| SAR register_8bit																	# SAR_R8						/* SAR D */

		/* RCL opcodes */
		| RCL register_8bit																	# RCL_R8						/* RCL D */

		/* RCR opcodes */
		| RCR register_8bit																	# RCR_R8						/* RCR D */

		/* NOT opcodes */
		| NOT register_8bit																	# NOT_R8						/* NOT D */

		/* NEG opcodes */
		| NEG register_8bit																	# NEG_R8						/* NEG D */

		/* INC opcodes */
		| INC register_8bit																	# INC_R8						/* INC D */

		/* DEC opcodes */
		| DEC register_8bit																	# DEC_R8						/* DEC D */

		/* SUB opcodes */
		| SUB register_8bit	',' register_8bit												# SUB_R8_R8						/* SUB D, E */
		| SUB register_16bit ',' int														# SUB_R16_CONST					/* SUB SP, 3 */

		/* SBB opcodes */
		| SBB register_8bit	',' register_8bit												# SBB_R8_R8						/* SBB D, E */

		/* CMP opcodes */
		| CMP register_8bit	',' register_8bit												# CMP_R8_R8						/* CMP D, E */

		/* PUSH opcodes */
		| PUSH register_8bit																# PUSH_R8						/* PUSH D */
		| PUSH register_16bit																# PUSH_R16						/* PUSH BP */
		| PUSH EightBitBinaryValue															# PUSH_CONST_BINARY				/* PUSH 10101010b */
		| PUSH int																			# PUSH_CONST_DECIMAL			/* PUSH 5 */
		| PUSH '0x' HexValue																# PUSH_CONST_HEX1				/* PUSH 0xAB */
		| PUSH HexValue 'h'																	# PUSH_CONST_HEX2				/* PUSH ABh */

		/* POP opcodes */
		| POP register_8bit																	# POP_R8						/* POP D */
		| POP register_16bit																# POP_R16						/* POP BP */

		/* PUSHF opcodes */
		| PUSHF																				# PUSHF							/* PUSHF */

		/* POPF opcodes */
		| POPF																				# POPF							/* POPF */

		/* ENTER/LEAVE opcodes */
		| ENTER int																			# ENTER							/* ENTER 3 */
		| LEAVE																				# LEAVE							/* LEAVE */

		/* Jump opcodes */
		| JumpLabel																			# JMP_LABEL						/* :JUMPLABEL */
		| JMP JumpLabel																		# JMP							/* JMP :JUMPLABEL */
		| JZ JumpLabel																		# JZ							/* JZ :JUMPLABEL */
		| JNZ JumpLabel																		# JNZ							/* JNZ :JUMPLABEL */
		| JNS JumpLabel																		# JNS							/* JNS :JUMPLABEL */
		| JNC JumpLabel																		# JNC							/* JNC :JUMPLABEL */
		| CALL JumpLabel																	# CALL							/* CALL :JUMPLABEL */
		| RET																				# RET							/* RET */

		/* IN opcodes */
		| IN port_8bit																		# IN							/* IN A */

		/* OUT opcodes */
		| OUT out_port_8bit																	# OUT							/* OUT C */
		| OUTB register_8bit																# OUTB							/* OUTB C */

		/* INT opcode */
		| INT int																			# INT							/* INT */

		/* NOP opcodes */
		| NOP																				# NOP							/* NOP */

		/* HLT opcode */
		| HLT																				# HLT							/* HLT */

		/* Data Section */
		| DATA SixteenBitBinaryValue ',' EightBitBinaryValue								# DATA							/* Data Section */
		;
		   
/* Register Rules */
register_8bit:	REG_8BIT;
register_16bit: REG_16BIT;
port_8bit:		PORT_8BIT;
out_port_8bit:	OUT_PORT_8BIT;
plus_sign:		PLUS_SIGN;
minus_sign:		MINUS_SIGN;
int:			NUMBER;

/* Opcode Token */
MOV:	'MOV';
ADD:	'ADD';
ADC:	'ADC';
AND:	'AND';
OR:		'OR';
XOR:	'XOR';
SHL:	'SHL';
SHR:	'SHR';
SAR:	'SAR';
RCL:	'RCL';
RCR:	'RCR';
NOT:	'NOT';
NEG:	'NEG';
INC:	'INC';
DEC:	'DEC';
SUB:	'SUB';
SBB:	'SBB';
CMP:	'CMP';
PUSH:	'PUSH';
POP:	'POP';
PUSHF:	'PUSHF';
POPF:	'POPF';
JMP:	'JMP';
JZ:		'JZ';
JNS:	'JNS';
JNZ:	'JNZ';
JNC:	'JNC';
CALL:	'CALL';
RET:	'RET';
IN:		'IN';
OUT:	'OUT';
OUTB:	'OUTB';
ENTER:	'ENTER';
LEAVE:	'LEAVE';
INT:	'INT';
NOP:	'NOP';
HLT:	'HLT';
DATA:	'DATA';

/* Register Token */
REG_8BIT	  :   'D' | 'E' | 'F' | 'G' | 'H' | 'XL' | 'XH';
REG_16BIT	  :   'J' | 'M' | 'SP' | 'BP' | 'X' | 'Y' | 'Z';
PORT_8BIT	  :	  'A' | 'B';
OUT_PORT_8BIT :	  'C' | 'D';

/* Arithmetic Token */
PLUS_SIGN	: '+';
MINUS_SIGN	: '-';

/* Other Token */
EightBitBinaryValue: BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit 'b';
SixteenBitBinaryValue: BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit BinaryDigit 'b';
HexValue: HexDigit HexDigit;
JumpLabel: ':' String+;
fragment BinaryDigit:	[01];
fragment HexDigit:		[0-9a-fA-F];
fragment String:		[a-zA-Z_];
NUMBER: [0-9]+;
WS  : [\t\r\n' ']+ -> skip;

COMMENTS: ';' ~[\r\n]* -> skip;