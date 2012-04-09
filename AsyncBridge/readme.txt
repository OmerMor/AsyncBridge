// Copyright (c) 2012 Daniel Grunwald
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

// This is a minimal implementation of the stuff needed by the C# 5 Beta
// compiler for 'async'/'await' feature.
// Simply add this file to a .NET 4.0 project, and 'async'/'await' will work
// in your code without requiring your users to install .NET 4.5.
// However, you still need the C# 5 compiler for compiling your code.
// Caveats:
//  - Stack trace is lost when rethrowing exceptions
//  - Unhandled Exceptions in 'async void' methods are re-thrown immediately
//    and not posted to the synchronization context
//  - Flowing ExecutionContext is not supported
//  --> do not use this in security critical code (APTCA)
//  - The code is not optimized. Tasks are always created, repeated boxing may occur.

