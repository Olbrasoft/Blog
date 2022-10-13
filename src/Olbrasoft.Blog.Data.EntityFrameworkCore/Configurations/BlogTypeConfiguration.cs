namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations
{
    public abstract class BlogTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
    {
        protected string Schema { get; }
        protected string Table { get; }

        protected BlogTypeConfiguration(string schema, string table)
        {
            Schema = schema;

            Table = table;
        }

        protected BlogTypeConfiguration(string table) : this(BuildSchema(), table)
        {
        }

        protected BlogTypeConfiguration() : this(BuildSchema(), BuildTable())
        {
        }

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            if (string.IsNullOrEmpty(Schema))
            {
                builder.ToTable(Table);
            }
            else
            {
                builder.ToTable(Table, Schema);
            }

            TypeConfigure(builder);
        }

        public abstract void TypeConfigure(EntityTypeBuilder<TEntity> builder);

        public static string BuildTable()
        {
            return $"{typeof(TEntity).Name}s";
        }

        public static string BuildSchema()
        {
            var ns = typeof(TEntity).Namespace;

            var result = ns != null ? ns.Substring(ns.LastIndexOf('.') + 1) : string.Empty;

            if (result == "Entities") result = "";

            return result;
        }
    }
}