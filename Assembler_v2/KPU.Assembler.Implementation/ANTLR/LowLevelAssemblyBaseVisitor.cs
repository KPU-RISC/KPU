//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from ANTLR/LowLevelAssembly.g4 by ANTLR 4.7

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="ILowLevelAssemblyVisitor{Result}"/>,
/// which can be extended to create a visitor which only needs to handle a subset
/// of the available methods.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public partial class LowLevelAssemblyBaseVisitor<Result> : AbstractParseTreeVisitor<Result>, ILowLevelAssemblyVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="LowLevelAssemblyParser.program"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitProgram([NotNull] LowLevelAssemblyParser.ProgramContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>SET</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitSET([NotNull] LowLevelAssemblyParser.SETContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>MOV_ALU_IN</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMOV_ALU_IN([NotNull] LowLevelAssemblyParser.MOV_ALU_INContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>MOV_ALU_OUT</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMOV_ALU_OUT([NotNull] LowLevelAssemblyParser.MOV_ALU_OUTContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>MOV_ALU_C_TO_AB</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMOV_ALU_C_TO_AB([NotNull] LowLevelAssemblyParser.MOV_ALU_C_TO_ABContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>SHL</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitSHL([NotNull] LowLevelAssemblyParser.SHLContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>SHR</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitSHR([NotNull] LowLevelAssemblyParser.SHRContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>SAR</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitSAR([NotNull] LowLevelAssemblyParser.SARContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>RCL</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitRCL([NotNull] LowLevelAssemblyParser.RCLContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>RCR</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitRCR([NotNull] LowLevelAssemblyParser.RCRContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>OR</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitOR([NotNull] LowLevelAssemblyParser.ORContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>ADD</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitADD([NotNull] LowLevelAssemblyParser.ADDContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>ADC</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitADC([NotNull] LowLevelAssemblyParser.ADCContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>SUB</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitSUB([NotNull] LowLevelAssemblyParser.SUBContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>SBB</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitSBB([NotNull] LowLevelAssemblyParser.SBBContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>XOR</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitXOR([NotNull] LowLevelAssemblyParser.XORContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>AND</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitAND([NotNull] LowLevelAssemblyParser.ANDContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>NOT</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitNOT([NotNull] LowLevelAssemblyParser.NOTContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>NEG</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitNEG([NotNull] LowLevelAssemblyParser.NEGContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>MOV8</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMOV8([NotNull] LowLevelAssemblyParser.MOV8Context context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>NOP</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitNOP([NotNull] LowLevelAssemblyParser.NOPContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>MOV</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMOV([NotNull] LowLevelAssemblyParser.MOVContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>MOV16</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMOV16([NotNull] LowLevelAssemblyParser.MOV16Context context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>LOAD</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitLOAD([NotNull] LowLevelAssemblyParser.LOADContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>STORE</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitSTORE([NotNull] LowLevelAssemblyParser.STOREContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>SAVE_FLAGS</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitSAVE_FLAGS([NotNull] LowLevelAssemblyParser.SAVE_FLAGSContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>RESTORE_FLAGS</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitRESTORE_FLAGS([NotNull] LowLevelAssemblyParser.RESTORE_FLAGSContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>FLAGS_TO_OUTBUFFER</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitFLAGS_TO_OUTBUFFER([NotNull] LowLevelAssemblyParser.FLAGS_TO_OUTBUFFERContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>STORE_FLAGS</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitSTORE_FLAGS([NotNull] LowLevelAssemblyParser.STORE_FLAGSContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>INBUFFER_TO_FLAGS</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitINBUFFER_TO_FLAGS([NotNull] LowLevelAssemblyParser.INBUFFER_TO_FLAGSContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>LOAD_FLAGS</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitLOAD_FLAGS([NotNull] LowLevelAssemblyParser.LOAD_FLAGSContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>BIT16_ADDER</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitBIT16_ADDER([NotNull] LowLevelAssemblyParser.BIT16_ADDERContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>JMP_LABEL</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitJMP_LABEL([NotNull] LowLevelAssemblyParser.JMP_LABELContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>JMP</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitJMP([NotNull] LowLevelAssemblyParser.JMPContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>JZ</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitJZ([NotNull] LowLevelAssemblyParser.JZContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>JNZ</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitJNZ([NotNull] LowLevelAssemblyParser.JNZContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>JNS</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitJNS([NotNull] LowLevelAssemblyParser.JNSContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>JNC</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitJNC([NotNull] LowLevelAssemblyParser.JNCContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>CALL</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitCALL([NotNull] LowLevelAssemblyParser.CALLContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>RET</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitRET([NotNull] LowLevelAssemblyParser.RETContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>IN</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitIN([NotNull] LowLevelAssemblyParser.INContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>OUT</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitOUT([NotNull] LowLevelAssemblyParser.OUTContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>INT</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitINT([NotNull] LowLevelAssemblyParser.INTContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>HLT</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitHLT([NotNull] LowLevelAssemblyParser.HLTContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>DATA</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitDATA([NotNull] LowLevelAssemblyParser.DATAContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by the <c>MACRO</c>
	/// labeled alternative in <see cref="LowLevelAssemblyParser.opcode"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMACRO([NotNull] LowLevelAssemblyParser.MACROContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="LowLevelAssemblyParser.register_8bit"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitRegister_8bit([NotNull] LowLevelAssemblyParser.Register_8bitContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="LowLevelAssemblyParser.register_16bit"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitRegister_16bit([NotNull] LowLevelAssemblyParser.Register_16bitContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="LowLevelAssemblyParser.register_ab"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitRegister_ab([NotNull] LowLevelAssemblyParser.Register_abContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="LowLevelAssemblyParser.out_port_8bit"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitOut_port_8bit([NotNull] LowLevelAssemblyParser.Out_port_8bitContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="LowLevelAssemblyParser.port_8bit"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitPort_8bit([NotNull] LowLevelAssemblyParser.Port_8bitContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="LowLevelAssemblyParser.plus_sign"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitPlus_sign([NotNull] LowLevelAssemblyParser.Plus_signContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="LowLevelAssemblyParser.minus_sign"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitMinus_sign([NotNull] LowLevelAssemblyParser.Minus_signContext context) { return VisitChildren(context); }
	/// <summary>
	/// Visit a parse tree produced by <see cref="LowLevelAssemblyParser.int"/>.
	/// <para>
	/// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
	/// on <paramref name="context"/>.
	/// </para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	public virtual Result VisitInt([NotNull] LowLevelAssemblyParser.IntContext context) { return VisitChildren(context); }
}