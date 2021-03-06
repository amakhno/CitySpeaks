﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CitySpeaks_samle.Models
{
    // Чтобы добавить данные профиля для пользователя, можно добавить дополнительные свойства в класс ApplicationUser. Дополнительные сведения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("HifiContext", throwIfV1Schema: false)
        {
        }

        public DbSet<News> News { get; set; }
        public DbSet<Programs> Programs { get; set; }
        public DbSet<Workers> Workers { get; set; }
        public DbSet<MainPage> MainPage { get; set; }
        public DbSet<CustomPage> CustomPage { get; set; }
        public DbSet<ProgramCategories> Categories { get; set; }

        public DbSet<Review> Review { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}