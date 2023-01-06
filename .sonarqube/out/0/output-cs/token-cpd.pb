°
uC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationEntityModels\CustomException\InvalidDataException.cs
	namespace 	$
NotificationEntityModels
 "
." #
CustomException# 2
{ 
[ #
ExcludeFromCodeCoverage 
] 
[ 
Serializable 
] 
public 

class  
InvalidDataException %
:& '
	Exception( 1
{		 
public

  
InvalidDataException

 #
(

# $
)

$ %
{

& '
}

( )
public  
InvalidDataException #
(# $
string$ *
name+ /
)/ 0
: 
base 
( 
String 
. 
Format  
(  !
name! %
)% &
)& '
{ 	
} 	
} 
} •
oC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationEntityModels\IRepository\IEmailNotification.cs
	namespace 	$
NotificationEntityModels
 "
." #
IRepository# .
{		 
public

 

	interface

 
IEmailNotification

 '
{ 
public 
int 
SeveNotification #
(# $%
EmailNotificationTemplate$ =%
emailNotificationTemplate> W
)W X
;X Y
} 
} Ê
fC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationEntityModels\IRepository\ITemplate.cs
	namespace 	$
NotificationEntityModels
 "
." #
IRepository# .
{		 
public

 

	interface

 
	ITemplate

 
{ 
IEnumerable 
< 
NotificationParams &
>& '
GetTemplateByType( 9
(9 :
string: @
typeA E
,E F
intF I
NotificationIdJ X
)X Y
;Y Z
} 
} ¿
hC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationEntityModels\Models\APIResponseModel.cs
	namespace 	$
NotificationEntityModels
 "
." #
Models# )
{ 
public 

class 
ApiResponseModel !
{ 
public 
object 
? 
MsgHdr 
{ 
get  #
;# $
set% (
;( )
}* +
public 
object 
? 
MsgBdy 
{ 
get  #
;# $
set% (
;( )
}* +
} 
public 

class 
ResponseModel 
< 
T  
>  !
{		 
public

 
T

 
?

 
Data

 
{

 
get

 
;

 
set

 !
;

! "
}

# $
} 
public 

class 
BaseResponseModel "
:# $

BaseEntity% /
{ 
public 
int 

StatusCode 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
? 
Status 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
? 
Message 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} Í
bC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationEntityModels\Models\BaseEntity.cs
	namespace 	$
NotificationEntityModels
 "
." #
Models# )
{ 
public 

class 

BaseEntity 
{ 
public 
long 
ID 
{ 
get 
; 
set !
;! "
}# $
}		 
}

 †
iC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationEntityModels\Models\EmailNotification.cs
	namespace 	$
NotificationEntityModels
 "
." #
Models# )
{ 
public 

class 
EmailNotification "
{ 
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 7
)7 8
]8 9
public		 
NotifyTo		 
?		 
NotifyTo		 !
{		" #
get		$ '
;		' (
set		) ,
;		, -
}		. /
[

 	
Required

	 
(

 
ErrorMessage

 
=

  
$str

! ?
)

? @
]

@ A
public 
Char 
? 
NotificationType %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
[ 	
Required	 
( 
ErrorMessage 
=  
$str! E
)E F
]F G
public 
string 
? "
NotificationTemplateId -
{. /
get0 3
;3 4
set5 8
;8 9
}: ;
} 
public 

class 
NotifyTo 
: 

BaseEntity $
{ 
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 3
)3 4
]4 5
public 
string 
? 
NAME 
{ 
get !
;! "
set# &
;& '
}( )
[ 	
Required	 
( 
ErrorMessage 
=  
$str  :
): ;
]; <
public 
string 
? 
EMAIL 
{ 
get "
;" #
set$ '
;' (
}) *
} 
public 

enum 
NFType 
{ 
SMS 
= 
$char 
, 
EMAIL 
= 
$char 
, 
WHATSAPP 
= 
$char 
} 
}   ³
lC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationEntityModels\Models\NotificationTemplate.cs
	namespace 	$
NotificationEntityModels
 "
." #
Models# )
{ 
public 

class %
EmailNotificationTemplate *
{ 
[ 	
Required	 
( 
ErrorMessage 
=  
$str  >
)> ?
]? @
public 
string 
? 
NotificationType '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
[		 	
Required			 
(		 
ErrorMessage		 
=		  
$str		! 3
)		3 4
]		4 5
public

 
string

 
?

 
Type

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
[ 	
DisplayFormat	 
( 
DataFormatString '
=( )
$str* :
): ;
]; <
public 
DateTime 
TemplateValidUpto )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 6
)6 7
]7 8
public 
string 
? 
Subject 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	
Required	 
( 
ErrorMessage 
=  
$str! :
): ;
]; <
public 
string 
? 
BodyMassage "
{# $
get% (
;( )
set* -
;- .
}/ 0
[ 	
Required	 
( 
ErrorMessage 
=  
$str! <
)< =
]= >
public 
string 
? 
RequestDevice $
{% &
get' *
;* +
set, /
;/ 0
}1 2
[ 	
Required	 
( 
ErrorMessage 
=  
$str! 9
)9 :
]: ;
public 
int 
? 

Requestion 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
public 

class 
NotificationParams #
{ 
public 
int 
? 
ID 
{ 
get 
; 
set !
;! "
}# $
public 
string 
? 
NotificationType '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
string 
? 
Type 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
? 
TemplateValidUpto (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
string 
? 
Subject 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
? 
BodyMessage "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
? 
RequestDevice $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public   
string   
?   

Requestion   !
{  " #
get  $ '
;  ' (
set  ) ,
;  , -
}  . /
}"" 
}## ä
gC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationEntityModels\Models\SMSNotification.cs
	namespace 	$
NotificationEntityModels
 "
." #
Models# )
{ 
public 

class 
SmsNotification  
:  !

BaseEntity! +
{ 
public		 
string		 
?		 
NAME		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
[

 	
IsPhoneAttribute

	 
]

 
public 
string 
? 
PHONE 
{ 
get "
;" #
set$ '
;' (
}) *
public 
Char 
NOTIFICATIONTYPE $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
int 

TEMPLATENO 
{ 
get  #
;# $
set% (
;( )
}* +
} 
[ #
ExcludeFromCodeCoverage 
] 
public 

class 
IsPhoneAttribute !
:" #
ValidationAttribute$ 7
{ 
	protected 
override 
ValidationResult +
IsValid, 3
(3 4
object4 :
?: ;
value< A
,A B
ValidationContextC T
validationContextU f
)f g
{ 	
try 
{ 
if 
( 
value 
== 
null 
) 
throw 
new  
InvalidDataException 2
(2 3
$str3 T
)T U
;U V
if 
( 
! 
Regex 
. 
IsMatch "
(" #
value# (
.( )
ToString) 1
(1 2
)2 3
!3 4
,4 5
$str6 G
)G H
)H I
return 
new 
ValidationResult /
(/ 0
$str0 M
)M N
;N O
return 
ValidationResult '
.' (
Success( /
!/ 0
;0 1
} 
catch 
( 
	Exception 
e 
) 
{ 
return   
new   
ValidationResult   +
(  + ,
e  , -
.  - .
Message  . 5
)  5 6
;  6 7
}!! 
}"" 	
}## 
}$$ º
jC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationEntityModels\ServiceHelper\MethodsName.cs
	namespace 	#
SMSNotificationServices
 !
.! "
ServiceHelper" /
{		 
[

 #
ExcludeFromCodeCoverage

 
]

 
public 

static 
class 
MethodsName #
{ 
public 
static 
readonly 
string %
GetTemplate& 1
=2 3
$str4 b
;b c
} 
} ¾
nC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationEntityModels\ServiceHelper\NotificationLog.cs
	namespace 	#
SMSNotificationServices
 !
.! "
ServiceHelper" /
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class 
NotificationLog  
{ 
private 
readonly 
long 

_timeStamp (
;( )
public		 
NotificationLog		 
(		 
long		 #
	timeStamp		$ -
)		- .
{

 	

_timeStamp 
= 
	timeStamp "
;" #
} 	
public 
void 
WriteLogMessage #
(# $
string$ *

logMessage+ 5
)5 6
{ 	
StreamWriter 
log 
; 

FileStream 
? 

fileStream "
=# $
null% )
;) *
DirectoryInfo 
? 

logDirInfo %
=& '
null( ,
;, -
FileInfo 
logFileInfo  
;  !
string 
logFilePath 
=  
Environment! ,
., -
CurrentDirectory- =
+= >
$str> H
;H I
logFilePath 
= 
logFilePath %
+& '
DateTime( 0
.0 1
Today1 6
.6 7
ToString7 ?
(? @
$str@ L
)L M
+N O
$strP S
+T U

_timeStampV `
.` a
ToStringa i
(i j
)j k
+l m
$strn q
+r s
$strt y
;y z
logFileInfo 
= 
new 
FileInfo &
(& '
logFilePath' 2
)2 3
;3 4

logDirInfo 
= 
new 
DirectoryInfo *
(* +
logFileInfo+ 6
.6 7
DirectoryName7 D
!D E
)E F
;F G
if 
( 
! 

logDirInfo 
. 
Exists "
)" #

logDirInfo$ .
.. /
Create/ 5
(5 6
)6 7
;7 8
if 
( 
! 
logFileInfo 
. 
Exists #
)# $
{ 

fileStream 
= 
logFileInfo (
.( )
Create) /
(/ 0
)0 1
;1 2
} 
else 
{ 

fileStream 
= 
new  

FileStream! +
(+ ,
logFilePath, 7
,7 8
FileMode9 A
.A B
AppendB H
)H I
;I J
}   
log!! 
=!! 
new!! 
StreamWriter!! "
(!!" #

fileStream!!# -
)!!- .
;!!. /
log"" 
."" 
Write"" 
("" 
$str"" x
)""x y
;""y z
log## 
.## 
Write## 
(## 
$str## -
,##- .
DateTime##/ 7
.##7 8
Now##8 ;
.##; <
ToString##< D
(##D E
$str##E ^
)##^ _
)##_ `
;##` a
log$$ 
.$$ 
Write$$ 
($$ 
$str$$ -
,$$- .

logMessage$$/ 9
)$$9 :
;$$: ;
log%% 
.%% 
Write%% 
(%% 
$str%% x
)%%x y
;%%y z
log&& 
.&& 
Close&& 
(&& 
)&& 
;&& 
}'' 	
})) 
}** á
hC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationEntityModels\ServiceHelper\TimeStamp.cs
	namespace 	#
SMSNotificationServices
 !
.! "
ServiceHelper" /
{ 
public 

static 
class 
	TimeStamp !
{ 
public 
static 
long 
GetTimeStamp '
(' (
)( )
{ 	
var		 
baseDate		 
=		 
new		 
DateTime		 '
(		' (
$num		( ,
,		, -
$num		. 0
,		0 1
$num		2 4
)		4 5
;		5 6
var

 
numberOfSeconds

 
=

  !
DateTime

" *
.

* +
Now

+ .
.

. /
Subtract

/ 7
(

7 8
baseDate

8 @
)

@ A
.

A B
TotalSeconds

B N
;

N O
return 
Convert 
. 
ToInt64 "
(" #
numberOfSeconds# 2
)2 3
;3 4
} 	
} 
} 