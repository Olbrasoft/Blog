namespace Olbrasoft.Blog.Data.FreeSql.Configurations.EntityConfigurations;
public class FakeConfiguration : IEntityTypeConfiguration<Fake>
{
    public void Configure(EfCoreTableFluent<Fake> model)
    {
        model.HasKey(p => p.MyId);
    }
}


public class Fake
{
    public int MyId { get; set; }
}
