namespace Olbrasoft.Blog.Data.FreeSql.Tests;

class FakeDbSet<T> : DbSet<T> where T : class
{
    private readonly ISelect<T> _select;

    public FakeDbSet(ISelect<T> select)
    {
        _select = select;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public FakeDbSet()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {

    }

    protected override ISelect<T> OrmSelect(object dywhere)
    {
        return _select ?? new Mock<ISelect<T>>().Object;

    }

}