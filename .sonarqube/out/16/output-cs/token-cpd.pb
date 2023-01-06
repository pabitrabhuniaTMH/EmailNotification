À
zC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationTemplateServices\IRepository\IEmailNotificationService.cs
	namespace 	(
NotificationTemplateServices
 &
.& '
IRepository' 2
{		 
public

 

	interface

 %
IEmailNotificationService

 .
{ 
public 
ApiResponseModel $
SaveNotificationTemplate  8
(8 9%
EmailNotificationTemplate9 R%
emailNotificationTemplateS l
)l m
;m n
} 
} ©
rC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationTemplateServices\IRepository\ITemplateServices.cs
	namespace 	(
NotificationTemplateServices
 &
.& '
IRepository' 2
{		 
public

 

	interface

 
ITemplateServices

 &
{ 
ApiResponseModel 
GetTemplateByType *
(* +
string+ 1
type2 6
,6 7
int7 :
NotificationId; I
)I J
;J K
} 
} Ê 
xC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationTemplateServices\Repository\EmailNotificationService.cs
	namespace 	(
NotificationTemplateServices
 &
.& '

Repository' 1
{ 
public 

class %
EmailNotificationServices *
:+ ,%
IEmailNotificationService- F
{		 
private

 
readonly

 
IEmailNotification

 +
_emailNotification

, >
;

> ?
private 
readonly 
NotificationLog (
_notificationLog) 9
;9 :
public %
EmailNotificationServices (
(( )
IEmailNotification) ;
emailNotification< M
)M N
{ 	
_notificationLog 
= 
new "
NotificationLog# 2
(2 3
	TimeStamp3 <
.< =
GetTimeStamp= I
(I J
)J K
)K L
;L M
_emailNotification 
=  
emailNotification  1
;1 2
} 	
public 
ApiResponseModel $
SaveNotificationTemplate  8
(8 9%
EmailNotificationTemplate9 R%
emailNotificationTemplateS l
)l m
{ 	
try 
{ 
_notificationLog  
.  !
WriteLogMessage! 0
(0 1
$str1 ^
)^ _
;_ `
if 
( %
emailNotificationTemplate -
.- .
NotificationType. >
!=? A
$strB E
)E F
throw 
new  
InvalidDataException 2
(2 3
$str3 Q
)Q R
;R S
var 
result 
= 
_emailNotification /
./ 0
SeveNotification0 @
(@ A%
emailNotificationTemplateA Z
)Z [
;[ \
if 
( 
result 
!= 
$num 
)  
{ 
return 
new 
ApiResponseModel /
{ 
MsgHdr 
=  
new! $
ResponseModel% 2
<2 3
BaseResponseModel3 D
>D E
{ 
Data    
=  ! "
new  # &
BaseResponseModel  ' 8
{!! 
ID""  "
=""# $
	TimeStamp""% .
."". /
GetTimeStamp""/ ;
(""; <
)""< =
,""= >

StatusCode##  *
=##+ ,
$num##- 0
,##0 1
Status$$  &
=$$' (
$str$$) 2
,$$2 3
Message%%  '
=%%( )
$str%%* L
}&& 
}'' 
}(( 
;(( 
})) 
throw** 
new**  
InvalidDataException** .
(**. /
)**/ 0
;**0 1
}++ 
catch,, 
(,,  
InvalidDataException,, '
e,,( )
),,) *
{-- 
_notificationLog..  
...  !
WriteLogMessage..! 0
(..0 1
$str..1 `
+..` a
e..a b
...b c
ToString..c k
(..k l
)..l m
)..m n
;..n o
return// 
new// 
ApiResponseModel// +
{00 
MsgHdr11 
=11 
new11  
ResponseModel11! .
<11. /
BaseResponseModel11/ @
>11@ A
{22 
Data33 
=33 
new33 "
BaseResponseModel33# 4
{44 
ID55 
=55  
	TimeStamp55! *
.55* +
GetTimeStamp55+ 7
(557 8
)558 9
,559 :

StatusCode66 &
=66' (
$num66) ,
,66, -
Status77 "
=77# $
$str77% -
,77- .
Message88 #
=88$ %
e88& '
.88' (
Message88( /
}99 
}:: 
};; 
;;; 
}<< 
}?? 	
}AA 
}BB ó
pC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationTemplateServices\Repository\TemplateServices.cs
	namespace 	(
NotificationTemplateServices
 &
.& '

Repository' 1
{ 
public 

class 
TemplateServices !
:" #
ITemplateServices$ 5
{		 
private

 
readonly

 
	ITemplate

 "
	_template

# ,
;

, -
public 
TemplateServices 
(  
	ITemplate  )
template* 2
)2 3
{ 	
	_template 
= 
template 
; 
} 	
public 
ApiResponseModel 
GetTemplateByType  1
(1 2
string2 8
type9 =
,= >
int> A
NotificationIdB P
)P Q
{ 	
try 
{ 
if 
( 
type 
== 
null  
||! #
type$ (
==) +
$str, .
). /
throw 
new  
InvalidDataException 2
(2 3
$str3 L
)L M
;M N
var 
result 
= 
	_template $
.$ %
GetTemplateByType% 6
(6 7
type7 ;
!; <
,< =
NotificationId> L
)L M
;M N
if 
( 
result 
!= 
null  
)  !
{ 
return 
new 
ApiResponseModel /
{ 
MsgHdr 
=  
new! $
BaseResponseModel% 6
{ 
ID 
=  
	TimeStamp! *
.* +
GetTimeStamp+ 7
(7 8
)8 9
,9 :
Status "
=# $
$str% .
,. /

StatusCode   &
=  ' (
$num  ) ,
}!! 
,!! 
MsgBdy"" 
=""  
new""! $
ResponseModel""% 2
<""2 3
NotificationParams""3 E
>""E F
{## 
Data$$  
=$$! "
result$$# )
.$$) *
FirstOrDefault$$* 8
($$8 9
)$$9 :
}%% 
}&& 
;&& 
}'' 
throw(( 
new((  
InvalidDataException(( .
(((. /
)((/ 0
;((0 1
})) 
catch** 
(**  
InvalidDataException** &
e**' (
)**( )
{++ 
return,, 
new,, 
ApiResponseModel,, +
{-- 
MsgHdr.. 
=.. 
new..  
BaseResponseModel..! 2
{// 
ID00 
=00 
	TimeStamp00 &
.00& '
GetTimeStamp00' 3
(003 4
)004 5
,005 6
Status11 
=11  
$str11! )
,11) *

StatusCode22 "
=22# $
$num22% (
,22( )
Message33 
=33  !
e33" #
.33# $
Message33$ +
}44 
}55 
;55 
}66 
}77 	
}99 
}:: Œ
\C:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationTemplateServices\Service.cs
	namespace 	(
NotificationTemplateServices
 &
{ 
public 

static 
class 
Service 
{		 
public

 
static

 
IServiceCollection

 (-
!ConfigNotificationTemplateService

) J
(

J K
this

K O
IServiceCollection

P b
service

c j
)

j k
{ 	
service 
. 
	AddScoped 
< %
IEmailNotificationService 7
,7 8%
EmailNotificationServices9 R
>R S
(S T
)T U
;U V
service 
. 
	AddScoped 
< 
ITemplateServices /
,/ 0
TemplateServices1 A
>A B
(B C
)C D
;D E
return 
service 
; 
} 	
} 
} 