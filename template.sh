#!/bin/bash

PATH=$PATH
export PATH
#echo $PATH
#source /c/Program Files/dotnet/

while getopts "i:gn:o:" opt; do
    case $opt in
        i)  sourcePath=${OPTARG};;
		g)	;;
        n)  namespace=${OPTARG};;
        o)  outputPath=${OPTARG};;
        \?) exit;;
    esac
done

if [ "$1" == "-i" ]; then
	#echo $sourcePath
	dotnet new -i "$sourcePath/backend"
	#dotnet new -l
fi

if [ "$1" == "-g" ]; then
	#run=$(dotnet new Template.NetCore -n $namespace -o $outputPath)
	#echo "$run"
	dotnet new Template.NetCore -n $namespace -o "$outputPath/backend"
	cp -R frontend "$outputPath/frontend" # copy frontend folder
	echo 'The template "Angular 16 Template with simple CRUD" was created successfully.'
fi
