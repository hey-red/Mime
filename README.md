# Mime
.NET wrapper for libmagic

[![NuGet](https://img.shields.io/nuget/v/Mime.svg)](https://www.nuget.org/packages/Mime)
[![license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/hey-red/Markdown/blob/master/LICENSE)

## Install
via [NuGet](https://www.nuget.org/packages/Mime):
```
PM> Install-Package Mime
```

## Requirements
Supports only x64 OS(Linux, MacOS and Windows).
If you run into issues, make sure you set your target platform to x64:
![x64.png](/x64.png)

## Basic usage
```C#
using HeyRed.Mime;

// (Optionally) You can set path to magic database file manually.
MimeGuesser.MagicFilePath = "/path/to/magic/file";

// Guess mime type of file(overloaded method takes byte array or stream as arg.)
MimeGuesser.GuessMimeType("path/to/file"); //=> image/jpeg

// Get extension of file(overloaded method takes byte array or stream as arg.)
MimeGuesser.GuessExtension("path/to/file"); //=> jpeg

// Get mime type and extension of file(overloaded method takes byte array or stream as arg.)
MimeGuesser.GuessFileType("path/to/file"); //=> FileType
```

## Advanced
Want more than just the mime type? Use the Magic class:
```C#
string calc = @"C:\Windows\System32\calc.exe";
var magic = new Magic(MagicOpenFlags.MAGIC_NONE);
magic.Read(calc); //=> PE32+ executable (GUI) x86-64, for MS Windows

// Check encoding:
string textFile = @"F:\Temp\file.txt";
var magic = new Magic(MagicOpenFlags.MAGIC_MIME_ENCODING);
magic.Read(textFile); //=> Output: utf-8
```
Also, we can combine flags with "|" operator.
For all flag options, see [this](src/Mime/MagicOpenFlags.cs)

## Remarks
- The Magic class is not thread safe, but if you use different instances on different threads it seems to work fine.
- The MimeGuesser seems to be thread safe, since it generates a new instance of Magic class on each use.
- If you publish application as Self-contained(SCD) with target RID linux/OSX(?), then make sure to set magic path manually.

## License
[MIT](LICENSE)
