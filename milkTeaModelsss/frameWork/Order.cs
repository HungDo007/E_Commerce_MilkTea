namespace milkTeaModelsss.frameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [Key]
        [Column(Order = 0)]
        public DateTime Oder_Time { get; set; }

        public int Amount { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        public int? ToppingId { get; set; }

        [StringLength(1)]
        public string Size { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(200)]
        public string Username { get; set; }

        public virtual Product Product { get; set; }

        public virtual Topping Topping { get; set; }

        public virtual User_Accounts User_Accounts { get; set; }
    }
}
