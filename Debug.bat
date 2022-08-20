@ECHO off

taskkill /f /im MultiAdmin.exe

del /f/q "C:\Users\Maciej\AppData\Roaming\EXILED\Plugins\ChaosMod.dll"
copy /b/v/y "C:\Users\Maciej\Desktop\RiderProjects\SCPSL_ChaosMod\SCPSL_ChaosMod\bin\x64\Debug x64\ChaosMod.dll" "C:\Users\Maciej\AppData\Roaming\EXILED\Plugins\ChaosMod.dll" 

Start P:\Serwery\SteamCMD\steamapps\content\app_786920\depot_786921\MultiAdmin.exe