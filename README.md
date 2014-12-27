PGPbiometric
============

Converts binary data to PGP biometric phrases and text containing them back into binary data


## How to use: ##

> Encode file from disk:
>
> `PGPbiometric encode file`
>
> or
>
> `PGPbiometric file`

Encode mode is the default. Output is written to stdOut, wherever that currently leads.
> Encode file on disk to text file:
>
> `PGPbiometric file > phrases.txt`

> Decode file on disk to binary file:
>
> `PGPbiometric decode file > output.bin`

You can also pipe input from stdIn. If you do, any file names passed will be ignored. The application will continue running in encode or decode mode in real time until the input stream is closed. You can direct the output stream elsewhere for further processing.

In decode mode upper case and lower case of the PGP biometric keywords are ignored, any character not in the latin alphabet (A-Z) will be treated as a separator, and any words not matching the correct biometric word in the currently active list (odd or even bytes) will not result in any output bytes. This means, you can write a book, and use PGP biometric words in sentences to hide binary data within it and then use the application to export it with the entire book text as the input.

There is no progress indicator of any kind, and the application is not performance optimized. You are free to recommend changes.