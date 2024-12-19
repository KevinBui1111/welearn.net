namespace welearn.net.learn.DependencyInjection.Config; 

public class CalcPhase {
    public string Remote { get; set; }
    public int Timeout { get; set; }
    public int? RetryCount { get; set; }
    public bool Required { get; set; }
}