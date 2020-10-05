using Scaffolding.Models;
namespace Scaffolding.EFConfiguration
{
    // product_stock
    public class product_stockConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<product_stock>
    {
        public product_stockConfiguration()
            : this("dbo")
        {
        }

        public product_stockConfiguration(string schema)
        {
            ToTable("product_stock", schema);
            HasKey(x => x.product_stock_id);

            Property(x => x.product_stock_id).HasColumnName(@"product_stock_id").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.product_id).HasColumnName(@"product_id").HasColumnType("int").IsRequired();
            Property(x => x.symptom_id).HasColumnName(@"symptom_id").HasColumnType("int").IsOptional();
            Property(x => x.serial).HasColumnName(@"serial").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.imei1).HasColumnName(@"imei1").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.imei2).HasColumnName(@"imei2").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.cosmetic).HasColumnName(@"cosmetic").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(300);
            Property(x => x.accessory).HasColumnName(@"accessory").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.grade).HasColumnName(@"grade").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(20);
            Property(x => x.cost_of_purchase).HasColumnName(@"cost_of_purchase").HasColumnType("decimal").IsOptional().HasPrecision(18,0);
            Property(x => x.cost_of_repairs).HasColumnName(@"cost_of_repairs").HasColumnType("decimal").IsOptional().HasPrecision(18,0);
            Property(x => x.min_price).HasColumnName(@"min_price").HasColumnType("decimal").IsOptional().HasPrecision(18,0);
            Property(x => x.sale_price).HasColumnName(@"sale_price").HasColumnType("decimal").IsOptional().HasPrecision(18,0);
            Property(x => x.is_active).HasColumnName(@"is_active").HasColumnType("bit").IsRequired();
            Property(x => x.is_delete).HasColumnName(@"is_delete").HasColumnType("bit").IsRequired();
            Property(x => x.create_by).HasColumnName(@"create_by").HasColumnType("int").IsOptional();
            Property(x => x.create_date).HasColumnName(@"create_date").HasColumnType("datetime").IsOptional();
            Property(x => x.modify_by).HasColumnName(@"modify_by").HasColumnType("int").IsOptional();
            Property(x => x.modify_date).HasColumnName(@"modify_date").HasColumnType("datetime").IsOptional();

            // Foreign keys
            HasOptional(a => a.symptom).WithMany(b => b.product_stocks).HasForeignKey(c => c.symptom_id).WillCascadeOnDelete(false); // FK_product_stock_symptom
            HasRequired(a => a.product).WithMany(b => b.product_stocks).HasForeignKey(c => c.product_id).WillCascadeOnDelete(false); // FK_product_stock_product
        }
    }

}

