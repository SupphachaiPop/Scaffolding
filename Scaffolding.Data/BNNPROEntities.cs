using Scaffolding.Models;
using Scaffolding.EFConfiguration;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Scaffolding.Data
{
    public class BNNPROEntities : DbContext
    {
        public BNNPROEntities()
            : base(nameOrConnectionString: "BNNPROEntities") // value of attribute "name" in <connectionStrings/>
        {
            Database.SetInitializer<BNNPROEntities>(null);
        }

        public DbSet<address> addresses { get; set; } // address
        public DbSet<bank> banks { get; set; } // bank
        public DbSet<bank_account> bank_accounts { get; set; } // bank_account
        public DbSet<brand> brands { get; set; } // brand
        public DbSet<cart> carts { get; set; } // cart
        public DbSet<category> categories { get; set; } // category
        public DbSet<category_specification> category_specifications { get; set; } // category_specification
        public DbSet<customer> customers { get; set; } // customer
        public DbSet<district> districts { get; set; } // district
        public DbSet<product> products { get; set; } // product
        public DbSet<product_image> product_images { get; set; } // product_image
        public DbSet<product_specification> product_specifications { get; set; } // product_specification
        public DbSet<product_stock> product_stocks { get; set; } // product_stock
        public DbSet<product_stock_image> product_stock_images { get; set; } // product_stock_image
        public DbSet<promotion_image> promotion_images { get; set; } // promotion_image
        public DbSet<province> provinces { get; set; } // province
        public DbSet<receipt_reference> receipt_references { get; set; } // receipt_reference
        public DbSet<refund_reference> refund_references { get; set; } // refund_reference
        public DbSet<sale_order> sale_orders { get; set; } // sale_order
        public DbSet<sale_order_item> sale_order_items { get; set; } // sale_order_item
        public DbSet<specification> specifications { get; set; } // specification
        public DbSet<sub_district> sub_districts { get; set; } // sub_district
        public DbSet<sub_specification> sub_specifications { get; set; } // sub_specification
        public DbSet<symptom> symptoms { get; set; } // symptom
        public DbSet<user> users { get; set; } // users

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new addressConfiguration());
            modelBuilder.Configurations.Add(new bankConfiguration());
            modelBuilder.Configurations.Add(new bank_accountConfiguration());
            modelBuilder.Configurations.Add(new brandConfiguration());
            modelBuilder.Configurations.Add(new cartConfiguration());
            modelBuilder.Configurations.Add(new categoryConfiguration());
            modelBuilder.Configurations.Add(new category_specificationConfiguration());
            modelBuilder.Configurations.Add(new customerConfiguration());
            modelBuilder.Configurations.Add(new districtConfiguration());
            modelBuilder.Configurations.Add(new productConfiguration());
            modelBuilder.Configurations.Add(new product_imageConfiguration());
            modelBuilder.Configurations.Add(new product_specificationConfiguration());
            modelBuilder.Configurations.Add(new product_stockConfiguration());
            modelBuilder.Configurations.Add(new product_stock_imageConfiguration());
            modelBuilder.Configurations.Add(new promotion_imageConfiguration());
            modelBuilder.Configurations.Add(new provinceConfiguration());
            modelBuilder.Configurations.Add(new receipt_referenceConfiguration());
            modelBuilder.Configurations.Add(new refund_referenceConfiguration());
            modelBuilder.Configurations.Add(new sale_orderConfiguration());
            modelBuilder.Configurations.Add(new sale_order_itemConfiguration());
            modelBuilder.Configurations.Add(new specificationConfiguration());
            modelBuilder.Configurations.Add(new sub_districtConfiguration());
            modelBuilder.Configurations.Add(new sub_specificationConfiguration());
            modelBuilder.Configurations.Add(new symptomConfiguration());
            modelBuilder.Configurations.Add(new userConfiguration());
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
