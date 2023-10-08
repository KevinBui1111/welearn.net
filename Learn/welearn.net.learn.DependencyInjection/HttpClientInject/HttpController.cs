namespace welearn.net.learn.DependencyInjection.HttpClientInject;

public abstract class HttpController {
    protected HttpController(HttpClient httpClient) {
        HttpClientObj = httpClient;
        Console.WriteLine($"{GetType().Name} Init");
    }

    public HttpClient HttpClientObj { get; }

    public void PrintBaseAddress() {
        Console.WriteLine($"{GetType().Name}, BaseAddress: {HttpClientObj.BaseAddress}");
    }
}

public class AaaController : HttpController {
    public AaaController(HttpClient httpClient) : base(httpClient) { }
}

public class BbbController : HttpController {
    public BbbController(HttpClient httpClient) : base(httpClient) { }
}