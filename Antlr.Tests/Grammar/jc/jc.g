grammar jc;

options {
    language=CSharp2;
    output=AST;
    ASTLabelType=CommonTree;
}

public build 
	: class* EOF
	;
	
class
	:	NAME (':' NAME)? OPEN_BRACE classBody CLOSE_BRACE
	;

classBody
	:	(class | member | property | function)*
	;
	
member
	:	decl SEMICOL
	;
	
property
	:	TYPE NAME OPEN_BRACE 
		('get' codeBlock)?
		('set' codeBlock)?
		CLOSE_BRACE
	;
	
function 
	: 'function' TYPE? OPEN_PAR args? CLOSE_PAR codeBlock
	;
	
args
	:	arg (COMMA arg)*
	;
	
arg
	:	TYPE NAME
	;

codeBlock
	:	OPEN_BRACE (line | statement)* CLOSE_BRACE
	;

line
	: (decl | expression) SEMICOL
	;
	
decl 
	:	(TYPE | 'var') NAME (ASSIGN expression)?
	;
	
statement
	:	 ifStatement | returnStatement
	;
	
ifStatement
	:	'if' OPEN_PAR expression CLOSE_PAR OPEN_BRACE (statement | expression)* CLOSE_BRACE
	;

returnStatement
	:	'return' expression SEMICOL
	;
	
expression
	:	call 
	| 	assignment 
	| 	STRING 
	| 	NUMBER 
	| 	BOOL 
	| 	DATE 
	| 	TIME
	| 	DATETIME
	|	NAME
	|	PATH
	;

call
	:	(NAME | PATH) OPEN_PAR args? CLOSE_PAR
	;

assignment
	:	(NAME | PATH) ASSIGN expression
	;

TYPE
	:	'string'
	|	'number'
	|	'bool'
	|	'date'
	|	'time'
	|	'datetime'
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

fragment PATH : ;
fragment DATETIME : ;

BOOL
	: 'true'
	| 'false'
	;

NAME : IDENT (('.' IDENT) => '.' IDENT {$type=PATH;})* ;

DOT: '.';
COMMA : ',';
SEMICOL : ';';
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

NUMBER : '-'? DIGIT+ ('.' DIGIT+)? ;



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

WS : (' ' | '\t' | '\n' | '\r' | '\f')+ {$channel = Hidden;};

COMMENT : '//' .* ('\n'|'\r') {$channel = Hidden;};
MULTILINE_COMMENT : '/*' .* '*/' {$channel = Hidden;} ;