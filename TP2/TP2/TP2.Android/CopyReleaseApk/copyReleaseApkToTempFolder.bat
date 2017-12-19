SET destination=c:\temp\release.apk
SET source=..\bin\Release\TP2.Android-Signed.apk

del %destination%
copy  %source% %destination%