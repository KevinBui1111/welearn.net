namespace welearn.net.DependencyInjection.Service;

public class BarService : IBarService
{
    private readonly IFooService _fooService;
    public BarService(IFooService fooService) => _fooService = fooService;

    public void DoSomeRealWork() => _fooService.DoThing("DoSomeRealWork");
}