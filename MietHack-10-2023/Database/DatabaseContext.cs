using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Npgsql.NameTranslation;
using System.Security.Principal;
using System;
using MietHack_10_2023.Database.Models;

namespace MietHack_10_2023.Database
{
    /// <inheritdoc/>
    public partial class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// .ctor
        /// </summary>
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);

            var mapper = new NpgsqlSnakeCaseNameTranslator();
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                var storeObjectIdentifier = StoreObjectIdentifier.Table(entity.GetTableName() ?? string.Empty, entity.GetSchema());
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(mapper.TranslateMemberName(property.GetColumnName(storeObjectIdentifier) ?? string.Empty));
                }
            }
        }
    }
}
