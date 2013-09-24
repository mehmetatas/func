//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 3.4
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// $ANTLR 3.4 Func.g 2013-04-27 19:38:51

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
public partial class FuncParser : Antlr.Runtime.Parser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "BOOLEAN", "CLOSE_PAR", "COMMA", "COMMENT", "DATE", "DATETIME", "DATE_FRAG", "DAY", "DIGIT", "DOT", "FUNC", "HOUR", "IDENT", "LETTER", "METHOD", "MILLISECOND", "MINUTE", "MONTH", "MULTILINE_COMMENT", "NUMBER", "OPEN_PAR", "PATH", "SECOND", "SEMICOL", "STRING", "TIME", "TIME_FRAG", "VAR", "WS", "YEAR"
	};
	public const int EOF=-1;
	public const int BOOLEAN=4;
	public const int CLOSE_PAR=5;
	public const int COMMA=6;
	public const int COMMENT=7;
	public const int DATE=8;
	public const int DATETIME=9;
	public const int DATE_FRAG=10;
	public const int DAY=11;
	public const int DIGIT=12;
	public const int DOT=13;
	public const int FUNC=14;
	public const int HOUR=15;
	public const int IDENT=16;
	public const int LETTER=17;
	public const int METHOD=18;
	public const int MILLISECOND=19;
	public const int MINUTE=20;
	public const int MONTH=21;
	public const int MULTILINE_COMMENT=22;
	public const int NUMBER=23;
	public const int OPEN_PAR=24;
	public const int PATH=25;
	public const int SECOND=26;
	public const int SEMICOL=27;
	public const int STRING=28;
	public const int TIME=29;
	public const int TIME_FRAG=30;
	public const int VAR=31;
	public const int WS=32;
	public const int YEAR=33;

	#if ANTLR_DEBUG
		private static readonly bool[] decisionCanBacktrack =
			new bool[]
			{
				false, // invalid decision
				false, false, false, false
			};
	#else
		private static readonly bool[] decisionCanBacktrack = new bool[0];
	#endif
	public FuncParser(ITokenStream input)
		: this(input, new RecognizerSharedState())
	{
	}
	public FuncParser(ITokenStream input, RecognizerSharedState state)
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

	public override string[] TokenNames { get { return FuncParser.tokenNames; } }
	public override string GrammarFileName { get { return "Func.g"; } }


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
	// Func.g:10:1: public build : ( func SEMICOL !)* EOF ;
	[GrammarRule("build")]
	public AstParserRuleReturnScope<CommonTree, IToken> build()
	{
		EnterRule_build();
		EnterRule("build", 1);
		TraceIn("build", 1);
	    AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
	    retval.Start = (IToken)input.LT(1);

	    CommonTree root_0 = default(CommonTree);

	    IToken SEMICOL2 = default(IToken);
	    IToken EOF3 = default(IToken);
	    AstParserRuleReturnScope<CommonTree, IToken> func1 = default(AstParserRuleReturnScope<CommonTree, IToken>);

	    CommonTree SEMICOL2_tree = default(CommonTree);
	    CommonTree EOF3_tree = default(CommonTree);

		try { DebugEnterRule(GrammarFileName, "build");
		DebugLocation(10, 1);
		try
		{
			// Func.g:11:2: ( ( func SEMICOL !)* EOF )
			DebugEnterAlt(1);
			// Func.g:11:4: ( func SEMICOL !)* EOF
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(11, 4);
			// Func.g:11:4: ( func SEMICOL !)*
			try { DebugEnterSubRule(1);
			while (true)
			{
				int alt1=2;
				try { DebugEnterDecision(1, decisionCanBacktrack[1]);
				int LA1_0 = input.LA(1);

				if ((LA1_0==FUNC||LA1_0==METHOD))
				{
					alt1 = 1;
				}


				} finally { DebugExitDecision(1); }
				switch ( alt1 )
				{
				case 1:
					DebugEnterAlt(1);
					// Func.g:11:5: func SEMICOL !
					{
					DebugLocation(11, 5);
					PushFollow(Follow._func_in_build48);
					func1=func();
					PopFollow();

					adaptor.AddChild(root_0, func1.Tree);
					DebugLocation(11, 17);
					SEMICOL2=(IToken)Match(input,SEMICOL,Follow._SEMICOL_in_build50); 

					}
					break;

				default:
					goto loop1;
				}
			}

			loop1:
				;

			} finally { DebugExitSubRule(1); }

			DebugLocation(11, 21);
			EOF3=(IToken)Match(input,EOF,Follow._EOF_in_build55); 
			EOF3_tree = (CommonTree)adaptor.Create(EOF3);
			adaptor.AddChild(root_0, EOF3_tree);


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
	 	DebugLocation(12, 1);
		} finally { DebugExitRule(GrammarFileName, "build"); }
		return retval;

	}
	// $ANTLR end "build"


	[Conditional("ANTLR_TRACE")]
	protected virtual void EnterRule_func() {}
	[Conditional("ANTLR_TRACE")]
	protected virtual void LeaveRule_func() {}

	// $ANTLR start "func"
	// Func.g:14:1: func : ( FUNC | METHOD ) ^ OPEN_PAR ! ( args )? CLOSE_PAR !;
	[GrammarRule("func")]
	private AstParserRuleReturnScope<CommonTree, IToken> func()
	{
		EnterRule_func();
		EnterRule("func", 2);
		TraceIn("func", 2);
	    AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
	    retval.Start = (IToken)input.LT(1);

	    CommonTree root_0 = default(CommonTree);

	    IToken set4 = default(IToken);
	    IToken OPEN_PAR5 = default(IToken);
	    IToken CLOSE_PAR7 = default(IToken);
	    AstParserRuleReturnScope<CommonTree, IToken> args6 = default(AstParserRuleReturnScope<CommonTree, IToken>);

	    CommonTree set4_tree = default(CommonTree);
	    CommonTree OPEN_PAR5_tree = default(CommonTree);
	    CommonTree CLOSE_PAR7_tree = default(CommonTree);

		try { DebugEnterRule(GrammarFileName, "func");
		DebugLocation(14, 1);
		try
		{
			// Func.g:15:2: ( ( FUNC | METHOD ) ^ OPEN_PAR ! ( args )? CLOSE_PAR !)
			DebugEnterAlt(1);
			// Func.g:15:4: ( FUNC | METHOD ) ^ OPEN_PAR ! ( args )? CLOSE_PAR !
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(15, 19);

			set4=(IToken)input.LT(1);
			set4=(IToken)input.LT(1);
			if (input.LA(1)==FUNC||input.LA(1)==METHOD)
			{
				input.Consume();
				root_0 = (CommonTree)adaptor.BecomeRoot((CommonTree)adaptor.Create(set4), root_0);
				state.errorRecovery=false;
			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				throw mse;
			}

			DebugLocation(15, 29);
			OPEN_PAR5=(IToken)Match(input,OPEN_PAR,Follow._OPEN_PAR_in_func76); 
			DebugLocation(15, 31);
			// Func.g:15:31: ( args )?
			int alt2=2;
			try { DebugEnterSubRule(2);
			try { DebugEnterDecision(2, decisionCanBacktrack[2]);
			int LA2_0 = input.LA(1);

			if ((LA2_0==BOOLEAN||(LA2_0>=DATE && LA2_0<=DATETIME)||LA2_0==FUNC||LA2_0==METHOD||LA2_0==NUMBER||(LA2_0>=STRING && LA2_0<=TIME)||LA2_0==VAR))
			{
				alt2 = 1;
			}
			} finally { DebugExitDecision(2); }
			switch (alt2)
			{
			case 1:
				DebugEnterAlt(1);
				// Func.g:15:31: args
				{
				DebugLocation(15, 31);
				PushFollow(Follow._args_in_func79);
				args6=args();
				PopFollow();

				adaptor.AddChild(root_0, args6.Tree);

				}
				break;

			}
			} finally { DebugExitSubRule(2); }

			DebugLocation(15, 46);
			CLOSE_PAR7=(IToken)Match(input,CLOSE_PAR,Follow._CLOSE_PAR_in_func82); 

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
			TraceOut("func", 2);
			LeaveRule("func", 2);
			LeaveRule_func();
	    }
	 	DebugLocation(16, 1);
		} finally { DebugExitRule(GrammarFileName, "func"); }
		return retval;

	}
	// $ANTLR end "func"


	[Conditional("ANTLR_TRACE")]
	protected virtual void EnterRule_args() {}
	[Conditional("ANTLR_TRACE")]
	protected virtual void LeaveRule_args() {}

	// $ANTLR start "args"
	// Func.g:18:1: args : term ( COMMA ! term )* ;
	[GrammarRule("args")]
	private AstParserRuleReturnScope<CommonTree, IToken> args()
	{
		EnterRule_args();
		EnterRule("args", 3);
		TraceIn("args", 3);
	    AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
	    retval.Start = (IToken)input.LT(1);

	    CommonTree root_0 = default(CommonTree);

	    IToken COMMA9 = default(IToken);
	    AstParserRuleReturnScope<CommonTree, IToken> term8 = default(AstParserRuleReturnScope<CommonTree, IToken>);
	    AstParserRuleReturnScope<CommonTree, IToken> term10 = default(AstParserRuleReturnScope<CommonTree, IToken>);

	    CommonTree COMMA9_tree = default(CommonTree);

		try { DebugEnterRule(GrammarFileName, "args");
		DebugLocation(18, 1);
		try
		{
			// Func.g:19:2: ( term ( COMMA ! term )* )
			DebugEnterAlt(1);
			// Func.g:19:4: term ( COMMA ! term )*
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(19, 4);
			PushFollow(Follow._term_in_args95);
			term8=term();
			PopFollow();

			adaptor.AddChild(root_0, term8.Tree);
			DebugLocation(19, 9);
			// Func.g:19:9: ( COMMA ! term )*
			try { DebugEnterSubRule(3);
			while (true)
			{
				int alt3=2;
				try { DebugEnterDecision(3, decisionCanBacktrack[3]);
				int LA3_0 = input.LA(1);

				if ((LA3_0==COMMA))
				{
					alt3 = 1;
				}


				} finally { DebugExitDecision(3); }
				switch ( alt3 )
				{
				case 1:
					DebugEnterAlt(1);
					// Func.g:19:10: COMMA ! term
					{
					DebugLocation(19, 15);
					COMMA9=(IToken)Match(input,COMMA,Follow._COMMA_in_args98); 
					DebugLocation(19, 17);
					PushFollow(Follow._term_in_args101);
					term10=term();
					PopFollow();

					adaptor.AddChild(root_0, term10.Tree);

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
			TraceOut("args", 3);
			LeaveRule("args", 3);
			LeaveRule_args();
	    }
	 	DebugLocation(20, 1);
		} finally { DebugExitRule(GrammarFileName, "args"); }
		return retval;

	}
	// $ANTLR end "args"


	[Conditional("ANTLR_TRACE")]
	protected virtual void EnterRule_term() {}
	[Conditional("ANTLR_TRACE")]
	protected virtual void LeaveRule_term() {}

	// $ANTLR start "term"
	// Func.g:22:1: term : ( STRING | BOOLEAN | NUMBER | DATETIME | DATE | TIME | VAR | func );
	[GrammarRule("term")]
	private AstParserRuleReturnScope<CommonTree, IToken> term()
	{
		EnterRule_term();
		EnterRule("term", 4);
		TraceIn("term", 4);
	    AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
	    retval.Start = (IToken)input.LT(1);

	    CommonTree root_0 = default(CommonTree);

	    IToken STRING11 = default(IToken);
	    IToken BOOLEAN12 = default(IToken);
	    IToken NUMBER13 = default(IToken);
	    IToken DATETIME14 = default(IToken);
	    IToken DATE15 = default(IToken);
	    IToken TIME16 = default(IToken);
	    IToken VAR17 = default(IToken);
	    AstParserRuleReturnScope<CommonTree, IToken> func18 = default(AstParserRuleReturnScope<CommonTree, IToken>);

	    CommonTree STRING11_tree = default(CommonTree);
	    CommonTree BOOLEAN12_tree = default(CommonTree);
	    CommonTree NUMBER13_tree = default(CommonTree);
	    CommonTree DATETIME14_tree = default(CommonTree);
	    CommonTree DATE15_tree = default(CommonTree);
	    CommonTree TIME16_tree = default(CommonTree);
	    CommonTree VAR17_tree = default(CommonTree);

		try { DebugEnterRule(GrammarFileName, "term");
		DebugLocation(22, 1);
		try
		{
			// Func.g:23:2: ( STRING | BOOLEAN | NUMBER | DATETIME | DATE | TIME | VAR | func )
			int alt4=8;
			try { DebugEnterDecision(4, decisionCanBacktrack[4]);
			switch (input.LA(1))
			{
			case STRING:
				{
				alt4 = 1;
				}
				break;
			case BOOLEAN:
				{
				alt4 = 2;
				}
				break;
			case NUMBER:
				{
				alt4 = 3;
				}
				break;
			case DATETIME:
				{
				alt4 = 4;
				}
				break;
			case DATE:
				{
				alt4 = 5;
				}
				break;
			case TIME:
				{
				alt4 = 6;
				}
				break;
			case VAR:
				{
				alt4 = 7;
				}
				break;
			case FUNC:
			case METHOD:
				{
				alt4 = 8;
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
				// Func.g:23:4: STRING
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(23, 4);
				STRING11=(IToken)Match(input,STRING,Follow._STRING_in_term114); 
				STRING11_tree = (CommonTree)adaptor.Create(STRING11);
				adaptor.AddChild(root_0, STRING11_tree);


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// Func.g:24:4: BOOLEAN
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(24, 4);
				BOOLEAN12=(IToken)Match(input,BOOLEAN,Follow._BOOLEAN_in_term119); 
				BOOLEAN12_tree = (CommonTree)adaptor.Create(BOOLEAN12);
				adaptor.AddChild(root_0, BOOLEAN12_tree);


				}
				break;
			case 3:
				DebugEnterAlt(3);
				// Func.g:25:4: NUMBER
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(25, 4);
				NUMBER13=(IToken)Match(input,NUMBER,Follow._NUMBER_in_term124); 
				NUMBER13_tree = (CommonTree)adaptor.Create(NUMBER13);
				adaptor.AddChild(root_0, NUMBER13_tree);


				}
				break;
			case 4:
				DebugEnterAlt(4);
				// Func.g:26:4: DATETIME
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(26, 4);
				DATETIME14=(IToken)Match(input,DATETIME,Follow._DATETIME_in_term129); 
				DATETIME14_tree = (CommonTree)adaptor.Create(DATETIME14);
				adaptor.AddChild(root_0, DATETIME14_tree);


				}
				break;
			case 5:
				DebugEnterAlt(5);
				// Func.g:27:4: DATE
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(27, 4);
				DATE15=(IToken)Match(input,DATE,Follow._DATE_in_term134); 
				DATE15_tree = (CommonTree)adaptor.Create(DATE15);
				adaptor.AddChild(root_0, DATE15_tree);


				}
				break;
			case 6:
				DebugEnterAlt(6);
				// Func.g:28:4: TIME
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(28, 4);
				TIME16=(IToken)Match(input,TIME,Follow._TIME_in_term139); 
				TIME16_tree = (CommonTree)adaptor.Create(TIME16);
				adaptor.AddChild(root_0, TIME16_tree);


				}
				break;
			case 7:
				DebugEnterAlt(7);
				// Func.g:29:4: VAR
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(29, 4);
				VAR17=(IToken)Match(input,VAR,Follow._VAR_in_term144); 
				VAR17_tree = (CommonTree)adaptor.Create(VAR17);
				adaptor.AddChild(root_0, VAR17_tree);


				}
				break;
			case 8:
				DebugEnterAlt(8);
				// Func.g:30:4: func
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(30, 4);
				PushFollow(Follow._func_in_term149);
				func18=func();
				PopFollow();

				adaptor.AddChild(root_0, func18.Tree);

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
			TraceOut("term", 4);
			LeaveRule("term", 4);
			LeaveRule_term();
	    }
	 	DebugLocation(31, 1);
		} finally { DebugExitRule(GrammarFileName, "term"); }
		return retval;

	}
	// $ANTLR end "term"
	#endregion Rules


	#region Follow sets
	private static class Follow
	{
		public static readonly BitSet _func_in_build48 = new BitSet(new ulong[]{0x8000000UL});
		public static readonly BitSet _SEMICOL_in_build50 = new BitSet(new ulong[]{0x44000UL});
		public static readonly BitSet _EOF_in_build55 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_func67 = new BitSet(new ulong[]{0x1000000UL});
		public static readonly BitSet _OPEN_PAR_in_func76 = new BitSet(new ulong[]{0xB0844330UL});
		public static readonly BitSet _args_in_func79 = new BitSet(new ulong[]{0x20UL});
		public static readonly BitSet _CLOSE_PAR_in_func82 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _term_in_args95 = new BitSet(new ulong[]{0x42UL});
		public static readonly BitSet _COMMA_in_args98 = new BitSet(new ulong[]{0xB0844310UL});
		public static readonly BitSet _term_in_args101 = new BitSet(new ulong[]{0x42UL});
		public static readonly BitSet _STRING_in_term114 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _BOOLEAN_in_term119 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _NUMBER_in_term124 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _DATETIME_in_term129 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _DATE_in_term134 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _TIME_in_term139 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _VAR_in_term144 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _func_in_term149 = new BitSet(new ulong[]{0x2UL});
	}
	#endregion Follow sets
}
