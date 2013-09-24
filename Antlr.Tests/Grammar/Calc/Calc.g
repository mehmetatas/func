grammar Calc;

options {
    language=CSharp2;
    output=AST;
    ASTLabelType=CommonTree;
}

tokens {
	NEGATION;
}

public 
build 
	:	body* EOF!
	;

body
	:	(declaration | assignment | clause)*
	;

ifClause
	:	'if' OPEN_PAR condition CLOSE_PAR OPEN_BRACE body* CLOSE_BRACE
	;

condition
	:	
	;

declaration
	:	IDENT IDENT (ASSIGN^ expression)?  SEMI_COL!
	;

assignment
	:	IDENT ASSIGN^ expression  SEMI_COL!
	;
	
// expressions -- fun time!
	
expression
	:	mult ((PLUS^ | MINUS^) mult)*
	;

mult
	:	unary ((MUL^ | DIV^ | MOD^) unary)*
	;
	
unary
	:	(PLUS! | negation^)* term
	;

term
	:	IDENT
	|	OPEN_PAR! expression CLOSE_PAR!
	|	NUMBER
	;

negation
	:	MINUS -> NEGATION
	;

fragment LETTER : ('a'..'z' | 'A'..'Z') ;
fragment DIGIT : '0'..'9';

NUMBER : DIGIT+ ('.' DIGIT+)?;
IDENT : LETTER (LETTER | DIGIT)*;

OPEN_PAR : '(';
CLOSE_PAR : ')';
OPEN_BRACE : '{';
CLOSE_BRACE : '}';
PLUS : '+' ;
MINUS : '-' ;
MUL : '*' ;
DIV : '/' ;
MOD : '%' ;
ASSIGN : '=' ;
SEMI_COL : ';' ;

WS : (' ' | '\t' | '\n' | '\r' | '\f')+ {$channel = Hidden;};

COMMENT : '//' .* ('\n'|'\r') {$channel = Hidden;};
MULTILINE_COMMENT : '/*' .* '*/' {$channel = Hidden;} ;