Å
wC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationTemplate\Controllers\NotificationTemplateController.cs
	namespace 	 
NotificationTemplate
 
. 
Controllers *
{ 
[		 
Route		 

(		
 
$str		 $
)		$ %
]		% &
[

 
ApiController

 
]

 
public 

class *
NotificationTemplateController /
:0 1
ControllerBase2 @
{ 
private 
readonly %
IEmailNotificationService 2%
_emailNotificationService3 L
;L M
private 
readonly 
ITemplateServices *
_templateServices+ <
;< =
private 
readonly 
NotificationLog (
_notificationLog) 9
;9 :
public *
NotificationTemplateController -
(- .%
IEmailNotificationService. G$
emailNotificationServiceH `
,` a
ITemplateServicesa r
templateServices	s ƒ
)
ƒ „
{ 	
_notificationLog 
= 
new "
NotificationLog# 2
(2 3
	TimeStamp3 <
.< =
GetTimeStamp= I
(I J
)J K
)K L
;L M%
_emailNotificationService %
=& '$
emailNotificationService' ?
;? @
_templateServices 
= 
templateServices .
;. /
} 	
[ 	
HttpPost	 
( 
$str 1
)1 2
]2 3
public 
IActionResult )
SaveEmailNotificationTemplate :
(: ;
[; <
FromBody< D
]D E%
EmailNotificationTemplateE ^
emailNotification_ p
)p q
{ 	
_notificationLog 
. 
WriteLogMessage ,
(, -
$str- ~
)~ 
;	 €
var 
result 
= %
_emailNotificationService 0
.0 1$
SaveNotificationTemplate1 I
(I J
emailNotificationJ [
)[ \
;\ ]
return 
Ok 
( 
result 
) 
; 
} 	
[ 	
HttpGet	 
( 
$str *
)* +
]+ ,
public 
IActionResult #
GetNotificationTemplate 4
(4 5
string5 ;
Type< @
,@ A
intA D
NotificationIdE S
)S T
{ 	
var   
result   
=   
_templateServices   *
.  * +
GetTemplateByType  + <
(  < =
Type  = A
,  A B
NotificationId  C Q
)  Q R
;  R S
return!! 
Ok!! 
(!! 
result!! 
)!! 
;!! 
}"" 	
}## 
}$$ Ë
TC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationTemplate\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. .
"ConfigNotificationTemplateDBAccess 3
(3 4
)4 5
;5 6
builder

 
.

 
Services

 
.

 -
!ConfigNotificationTemplateService

 2
(

2 3
)

3 4
;

4 5
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder 
. 
Services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
builder 
. 
Services 
. 
AddSwaggerGen 
( 
)  
;  !
var 
app 
= 	
builder
 
. 
Build 
( 
) 
; 
if 
( 
app 
. 
Environment 
. 
IsDevelopment !
(! "
)" #
)# $
{ 
app 
. 

UseSwagger 
( 
) 
; 
app 
. 
UseSwaggerUI 
( 
) 
; 
} 
app 
. 
UseHttpsRedirection 
( 
) 
; 
app 
. 
UseAuthorization 
( 
) 
; 
app 
. 
MapControllers 
( 
) 
; 
app   
.   
Run   
(   
)   	
;  	 
