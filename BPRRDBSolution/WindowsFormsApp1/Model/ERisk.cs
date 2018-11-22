using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    class ERisk : EProjectItem
    {
        //String
        public string mainRootCause { get; set; }
        public string otherRootCause { get; set; }
        public string actionsRootCause { get; set; }
        public string impactDesc { get; set; }
        public string formulaBefore { get; set; }
        public string formulaBeforeDesc { get; set; }
        public string actionsImpact { get; set; }
        public string monetaryValueAfterDesc { get; set; }
        public string remarks { get; set; }
        //Int
        public int categoryID { get; set; }
        public int respStratRootCauseID { get; set; }
        public int actionOwnerRootCauseID { get; set; }
        public int riskOwnerID { get; set; }
        public int phaseID { get; set; }
        public int wbsID { get; set; }
        public int daysImpactBefore { get; set; }
        public int respStratImpactID { get; set; }
        public int actionOwnerImpactID { get; set; }
        public int daysImpactAfter { get; set; }
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
        public Double costRootCause { get; set; }
        public Double monetaryValueBefore { get; set; }
        public Double monetaryValueAfter { get; set; }
        public Double percentageBefore { get; set; }
        public Double percentageAfter { get; set; }
        //DateTime
        public DateTime ResponseRootCauseDate { get; set; }
        public DateTime ResponseImpactDate { get; set; }
        public DateTime impactStartDate { get; set; }
        public DateTime impactEndDate { get; set; }

        //Consturctor
        public ERisk
            (
            long itemID,
            string excelID, string itemName, string mainRootCause, string otherRootCause, string actionsRootCause, string riskDesc, string impactDesc, string formulaBefore, string formulaBeforeDesc, string actionsImpact,
            string monetaryValueAfterDesc, string remarks,
            int itemStatusID, int customerShareID, int categoryID, Double percentageBefore, int respStratRootCauseID, int actionOwnerRootCauseID, Double percentageAfter, int riskOwnerID, int phaseID, int wbsID, int daysImpactBefore,
            int respStratImpactID, int actionOwnerImpactID, int daysImpactAfter, int buRate, int nccID, int orgUnitID, Boolean removedItem, Boolean watchlist, Boolean newChanges,
            Boolean timeObjective, Boolean costObjective, Boolean customerSatisfObjective, Boolean safetyObjective, Boolean qualityObjective,
            Double costRootCause, Double monetaryValueBefore, Double monetaryValueAfter,
            DateTime createDate, DateTime updateDate, DateTime ResponseRootCauseDate, DateTime ResponseImpactDate, DateTime impactStartDate, DateTime impactEndDate
            ) : base(itemID, excelID, itemName, riskDesc, itemStatusID, customerShareID, removedItem, watchlist, createDate, updateDate)
        {

            this.mainRootCause = mainRootCause;
            this.otherRootCause = otherRootCause;
            this.actionsRootCause = actionsRootCause;
            this.impactDesc = impactDesc;
            this.formulaBefore = formulaBefore;
            this.formulaBeforeDesc = formulaBeforeDesc;
            this.actionsImpact = actionsImpact;
            this.monetaryValueAfterDesc = monetaryValueAfterDesc;
            this.remarks = remarks;
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
            this.ResponseRootCauseDate = ResponseRootCauseDate;
            this.ResponseImpactDate = ResponseImpactDate;
            this.impactStartDate = impactStartDate;
            this.impactEndDate = impactEndDate;
            this.newChanges = newChanges;
        }

        public override string ToString() {
            return base.ToString() +
                    mainRootCause + ", " +
                    otherRootCause + ", " +
                    actionsRootCause + ", " +
                    impactDesc + ", " +
                    formulaBefore + ", " +
                    formulaBeforeDesc + ", " +
                    actionsImpact + ", " +
                    monetaryValueAfterDesc + ", " +
                    remarks + ", " +
                    categoryID + ", " +
                    respStratRootCauseID + ", " +
                    actionOwnerRootCauseID + ", " +
                    riskOwnerID + ", " +
                    phaseID + ", " +
                    wbsID + ", " +
                    daysImpactBefore + ", " +
                    respStratImpactID + ", " +
                    actionOwnerImpactID + ", " +
                    daysImpactAfter + ", " +
                    buRate + ", " +
                    nccID + ", " +
                    orgUnitID + ", " +
                    timeObjective + ", " +
                    costObjective + ", " +
                    customerSatisfObjective + ", " +
                    safetyObjective + ", " +
                    qualityObjective + ", " +
                    costRootCause + ", " +
                    monetaryValueBefore + ", " +
                    monetaryValueAfter + ", " +
                    percentageBefore + ", " +
                    percentageAfter + ", " +
                    ResponseRootCauseDate + ", " +
                    ResponseImpactDate + ", " +
                    impactStartDate + ", " +
                    impactEndDate + ", " +
                    newChanges;
        }

    }
}
