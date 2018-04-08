grammar sgf;

collection
	: gameTree+
	;

gameTree
	: '(' sequence gameTree* ')'
	;

sequence
	: (';' property)+
	;

property
	: PROP_IDENT propValue+
	;

propValue
	: '[' (NUMBER | REAL | TEXT | PROP_IDENT)? ']'
	;

REAL:       [+-]? [0-9]+ ('.' [0-9]*)?;
NUMBER:     [+-]? [0-9]+;
PROP_IDENT: [A-Z][A-Z0-9]*;
TEXT:       (~']' | '\\]' | '\\\\')+;

/* game-specific:
DOUBLE:     [12];
COLOR:      [BW];
Point
Move
Stone
*/