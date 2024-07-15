namespace welearn.net.play.interview.junior;

public class Sort {
    public static void Test() {
        var listTicket = new JiraTicket[] {
            new JiraTicket(1, "PAY", "DONE", "M", 100),
            new JiraTicket(2, "PAY", "DONE", "X", 100),
        };
        Dictionary<string, int> mapProjectNamePriority = new Dictionary<string, int>() {
            ["PAY"] = 1,
            ["BOA"] = 2,
            ["SUB"] = 3,
        };

    }

    public class JiraTicket {
        public int TicketId;
        public string Project;
        public string Status;
        public string Size;
        public int Progress;
        
        public JiraTicket(int id, string project, string status, string size, int progress) {
            TicketId = TicketId;
            Project = project;
            Status = status;
            Size = size;
            Progress = progress;
        }
    }
}