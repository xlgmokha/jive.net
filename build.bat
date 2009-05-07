@echo off
cls
build\tools\nant\nant.exe -nologo -buildfile:build\project.build %*
@echo %time%
