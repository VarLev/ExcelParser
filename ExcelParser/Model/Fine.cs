using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ganss.Excel;


namespace ExcelParser.Model
{
    public class Fine
    {
        public int Id { get; set; }
        private string Segment { get; set; }
        public string Product { get; set; }
        public string Country { get; set; }
        [Column("Discount Band")]
        private string DiscountBand { get; set; }
        [Column("Units Sold")]
        private decimal UnitsSold { get; set; }
        [Column("Manufacturing Price")]
        private decimal ManufacturingPrice { get; set; }
        [Column("Sale Price")]
        private decimal SalePrice { get; set; }
        [Column("Gross Sales")]
        private decimal GrossSales { get; set; }
        private decimal Discounts { get; set; }
        private decimal Sales { get; set; }
        private decimal COGS { get; set; }
        public DateTime Date { get; set; }
        public decimal Profit { get; set; }
        [Column("Month Number")]
        private int MonthNumber { get; set; }
        [Column("Month Name")]
        private string MonthName { get; set; }
        private int Year { get; set; }
    }
}
