#!/bin/bash
solutions=$(find . -name '*.sln')

for sln in $solutions
do
  dotnet build $sln --configuration Release
done