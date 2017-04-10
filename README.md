# Mime
Simple MIME type guesser for .NET and .NET Core.

## Install
via [NuGet](https://www.nuget.org/packages/Mime):
```
PM> Install-Package Mime
```

## Requirements
Supports x64 OS(Linux and Windows). With .NET Framework you need to set platform x64.

## Usage
```C#
using HeyRed.Mime;

// (Optionally) You can set path to magic database file manually.
MimeGuesser.MagicFilePath = "/path/to/magic/file";

// Guess mime type of file(overloaded method takes byte array or stream as arg.)
MimeGuesser.GuessMimeType("path/to/file") //=> image/jpeg

// Get extension of file(overloaded method takes byte array or stream as arg.)
MimeGuesser.GuessExtension("path/to/file") //=> jpeg

// Get mime type and extension of file(overloaded method takes byte array or stream as arg.)
MimeGuesser.GuessFileType("path/to/file") //=> FileType
```
Also available extension methods for FileInfo.

## License
[MIT](\LICENSE)
