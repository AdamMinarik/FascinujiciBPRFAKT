using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class ExecutionProject
    {
        
        public string sap {get;set;}
        public string loa { get; set; }
        public string cpm { get; set; }
        public string pm { get; set; }
        public string prepBy { get; set; }
        public string updatedBy { get; set; }
        public string checkBy { get; set; }
        public string name { get; set; }
        public string ownerName { get; set; }

        public int projectID { get; set; }
        public int ownerID { get; set; }
        public int segmentID { get; set; }
        public int scopeID { get; set; }
        public int wtgID { get; set; }
        public int numberWtgs { get; set; }
        public int entryCurID { get; set; }
        public int foundationID { get; set; }
        public int harbourID { get; set; }

        public decimal BUrate { get; set; }
        public decimal RUrate { get; set; }

        public DateTime toc { get; set; }
        public DateTime prepDate { get; set; }
        public DateTime updateDate { get; set; }
        public DateTime checkDate { get; set; }

        public double BUcontract { get; set; }
        public double RUcontract { get; set; }

        public ExecutionProject(
                                 string sap, string loa, string cpm, string pm, string prepBy, string updatedBy, string checkBy,
                                 string name, string ownerName, int projectID, int ownerID, int segmentID, int scopeID, int wtgID, int numberWtgs, int entryCurID,
                                 int foundationID, int harbourID, decimal BUrate, decimal RUrate, DateTime toc, DateTime prepDate,
                                 DateTime updateDate, DateTime checkDate, double BUcontract, double RUcontract
                               )
        {
            this.sap = sap;
            this.loa = loa;
            this.cpm = cpm;
            this.pm = pm;
            this.prepBy = prepBy;
            this.updatedBy = updatedBy;
            this.checkBy = checkBy;
            this.name = name;
            this.ownerName = ownerName;
            this.projectID = projectID;
            this.ownerID = ownerID;
            this.segmentID = segmentID;
            this.scopeID = scopeID;
            this.wtgID = wtgID;
            this.numberWtgs = numberWtgs;
            this.entryCurID = entryCurID;
            this.foundationID = foundationID;
            this.harbourID = harbourID;
            this.BUrate = BUrate;
            this.RUrate = RUrate;
            this.toc = toc;
            this.prepDate = prepDate;
            this.updateDate = updateDate;
            this.checkDate = checkDate;
            this.BUcontract = BUcontract;
            this.RUcontract = RUcontract;
        }


        


    }
}



