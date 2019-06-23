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
        public bool forTests;

        private DbCommerce() : base()
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            forTests = true;
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
            modelBuilder.Entity<StoreOwnersOfStore>().HasMany(os => os.storeOwners).WithRequired(o => o.storeOwners);
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Store>().HasKey(s => s.name);
            modelBuilder.Entity<ProductAmountInventory>().HasKey(pi => new { pi.storeName, pi.productId });
            modelBuilder.Entity<Store>().HasMany(s => s.inventory).WithRequired(pi => pi.store).HasForeignKey(pi => pi.storeName);
            modelBuilder.Entity<ProductAmountInventory>().HasRequired(pi => pi.product);
            modelBuilder.Entity<MultiCart>().HasKey(mc => mc.multiCartId);
            modelBuilder.Entity<Cart>().HasKey(c => new { c.multiCartId, c.storeName });
            modelBuilder.Entity<ProductAmountCart>().HasKey(pc => new { pc.multiCartId, pc.productId });
            modelBuilder.Entity<MultiCart>().HasMany(mc => mc.carts).WithRequired(c => c.multiCart).HasForeignKey(c => c.multiCartId);
            modelBuilder.Entity<Cart>().HasMany(c => c.productAmount).WithRequired(pa => pa.cart).HasForeignKey(pa => new { pa.multiCartId, pa.storeName });
            modelBuilder.Entity<ProductAmountCart>().HasRequired(pa => pa.product);
        }

        public DbSet<UserInfo> users { get; set; }
        public DbSet<Store> stores { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<MultiCart> multiCarts { get; set; }
        public DbSet<Cart> carts { get; set; }

        public void AddUserInfo(UserInfo info)
        {
            if (forTests)
                return;
            users.Add(info);
            SaveChanges();
        }

        public void RemoveUserInfo(UserInfo info)
        {
            if (forTests)
                return;
            users.Remove(info);
            SaveChanges();
        }

        public void AddStore(Store store)
        {
            if (forTests)
                return;
            stores.Add(store);
            SaveChanges();
        }

        public void AddMultiCart(MultiCart multiCart)
        {
            if (forTests)
                return;
            multiCarts.Add(multiCart);
            SaveChanges();
        }

        public void RemoveCart(Cart cart)
        {
            if (forTests)
                return;
            carts.Remove(cart);
        }

        public LinkedList<UserInfo> GetUserInfos()
        {
            if (forTests)
                return new LinkedList<UserInfo>();
            LinkedList<UserInfo> userInfos = new LinkedList<UserInfo>();
            try
            {
                foreach (UserInfo info in users)
                    userInfos.AddLast(info);
            }
            catch { }
            return userInfos;
        }

        public LinkedList<Store> GetStores()
        {
            if (forTests)
                return new LinkedList<Store>();
            LinkedList<Store> stores = new LinkedList<Store>();
            try
            {
                foreach (Store store in this.stores)
                    stores.AddLast(store);
            }
            catch { }
            return stores;
        }

        public LinkedList<MultiCart> GetMultiCarts()
        {
            if (forTests)
                return new LinkedList<MultiCart>();
            LinkedList<MultiCart> multiCarts = new LinkedList<MultiCart>();
            try
            {
                foreach (MultiCart multiCart in this.multiCarts)
                    multiCarts.AddLast(multiCart);
            }
            catch { }
            return multiCarts;
        }

        public int GetProductId()
        {
            if (forTests)
                return 0;
            try
            {
                return products.Count();
            }
            catch
            {
                return 0;
            }
        }

        public int GetMultiCartId()
        {
            if (forTests)
                return 0;
            try
            {
                int max = 0;
                foreach (MultiCart multiCart in multiCarts)
                    if (max < multiCart.multiCartId)
                        max = multiCart.multiCartId;
                return max;
            }
            catch
            {
                return 0;
            }
        }

        public void SaveDb()
        {
            if (forTests)
                return;
            SaveChanges();
        }
    }
}
