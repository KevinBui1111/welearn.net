namespace welearn.net.DependencyInjection;

internal abstract class AbsBaseRepo : IBaseRepo
{
    private readonly IFooService _fooService;
    public AbsBaseRepo(IFooService fooService) => _fooService = fooService;

    public virtual void save() => _fooService.DoThing("123");
}