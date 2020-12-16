using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Domain.Entities.Identity;

namespace WebStore.Data
{
    public class WebStoreDbInitializer
    {
        private readonly WebStoreDbContext _db;
        private readonly ILogger<WebStoreDbInitializer> _Logger;
        private readonly RoleManager<Role> _RoleManager;
        private readonly UserManager<User> _UserManager;

        public WebStoreDbInitializer(WebStoreDbContext db, UserManager<User> UserManager, RoleManager<Role> RoleManager, ILogger<WebStoreDbInitializer> Logger)
        {
            _db = db;
            _Logger = Logger;
            _RoleManager = RoleManager;
            _UserManager = UserManager;
        }

        public void Initialize()
        {
            _Logger.LogInformation("Инициализация БД...");
            var db = _db.Database;

            if (db.GetPendingMigrations().Any())
            {
                _Logger.LogInformation("Есть неприменённые миграции...");
                db.Migrate();
                _Logger.LogInformation("Миграции БД выполнены успешно");
            }
            else
                _Logger.LogInformation("Структура БД в актуальном состоянии");

            try
            {
                InitializeProducts();
            }
            catch (Exception e)
            {
                _Logger.LogInformation("Ошибка при инициализации БД данными...");
                throw;
            }

            try
            {
                InitializeIdentityAsync().Wait();
            }
            catch (Exception e)
            {
                _Logger.LogError(e, "Ошибка при инициализации БД системы Identity");
                throw;
            }

        }

        private void InitializeProducts()
        {
            var timer = Stopwatch.StartNew();

            if (_db.Products.Any())
            {
                _Logger.LogInformation("Добавление исходных данных в БД не требуется");
                return;
            }


            _Logger.LogInformation("Добавление секций... {0} мс", timer.ElapsedMilliseconds);
            using (_db.Database.BeginTransaction())
            {
                _db.Sections.AddRange(TestData.Sections);

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Sections] ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Sections] OFF");

                _db.Database.CommitTransaction();
            }

            _Logger.LogInformation("Добавление брэндов...");
            using (_db.Database.BeginTransaction())
            {
                _db.Brands.AddRange(TestData.Brands);

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Brands] ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Brands] OFF");

                _db.Database.CommitTransaction();
            }

            _Logger.LogInformation("Добавление товаров...");
            using (_db.Database.BeginTransaction())
            {
                _db.Products.AddRange(TestData.Products);

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] OFF");

                _db.Database.CommitTransaction();
            }

            _Logger.LogInformation("Добавление товаров в корзину...");
            using (_db.Database.BeginTransaction())
            {
                _db.CartProducts.AddRange(TestData.CartProducts);

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[CartProducts] ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[CartProducts] OFF");

                _db.Database.CommitTransaction();
            }
            _Logger.LogInformation("Инициализация БД данными выполнена успешно за {0} мс", timer.ElapsedMilliseconds);
        }

        private async Task InitializeIdentityAsync()
        {
            async Task CheckRole(string RoleName)
            {
                if (!await _RoleManager.RoleExistsAsync(RoleName))
                    await _RoleManager.CreateAsync(new Role { Name = RoleName });
            }

            await CheckRole(Role.Administrator);
            await CheckRole(Role.User);

            if (await _UserManager.FindByNameAsync(User.Administrator) is null)
            {
                var admin = new User
                {
                    UserName = User.Administrator
                };
                var creation_result = await _UserManager.CreateAsync(admin, User.DefaultAdminPassword);
                if (creation_result.Succeeded)
                    await _UserManager.AddToRoleAsync(admin, Role.Administrator);
                else
                {
                    var errors = creation_result.Errors.Select(e => e.Description);
                    throw new InvalidOperationException($"Ошибка при создании учётно записи администратора {string.Join(",", errors)}");
                }
            }
        }
    }
}
