# XorCipher
![C#11.0](https://img.shields.io/badge/CSharp-11.0-blueviolet) ![.NET-7.0](https://img.shields.io/badge/.NET-7.0-blueviolet)

Message cipher based on Xor bitwise operation

## Working Principle
Every single character of your message is taken, a random character from 0 to 65536 is generated for it, as char in c# takes 2 bytes (Uint16). A bitwise mutual exclusion operator (Xor) is applied to both characters and a new character is generated which we write to the encrypted message.
All random characters are added together and we get a key that allows us to revert the encrypted message to its original state.

Read more about xor-cipher here: https://en.wikipedia.org/wiki/XOR_cipher.

## Requirements
- *.NET 7.0*
