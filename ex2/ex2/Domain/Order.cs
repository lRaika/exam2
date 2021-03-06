﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2.Domain
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int ShipVia { get; set; }
        public string Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }

    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            HasKey(p => p.OrderID);
            Property(p => p.OrderID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.OrderDate).IsRequired();
            Property(p => p.RequiredDate).IsOptional();
            Property(p => p.ShippedDate).IsOptional();
            Property(p => p.Freight).HasMaxLength(20).IsRequired();
            Property(p => p.ShipName).HasMaxLength(20).IsRequired();
            Property(p => p.ShipAddress).HasMaxLength(40).IsRequired();
            Property(p => p.ShipCity).HasMaxLength(20).IsRequired();
            Property(p => p.ShipRegion).HasMaxLength(20).IsRequired();
            Property(p => p.ShipPostalCode).HasMaxLength(20).IsRequired();
            Property(p => p.ShipCountry).HasMaxLength(20).IsRequired();

            HasMany(p => p.OrderDetails).WithRequired(p => p.Order).HasForeignKey(p => p.OrderId);

        }
    }
}
