// See https://aka.ms/new-console-template for more information

using welenet.LibA;

Console.WriteLine("Hello, World!");

/*
 * dotnet nuget push .\bin\Release\LibA.1.0.1.nupkg -s localPkg
 * dotnet nuget push .\bin\Release\LibA.1.0.2.nupkg -s localPkg
 * refer 1.0.1.5 -> pick 1.0.2
 */
new ClassA().Bar();