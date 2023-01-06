Æ
sC:\Users\Pabitra Bhunia\source\EmailNotification GIT\SMSNotificationServices\IRepository\ISMSNotificationService.cs
	namespace 	#
SMSNotificationServices
 !
.! "
IRepository" -
{ 
public 

	interface #
ISmsNotificationService ,
{ 
public 
Task 
< 
ApiResponseModel $
>$ %
SendNotification& 6
(6 7
SmsNotification7 F
sMSNotificationG V
)V W
;W X
} 
} ÃN
qC:\Users\Pabitra Bhunia\source\EmailNotification GIT\SMSNotificationServices\Repository\SMSNotificationService.cs
	namespace

 	#
SMSNotificationServices


 !
.

! "

Repository

" ,
{ 
public 

class "
SmsNotificationService '
:( )#
ISmsNotificationService* A
{ 
public 
readonly 
IConfiguration &
?& '
_configuration( 6
;6 7
private 
readonly 
string  
?  !

apiBaseUrl" ,
;, -
private 
readonly 

HttpClient $
_httpClient% 0
=1 2
new3 6
(6 7
)7 8
;8 9
private 
readonly 
string 
?  
_accountSID! ,
;, -
private 
readonly 
string 
?  

_authToken! +
;+ ,
private 
readonly 
string 
?  

_fromPhone! +
;+ ,
private 
readonly 
NotificationLog (
_notificationLog) 9
;9 :
public "
SmsNotificationService %
(% &
IConfiguration& 4
configuration5 B
)B C
{ 	
_notificationLog 
= 
new "
NotificationLog# 2
(2 3
	TimeStamp3 <
.< =
GetTimeStamp= I
(I J
)J K
)K L
;L M
_accountSID 
= 
configuration '
.' (

GetSection( 2
(2 3
$str3 ?
)? @
.@ A

GetSectionA K
(K L
$strL X
)X Y
.Y Z
ValueZ _
;_ `

_authToken 
= 
configuration &
.& '

GetSection' 1
(1 2
$str2 >
)> ?
.? @

GetSection@ J
(J K
$strK V
)V W
.W X
ValueX ]
;] ^

_fromPhone 
= 
configuration %
.% &

GetSection& 0
(0 1
$str1 =
)= >
.> ?

GetSection? I
(I J
$strJ U
)U V
.V W
ValueW \
;\ ]

apiBaseUrl 
= 
configuration &
.& '

GetSection' 1
(1 2
$str2 K
)K L
.L M
ValueM R
;R S
if 
( 
_httpClient 
. 
BaseAddress '
==( *
null+ /
)/ 0
_httpClient 
. 
BaseAddress '
=( )
new* -
Uri. 1
(1 2

apiBaseUrl2 <
!< =
)= >
;> ?
} 	
public   
async   
Task   
<   
ApiResponseModel   *
>  * +
SendNotification  , <
(  < =
SmsNotification  = L
sMSNotification  M \
)  \ ]
{!! 	
try"" 
{## 
NFType$$ 
?$$ 
nFType$$ 
=$$  
($$! "
NFType$$" (
)$$( )
sMSNotification$$) 8
.$$8 9
NOTIFICATIONTYPE$$9 I
;$$I J
if%% 
(%% 
nFType%% 
!=%% 
NFType%% $
.%%$ %
SMS%%% (
)%%( )
throw&& 
new&&  
InvalidDataException&& 2
(&&2 3
$str&&3 Z
)&&Z [
;&&[ \
_notificationLog((  
.((  !
WriteLogMessage((! 0
(((0 1
$str((1 J
+((J K
sMSNotification((K Z
.((Z [
PHONE(([ `
)((` a
;((a b
ApiResponseModel))  
?))  !
apiResponseModel))" 2
;))2 3
if** 
(** 
sMSNotification** #
.**# $
PHONE**$ )
==*** ,
null**- 1
&&**2 4
sMSNotification**5 D
.**D E
PHONE**E J
==**K M
$str**N P
)**P Q
throw++ 
new++  
InvalidDataException++ 2
(++2 3
$str++3 T
)++T U
;++U V
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
+//R S
nFType//T Z
+//[ \
$str//] p
+//q r
Convert//s z
.//z {
ToInt32	//{ ‚
(
//‚ ƒ
sMSNotification
//ƒ ’
.
//’ “

TEMPLATENO
//“ 
)
// ž
;
//ž Ÿ
_notificationLog00  
.00  !
WriteLogMessage00! 0
(000 1
$str001 W
+00X Y
endpoint00Z b
)00b c
;00c d
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
if:: 
(:: 
data:: 
!:: 
.:: 
Data:: 
==:: !
null::" &
)::& '
throw;; 
new;;  
InvalidDataException;; 2
(;;2 3
$str;;3 N
);;N O
;;;O P
TwilioClient@@ 
.@@ 
Init@@ !
(@@! "
_accountSID@@" -
,@@- .

_authToken@@/ 9
)@@9 :
;@@: ;
varAA 
usernameAA 
=AA 
sMSNotificationAA .
.AA. /
NAMEAA/ 3
;AA3 4
varBB 
messageBB 
=BB 
MessageResourceBB -
.BB- .
CreateBB. 4
(BB4 5
fromBB5 9
:BB9 :
newBB; >
TwilioBB? E
.BBE F
TypesBBF K
.BBK L
PhoneNumberBBL W
(BBW X

_fromPhoneBBX b
)BBb c
,BBc d
bodyCC 
:CC 
StringCC  
.CC  !
FormatCC! '
(CC' (
dataCC( ,
.CC, -
DataCC- 1
.CC1 2
BodyMessageCC2 =
!CC= >
,CC> ?
usernameCC@ H
)CCH I
,CCI J
toCCK M
:CCM N
newCCO R
TwilioCCS Y
.CCY Z
TypesCCZ _
.CC_ `
PhoneNumberCC` k
(CCk l
$strCCl q
+CCr s
sMSNotification	CCt ƒ
.
CCƒ „
PHONE
CC„ ‰
)
CC‰ Š
)
CCŠ ‹
;
CC‹ Œ
_notificationLogDD  
.DD  !
WriteLogMessageDD! 0
(DD0 1
$strDD1 R
+DDR S
messageDDS Z
)DDZ [
;DD[ \
returnGG 
newGG 
ApiResponseModelGG +
{HH 
MsgHdrII 
=II 
newII  
BaseResponseModelII! 2
{JJ 
IDKK 
=KK 
	TimeStampKK &
.KK& '
GetTimeStampKK' 3
(KK3 4
)KK4 5
,KK5 6

StatusCodeLL "
=LL# $
$numLL% (
,LL( )
StatusMM 
=MM  
$strMM! *
,MM* +
MessageNN 
=NN  !
$strNN" F
}OO 
,OO 
MsgBdyPP 
=PP 
newPP  
ResponseModelPP! .
<PP. /
stringPP/ 5
>PP5 6
{PP7 8
DataPP9 =
=PP> ?
messagePP@ G
.PPG H
SidPPH K
}PPL M
,PPM N
}QQ 
;QQ 
}RR 
catchSS 
(SS 
	ExceptionSS 
eSS 
)SS 
{TT 
_notificationLogUU  
.UU  !
WriteLogMessageUU! 0
(UU0 1
$strUU1 `
+UU` a
eUUa b
.UUb c
ToStringUUc k
(UUk l
)UUl m
)UUm n
;UUn o
returnVV 
newVV 
ApiResponseModelVV +
{WW 
MsgHdrXX 
=XX 
newXX  
BaseResponseModelXX! 2
{YY 
IDZZ 
=ZZ 
	TimeStampZZ &
.ZZ& '
GetTimeStampZZ' 3
(ZZ3 4
)ZZ4 5
,ZZ5 6

StatusCode[[ "
=[[# $
$num[[% (
,[[( )
Status\\ 
=\\  
$str\\! )
,\\) *
Message]] 
=]]  !
e]]" #
.]]# $
Message]]$ +
}^^ 
}__ 
;__ 
}`` 
}bb 	
}dd 
}ee ¦
WC:\Users\Pabitra Bhunia\source\EmailNotification GIT\SMSNotificationServices\Service.cs
	namespace 	#
SMSNotificationServices
 !
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
 ((
ConfigSMSNotificationService

) E
(

E F
this

F J
IServiceCollection

K ]
service

^ e
)

e f
{ 	
service 
. 
	AddScoped 
< #
ISmsNotificationService 5
,5 6"
SmsNotificationService6 L
>L M
(M N
)N O
;O P
return 
service 
; 
} 	
} 
} 