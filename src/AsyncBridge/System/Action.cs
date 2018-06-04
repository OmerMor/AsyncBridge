// https://github.com/dotnet/coreclr/blob/v2.1.0/src/mscorlib/shared/System/Action.cs
// Original work under MIT license, Copyright (c) .NET Foundation and Contributors https://github.com/dotnet/coreclr/blob/v2.1.0/LICENSE.TXT
// Docs supplemented from https://github.com/dotnet/dotnet-api-docs/blob/live/xml/System/Action.xml, Func.xml, and higher arities
// Docs under Creative Commons Attribution 4.0 International Public License https://github.com/dotnet/dotnet-api-docs/blob/live/LICENSE

#if NET20 || NET35
namespace System
{
#if NET20
    /// <summary>Encapsulates a method that has no parameters and does not return a value.</summary>
    public delegate void Action();
    
    /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
    /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
    /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
    /// <summary>Encapsulates a method that has two parameters and does not return a value.</summary>
    public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2);
    
    /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
    /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
    /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
    /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
    /// <summary>Encapsulates a method that has three parameters and does not return a value.</summary>
    public delegate void Action<in T1, in T2, in T3>(T1 arg1, T2 arg2, T3 arg3);
    
    /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
    /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
    /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
    /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
    /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
    /// <summary>Encapsulates a method that has four parameters and does not return a value.</summary>
    public delegate void Action<in T1, in T2, in T3, in T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);
#endif

#if NET20
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
    /// <summary>Encapsulates a method that has no parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.</summary>
    /// <returns>The return value of the method that this delegate encapsulates.</returns>
    public delegate TResult Func<out TResult>();

    /// <typeparam name="T">The type of the parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
    /// <param name="arg">The parameter of the method that this delegate encapsulates.</param>
    /// <summary>Encapsulates a method that has one parameter and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.</summary>
    /// <returns>The return value of the method that this delegate encapsulates.</returns>
    public delegate TResult Func<in T, out TResult>(T arg);

    /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
    /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
    /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
    /// <summary>Encapsulates a method that has two parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.</summary>
    /// <returns>The return value of the method that this delegate encapsulates.</returns>
    public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);

    /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
    /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
    /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
    /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
    /// <summary>Encapsulates a method that has three parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.</summary>
    /// <returns>The return value of the method that this delegate encapsulates.</returns>
    public delegate TResult Func<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3);

    /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
    /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
    /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
    /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
    /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
    /// <summary>Encapsulates a method that has four parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.</summary>
    /// <returns>The return value of the method that this delegate encapsulates.</returns>
    public delegate TResult Func<in T1, in T2, in T3, in T4, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);
#endif

    /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
    /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
    /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
    /// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
    /// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
    /// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
    /// <summary>Encapsulates a method that has five parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.</summary>
    /// <returns>The return value of the method that this delegate encapsulates.</returns>
    public delegate TResult Func<in T1, in T2, in T3, in T4, in T5, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
}
#endif
