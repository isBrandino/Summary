#!/bin/bash

cd Summary.Test
dotnet test
cd .. 
cd Summary
dotnet list package
dotnet build
dotnet run
