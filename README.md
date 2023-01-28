# XorCipher
![C#11.0](https://img.shields.io/badge/CSharp-11.0-blueviolet) ![.NET-7.0](https://img.shields.io/badge/.NET-7.0-blueviolet)

Message cipher based on Xor bitwise operation

## Working Principle.
Each character of your message is taken and a random character from 0 to 65536 is generated for it, as char in c# takes 2 bytes (Uint16). A bitwise mutual exclusion operator (Xor) is applied to both symbols and a new symbol is generated which we write to the encrypted message.
All random characters are added together and we get a key that allows to return the encrypted message to its original state by performing an xor operator between the characters of the encrypted message and the key in their order

Read more about xor-cipher here: https://en.wikipedia.org/wiki/XOR_cipher.

Easy explanation : https://www.youtube.com/watch?v=xK_SqWG9w-Y

## Requirements
- *.NET 7.0*
