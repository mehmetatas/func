//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 3.4
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// $ANTLR 3.4 Calc.g 2013-04-24 19:32:39

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162
// Missing XML comment for publicly visible type or member 'Type_or_Member'
#pragma warning disable 1591


using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Misc;
using ConditionalAttribute = System.Diagnostics.ConditionalAttribute;


using Antlr.Runtime.Tree;
using RewriteRuleITokenStream = Antlr.Runtime.Tree.RewriteRuleTokenStream;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.4")]
[System.CLSCompliant(false)]
public partial class CalcParser : Antlr.Runtime.Parser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "ASSIGN", "CLOSE_PAR", "COMMENT", "DIGIT", "DIV", "IDENT", "LETTER", "MINUS", "MOD", "MUL", "MULTILINE_COMMENT", "NEGATION", "NUMBER", "OPEN_PAR", "PLUS", "SEMI_COL", "WS"
	};
	public const int EOF=-1;
	public const int ASSIGN=4;
	public const int CLOSE_PAR=5;
	public const int COMMENT=6;
	public const int DIGIT=7;
	public const int DIV=8;
	public const int IDENT=9;
	public const int LETTER=10;
	public const int MINUS=11;
	public const int MOD=12;
	public const int MUL=13;
	public const int MULTILINE_COMMENT=14;
	public const int NEGATION=15;
	public const int NUMBER=16;
	public const int OPEN_PAR=17;
	public const int PLUS=18;
	public const int SEMI_COL=19;
	public const int WS=20;

	#if ANTLR_DEBUG
		private static readonly bool[] decisionCanBacktrack =
			new bool[]
			{
				false, // invalid decision
				false, false, false, false, false, false, false
			};
	#else
		private static readonly bool[] decisionCanBacktrack = new bool[0];
	#endif
	public CalcParser(ITokenStream input)
		: this(input, new RecognizerSharedState())
	{
	}
	public CalcParser(ITokenStream input, RecognizerSharedState state)
		: base(input, state)
	{
		OnCreated();
	}
	private ITreeAdaptor adaptor;

	public ITreeAdaptor TreeAdaptor
	{
		get
		{
			return adaptor;
		}

		set
		{
			this.adaptor = value;
		}
	}

	public override string[] TokenNames { get { return CalcParser.tokenNames; } }
	public override string GrammarFileName { get { return "Calc.g"; } }


	[Conditional("ANTLR_TRACE")]
	protected virtual void OnCreated() {}
	[Conditional("ANTLR_TRACE")]
	protected virtual void EnterRule(string ruleName, int ruleIndex) {}
	[Conditional("ANTLR_TRACE")]
	protected virtual void LeaveRule(string ruleName, int ruleIndex) {}

	#region Rules

	[Conditional("ANTLR_TRACE")]
	protected virtual void EnterRule_build() {}
	[Conditional("ANTLR_TRACE")]
	protected virtual void LeaveRule_build() {}

	// $ANTLR start "build"
	// Calc.g:14:1: public build : ( assignment )* EOF !;
	[GrammarRule("build")]
	public AstParserRuleReturnScope<CommonTree, IToken> build()
	{
		EnterRule_build();
		EnterRule("build", 1);
		TraceIn("build", 1);
	    AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
	    retval.Start = (IToken)input.LT(1);

	    CommonTree root_0 = default(CommonTree);

	    IToken EOF2 = default(IToken);
	    AstParserRuleReturnScope<CommonTree, IToken> assignment1 = default(AstParserRuleReturnScope<CommonTree, IToken>);

	    CommonTree EOF2_tree = default(CommonTree);

		try { DebugEnterRule(GrammarFileName, "build");
		DebugLocation(14, 1);
		try
		{
			// Calc.g:15:2: ( ( assignment )* EOF !)
			DebugEnterAlt(1);
			// Calc.g:15:4: ( assignment )* EOF !
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(15, 4);
			// Calc.g:15:4: ( assignment )*
			try { DebugEnterSubRule(1);
			while (true)
			{
				int alt1=2;
				try { DebugEnterDecision(1, decisionCanBacktrack[1]);
				int LA1_0 = input.LA(1);

				if ((LA1_0==IDENT))
				{
					alt1 = 1;
				}


				} finally { DebugExitDecision(1); }
				switch ( alt1 )
				{
				case 1:
					DebugEnterAlt(1);
					// Calc.g:15:4: assignment
					{
					DebugLocation(15, 4);
					PushFollow(Follow._assignment_in_build56);
					assignment1=assignment();
					PopFollow();

					adaptor.AddChild(root_0, assignment1.Tree);

					}
					break;

				default:
					goto loop1;
				}
			}

			loop1:
				;

			} finally { DebugExitSubRule(1); }

			DebugLocation(15, 19);
			EOF2=(IToken)Match(input,EOF,Follow._EOF_in_build59); 

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (CommonTree)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("build", 1);
			LeaveRule("build", 1);
			LeaveRule_build();
	    }
	 	DebugLocation(16, 1);
		} finally { DebugExitRule(GrammarFileName, "build"); }
		return retval;

	}
	// $ANTLR end "build"


	[Conditional("ANTLR_TRACE")]
	protected virtual void EnterRule_assignment() {}
	[Conditional("ANTLR_TRACE")]
	protected virtual void LeaveRule_assignment() {}

	// $ANTLR start "assignment"
	// Calc.g:18:1: assignment : IDENT ASSIGN ^ expression SEMI_COL !;
	[GrammarRule("assignment")]
	private AstParserRuleReturnScope<CommonTree, IToken> assignment()
	{
		EnterRule_assignment();
		EnterRule("assignment", 2);
		TraceIn("assignment", 2);
	    AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
	    retval.Start = (IToken)input.LT(1);

	    CommonTree root_0 = default(CommonTree);

	    IToken IDENT3 = default(IToken);
	    IToken ASSIGN4 = default(IToken);
	    IToken SEMI_COL6 = default(IToken);
	    AstParserRuleReturnScope<CommonTree, IToken> expression5 = default(AstParserRuleReturnScope<CommonTree, IToken>);

	    CommonTree IDENT3_tree = default(CommonTree);
	    CommonTree ASSIGN4_tree = default(CommonTree);
	    CommonTree SEMI_COL6_tree = default(CommonTree);

		try { DebugEnterRule(GrammarFileName, "assignment");
		DebugLocation(18, 1);
		try
		{
			// Calc.g:19:2: ( IDENT ASSIGN ^ expression SEMI_COL !)
			DebugEnterAlt(1);
			// Calc.g:19:4: IDENT ASSIGN ^ expression SEMI_COL !
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(19, 4);
			IDENT3=(IToken)Match(input,IDENT,Follow._IDENT_in_assignment72); 
			IDENT3_tree = (CommonTree)adaptor.Create(IDENT3);
			adaptor.AddChild(root_0, IDENT3_tree);

			DebugLocation(19, 16);
			ASSIGN4=(IToken)Match(input,ASSIGN,Follow._ASSIGN_in_assignment74); 
			ASSIGN4_tree = (CommonTree)adaptor.Create(ASSIGN4);
			root_0 = (CommonTree)adaptor.BecomeRoot(ASSIGN4_tree, root_0);

			DebugLocation(19, 18);
			PushFollow(Follow._expression_in_assignment77);
			expression5=expression();
			PopFollow();

			adaptor.AddChild(root_0, expression5.Tree);
			DebugLocation(19, 37);
			SEMI_COL6=(IToken)Match(input,SEMI_COL,Follow._SEMI_COL_in_assignment79); 

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (CommonTree)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("assignment", 2);
			LeaveRule("assignment", 2);
			LeaveRule_assignment();
	    }
	 	DebugLocation(20, 1);
		} finally { DebugExitRule(GrammarFileName, "assignment"); }
		return retval;

	}
	// $ANTLR end "assignment"


	[Conditional("ANTLR_TRACE")]
	protected virtual void EnterRule_expression() {}
	[Conditional("ANTLR_TRACE")]
	protected virtual void LeaveRule_expression() {}

	// $ANTLR start "expression"
	// Calc.g:24:1: expression : mult ( ( PLUS ^| MINUS ^) mult )* ;
	[GrammarRule("expression")]
	private AstParserRuleReturnScope<CommonTree, IToken> expression()
	{
		EnterRule_expression();
		EnterRule("expression", 3);
		TraceIn("expression", 3);
	    AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
	    retval.Start = (IToken)input.LT(1);

	    CommonTree root_0 = default(CommonTree);

	    IToken PLUS8 = default(IToken);
	    IToken MINUS9 = default(IToken);
	    AstParserRuleReturnScope<CommonTree, IToken> mult7 = default(AstParserRuleReturnScope<CommonTree, IToken>);
	    AstParserRuleReturnScope<CommonTree, IToken> mult10 = default(AstParserRuleReturnScope<CommonTree, IToken>);

	    CommonTree PLUS8_tree = default(CommonTree);
	    CommonTree MINUS9_tree = default(CommonTree);

		try { DebugEnterRule(GrammarFileName, "expression");
		DebugLocation(24, 1);
		try
		{
			// Calc.g:25:2: ( mult ( ( PLUS ^| MINUS ^) mult )* )
			DebugEnterAlt(1);
			// Calc.g:25:4: mult ( ( PLUS ^| MINUS ^) mult )*
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(25, 4);
			PushFollow(Follow._mult_in_expression95);
			mult7=mult();
			PopFollow();

			adaptor.AddChild(root_0, mult7.Tree);
			DebugLocation(25, 9);
			// Calc.g:25:9: ( ( PLUS ^| MINUS ^) mult )*
			try { DebugEnterSubRule(3);
			while (true)
			{
				int alt3=2;
				try { DebugEnterDecision(3, decisionCanBacktrack[3]);
				int LA3_0 = input.LA(1);

				if ((LA3_0==MINUS||LA3_0==PLUS))
				{
					alt3 = 1;
				}


				} finally { DebugExitDecision(3); }
				switch ( alt3 )
				{
				case 1:
					DebugEnterAlt(1);
					// Calc.g:25:10: ( PLUS ^| MINUS ^) mult
					{
					DebugLocation(25, 10);
					// Calc.g:25:10: ( PLUS ^| MINUS ^)
					int alt2=2;
					try { DebugEnterSubRule(2);
					try { DebugEnterDecision(2, decisionCanBacktrack[2]);
					int LA2_0 = input.LA(1);

					if ((LA2_0==PLUS))
					{
						alt2 = 1;
					}
					else if ((LA2_0==MINUS))
					{
						alt2 = 2;
					}
					else
					{
						NoViableAltException nvae = new NoViableAltException("", 2, 0, input);
						DebugRecognitionException(nvae);
						throw nvae;
					}
					} finally { DebugExitDecision(2); }
					switch (alt2)
					{
					case 1:
						DebugEnterAlt(1);
						// Calc.g:25:11: PLUS ^
						{
						DebugLocation(25, 15);
						PLUS8=(IToken)Match(input,PLUS,Follow._PLUS_in_expression99); 
						PLUS8_tree = (CommonTree)adaptor.Create(PLUS8);
						root_0 = (CommonTree)adaptor.BecomeRoot(PLUS8_tree, root_0);


						}
						break;
					case 2:
						DebugEnterAlt(2);
						// Calc.g:25:19: MINUS ^
						{
						DebugLocation(25, 24);
						MINUS9=(IToken)Match(input,MINUS,Follow._MINUS_in_expression104); 
						MINUS9_tree = (CommonTree)adaptor.Create(MINUS9);
						root_0 = (CommonTree)adaptor.BecomeRoot(MINUS9_tree, root_0);


						}
						break;

					}
					} finally { DebugExitSubRule(2); }

					DebugLocation(25, 27);
					PushFollow(Follow._mult_in_expression108);
					mult10=mult();
					PopFollow();

					adaptor.AddChild(root_0, mult10.Tree);

					}
					break;

				default:
					goto loop3;
				}
			}

			loop3:
				;

			} finally { DebugExitSubRule(3); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (CommonTree)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("expression", 3);
			LeaveRule("expression", 3);
			LeaveRule_expression();
	    }
	 	DebugLocation(26, 1);
		} finally { DebugExitRule(GrammarFileName, "expression"); }
		return retval;

	}
	// $ANTLR end "expression"


	[Conditional("ANTLR_TRACE")]
	protected virtual void EnterRule_mult() {}
	[Conditional("ANTLR_TRACE")]
	protected virtual void LeaveRule_mult() {}

	// $ANTLR start "mult"
	// Calc.g:28:1: mult : unary ( ( MUL ^| DIV ^| MOD ^) unary )* ;
	[GrammarRule("mult")]
	private AstParserRuleReturnScope<CommonTree, IToken> mult()
	{
		EnterRule_mult();
		EnterRule("mult", 4);
		TraceIn("mult", 4);
	    AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
	    retval.Start = (IToken)input.LT(1);

	    CommonTree root_0 = default(CommonTree);

	    IToken MUL12 = default(IToken);
	    IToken DIV13 = default(IToken);
	    IToken MOD14 = default(IToken);
	    AstParserRuleReturnScope<CommonTree, IToken> unary11 = default(AstParserRuleReturnScope<CommonTree, IToken>);
	    AstParserRuleReturnScope<CommonTree, IToken> unary15 = default(AstParserRuleReturnScope<CommonTree, IToken>);

	    CommonTree MUL12_tree = default(CommonTree);
	    CommonTree DIV13_tree = default(CommonTree);
	    CommonTree MOD14_tree = default(CommonTree);

		try { DebugEnterRule(GrammarFileName, "mult");
		DebugLocation(28, 1);
		try
		{
			// Calc.g:29:2: ( unary ( ( MUL ^| DIV ^| MOD ^) unary )* )
			DebugEnterAlt(1);
			// Calc.g:29:4: unary ( ( MUL ^| DIV ^| MOD ^) unary )*
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(29, 4);
			PushFollow(Follow._unary_in_mult121);
			unary11=unary();
			PopFollow();

			adaptor.AddChild(root_0, unary11.Tree);
			DebugLocation(29, 10);
			// Calc.g:29:10: ( ( MUL ^| DIV ^| MOD ^) unary )*
			try { DebugEnterSubRule(5);
			while (true)
			{
				int alt5=2;
				try { DebugEnterDecision(5, decisionCanBacktrack[5]);
				int LA5_0 = input.LA(1);

				if ((LA5_0==DIV||(LA5_0>=MOD && LA5_0<=MUL)))
				{
					alt5 = 1;
				}


				} finally { DebugExitDecision(5); }
				switch ( alt5 )
				{
				case 1:
					DebugEnterAlt(1);
					// Calc.g:29:11: ( MUL ^| DIV ^| MOD ^) unary
					{
					DebugLocation(29, 11);
					// Calc.g:29:11: ( MUL ^| DIV ^| MOD ^)
					int alt4=3;
					try { DebugEnterSubRule(4);
					try { DebugEnterDecision(4, decisionCanBacktrack[4]);
					switch (input.LA(1))
					{
					case MUL:
						{
						alt4 = 1;
						}
						break;
					case DIV:
						{
						alt4 = 2;
						}
						break;
					case MOD:
						{
						alt4 = 3;
						}
						break;
					default:
						{
							NoViableAltException nvae = new NoViableAltException("", 4, 0, input);
							DebugRecognitionException(nvae);
							throw nvae;
						}
					}

					} finally { DebugExitDecision(4); }
					switch (alt4)
					{
					case 1:
						DebugEnterAlt(1);
						// Calc.g:29:12: MUL ^
						{
						DebugLocation(29, 15);
						MUL12=(IToken)Match(input,MUL,Follow._MUL_in_mult125); 
						MUL12_tree = (CommonTree)adaptor.Create(MUL12);
						root_0 = (CommonTree)adaptor.BecomeRoot(MUL12_tree, root_0);


						}
						break;
					case 2:
						DebugEnterAlt(2);
						// Calc.g:29:19: DIV ^
						{
						DebugLocation(29, 22);
						DIV13=(IToken)Match(input,DIV,Follow._DIV_in_mult130); 
						DIV13_tree = (CommonTree)adaptor.Create(DIV13);
						root_0 = (CommonTree)adaptor.BecomeRoot(DIV13_tree, root_0);


						}
						break;
					case 3:
						DebugEnterAlt(3);
						// Calc.g:29:26: MOD ^
						{
						DebugLocation(29, 29);
						MOD14=(IToken)Match(input,MOD,Follow._MOD_in_mult135); 
						MOD14_tree = (CommonTree)adaptor.Create(MOD14);
						root_0 = (CommonTree)adaptor.BecomeRoot(MOD14_tree, root_0);


						}
						break;

					}
					} finally { DebugExitSubRule(4); }

					DebugLocation(29, 32);
					PushFollow(Follow._unary_in_mult139);
					unary15=unary();
					PopFollow();

					adaptor.AddChild(root_0, unary15.Tree);

					}
					break;

				default:
					goto loop5;
				}
			}

			loop5:
				;

			} finally { DebugExitSubRule(5); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (CommonTree)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("mult", 4);
			LeaveRule("mult", 4);
			LeaveRule_mult();
	    }
	 	DebugLocation(30, 1);
		} finally { DebugExitRule(GrammarFileName, "mult"); }
		return retval;

	}
	// $ANTLR end "mult"


	[Conditional("ANTLR_TRACE")]
	protected virtual void EnterRule_unary() {}
	[Conditional("ANTLR_TRACE")]
	protected virtual void LeaveRule_unary() {}

	// $ANTLR start "unary"
	// Calc.g:32:1: unary : ( PLUS !| negation ^)* term ;
	[GrammarRule("unary")]
	private AstParserRuleReturnScope<CommonTree, IToken> unary()
	{
		EnterRule_unary();
		EnterRule("unary", 5);
		TraceIn("unary", 5);
	    AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
	    retval.Start = (IToken)input.LT(1);

	    CommonTree root_0 = default(CommonTree);

	    IToken PLUS16 = default(IToken);
	    AstParserRuleReturnScope<CommonTree, IToken> negation17 = default(AstParserRuleReturnScope<CommonTree, IToken>);
	    AstParserRuleReturnScope<CommonTree, IToken> term18 = default(AstParserRuleReturnScope<CommonTree, IToken>);

	    CommonTree PLUS16_tree = default(CommonTree);

		try { DebugEnterRule(GrammarFileName, "unary");
		DebugLocation(32, 1);
		try
		{
			// Calc.g:33:2: ( ( PLUS !| negation ^)* term )
			DebugEnterAlt(1);
			// Calc.g:33:4: ( PLUS !| negation ^)* term
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(33, 4);
			// Calc.g:33:4: ( PLUS !| negation ^)*
			try { DebugEnterSubRule(6);
			while (true)
			{
				int alt6=3;
				try { DebugEnterDecision(6, decisionCanBacktrack[6]);
				int LA6_0 = input.LA(1);

				if ((LA6_0==PLUS))
				{
					alt6 = 1;
				}
				else if ((LA6_0==MINUS))
				{
					alt6 = 2;
				}


				} finally { DebugExitDecision(6); }
				switch ( alt6 )
				{
				case 1:
					DebugEnterAlt(1);
					// Calc.g:33:5: PLUS !
					{
					DebugLocation(33, 9);
					PLUS16=(IToken)Match(input,PLUS,Follow._PLUS_in_unary154); 

					}
					break;
				case 2:
					DebugEnterAlt(2);
					// Calc.g:33:13: negation ^
					{
					DebugLocation(33, 21);
					PushFollow(Follow._negation_in_unary159);
					negation17=negation();
					PopFollow();

					root_0 = (CommonTree)adaptor.BecomeRoot(negation17.Tree, root_0);

					}
					break;

				default:
					goto loop6;
				}
			}

			loop6:
				;

			} finally { DebugExitSubRule(6); }

			DebugLocation(33, 25);
			PushFollow(Follow._term_in_unary164);
			term18=term();
			PopFollow();

			adaptor.AddChild(root_0, term18.Tree);

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (CommonTree)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("unary", 5);
			LeaveRule("unary", 5);
			LeaveRule_unary();
	    }
	 	DebugLocation(34, 1);
		} finally { DebugExitRule(GrammarFileName, "unary"); }
		return retval;

	}
	// $ANTLR end "unary"


	[Conditional("ANTLR_TRACE")]
	protected virtual void EnterRule_term() {}
	[Conditional("ANTLR_TRACE")]
	protected virtual void LeaveRule_term() {}

	// $ANTLR start "term"
	// Calc.g:36:1: term : ( IDENT | OPEN_PAR ! expression CLOSE_PAR !| NUMBER );
	[GrammarRule("term")]
	private AstParserRuleReturnScope<CommonTree, IToken> term()
	{
		EnterRule_term();
		EnterRule("term", 6);
		TraceIn("term", 6);
	    AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
	    retval.Start = (IToken)input.LT(1);

	    CommonTree root_0 = default(CommonTree);

	    IToken IDENT19 = default(IToken);
	    IToken OPEN_PAR20 = default(IToken);
	    IToken CLOSE_PAR22 = default(IToken);
	    IToken NUMBER23 = default(IToken);
	    AstParserRuleReturnScope<CommonTree, IToken> expression21 = default(AstParserRuleReturnScope<CommonTree, IToken>);

	    CommonTree IDENT19_tree = default(CommonTree);
	    CommonTree OPEN_PAR20_tree = default(CommonTree);
	    CommonTree CLOSE_PAR22_tree = default(CommonTree);
	    CommonTree NUMBER23_tree = default(CommonTree);

		try { DebugEnterRule(GrammarFileName, "term");
		DebugLocation(36, 1);
		try
		{
			// Calc.g:37:2: ( IDENT | OPEN_PAR ! expression CLOSE_PAR !| NUMBER )
			int alt7=3;
			try { DebugEnterDecision(7, decisionCanBacktrack[7]);
			switch (input.LA(1))
			{
			case IDENT:
				{
				alt7 = 1;
				}
				break;
			case OPEN_PAR:
				{
				alt7 = 2;
				}
				break;
			case NUMBER:
				{
				alt7 = 3;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 7, 0, input);
					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(7); }
			switch (alt7)
			{
			case 1:
				DebugEnterAlt(1);
				// Calc.g:37:4: IDENT
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(37, 4);
				IDENT19=(IToken)Match(input,IDENT,Follow._IDENT_in_term175); 
				IDENT19_tree = (CommonTree)adaptor.Create(IDENT19);
				adaptor.AddChild(root_0, IDENT19_tree);


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// Calc.g:38:4: OPEN_PAR ! expression CLOSE_PAR !
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(38, 12);
				OPEN_PAR20=(IToken)Match(input,OPEN_PAR,Follow._OPEN_PAR_in_term180); 
				DebugLocation(38, 14);
				PushFollow(Follow._expression_in_term183);
				expression21=expression();
				PopFollow();

				adaptor.AddChild(root_0, expression21.Tree);
				DebugLocation(38, 34);
				CLOSE_PAR22=(IToken)Match(input,CLOSE_PAR,Follow._CLOSE_PAR_in_term185); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// Calc.g:39:4: NUMBER
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(39, 4);
				NUMBER23=(IToken)Match(input,NUMBER,Follow._NUMBER_in_term191); 
				NUMBER23_tree = (CommonTree)adaptor.Create(NUMBER23);
				adaptor.AddChild(root_0, NUMBER23_tree);


				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (CommonTree)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("term", 6);
			LeaveRule("term", 6);
			LeaveRule_term();
	    }
	 	DebugLocation(40, 1);
		} finally { DebugExitRule(GrammarFileName, "term"); }
		return retval;

	}
	// $ANTLR end "term"


	[Conditional("ANTLR_TRACE")]
	protected virtual void EnterRule_negation() {}
	[Conditional("ANTLR_TRACE")]
	protected virtual void LeaveRule_negation() {}

	// $ANTLR start "negation"
	// Calc.g:42:1: negation : MINUS -> NEGATION ;
	[GrammarRule("negation")]
	private AstParserRuleReturnScope<CommonTree, IToken> negation()
	{
		EnterRule_negation();
		EnterRule("negation", 7);
		TraceIn("negation", 7);
	    AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
	    retval.Start = (IToken)input.LT(1);

	    CommonTree root_0 = default(CommonTree);

	    IToken MINUS24 = default(IToken);

	    CommonTree MINUS24_tree = default(CommonTree);
	    RewriteRuleITokenStream stream_MINUS=new RewriteRuleITokenStream(adaptor,"token MINUS");

		try { DebugEnterRule(GrammarFileName, "negation");
		DebugLocation(42, 1);
		try
		{
			// Calc.g:43:2: ( MINUS -> NEGATION )
			DebugEnterAlt(1);
			// Calc.g:43:4: MINUS
			{
			DebugLocation(43, 4);
			MINUS24=(IToken)Match(input,MINUS,Follow._MINUS_in_negation202);  
			stream_MINUS.Add(MINUS24);



			{
			// AST REWRITE
			// elements: 
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (CommonTree)adaptor.Nil();
			// 43:10: -> NEGATION
			{
				DebugLocation(43, 13);
				adaptor.AddChild(root_0, (CommonTree)adaptor.Create(NEGATION, "NEGATION"));

			}

			retval.Tree = root_0;
			}

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (CommonTree)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("negation", 7);
			LeaveRule("negation", 7);
			LeaveRule_negation();
	    }
	 	DebugLocation(44, 1);
		} finally { DebugExitRule(GrammarFileName, "negation"); }
		return retval;

	}
	// $ANTLR end "negation"
	#endregion Rules


	#region Follow sets
	private static class Follow
	{
		public static readonly BitSet _assignment_in_build56 = new BitSet(new ulong[]{0x200UL});
		public static readonly BitSet _EOF_in_build59 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IDENT_in_assignment72 = new BitSet(new ulong[]{0x10UL});
		public static readonly BitSet _ASSIGN_in_assignment74 = new BitSet(new ulong[]{0x70A00UL});
		public static readonly BitSet _expression_in_assignment77 = new BitSet(new ulong[]{0x80000UL});
		public static readonly BitSet _SEMI_COL_in_assignment79 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _mult_in_expression95 = new BitSet(new ulong[]{0x40802UL});
		public static readonly BitSet _PLUS_in_expression99 = new BitSet(new ulong[]{0x70A00UL});
		public static readonly BitSet _MINUS_in_expression104 = new BitSet(new ulong[]{0x70A00UL});
		public static readonly BitSet _mult_in_expression108 = new BitSet(new ulong[]{0x40802UL});
		public static readonly BitSet _unary_in_mult121 = new BitSet(new ulong[]{0x3102UL});
		public static readonly BitSet _MUL_in_mult125 = new BitSet(new ulong[]{0x70A00UL});
		public static readonly BitSet _DIV_in_mult130 = new BitSet(new ulong[]{0x70A00UL});
		public static readonly BitSet _MOD_in_mult135 = new BitSet(new ulong[]{0x70A00UL});
		public static readonly BitSet _unary_in_mult139 = new BitSet(new ulong[]{0x3102UL});
		public static readonly BitSet _PLUS_in_unary154 = new BitSet(new ulong[]{0x70A00UL});
		public static readonly BitSet _negation_in_unary159 = new BitSet(new ulong[]{0x70A00UL});
		public static readonly BitSet _term_in_unary164 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IDENT_in_term175 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _OPEN_PAR_in_term180 = new BitSet(new ulong[]{0x70A00UL});
		public static readonly BitSet _expression_in_term183 = new BitSet(new ulong[]{0x20UL});
		public static readonly BitSet _CLOSE_PAR_in_term185 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _NUMBER_in_term191 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _MINUS_in_negation202 = new BitSet(new ulong[]{0x2UL});
	}
	#endregion Follow sets
}
