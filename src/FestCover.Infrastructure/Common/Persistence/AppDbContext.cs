using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using FestCover.Application.Common.Contracts;
using FestCover.Domain.Albums;
using FestCover.Domain.Common;
using FestCover.Infrastructure.Common.Persistence.Configurations;
using FestCover.Infrastructure.Common.Persistence.Identity;
using FestCover.Infrastructure.Common.Persistence.Interceptors;
using FestCover.Domain.AlbumContents;
using System.Reflection.Emit;

namespace FestCover.Infrastructure.Common.Persistence
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        private readonly IUserService _tenant;
        public string TenantId { get; set; }
        private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
        private readonly AuditInterceptor _auditInterceptor;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options,
            PublishDomainEventsInterceptor publishDomainEventsInterceptor,
            AuditInterceptor auditInterceptor,
            IUserService tenant
            ) : base(options)
        {
            _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
            _auditInterceptor = auditInterceptor;
            _tenant = tenant;
            TenantId = _tenant.GetCurrentUserId();
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumContent> AlbumContents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<List<IDomainEvent>>().ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
            SeedRolesConfig(modelBuilder);
            IdentityConfigurations(modelBuilder);
            DatabaseConfigurations(modelBuilder);


        }

        private void DatabaseConfigurations(ModelBuilder modelBuilder)
        {
            if (!string.IsNullOrEmpty(TenantId))
            {
                var currentUser = UserId.Create(Guid.Parse(TenantId));
                modelBuilder.Entity<Album>().HasQueryFilter(q => q.UserId == currentUser);

            }
            modelBuilder.Entity<Album>().HasQueryFilter(q => !q.IsDeleted);
            modelBuilder.Entity<AlbumContent>().HasQueryFilter(q => !q.IsDeleted);
        }
        public void IdentityConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UsersClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UsersRoles");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UsersLogins");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RolesClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UsersTokens");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditInterceptor);
            optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
            optionsBuilder.ReplaceService<IModelCacheKeyFactory, TenantModelCacheKeyFactory>();
            base.OnConfiguring(optionsBuilder);
        }
        public void SeedRolesConfig(ModelBuilder modelBuilder)
        {
            var adminRoleId = Guid.Parse("D67C7FBD-69BB-4926-ACB6-F393143C16B3");
            var adminConcurrencyStamp = Guid.Parse("34A8BD40-92FE-4640-84D5-0DA273563AA1");

            var userRoleId = Guid.Parse("E67C7FBD-69BB-4926-ACB6-F393143C16B3");
            var userConcurrencyStamp = Guid.Parse("24A8BD40-92FE-4640-84D5-0DA273563AA1");
            modelBuilder.Entity<Role>().HasData(new Role
            {

                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = adminRoleId,
                ConcurrencyStamp = adminConcurrencyStamp.ToString(),

            });
            modelBuilder.Entity<Role>().HasData(new Role
            {

                Name = "User",
                NormalizedName = "USER",
                Id = userRoleId,
                ConcurrencyStamp = userConcurrencyStamp.ToString()

            });
            var hasher = new PasswordHasher<User>();
            var userId = Guid.Parse("F69B50AA-DE02-423B-ABC4-0BA2FB3EB64D");
            var user2Id = Guid.Parse("613DE40E-809C-47C2-8F8B-005EFFFFF05E");
            modelBuilder.Entity<User>().HasData(new User
            {
                UserName = "JoelFerreira",
                Id = userId,
                NormalizedUserName = "JOELFERREIRA",
                EmailConfirmed = true,
                PhoneNumber = "+351960180464",
                SecurityStamp = Guid.NewGuid().ToString(),
                NormalizedEmail = "J141996@HOTMAIL.COM",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "jJ963679933"),
                Email = "j141996@hotmail.com",
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                UserName = "JoaoMiranda",
                Id = user2Id,
                NormalizedUserName = "JOAOMIRANDA",
                EmailConfirmed = true,
                PhoneNumber = "+351960180464",
                SecurityStamp = Guid.NewGuid().ToString(),
                NormalizedEmail = "MIRANDAJP@GMAIL.COM",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "milliondollaridea$1"),
                Email = "mirandajp@gmail.com",
            });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                UserId = userId,
                RoleId = adminRoleId,

            });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                UserId = user2Id,
                RoleId = adminRoleId,

            });
        }
    }
}
