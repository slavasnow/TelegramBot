#!/bin/bash

#dotnet publish -c release -r linux-x64

dotnet publish -c release -r linux-x64 -p:PublishSingleFile=true -p:SelfContained=true
