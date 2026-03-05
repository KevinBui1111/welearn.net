// See https://aka.ms/new-console-template for more information

using welearn.net.play.Doodle;
using welearn.net.play.Doodle.Support;

// WeekDate.ListAllWeek(2021);
// WeekDate.ListAllWeek(2022);

if (args[0] == "old-enc") {
    var res = args[1] == "-d"
        ? OldEncConn.DecryptString(args[2])
        : OldEncConn.EncryptString(args[1]);
    Console.WriteLine(res);
}