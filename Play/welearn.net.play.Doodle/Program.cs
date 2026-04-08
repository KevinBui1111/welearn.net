// See https://aka.ms/new-console-template for more information

using System.Text;
using welearn.net.play.Doodle;
using welearn.net.play.Doodle.Support;

// WeekDate.ListAllWeek(2021);
// WeekDate.ListAllWeek(2022);

switch (args[0]) {
    case "old-enc": {
        var res = args[1] == "-d"
            ? OldEncConn.DecryptString(args[2])
            : OldEncConn.EncryptString(args[1]);
        Console.WriteLine(res);
        break;
    }
    case "xmlTrans":
        XmlTrans.Apply(
            args[1],
            args[2..]
        );
        break;
}
