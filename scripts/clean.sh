#!/bin/sh

solution=smashup-crash-automation.sln

dotnet clean $solution && \
rm -rf src/{CLI,Infrastructure,Persistence,Core/{Domain,Application}}/{bin,obj}