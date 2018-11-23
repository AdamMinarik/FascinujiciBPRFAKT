using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    abstract class EProjectItem
    {
        public long itemID { get; set; }
        //String
        public string excelID { get; set; }
        public string itemName { get; set; }
        public string itemDescription { get; set; }
        //Int
        public int itemStatusID { get; set; }
        public int customerShareID { get; set; }

        public bool removedItem { get; set; }
        public bool watchlist { get; set; }

        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
        

        public EProjectItem(long itemID, string excelID, string itemName, string itemDescription, int itemStatusID, int customerShareID, Boolean removedItem, Boolean watchlist, DateTime created, DateTime updated)
        {
            this.itemID = itemID;
            this.excelID = excelID;
            this.itemName = itemName;
            this.itemDescription = itemDescription;
            this.itemStatusID = itemStatusID;
            this.customerShareID = customerShareID;
            this.createDate = created;
            this.updateDate = updated;
            this.removedItem = removedItem;
            this.watchlist = watchlist;
        }

        public override string ToString()
        {
            return itemID + ", " +
                   excelID + ", " +
                   itemName + ", " +
                   itemDescription + ", " +
                   itemStatusID + ", " +
                   customerShareID + ", " +
                   removedItem + ", " +
                   watchlist + ", " +
                   createDate + ", " +
                   updateDate;
        }

        public long getItemID()
        {
            return itemID;
        }
    }
}
