#!/bin/sh
dotnet ef database update
dotnet MonterdeNote.Server.dll
