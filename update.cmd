@echo off
echo "Updating....."
timeout /t 3

pskill.exe ImageClick.exe
xcopy ImageClick.exe ..\ImageClick.exe /Y
xcopy language.xml ..\language.xml /Y
echo "Update complete"
Pause