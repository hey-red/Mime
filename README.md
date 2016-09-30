# Mime
Simple MIME type guesser for .NET and .NET Core.

## Install
via [NuGet](https://www.nuget.org/packages/Mime):
```
PM> Install-Package Mime
```

## Requirements
Currently supports only Linux based OS(ex. Ubuntu 16.04), if you want to use package in Windows or MacOS, then you need to manually install libmagic.

Open issue [here](https://github.com/hey-red/libmagic-package) if u want to maintain native libs for other OS.
### Note
GuessExtension methods working **only** with libmagic **version >= 5.23**

## Usage
```C#
using HeyRed.MimeGuesser;

// Guess mime type of file(overloaded method takes byte array or stream as arg.)
Mime.GuessMimeType("path/to/file") //=> image/jpeg

// Get extension of file(overloaded method takes byte array or stream as arg.)
Mime.GuessExtension("path/to/file") //=> jpeg
```

## License
[MIT](\LICENSE)
