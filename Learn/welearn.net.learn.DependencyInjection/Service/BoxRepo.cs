using Microsoft.Extensions.Logging;

namespace welearn.net.learn.DependencyInjection;

internal class BoxRepo : AbsBaseRepo, IBoxRepo
{
    private readonly ILogger<BoxRepo> _logger;
    public BoxRepo(IFooService _foo, ILogger<BoxRepo> logger) : base(_foo)
    {
        _logger = logger;
    }

    //public void save() => Console.WriteLine("absBaseRepo SAVE");
    //public override void save() => Console.WriteLine("BoxRepo SAVE");
    public void find_box() => _logger.LogWarning(9, "find_box {} {-1}", "BoxRepo", "aaa");
}