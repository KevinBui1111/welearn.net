using System.Diagnostics;

namespace welearn.net.learn.csharp;

public class NullValue {
    public static void TestNull() {
        DateTime? today = "Hi".Length == 3 ? DateTime.Today : null;
        int? day = today?.Day;
        Debug.Assert(day is null);
        
        ProcessType? p = "Hi".Length == 2 ? ProcessType.BigTicket : null;
        var strProcessType = p?.ToString();
        // Debug.Assert(strProcessType is null);
        Console.WriteLine(strProcessType);
    }

    private enum ProcessType {
        CardPickup,
        O2O,
        TwoWheeler,
        BigTicket,
    }
}