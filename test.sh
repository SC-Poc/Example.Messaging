#!/bin/bash
solutions=$(find . -name '*.sln')

for sln in $solutions
do
  dotnet test $sln --no-build --configuration Release
done