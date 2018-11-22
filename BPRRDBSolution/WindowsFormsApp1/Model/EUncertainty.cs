using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    class EUncertainty : EProjectItem
    {
        //Long
        //private long itemID;
        //String
        private string excelID;
        private string itemName;
        private string mainRootCause;
        private string otherRootCause;
        private string actionsRootCause;
        private string riskDesc;
        private string impactDesc;
        private string formulaBefore;
        private string formulaBeforeDesc;
        private string actionsImpact;
        private string monetaryValueAfterDesc;
        private string remarks;
        //Int
        private int itemStatusID;
        private int customerShareID;
        private int categoryID;
        private int respStratRootCauseID;
        private int actionOwnerRootCauseID;
        private int riskOwnerID;
        private int phaseID;
        private int wbsID;
        private int daysImpactBefore;
        private int respStratImpactID;
        private int actionOwnerImpactID;
        private int daysImpactAfter;
        private int buRate;
        private int nccID;
        private int orgUnitID;
        //Boolean
        private Boolean timeObjective;
        private Boolean costObjective;
        private Boolean customerSatisfObjective;
        private Boolean safetyObjective;
        private Boolean qualityObjective;
        //Double
        private Double costRootCause;
        private Double monetaryValueBefore;
        private Double monetaryValueAfter;
        private Double percentageBefore;
        private Double percentageAfter;
        //DateTime
        private DateTime createDate;
        private DateTime updateDate;
        private DateTime ResponseRootCauseDate;
        private DateTime ResponseImpactDate;
        private DateTime impactStartDate;
        private DateTime impactEndDate;

        //Consturctor
        public EUncertainty
            (
            long itemID,
            string excelID, string itemName, string mainRootCause, string otherRootCause, string actionsRootCause, string riskDesc, string impactDesc, string formulaBefore, string formulaBeforeDesc, string actionsImpact,
            string monetaryValueAfterDesc, string remarks,
            int itemStatusID, int customerShareID, int categoryID, Double percentageBefore, int respStratRootCauseID, int actionOwnerRootCauseID, Double percentageAfter, int riskOwnerID, int phaseID, int wbsID, int daysImpactBefore,
            int respStratImpactID, int actionOwnerImpactID, int daysImpactAfter, int buRate, int nccID, int orgUnitID, Boolean removedItem, Boolean watchlist,
            Boolean timeObjective, Boolean costObjective, Boolean customerSatisfObjective, Boolean safetyObjective, Boolean qualityObjective,
            Double costRootCause, Double monetaryValueBefore, Double monetaryValueAfter,
            DateTime createDate, DateTime updateDate, DateTime ResponseRootCauseDate, DateTime ResponseImpactDate, DateTime impactStartDate, DateTime impactEndDate
            ) : base(itemID, excelID, itemName, riskDesc, itemStatusID, customerShareID, removedItem, watchlist, createDate, updateDate)
        {
            //base.itemID = itemID;
            //this.excelID = excelID;
            //this.itemName = itemName;
            this.mainRootCause = mainRootCause;
            this.otherRootCause = otherRootCause;
            this.actionsRootCause = actionsRootCause;
            //this.riskDesc = riskDesc;
            this.impactDesc = impactDesc;
            this.formulaBefore = formulaBefore;
            this.formulaBeforeDesc = formulaBeforeDesc;
            this.actionsImpact = actionsImpact;
            this.monetaryValueAfterDesc = monetaryValueAfterDesc;
            this.remarks = remarks;
            //this.itemStatusID = itemStatusID;
            //this.customerShareID = customerShareID;
            this.categoryID = categoryID;
            this.percentageBefore = percentageBefore;
            this.respStratRootCauseID = respStratRootCauseID;
            this.actionOwnerRootCauseID = actionOwnerRootCauseID;
            this.percentageAfter = percentageAfter;
            this.riskOwnerID = riskOwnerID;
            this.phaseID = phaseID;
            this.wbsID = wbsID;
            this.daysImpactBefore = daysImpactBefore;
            this.respStratImpactID = respStratImpactID;
            this.actionOwnerImpactID = actionOwnerImpactID;
            this.daysImpactAfter = daysImpactAfter;
            this.buRate = buRate;
            this.nccID = nccID;
            this.orgUnitID = orgUnitID;
            this.timeObjective = timeObjective;
            this.costObjective = costObjective;
            this.customerSatisfObjective = customerSatisfObjective;
            this.safetyObjective = safetyObjective;
            this.qualityObjective = qualityObjective;
            this.costRootCause = costRootCause;
            this.monetaryValueBefore = monetaryValueBefore;
            this.monetaryValueAfter = monetaryValueAfter;
            //this.createDate = createDate;
            //this.updateDate = updateDate;
            this.ResponseRootCauseDate = ResponseRootCauseDate;
            this.ResponseImpactDate = ResponseImpactDate;
            this.impactStartDate = impactStartDate;
            this.impactEndDate = impactEndDate;
        }

        public string kokotinka()
        {
            //return base.kokotina() + 
            //        "kokotina, " +
            //        //itemID + ", " +
            //        //excelID + ", " +
            //        //itemName + ", " +
            //        mainRootCause + ", " +
            //        otherRootCause + ", " +
            //        actionsRootCause + ", " +
            //        //riskDesc + ", " +
            //        impactDesc + ", " +
            //        formulaBefore + ", " +
            //        formulaBeforeDesc + ", " +
            //        actionsImpact + ", " +
            //        monetaryValueAfterDesc + ", " +
            //        remarks + ", " +
            //        //itemStatusID + ", " +
            //        //customerShareID + ", " +
            //        categoryID + ", " +
            //        respStratRootCauseID + ", " +
            //        actionOwnerRootCauseID + ", " +
            //        riskOwnerID + ", " +
            //        phaseID + ", " +
            //        wbsID + ", " +
            //        daysImpactBefore + ", " +
            //        respStratImpactID + ", " +
            //        actionOwnerImpactID + ", " +
            //        daysImpactAfter + ", " +
            //        buRate + ", " +
            //        nccID + ", " +
            //        orgUnitID + ", " +
            //        timeObjective + ", " +
            //        costObjective + ", " +
            //        customerSatisfObjective + ", " +
            //        safetyObjective + ", " +
            //        qualityObjective + ", " +
            //        costRootCause + ", " +
            //        monetaryValueBefore + ", " +
            //        monetaryValueAfter + ", " +
            //        percentageBefore + ", " +
            //        percentageAfter + ", " +
            //        //createDate + ", " +
            //        //updateDate + ", " +
            //        ResponseRootCauseDate + ", " +
            //        ResponseImpactDate + ", " +
            //        impactStartDate + ", " +
            //        impactEndDate;
            return "PIKO";
        }
    }
}

