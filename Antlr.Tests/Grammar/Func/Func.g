grammar Func;

options {
    language=CSharp2;
    output=AST;
    ASTLabelType=CommonTree;
}

public 
build 
	: (func SEMICOL!)* EOF
	;
	
func
	:	(FUNC | METHOD)^ OPEN_PAR! args? CLOSE_PAR! // (DOT (FUNC | METHOD) OPEN_PAR args? CLOSE_PAR)*
	;

args
	:	term (COMMA! term)*
	;

term
	:	STRING
	|	BOOLEAN
	|	NUMBER
	|	DATETIME
	|	DATE
	|	TIME
	|	VAR
	|	func
	;
	
fragment LETTER : ('a'..'z' | 'A'..'Z') ;
fragment DIGIT : '0'..'9';
fragment IDENT : LETTER (LETTER | DIGIT)*;

fragment YEAR :			DIGIT DIGIT DIGIT DIGIT ;
fragment MONTH :		DIGIT DIGIT ;
fragment DAY :			DIGIT DIGIT ;
fragment HOUR :			DIGIT DIGIT ;
fragment MINUTE :		DIGIT DIGIT ;
fragment SECOND :		DIGIT DIGIT ;
fragment MILLISECOND :	DIGIT DIGIT DIGIT ;

fragment DATE_FRAG : YEAR '-' MONTH '-' DAY;
fragment TIME_FRAG : HOUR ':' MINUTE ':' SECOND ('.' MILLISECOND)?;

fragment DATETIME : ;
fragment PATH : IDENT ('.' IDENT)* ;
fragment METHOD : ;
	
DOT: '.';
COMMA : ',';
SEMICOL : ';';
OPEN_PAR : '(';
CLOSE_PAR : ')';
PLUS : '+' ;
MINUS : '-' ;
MUL : '*' ;
DIV : '/' ;
MOD : '%' ;
ASSIGN : '=' ;

NUMBER : '-'? DIGIT+ ('.' DIGIT+)? ;

BOOLEAN	
	: 'true' 
	| 'false'
	;

STRING
	@init{ System.Text.StringBuilder b = new System.Text.StringBuilder(); }
	:	'"'
		(	'\\' '"'			{ b.Append('"');}
		|	c=~('"')			{ b.Append((char)c);}
		)*
		'"'
		{ Text = b.ToString(); }
	;

DATE : DATE_FRAG ((' ' TIME_FRAG) => ' ' TIME_FRAG {$type=DATETIME;})?;
TIME : TIME_FRAG ;

VAR : '$' PATH ((OPEN_PAR) => {$type=METHOD;})?;
FUNC : PATH ;

WS : (' ' | '\t' | '\n' | '\r' | '\f')+ {$channel = Hidden;};

COMMENT : '//' .* ('\n'|'\r') {$channel = Hidden;};
MULTILINE_COMMENT : '/*' .* '*/' {$channel = Hidden;} ;