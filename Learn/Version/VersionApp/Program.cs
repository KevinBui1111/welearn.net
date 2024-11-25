// See https://aka.ms/new-console-template for more information

using welenet.LibA;

Console.WriteLine("Hello, World!");

/* case 1:
 * dotnet nuget push .\bin\Release\LibA.1.0.1.nupkg -s localPkg
 * dotnet nuget push .\bin\Release\LibA.1.0.2.nupkg -s localPkg
 * refer 1.0.1.5 -> pick 1.0.2
 */
new ClassA().Bar();

/* case 2: Direct dependency wins
 * VersionApp -> welenet.LibA 1.1.1 -> welenet.LibB (>= 0.2.0)
 * VersionApp -> welenet.LibB (>= 0.1.0)
 * Error NU1605 : Warning As Error: Detected package downgrade: welenet.LibB from 0.2.0 to 0.1.0.
 */