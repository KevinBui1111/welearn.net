// See https://aka.ms/new-console-template for more information

using welenet.LibA;
using welenet.LibB;

Console.WriteLine("Hello, World!");

/* case 1:
 * dotnet nuget push .\bin\Release\LibA.1.0.1.nupkg -s localPkg
 * dotnet nuget push .\bin\Release\LibA.1.0.2.nupkg -s localPkg
 * refer 1.0.1.5 -> pick 1.0.2
 */
new ClassA().Bar();

/* case 2.1: Direct dependency wins
 * VersionApp -> welenet.LibA 1.1.1 -> welenet.LibB (>= 0.2.0)
 * VersionApp -> welenet.LibB (>= 0.1.0)
 * Error NU1605 : Warning As Error: Detected package downgrade: welenet.LibB from 0.2.0 to 0.1.0.

 * case 2.2: Direct dependency wins
 * VersionApp -> welenet.LibA 1.1.1 -> welenet.LibB (>= 0.2.0)
 * VersionApp -> welenet.LibB (>= 0.3.0)
 * Build OK, choose welenet.LibB 0.3.0
 * Runtime: System.MissingMethodException: Method not found: 'Void welenet.LibB.ClassB.Bar()'
 */

new ClassA().ReferBxBar();

/* case 2.3: Could not load file or assembly
 * A 1.2 -> B 0.5 -> C 0.2
 * B 0.4 -> C 0.1
 * Error NU1605 : Warning As Error: Detected package downgrade
 * -> add <NoWarn>NU1605</NoWarn>
 * Runtime: System.IO.FileNotFoundException: Could not load file or assembly 'welenet.LibB, Version=0.5.0.0'
*/
new ClassA().ReferBxBar2();