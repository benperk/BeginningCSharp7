namespace BeginningCSharp7_23_3_XMLfromDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Stock
    {
        public int StockId { get; set; }

        public int OnHand { get; set; }

        public int OnOrder { get; set; }

        public int? Item_Code { get; set; }

        public int? Store_StoreId { get; set; }

        public virtual Book Book { get; set; }

        public virtual Store Store { get; set; }
    }
}
