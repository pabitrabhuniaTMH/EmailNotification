Ê
sC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationServices\IRepository\IEmailNotificationServices.cs
	namespace 	 
NotificationServices
 
. 
IRepository *
{ 
public 

	interface &
IEmailNotificationServices /
{ 
public 
Task 
< 
ApiResponseModel $
>$ %
SendNotification& 6
(6 7
EmailNotification7 H
emailNotificationI Z
)Z [
;[ \
} 
}		 ‚X
qC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationServices\Repository\EmailNotificationServices.cs
	namespace

 	 
NotificationServices


 
.

 

Repository

 )
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class $
EmailNotificationService )
:* +&
IEmailNotificationServices, F
{ 
public 
readonly 
IConfiguration &
?& '
_configuration( 6
;6 7
public 
readonly 
string 
? 

_sendEmail  *
;* +
public 
readonly 
string 
? 
_sendPassword  -
;- .
private 
readonly 
NotificationLog (
_notificationLog) 9
;9 :
private 
readonly 
string 
?  

apiBaseUrl! +
;+ ,
private 
static 
readonly 

HttpClient  *
_httpClient+ 6
=7 8
new9 <
(< =
)= >
;> ?
public $
EmailNotificationService '
(' (
IConfiguration( 6
configuration7 D
)D E
{ 	
_notificationLog 
= 
new "
NotificationLog# 2
(2 3
	TimeStamp3 <
.< =
GetTimeStamp= I
(I J
)J K
)K L
;L M

apiBaseUrl 
= 
configuration &
.& '

GetSection' 1
(1 2
$str2 K
)K L
.L M
ValueM R
;R S
if 
( 
_httpClient 
. 
BaseAddress '
==' )
null) -
)- .
_httpClient 
. 
BaseAddress '
=( )
new* -
Uri. 1
(1 2

apiBaseUrl2 <
!< =
)= >
;> ?

_sendEmail 
= 
configuration &
.& '

GetSection' 1
(1 2
$str2 <
)< =
.= >

GetSection> H
(H I
$strI P
)P Q
.Q R
ValueR W
;W X
_sendPassword 
= 
configuration )
.) *

GetSection* 4
(4 5
$str5 ?
)? @
.@ A

GetSectionA K
(K L
$strL V
)V W
.W X
ValueX ]
;] ^
} 	
public   
async   
Task   
<   
ApiResponseModel   *
>  * +
SendNotification  , <
(  < =
EmailNotification  = N
emailNotification  O `
)  ` a
{!! 	
try"" 
{## 
NFType$$ 
?$$ 
nFType$$ 
=$$  
($$  !
NFType$$! '
)$$' (
emailNotification$$( 9
.$$9 :
NotificationType$$: J
!$$J K
;$$K L
if%% 
(%% 
nFType%% 
!=%% 
NFType%% $
.%%$ %
EMAIL%%% *
)%%* +
throw&& 
new&&  
InvalidDataException&& 2
(&&2 3
$str&&3 Z
)&&Z [
;&&[ \
ApiResponseModel''  
?''  !
apiResponseModel''" 2
;''2 3
_notificationLog((  
.((  !
WriteLogMessage((! 0
(((0 1
$str((1 G
)((G H
;((H I
if++ 
(++ 
!++ 
Regex++ 
.++ 
IsMatch++ "
(++" #
emailNotification++# 4
.++4 5
NotifyTo++5 =
!++= >
.++> ?
EMAIL++? D
!++D E
,++E F
$str	++G ×
,
++× Ø
RegexOptions
++Ù å
.
++å æ

IgnoreCase
++æ ð
)
++ð ñ
)
++ñ ò
throw,, 
new,,  
InvalidDataException,, 2
(,,2 3
emailNotification,,3 D
.,,D E
NotifyTo,,E M
.,,M N
EMAIL,,N S
+,,T U
$str,,V m
),,m n
;,,n o
string// 
endpoint// 
=//  !

apiBaseUrl//" ,
+//- .
MethodsName/// :
.//: ;
GetTemplate//; F
+//G H
$str//I Q
+//Q R
nFType//S Y
+//Y Z
$str//Z m
+//m n
Convert//n u
.//u v
ToInt32//v }
(//} ~
emailNotification	//~ 
.
// $
NotificationTemplateId
// ¦
)
//¦ §
;
//§ ¨
_notificationLog00  
.00  !
WriteLogMessage00! 0
(000 1
$str001 W
+00W X
endpoint00X `
)00` a
;00a b
_httpClient11 
.11 !
DefaultRequestHeaders11 1
.111 2
Accept112 8
.118 9
Clear119 >
(11> ?
)11? @
;11@ A
using22 
(22 
var22 
Response22 #
=22$ %
await22& +
_httpClient22, 7
.227 8
GetAsync228 @
(22@ A
endpoint22A I
)22I J
)22J K
{33 
var44 
result44 
=44  
await44! &
Response44' /
.44/ 0
Content440 7
.447 8
ReadAsStringAsync448 I
(44I J
)44J K
;44K L
apiResponseModel55 $
=55% &
JsonConvert55' 2
.552 3
DeserializeObject553 D
<55D E
ApiResponseModel55E U
>55U V
(55V W
result55W ]
)55] ^
;55^ _
}66 
var77 
data77 
=77 
JsonConvert77 &
.77& '
DeserializeObject77' 8
<778 9
ResponseModel779 F
<77F G
NotificationParams77G Y
>77Y Z
>77Z [
(77[ \
apiResponseModel77\ l
!77l m
.77m n
MsgBdy77n t
!77t u
.77u v
ToString77v ~
(77~ 
)	77 €
!
77€ 
)
77 ‚
;
77‚ ƒ
if99 
(99 
data99 
!99 
.99 
Data99 
==99 !
null99" &
)99& '
throw:: 
new::  
InvalidDataException:: 2
(::2 3
$str::3 N
)::N O
;::O P
var;; 
username;; 
=;; 
emailNotification;; 0
.;;0 1
NotifyTo;;1 9
.;;9 :
NAME;;: >
;;;> ?
MailMessage== 
mail==  
===! "
new==# &
MailMessage==' 2
(==2 3
)==3 4
;==4 5
mail>> 
.>> 
To>> 
.>> 
Add>> 
(>> 
emailNotification>> -
.>>- .
NotifyTo>>. 6
.>>6 7
EMAIL>>7 <
!>>< =
)>>= >
;>>> ?
mail?? 
.?? 
From?? 
=?? 
new?? 
MailAddress??  +
(??+ ,

_sendEmail??, 6
!??6 7
)??7 8
;??8 9
mail@@ 
.@@ 
Subject@@ 
=@@ 
data@@ "
.@@" #
Data@@# '
.@@' (
Subject@@( /
;@@/ 0
mailAA 
.AA 
BodyAA 
=AA 
StringAA "
.AA" #
FormatAA# )
(AA) *
dataAA* .
.AA. /
DataAA/ 3
.AA3 4
BodyMessageAA4 ?
!AA? @
,AA@ A
usernameAAA I
)AAI J
;AAJ K
mailBB 
.BB 

IsBodyHtmlBB 
=BB  !
trueBB" &
;BB& '
usingCC 
(CC 

SmtpClientCC !
smtpCC" &
=CC' (
newCC) ,

SmtpClientCC- 7
(CC7 8
)CC8 9
)CC9 :
{DD 
smtpEE 
.EE 
HostEE 
=EE 
$strEE  0
;EE0 1
smtpFF 
.FF 
PortFF 
=FF 
$numFF  #
;FF# $
smtpGG 
.GG !
UseDefaultCredentialsGG .
=GG/ 0
falseGG1 6
;GG6 7
smtpHH 
.HH 
CredentialsHH $
=HH% &
newHH' *
SystemHH+ 1
.HH1 2
NetHH2 5
.HH5 6
NetworkCredentialHH6 G
(HHG H

_sendEmailHHH R
,HHR S
_sendPasswordHHT a
)HHa b
;HHb c
smtpII 
.II 
	EnableSslII "
=II# $
trueII% )
;II) *
_notificationLogJJ $
.JJ$ %
WriteLogMessageJJ% 4
(JJ4 5
$strJJ5 G
)JJG H
;JJH I
smtpKK 
.KK 
SendKK 
(KK 
mailKK "
)KK" #
;KK# $
_notificationLogLL $
.LL$ %
WriteLogMessageLL% 4
(LL4 5
$strLL5 Q
)LLQ R
;LLR S
}MM 
returnPP 
newPP 
ApiResponseModelPP +
{QQ 
MsgHdrRR 
=RR 
newRR  
ResponseModelRR! .
<RR. /
BaseResponseModelRR/ @
>RR@ A
{RRB C
DataSS 
=SS 
newSS  
BaseResponseModelSS! 2
{SS3 4
IDTT 
=TT 
	TimeStampTT (
.TT( )
GetTimeStampTT) 5
(TT5 6
)TT6 7
,TT7 8
StatusUU "
=UU" #
$strUU# ,
,UU, -

StatusCodeVV &
=VV& '
$numVV' *
,VV* +
MessageWW #
=WW# $
$strWW$ K
}XX 
}YY 
}ZZ 
;ZZ 
}[[ 
catch\\ 
(\\ 
	Exception\\ 
ex\\ 
)\\  
{]] 
_notificationLog^^  
.^^  !
WriteLogMessage^^! 0
(^^0 1
ex^^1 3
.^^3 4
ToString^^4 <
(^^< =
)^^= >
)^^> ?
;^^? @
return__ 
new__ 
ApiResponseModel__ +
{`` 
MsgHdraa 
=aa 
newaa  
ResponseModelaa! .
<aa. /
BaseResponseModelaa/ @
>aa@ A
{bb 
Datacc 
=cc 
newcc "
BaseResponseModelcc# 4
{dd 
IDee 
=ee  
	TimeStampee! *
.ee* +
GetTimeStampee+ 7
(ee7 8
)ee8 9
,ee9 :
Statusff "
=ff# $
$strff% -
,ff- .

StatusCodegg &
=gg' (
$numgg) ,
,gg, -
Messagehh #
=hh$ %
exhh& (
.hh( )
ToStringhh) 1
(hh1 2
)hh2 3
}ii 
}jj 
}kk 
;kk 
}ll 
}nn 	
}qq 
}ss ¥
TC:\Users\Pabitra Bhunia\source\EmailNotification GIT\NotificationServices\Service.cs
	namespace 	 
NotificationServices
 
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
 (%
ConfigNotificationService

) B
(

B C
this

C G
IServiceCollection

H Z
services

[ c
)

c d
{ 	
services 
. 
	AddScoped 
< &
IEmailNotificationServices 9
,9 :$
EmailNotificationService: R
>R S
(S T
)T U
;U V
return 
services 
; 
} 	
} 
} 