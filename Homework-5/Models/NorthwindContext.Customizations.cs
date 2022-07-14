using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreScaffolding.Models
{
    public partial class NorthwindContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Territory>().
        }
    }
}
