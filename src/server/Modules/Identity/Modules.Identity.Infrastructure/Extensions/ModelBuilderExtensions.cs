// --------------------------------------------------------------------------------------------------
// <copyright file="ModelBuilderExtensions.cs" company="AccentDesign">
// </copyright>
// --------------------------------------------------------------------------------------------------

using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modules.Identity.Core.Entities;
using Modules.Identity.Core.Entities.ExtendedAttributes;
using Shared.Core.Settings;

namespace Modules.Identity.Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyIdentityConfiguration(this ModelBuilder builder, PersistenceSettings persistenceOptions)
        {
            // build model for MSSQL and Postgres

            if (persistenceOptions.UseMsSql)
            {
                foreach (var property in builder.Model.GetEntityTypes()
                    .SelectMany(t => t.GetProperties())
                    .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
                {
                    property.SetColumnType("decimal(23,2)");
                }
            }

            builder.Entity<AccentUser>(entity =>
            {
                entity.ToTable(name: "Users");
            });
            builder.Entity<AccentRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });
            builder.Entity<AccentRoleClaim>(entity =>
            {
                entity.ToTable(name: "RoleClaims");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            builder.Entity<UserExtendedAttribute>(entity =>
            {
                entity.ToTable("UserExtendedAttributes");
            });
            builder.Entity<RoleExtendedAttribute>(entity =>
            {
                entity.ToTable("RoleExtendedAttributes");
            });
        }
    }
}