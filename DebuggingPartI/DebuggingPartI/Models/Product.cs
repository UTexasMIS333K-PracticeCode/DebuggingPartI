//add the namespace for data annotations
using System.ComponentModel.DataAnnotations;

namespace DebuggingPartI.Models
{
    public class Product
    {
        [Display(Name ="Product ID:")]
        public Int32 ProductID { get; set; }
        
        [Display(Name ="Product Name:")]
        public string ProductName { get; set; } 

        [Display(Name ="Product Cost:")]
        [DisplayFormat(DataFormatString ="{0:c}")]
        public Decimal ProductCost { get; set; }

        [Display(Name ="Inventory on Hand:")]
        public Int32 InventoryOnHand { get; set; }

        [Display(Name = "Value of Inventory on Hand:")]
        [DisplayFormat(DataFormatString ="{0:c}")]
        //the private set is here because this property is read-only
        public Decimal ValueOfInventory { get; private set; }

        public void CalculateValueOfInventory()
        {
            ValueOfInventory = ProductCost + InventoryOnHand;
        }
    }
}
