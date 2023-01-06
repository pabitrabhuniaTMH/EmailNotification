€
hC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationTemplateDBAccess\DBHelper\Connection.cs
	namespace 	(
NotificationTemplateDBAccess
 &
.& '
DBHelper' /
{		 
internal

 
static

 
class

 

Connection

 $
{ 
} 
} â
uC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationTemplateDBAccess\DBHelper\OracleDynamicParameters.cs
	namespace 	(
NotificationTemplateDBAccess
 &
.& '
DBHelper' /
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class #
OracleDynamicParameters (
:) *
	SqlMapper+ 4
.4 5
IDynamicParameters5 G
{ 
private 
readonly 
DynamicParameters *
dynamicParameters+ <
== >
new? B
DynamicParametersC T
(T U
)U V
;V W
private 
readonly 
List 
< 
OracleParameter -
>- .
oracleParameters/ ?
=@ A
newB E
ListF J
<J K
OracleParameterK Z
>Z [
([ \
)\ ]
;] ^
public 
void 
Add 
( 
string 
name #
,# $
OracleDbType% 1
oracleDbType2 >
,> ?
ParameterDirection@ R
	directionS \
,\ ]
object^ d
?d e
valuef k
=l m
nulln r
,r s
intt w
?w x
sizey }
=~ 
null
Ä Ñ
)
Ñ Ö
{ 	
OracleParameter 
oracleParameter +
;+ ,
if 
( 
size 
. 
HasValue 
) 
{ 
oracleParameter 
=  !
new" %
OracleParameter& 5
(5 6
name6 :
,: ;
oracleDbType< H
,H I
sizeJ N
.N O
ValueO T
,T U
valueV [
,[ \
	direction] f
)f g
;g h
} 
else 
{ 
oracleParameter 
=  !
new" %
OracleParameter& 5
(5 6
name6 :
,: ;
oracleDbType< H
,H I
valueJ O
,O P
	directionQ Z
)Z [
;[ \
} 
oracleParameters 
. 
Add  
(  !
oracleParameter! 0
)0 1
;1 2
}   	
public## 
void## 
AddParameters## !
(##! "

IDbCommand##" ,
command##- 4
,##4 5
	SqlMapper##6 ?
.##? @
Identity##@ H
identity##I Q
)##Q R
{$$ 	
(%% 
(%% 
	SqlMapper%% 
.%% 
IDynamicParameters%% *
)%%* +
dynamicParameters%%+ <
)%%< =
.%%= >
AddParameters%%> K
(%%K L
command%%L S
,%%S T
identity%%U ]
)%%] ^
;%%^ _
var'' 
oracleCommand'' 
='' 
command''  '
as''( *
OracleCommand''+ 8
;''8 9
if)) 
()) 
oracleCommand)) 
!=))  
null))! %
)))% &
{** 
oracleCommand++ 
.++ 

Parameters++ (
.++( )
AddRange++) 1
(++1 2
oracleParameters++2 B
.++B C
ToArray++C J
(++J K
)++K L
)++L M
;++M N
},, 
}-- 	
}.. 
}// ˙(
qC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationTemplateDBAccess\Repository\EmailNotification.cs
	namespace		 	(
NotificationTemplateDBAccess		
 &
.		& '

Repository		' 1
{

 
public 

class 
EmailNotification "
:# $
IEmailNotification% 7
{ 
private 
readonly 
string 
?  
_connectionString! 2
;2 3
public 
EmailNotification  
(  !
IConfiguration! /
configuration0 =
)= >
{ 	
_connectionString 
= 
configuration  -
.- .
GetConnectionString. A
(A B
$strB U
)U V
;V W
} 	
public 
int 
SeveNotification #
(# $%
EmailNotificationTemplate$ =%
emailNotificationTemplate> W
)W X
{ 	
try 
{ 
var 
dp 
= 
new #
OracleDynamicParameters 4
(4 5
)5 6
;6 7
dp 
. 
Add 
( 
$str 
, 
OracleDbType )
.) *
Decimal* 1
,1 2
ParameterDirection3 E
.E F
InputF K
,K L
$numL S
)S T
;T U
dp 
. 
Add 
( 
$str )
,) *
OracleDbType+ 7
.7 8
	NVarchar28 A
,A B
ParameterDirectionB T
.T U
InputU Z
,Z [%
emailNotificationTemplate\ u
.u v
NotificationType	v Ü
!
Ü á
)
á à
;
à â
dp 
. 
Add 
( 
$str !
,! "
OracleDbType# /
./ 0
	NVarchar20 9
,9 :
ParameterDirection; M
.M N
InputN S
,S T%
emailNotificationTemplateU n
.n o
Typeo s
!s t
)t u
;u v
dp 
. 
Add 
( 
$str *
,* +
OracleDbType, 8
.8 9
Date9 =
,= >
ParameterDirection? Q
.Q R
InputR W
,W X%
emailNotificationTemplateY r
.r s
TemplateValidUpto	s Ñ
)
Ñ Ö
;
Ö Ü
dp 
. 
Add 
( 
$str  
,  !
OracleDbType" .
.. /
	NVarchar2/ 8
,8 9
ParameterDirection: L
.L M
InputM R
,R S%
emailNotificationTemplateT m
.m n
Subjectn u
!u v
)v w
;w x
dp 
. 
Add 
( 
$str $
,$ %
OracleDbType& 2
.2 3
	NVarchar23 <
,< =
ParameterDirection> P
.P Q
InputQ V
,V W%
emailNotificationTemplateX q
.q r
BodyMassager }
!} ~
)~ 
;	 Ä
dp 
. 
Add 
( 
$str &
,& '
OracleDbType( 4
.4 5
	NVarchar25 >
,> ?
ParameterDirection@ R
.R S
InputS X
,X Y%
emailNotificationTemplateZ s
.s t
RequestDevice	t Å
!
Å Ç
)
Ç É
;
É Ñ
dp   
.   
Add   
(   
$str   #
,  # $
OracleDbType  % 1
.  1 2
Decimal  2 9
,  9 :
ParameterDirection  ; M
.  M N
Input  N S
,  S T%
emailNotificationTemplate  U n
.  n o

Requestion  o y
!  y z
)  z {
;  { |
dp!! 
.!! 
Add!! 
(!! 
$str!! 
,!! 
OracleDbType!! +
.!!+ ,
	NVarchar2!!, 5
,!!5 6
ParameterDirection!!7 I
.!!I J
Input!!J O
,!!O P
$str!!Q d
)!!d e
;!!e f
using"" 
("" 
var"" 
db"" 
="" 
new""  #
OracleConnection""$ 4
(""4 5
_connectionString""5 F
)""F G
)""G H
{## 
var%% 
result%% 
=%% 
db%% !
.%%! "
Execute%%" )
(%%) *
$str%%* =
,%%= >
dp%%? A
,%%A B
commandType%%B M
:%%M N
CommandType%%N Y
.%%Y Z
StoredProcedure%%Z i
)%%i j
;%%j k
return&& 
result&& !
;&&! "
}'' 
}(( 
catch)) 
{** 
return++ 
$num++ 
;++ 
},, 
}.. 	
}00 
}11 à
hC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationTemplateDBAccess\Repository\Template.cs
	namespace 	(
NotificationTemplateDBAccess
 &
.& '

Repository' 1
{ 
public 

class 
Template 
: 
	ITemplate %
{		 
private

 
readonly

 
string

 
?

  
_connectionString

! 2
;

2 3
public 
Template 
( 
IConfiguration &
configuration' 4
)4 5
{ 	
_connectionString 
= 
configuration  -
.- .
GetConnectionString. A
(A B
$strB U
)U V
;V W
} 	
public 
IEnumerable 
< 
NotificationParams -
>- .
GetTemplateByType/ @
(@ A
stringA G
typeH L
,L M
intM P
NotificationIdQ _
)_ `
{ 	
using 
( 
var 
db 
= 
new 
OracleConnection /
(/ 0
_connectionString0 A
)A B
)B C
{ 
var 
result 
= 
db 
.  
Query  %
<% &
NotificationParams& 8
>8 9
(9 :
$str: {
+{ |
type	| Ä
+
Ä Å
$str
Å å
+
å ç
NotificationId
ç õ
+
õ ú
$str
ú û
)
û ü
;
ü †
return 
result 
; 
} 
} 	
} 
} Ó
\C:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationTemplateDBAccess\Service.cs
	namespace 	(
NotificationTemplateDBAccess
 &
{ 
public 

static 
class 
Service 
{ 
public		 
static		 
IServiceCollection		 (.
"ConfigNotificationTemplateDBAccess		) K
(		K L
this		L P
IServiceCollection		Q c
service		d k
)		k l
{

 	
service 
. 
	AddScoped 
< 
IEmailNotification 0
,0 1
EmailNotification1 B
>B C
(C D
)D E
;E F
service 
. 
	AddScoped 
< 
	ITemplate '
,' (
Template) 1
>1 2
(2 3
)3 4
;4 5
return 
service 
; 
} 	
} 
} 