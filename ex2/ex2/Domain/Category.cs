﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2.Domain
{
    public class Category
    {
        public Guid? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public ICollection<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }
    }

    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            HasKey(p => p.CategoryID);
            Property(p => p.CategoryID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.CategoryName).HasMaxLength(30).IsRequired();
            Property(p => p.Description).HasMaxLength(150).IsRequired();
            Property(p => p.Picture).HasMaxLength(150).IsRequired();
            HasMany(p => p.Products).WithOptional(p => p.Category).HasForeignKey(p => p.CategoryID);
        }
    }
}
