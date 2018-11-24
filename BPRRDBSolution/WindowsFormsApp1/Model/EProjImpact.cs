using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    class EProjImpact : EProjectItem
    {
        //String
        public string projImpactDesc { get; set; }
        public string formulaBefore { get; set; }
        public string formulaBeforeDesc { get; set; }
        public string actions { get; set; }
        public string remarks { get; set; }

        //Int
        public int projImpactOwnerID { get; set; }
        public int daysImpactBefore { get; set; }
        public int respStratImpactID { get; set; }
        public int actionOwnerImpactID { get; set; }
        public int buRate { get; set; }
        public int nccID { get; set; }
        public int orgUnitID { get; set; }

        //Boolean
        public Boolean timeObjective { get; set; }
        public Boolean costObjective { get; set; }
        public Boolean customerSatisfObjective { get; set; }
        public Boolean safetyObjective { get; set; }
        public Boolean qualityObjective { get; set; }
        public Boolean newChanges { get; set; }

        //Double
        public Double percentageBefore { get; set; }
        public Double percentageAfter { get; set; }
        public Double projImpactCost { get; set; }
        public Double monetValueAfter { get; set; }

        //DateTime
        public DateTime ResponseDate { get; set; }
        public DateTime impactStartDate { get; set; }
        public DateTime impactEndDate { get; set; }

        //Consturctor
        public EProjImpact
            (
            long itemID, string excelID, string itemName, string projImpactDesc, int itemStatusID, int customerShareID, bool removedItem, bool watchlist, DateTime createDate, DateTime updateDate, string actions, string remarks, int projImpactOwnerID, int daysImpactBefore,
            int respStratImpactID, int actionOwnerImpactID, int buRate, int nccID, int orgUnitID, Boolean timeObjective, Boolean costObjective,
            Boolean customerSatisfObjective, Boolean safetyObjective, Boolean qualityObjective, Boolean newChanges, Double percentageBefore, Double percentageAfter, Double monetValueAfter,
            Double projImpactCost, DateTime ResponseDate, DateTime impactStartDate, DateTime impactEndDate
            ) : base(itemID, excelID, itemName, projImpactDesc, itemStatusID, customerShareID, removedItem, watchlist, createDate, updateDate)
        {

            this.projImpactDesc = projImpactDesc;
            this.formulaBefore = formulaBefore;
            this.formulaBeforeDesc = formulaBeforeDesc;
            this.monetValueAfter = monetValueAfter;
            this.actions = actions;
            this.remarks = remarks;
            this.projImpactOwnerID = projImpactOwnerID;
            this.daysImpactBefore = daysImpactBefore;
            this.respStratImpactID = respStratImpactID;
            this.actionOwnerImpactID = actionOwnerImpactID;
            this.buRate = buRate;
            this.nccID = nccID;
            this.orgUnitID = orgUnitID;
            this.timeObjective = timeObjective;
            this.costObjective = costObjective;
            this.customerSatisfObjective = customerSatisfObjective;
            this.safetyObjective = safetyObjective;
            this.qualityObjective = qualityObjective;
            this.newChanges = newChanges;
            this.percentageBefore = percentageBefore;
            this.percentageAfter = percentageAfter;
            this.projImpactCost = projImpactCost;
            this.ResponseDate = ResponseDate;
            this.impactStartDate = impactStartDate;
            this.impactEndDate = impactEndDate;
    }
    }
}

