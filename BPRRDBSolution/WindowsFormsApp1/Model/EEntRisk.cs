using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    class EEntRisk : EProjectItem
    {
        //String
        public string itemDesc { get; set; }
        public string itemActions { get; set; }
        public string otherComment { get; set; }

        //Int
        public int categoryID { get; set; }
        public int itemOwnerID { get; set; }
        public int impactID { get; set; }
        public int manageabilityID { get; set; }
        public int predictabilityID { get; set; }
        public int actionOwnerID { get; set; }

        //DateTime
        public DateTime ResponseDate { get; set; }

        //Consturctor
        public EEntRisk
            (
            long itemID, string excelID, string itemName, string itemDesc, int itemStatusID, int customerShareID, bool removedItem, bool watchlist, DateTime createDate, DateTime updateDate,
            string itemActions, string otherComment, int categoryID, int itemOwnerID, int impactID, int manageabilityID, int predictabilityID, int actionOwnerID, DateTime ResponseDate
            ) : base(itemID, excelID, itemName, itemDesc, itemStatusID, customerShareID, removedItem, watchlist, createDate, updateDate)
        {
            this.itemDesc = itemDesc;
            this.itemActions = itemActions;
            this.otherComment = otherComment;
            this.categoryID = categoryID;
            this.itemOwnerID = itemOwnerID;
            this.impactID = impactID;
            this.manageabilityID = manageabilityID;
            this.predictabilityID = predictabilityID;
            this.actionOwnerID = actionOwnerID;
            this.ResponseDate = ResponseDate;
        }
    }
}
