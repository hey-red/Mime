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
Supported runtimes:
* linux-arm64
* linux-musl-x64
* linux-x64
* osx-arm64(tested on macOS 13 Ventura)
* osx-x64
* win-arm64
* win-x64
* win-x86

## Basic usage
```C#
using HeyRed.Mime;

// (Optionally) You can set path to magic database file manually.
MimeGuesser.MagicFilePath = "/path/to/magic.mgc";

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
using var magic = new Magic(MagicOpenFlags.MAGIC_NONE);
magic.Read(calc); //=> PE32+ executable (GUI) x86-64, for MS Windows

// Check encoding:
string textFile = @"F:\Temp\file.txt";
using var magic = new Magic(MagicOpenFlags.MAGIC_MIME_ENCODING);
magic.Read(textFile); //=> Output: utf-8
```
Also, we can combine flags with "|" operator.
See all [flags](src/Mime/MagicOpenFlags.cs) for more info.

## Remarks
- The Magic class is not thread safe, but if you use different instances on different threads it seems to work fine.
- The MimeGuesser is thread safe, since it generates a new instance of Magic class on each use.

## Possible problems
| Exception | Solution |
| :--- | :--- |
| DllNotFoundException | Make sure that your `bin` folder contains runtimes directory. If you publishing platform dependent app, then `bin` should be contains `libmagic-1`(.dll, .so or .dylib) and `magic.mgc` files. |
| BadImageFormatException | Make sure when you target the `AnyCPU` platform the `Prefer 32-bit` option is unchecked. Or try to target `x64/arm64` instead. |
| MagicException: Could not find any valid magic files! | Make sure your magic.mgc file contains in one of /runtimes/ subdirs or along with libmagic-1.[dll\|lib\|dylib]. Or set path to custom database as described in [basic usage](https://github.com/hey-red/Mime#basic-usage) |

## License
[MIT](LICENSE)
