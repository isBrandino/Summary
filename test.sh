#!/bin/bash
dotnet list package
dotnet test
dotnet build
dotnet run
