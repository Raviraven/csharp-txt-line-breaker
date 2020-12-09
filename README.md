# Txt line breaker
Small script written in .NET Core for converting .txt files. 
It's getting file as an argument, adds line breaks after '/' and saves output as filename_break.txt.

## What does it actually do?
Converts file.txt:

```
some/file/to/convert
```

into file_break.txt:
```
some
file
to
convert
```

## Setup
1. To run this program you net .net sdk.  
2. Download repository
3. Open terminal and go into folder with downloaded files
4. Type
``` cmd
dotnet build -o directory
```
  to build app into txt-line-breaker.exe  
5. Run builded .exe file from terminal providing path to .txt file you want to "break"  
6. It's done :) 
