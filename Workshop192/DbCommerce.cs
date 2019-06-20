using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Workshop192.UserManagment;
using Workshop192.MarketManagment;

namespace Workshop192
{
    public class DbCommerce : DbContext
    {
        private static DbCommerce instance = null;
        private bool forTests;

        private DbCommerce()
        {
            forTests = false;
        }

        public static DbCommerce GetInstance()
        {
            if (instance == null)
                instance = new DbCommerce();
            return instance;
        }

        public void StartTests()
        {
            forTests = true;
        }

        public void EndTests()
        {
            forTests = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserInfo>().HasKey(u => u.userName);
            modelBuilder.Entity<Admin>().HasKey(a => a.userName);
            modelBuilder.Entity<StoreOwner>().HasKey(o => new { o.store, o.userName });
            modelBuilder.Entity<StoreManager>().HasKey(m => new { m.store, m.userName });
            modelBuilder.Entity<StoreOwnersOfStore>().HasKey(os => os.store);
            modelBuilder.Entity<UserInfo>().HasOptional(u => u.admin).WithRequired(a => a.user);
            modelBuilder.Entity<UserInfo>().HasMany(u => u.storeOwners).WithRequired(o => o.user).HasForeignKey(o => o.userName);
            modelBuilder.Entity<UserInfo>().HasMany(u => u.storeManagers).WithRequired(m => m.user).HasForeignKey(m => m.userName);
            //modelBuilder.Entity<StoreOwner>().HasMany(o => o.appointedManagers).WithRequired(m => m.owner);
            modelBuilder.Entity<StoreOwnersOfStore>().HasMany(os => os.storeOwners).WithRequired(o => o.storeOwners);
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Ignore(p => p.discountPolicy);
            modelBuilder.Entity<Product>().Ignore(p => p.sellingPolicy);
            modelBuilder.Entity<Store>().HasKey(s => s.name);
            modelBuilder.Entity<Store>().Ignore(s => s.discountPolicy);
            modelBuilder.Entity<Store>().Ignore(s => s.sellingPolicy);
            modelBuilder.Entity<ProductAmountInventory>().HasKey(pi => new { pi.storeName, pi.productId });
            modelBuilder.Entity<Store>().HasMany(s => s.inventory).WithRequired(pi => pi.store).HasForeignKey(pi => pi.storeName);
            modelBuilder.Entity<ProductAmountInventory>().HasRequired(pi => pi.product).WithMany();
        }

        public DbSet<UserInfo> users { get; set; }
        public DbSet<Store> stores { get; set; }

        public LinkedList<UserInfo> GetUserInfos()
        {
            if (forTests)
                return new LinkedList<UserInfo>();
            LinkedList<UserInfo> userInfos = new LinkedList<UserInfo>();
            foreach (UserInfo info in users)
                userInfos.AddLast(info);
            return userInfos;
        }

        public LinkedList<Store> GetStores()
        {
            if (forTests)
                return new LinkedList<Store>();
            LinkedList<Store> stores = new LinkedList<Store>();
            foreach (Store store in this.stores)
                stores.AddLast(store);
            return stores;
        }

        public void SaveDb()
        {
            if (forTests)
                return;
            SaveChanges();
        }
    }
}
