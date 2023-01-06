˙
xC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationSystem\Controllers\SendNotificationToEmailController.cs
	namespace 	
NotificationSystem
 
. 
Controllers (
{ 
[ 
Route 

(
 
$str $
)$ %
]% &
[		 
ApiController		 
]		 
public

 

class

 -
!SendNotificationToEmailController

 2
:

3 4
ControllerBase

5 C
{ 
private 
readonly &
IEmailNotificationServices 3&
_emailNotificationServices4 N
;N O
private 
readonly 
NotificationLog (
_notificationLog) 9
;9 :
public -
!SendNotificationToEmailController 0
(0 1&
IEmailNotificationServices1 K%
emailNotificationServicesL e
)e f
{ 	
_notificationLog 
= 
new "
NotificationLog# 2
(2 3
	TimeStamp3 <
.< =
GetTimeStamp= I
(I J
)J K
)K L
;L M&
_emailNotificationServices &
=' (%
emailNotificationServices) B
;B C
} 	
[ 	
HttpPost	 
] 
[ 	
Route	 
( 
$str (
)( )
]) *
public 
async 
Task 
< 
IActionResult '
>' (#
SendNotificationToEmail) @
(@ A
[A B
FromBodyB J
]J K
EmailNotificationK \
emailNotification] n
)n o
{ 	
_notificationLog 
. 
WriteLogMessage ,
(, -
$str- i
)i j
;j k
var 
result 
= 
await &
_emailNotificationServices 9
.9 :
SendNotification: J
(J K
emailNotificationK \
)\ ]
;] ^
return 
Ok 
( 
result 
) 
; 
} 	
} 
} ù
RC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationSystem\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. %
ConfigNotificationService *
(* +
)+ ,
;, -
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder		 
.		 
Services		 
.		 #
AddEndpointsApiExplorer		 (
(		( )
)		) *
;		* +
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
 
AddSwaggerGen

 
(

 
)

  
;

  !
var 
app 
= 	
builder
 
. 
Build 
( 
) 
; 
if 
( 
app 
. 
Environment 
. 
IsDevelopment !
(! "
)" #
)# $
{ 
app 
. 

UseSwagger 
( 
) 
; 
app 
. 
UseSwaggerUI 
( 
) 
; 
} 
app 
. 
UseHttpsRedirection 
( 
) 
; 
app 
. 
UseAuthorization 
( 
) 
; 
app 
. 
MapControllers 
( 
) 
; 
app 
. 
Run 
( 
) 	
;	 
