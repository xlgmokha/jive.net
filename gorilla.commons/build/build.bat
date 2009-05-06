@echo off
cls
tools\nant\nant.exe -nologo -buildfile:project.build %*
@echo %time%