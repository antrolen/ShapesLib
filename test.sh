#!/bin/sh

if [ "$1" = "" ] ; then
    dotnet build ./ShapesLib.Lib
    dotnet build ./ShapesLib.Test
    dotnet test 
fi

if [ "$1" = "lcov" ] ; then
    dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov
fi

if [ "$1" = "teamcity" ] ; then
    dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=teamcity
fi

if [ "$1" = "genhtml" ] ; then
    genhtml -o TestCoverage ./ShapesLib.Test/coverage.info
fi

if [ "$1" = "zip" ] ; then
    rm ShapesLib.zip
    zip -r ShapesLib.zip . -x "**/bin/*" -x "**/obj/*" -x ".gitignore" -x "Commands.md" -x "TODO.md" -x "ShapesLib.zip"
fi