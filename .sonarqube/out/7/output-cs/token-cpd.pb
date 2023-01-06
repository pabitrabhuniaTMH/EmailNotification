¨
vC:\Users\Pabitra Bhunia\source\EmailNotification GIT\SMSBasedNotification\Controllers\SendSMSNotificationController.cs
	namespace 	 
SMSBasedNotification
 
. 
Controllers *
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
 +
SendNotificationToSmsController

 0
:

1 2
ControllerBase

3 A
{ 
private 
readonly #
ISmsNotificationService 0#
_sMSNotificationService1 H
;H I
private 
readonly 
NotificationLog (
_notificationLog) 9
;9 :
public +
SendNotificationToSmsController .
(. /#
ISmsNotificationService/ F"
sMSNotificationServiceG ]
)] ^
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
;L M#
_sMSNotificationService #
=$ %"
sMSNotificationService& <
;< =
} 	
[ 	
HttpPost	 
( 
$str )
)) *
]* +
public 
async 
Task 
< 
IActionResult '
>' (!
SendNotificationToSMS) >
(> ?
[? @
FromBody@ H
]H I
SmsNotificationI X
sMSNotificationY h
)h i
{ 	
_notificationLog 
. 
WriteLogMessage ,
(, -
$str- G
)G H
;H I
var 
result 
= 
await #
_sMSNotificationService 6
.6 7
SendNotification7 G
(G H
sMSNotificationH W
)W X
;X Y
return 
Ok 
( 
result 
) 
; 
} 	
} 
} ¢
TC:\Users\Pabitra Bhunia\source\EmailNotification GIT\SMSBasedNotification\Program.cs
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
. (
ConfigSMSNotificationService -
(- .
). /
;/ 0
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
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
 #
AddEndpointsApiExplorer

 (
(

( )
)

) *
;

* +
builder 
. 
Services 
. 
AddSwaggerGen 
( 
)  
;  !
var 
app 
= 	
builder
 
. 
Build 
( 
) 
; 
if 
( 
app 
. 
Environment 
. 
IsDevelopment !
(! "
)" #
)# $
{ 
app 
. 

UseSwagger 
( 
) 
; 
app 
. 
UseSwaggerUI 
( 
) 
; 
} 
app 
. 
UseHttpsRedirection 
( 
) 
; 
app 
. 
UseAuthorization 
( 
) 
; 
app 
. 
MapControllers 
( 
) 
; 
app 
. 
Run 
( 
) 	
;	 
