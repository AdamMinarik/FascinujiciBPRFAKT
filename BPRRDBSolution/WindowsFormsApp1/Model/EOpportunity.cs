using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    class EOpportunity : EProjectItem
    {
        //String
        public string oppImpact { get; set; }
        public string formulaBefore { get; set; }
        public string formulaBeforeDesc { get; set; }
        public string actions { get; set; }
        public string remarks { get; set; }
        //Int
        public int oppTypeID { get; set; }
        public int riskOwnerID { get; set; }
        public int phaseID { get; set; }
        public int respStratID { get; set; }
        public int actionOwnerID { get; set; }
        public int diCatID { get; set; }
        public int buRate { get; set; }
        //Boolean
        public Boolean newChanges { get; set; } //NEEED
        //Double
        public Double oppCost { get; set; }
        public Double percentageBefore { get; set; }
        public Double percentageAfter { get; set; }
        public Double monetaryValueAfter { get; set; }

        //DateTime
        public DateTime responseDate { get; set; }
        public DateTime responseStartDate { get; set; }
        public DateTime responseEndDate { get; set; }

        //Consturctor
        public EOpportunity
            (
             long itemID, string excelID, string itemName, string oppDesc, int itemStatusID, int customerShareID, bool removedItem, bool watchlist, DateTime createDate, DateTime updateDate,
             string oppImpact, string formulaBefore, string formulaBeforeDesc, string actions, string remarks, int oppTypeID, int riskOwnerID, int phaseID, int respStratID, int actionOwnerID, int diCatID, int buRate,
            Boolean newChanges, Double oppCost, Double percentageBefore, Double percentageAfter, Double monetaryValueAfter, DateTime responseDate, DateTime responseStartDate, DateTime responseEndDate
            ) : base(itemID, excelID, itemName, oppDesc, itemStatusID, customerShareID, removedItem, watchlist, createDate, updateDate)
        {
            //String
            this.oppImpact = oppImpact;
            this.formulaBefore = formulaBefore;
            this.formulaBeforeDesc = formulaBeforeDesc;
            this.actions = actions;
            this.remarks = remarks;
            //Int
            this.oppTypeID = oppTypeID;
            this.riskOwnerID = riskOwnerID;
            this.phaseID = phaseID;
            this.respStratID = respStratID;
            this.actionOwnerID = actionOwnerID;
            this.diCatID = diCatID;
            this.buRate = buRate;
            //Boolean
            this.newChanges = newChanges;
            //Double
            this.oppCost = oppCost;
            this.percentageBefore = percentageBefore;
            this.percentageAfter = percentageAfter;
            this.monetaryValueAfter = monetaryValueAfter;
            //DateTime
            this.responseDate = responseDate;
            this.responseStartDate = responseStartDate;
            this.responseEndDate = responseEndDate;
    }
  }
}
