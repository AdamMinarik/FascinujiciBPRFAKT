using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Mediator
{
    class Storage : RDBModel
    {
      
        private SqlConnectionStringBuilder connectionString;
        //Risk
        private DataTable dataSourceERisk;
        private SqlDataAdapter dataAdapterERisk;
        //Opportunity
        private DataTable dataSourceEOpportunity;
        private SqlDataAdapter dataAdapterEOpportunity;
        //Project Impact
        private DataTable dataSourceEProjectImpact;
        private SqlDataAdapter dataAdapterEProjectImpact;
        //Enterprise Risk
        private DataTable dataSourceEEnterpriseRisk;
        private SqlDataAdapter dataAdapterEEnterpriseRisk;
        //Other Uncertainties
        private DataTable dataSourceEOtherUncertainties;
        private SqlDataAdapter dataAdapterEOtherUncertainties;
        //User
        private DataTable dataSourceExecutionUser;
        private SqlDataAdapter dataAdapterExecutionUser;

        //UPDATES,INSERTS
        private SqlCommand command;




        private SqlConnection connection;

        public Storage()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "riskdbsserver.database.windows.net";
            builder.UserID = "superuser@riskdbsserver";
            builder.Password = "Greenpear@1";
            builder.InitialCatalog = "[EW_Risk_Test]";
            connectionString = builder;
            connection = new SqlConnection(connectionString.ConnectionString);
        }
           
        public void addItem(EProjectItem item, bool approval)
        {
            throw new NotImplementedException();
        }

        public EProjectItemList getClosedItems(int projectID, string month, string type)
        {
            //RISKS
            if (type.ToLower() == "risk")
            {
                connection.Open();
                string SQL = "SELECT * FROM rk_ROlog WHERE status != 1";

                dataAdapterERisk = new SqlDataAdapter(SQL, connection);
                dataSourceERisk = new DataTable();
                dataAdapterERisk.Fill(dataSourceERisk);
                EProjectItem riskItem;
                EProjectItemList itemsList = new EProjectItemList();
                foreach (DataRow row in dataSourceERisk.Rows)
                {
                    riskItem = new ERisk(
                                   Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())),
                                   row["ExcelID"].ToString(),
                                   row["Rname"].ToString(),
                                   row["RootCause"].ToString(),
                                   row["OtherRootCause"].ToString(),
                                   row["MitDesc"].ToString(),
                                   row["rkDesc"].ToString(),
                                   row["ImpactDirect"].ToString(),
                                   row["formula"].ToString(),
                                   row["forDesc"].ToString(),
                                   row["Impact"].ToString(),
                                   row["calcDescAfter"].ToString(),
                                   row["remarks"].ToString(),
                                   Convert.ToInt32(row["Status"].ToString()),
                                   Convert.ToInt32(row["ID_customerShare"].ToString()),
                                   Convert.ToInt32(row["IDcat"].ToString()),
                                   Convert.ToDouble(row["P"].ToString()),
                                   Convert.ToInt32(row["reStrategy"].ToString()),
                                   Convert.ToInt32(row["ID_riskActionOwner"].ToString()),
                                   Convert.ToDouble(row["pAfter"].ToString()),
                                   Convert.ToInt32(row["IDowner"].ToString()),
                                   Convert.ToInt32(row["ID_Phase"].ToString()),
                                   Convert.ToInt32(row["ID_WBS"].ToString()),
                                   Convert.ToInt32(row["ExpValueDays"].ToString()),
                                   Convert.ToInt32(row["ID_resp"].ToString()),
                                   Convert.ToInt32(row["IDOwnerDirect"].ToString()),
                                   Convert.ToInt32(row["expValueDaysAfter"].ToString()),
                                   Convert.ToInt32(row["BU"].ToString()),
                                   Convert.ToInt32(row["IDncc"].ToString()),
                                   Convert.ToInt32(row["OriginatingID"].ToString()),
                                   Convert.ToBoolean(row["RemovedItem"].ToString()),
                                   Convert.ToBoolean(row["Watchlist"].ToString()),
                                   Convert.ToBoolean(row["newChanges"].ToString()),
                                   Convert.ToBoolean(row["timeObjective"].ToString()),
                                   Convert.ToBoolean(row["costObjective"].ToString()),
                                   Convert.ToBoolean(row["costSatisfObjective"].ToString()),
                                   Convert.ToBoolean(row["safetyfObjective"].ToString()),
                                   Convert.ToBoolean(row["qualityObjective"].ToString()),
                                   Convert.ToDouble(row["MitCost"].ToString()),
                                   Convert.ToDouble(row["CostMitiImpact"].ToString()),
                                   Convert.ToDouble(row["rkBef"].ToString()),
                                   Convert.ToDouble(row["valAfterMiti"].ToString()),
                                   Convert.ToDateTime(row["creationdate"].ToString()),
                                   Convert.ToDateTime(row["updateDate"].ToString()),
                                   Convert.ToDateTime(row["mitDate"].ToString()),
                                   Convert.ToDateTime(row["mitiActDate"].ToString()),
                                   Convert.ToDateTime(row["DueDate"].ToString()),
                                   Convert.ToDateTime(row["ImpEndDate"].ToString())
                                   );
                    itemsList.add(riskItem);

                }
                return itemsList;
            }
            //OPPORTUNITIES
            else if (type.ToLower() == "opportunity")
            {
                connection.Open();
                string SQL = "SELECT * FROM rk_Opportunities WHERE watchlist = 1";

                dataAdapterEOpportunity = new SqlDataAdapter(SQL, connection);
                dataSourceEOpportunity = new DataTable();
                dataAdapterEOpportunity.Fill(dataSourceEOpportunity);
                EProjectItem opportunityItem;
                EProjectItemList itemsList = new EProjectItemList();

                foreach (DataRow row in dataSourceEOpportunity.Rows)
                {
                    opportunityItem = new EOpportunity(
                                   Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())),
                                   row["ExcelID"].ToString(),
                                   row["Name"].ToString(),
                                   row["oppDescription"].ToString(),
                                   Convert.ToInt32(row["Status"].ToString()),
                                   Convert.ToInt32(row["customerShareID"].ToString()),
                                   Convert.ToBoolean(row["removedItem"].ToString()),
                                   Convert.ToBoolean(row["watchlist"].ToString()),
                                   Convert.ToDateTime(row["creationdate"].ToString()),
                                   Convert.ToDateTime(row["updatedate"].ToString()),
                                   row["impactDescription"].ToString(),
                                   row["formula"].ToString(),
                                   row["formDesc"].ToString(),
                                   row["actions"].ToString(),
                                   row["Remarks"].ToString(),
                                   Convert.ToInt32(row["rootCauseCat"].ToString()),
                                   Convert.ToInt32(row["oppOwnerID"].ToString()),
                                   Convert.ToInt32(row["phaseID"].ToString()),
                                   Convert.ToInt32(row["responseID"].ToString()),
                                   Convert.ToInt32(row["oppActionOwnerID"].ToString()),
                                   Convert.ToInt32(row["DICatID"].ToString()),
                                   Convert.ToInt32(row["BU"].ToString()),
                                   Convert.ToBoolean(row["newChanges"].ToString()),
                                   Convert.ToDouble(row["costEstimateResponse"].ToString()),
                                   Convert.ToDouble(row["P"].ToString()),
                                   Convert.ToDouble(row["Pafter"].ToString()),
                                   Convert.ToDouble(row["monetValueAfter"].ToString()),
                                   Convert.ToDateTime(row["dateResponse"].ToString()),
                                   Convert.ToDateTime(row["startDate"].ToString()),
                                   Convert.ToDateTime(row["endDate"].ToString())
                                   );
                    itemsList.add(opportunityItem);
                }
                return itemsList;
            }
            //PROJECT IMPACTS
            else if (type.ToLower() == "projectimpact")
            {
                connection.Open();
                string SQL = "SELECT * FROM rk_ProjectImpacts WHERE status != 1";

                dataAdapterEProjectImpact = new SqlDataAdapter(SQL, connection);
                dataSourceEProjectImpact = new DataTable();
                dataAdapterEProjectImpact.Fill(dataSourceEProjectImpact);
                EProjectItem projImpactItem;
                EProjectItemList itemsList = new EProjectItemList();

                foreach (DataRow row in dataSourceEProjectImpact.Rows)
                {
                    projImpactItem = new EProjImpact(
                                   Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())),
                                   row["ExcelID"].ToString(),
                                   row["Name"].ToString(),
                                   row["impactDescription"].ToString(),
                                   Convert.ToInt32(row["status"].ToString()),
                                   Convert.ToInt32(row["ID_customerShare"].ToString()),
                                   Convert.ToBoolean(row["removeItem"].ToString()),
                                   Convert.ToBoolean(row["watchlist"].ToString()),
                                   Convert.ToDateTime(row["createdItem"].ToString()),
                                   Convert.ToDateTime(row["updatedate"].ToString()),
                                   row["Actions"].ToString(),
                                   row["Remarks"].ToString(),
                                   Convert.ToInt32(row["impactOwner"].ToString()),
                                   Convert.ToInt32(row["impactDays"].ToString()),
                                   Convert.ToInt32(row["respStrat"].ToString()),
                                   Convert.ToInt32(row["riskActionOwner"].ToString()),
                                   Convert.ToInt32(row["BU"].ToString()),
                                   Convert.ToInt32(row["IDncc"].ToString()),
                                   Convert.ToInt32(row["OriginatingID"].ToString()),
                                   Convert.ToBoolean(row["timeObjective"].ToString()),
                                   Convert.ToBoolean(row["costObjective"].ToString()),
                                   Convert.ToBoolean(row["costSatisfObjective"].ToString()),
                                   Convert.ToBoolean(row["safetyfObjective"].ToString()),
                                   Convert.ToBoolean(row["qualityObjective"].ToString()),
                                   Convert.ToBoolean(row["newChanges"].ToString()),
                                   Convert.ToInt32(row["P"].ToString()),
                                   Convert.ToInt32(row["Pafter"].ToString()),
                                   Convert.ToInt32(row["monetAfterTxt"].ToString()),
                                   Convert.ToInt32(row["costEstimRespPlan"].ToString()),
                                   Convert.ToDateTime(row["respPlanDate"].ToString()),
                                   Convert.ToDateTime(row["startDate"].ToString()),
                                   Convert.ToDateTime(row["endDate"].ToString())
                                );
                    itemsList.add(projImpactItem);
                }
                return itemsList;
            }
            //ENTERPRISE RISKS
            else if (type.ToLower() == "enterpriserisk")
            {
                connection.Open();
                string SQL = "SELECT * FROM [rk_EnterpriseRisk] WHERE status != 1";

                dataAdapterEEnterpriseRisk = new SqlDataAdapter(SQL, connection);
                dataSourceEEnterpriseRisk = new DataTable();
                dataAdapterEEnterpriseRisk.Fill(dataSourceEEnterpriseRisk);
                EProjectItem enterpriseRiskItem;
                EProjectItemList itemsList = new EProjectItemList();

                foreach (DataRow row in dataSourceEEnterpriseRisk.Rows)
                {
                    enterpriseRiskItem = new EEntRisk(
                                   Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())),
                                   row["ExcelID"].ToString(),
                                   row["Name"].ToString(),
                                   row["ItemDescription"].ToString(),
                                   Convert.ToInt32(row["Status"].ToString()),
                                   Convert.ToInt32(row["CustomerShareID"].ToString()),
                                   Convert.ToBoolean(row["removedItem"].ToString()),
                                   Convert.ToBoolean(row["watchlist"].ToString()),
                                   Convert.ToDateTime(row["CreateDate"].ToString()),
                                   Convert.ToDateTime(row["UpdateDate"].ToString()),
                                   row["Actions"].ToString(),
                                   row["OtherComment"].ToString(),
                                   Convert.ToInt32(row["CategoryID"].ToString()),
                                   Convert.ToInt32(row["ItemOwnerID"].ToString()),
                                   Convert.ToInt32(row["ImpactID"].ToString()),
                                   Convert.ToInt32(row["ManageabilityID"].ToString()),
                                   Convert.ToInt32(row["PredictabilityID"].ToString()),
                                   Convert.ToInt32(row["ActionsOwner"].ToString()),
                                   Convert.ToDateTime(row["MitiActionsDate"].ToString())
                                );
                    itemsList.add(enterpriseRiskItem);
                }
                return itemsList;
            }
            //OTHER UNCERTAINTIES
            else if (type.ToLower() == "otheruncertainty")
            {
                connection.Open();
                string SQL = "SELECT * FROM [rk_OtherUncertainties] WHERE status != 1";

                dataAdapterEOtherUncertainties = new SqlDataAdapter(SQL, connection);
                dataSourceEOtherUncertainties = new DataTable();
                dataAdapterEOtherUncertainties.Fill(dataSourceEOtherUncertainties);
                EProjectItem otherUncertaintyItem;
                EProjectItemList itemsList = new EProjectItemList();

                foreach (DataRow row in dataSourceEOtherUncertainties.Rows)
                {
                    otherUncertaintyItem = new EUncertainty(
                                   Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())),
                                   row["ExcelID"].ToString(),
                                   row["Name"].ToString(),
                                   row["ItemDescription"].ToString(),
                                   Convert.ToInt32(row["Status"].ToString()),
                                   Convert.ToInt32(row["CustomerShareID"].ToString()),
                                   Convert.ToBoolean(row["removedItem"].ToString()),
                                   Convert.ToBoolean(row["watchlist"].ToString()),
                                   Convert.ToDateTime(row["CreateDate"].ToString()),
                                   Convert.ToDateTime(row["UpdateDate"].ToString()),
                                   row["Actions"].ToString(),
                                   row["OtherComment"].ToString(),
                                   Convert.ToInt32(row["CategoryID"].ToString()),
                                   Convert.ToInt32(row["ItemOwnerID"].ToString()),
                                   Convert.ToInt32(row["ImpactID"].ToString()),
                                   Convert.ToInt32(row["ManageabilityID"].ToString()),
                                   Convert.ToInt32(row["PredictabilityID"].ToString()),
                                   Convert.ToInt32(row["ActionsOwner"].ToString()),
                                   Convert.ToDateTime(row["MitiActionsDate"].ToString())
                                );
                    itemsList.add(otherUncertaintyItem);
                }
                return itemsList;
            }
            else
            {

                EProjectItemList itemsList = new EProjectItemList();
                return itemsList;
            }
        }

        public ExecutionUser getExecutionUser(string userName)
        {
            connection.Open();
            string SQL = "SELECT * FROM rk_users WHERE UserName = '" + userName + "'";
            
            dataAdapterExecutionUser = new SqlDataAdapter(SQL, connection);
            dataSourceExecutionUser = new DataTable();
            dataAdapterExecutionUser.Fill(dataSourceExecutionUser);
            foreach (DataRow row in dataSourceExecutionUser.Rows)
            {
                ExecutionUser user = new ExecutionUser(
                                                      Convert.ToInt32(row["ID"].ToString()),
                                                      Convert.ToInt32(row["IDRoles"].ToString()),
                                                      row["userName"].ToString(),
                                                      row["firstName"].ToString(),
                                                      row["middleName"].ToString(),
                                                      row["lastName"].ToString(),
                                                      row["GID"].ToString(),
                                                      row["email"].ToString()
                                                     );
                connection.Close();
                return user;
            }

            connection.Close();
            return null;
        }

        public EProjectItemList getFilterItems(int projectID, string month, string field, string fieldValue)
        {
            throw new NotImplementedException();
        }

        public EProjectItemList getItems(int projectID, string month, string type)
        {
            //RISKS
            if (type.ToLower() == "risk")
            {
                connection.Open();
                string SQL = "SELECT * FROM rk_ROlog";

                dataAdapterERisk = new SqlDataAdapter(SQL, connection);
                dataSourceERisk = new DataTable();
                dataAdapterERisk.Fill(dataSourceERisk);
                EProjectItem riskItem;
                EProjectItemList itemsList = new EProjectItemList();
                foreach (DataRow row in dataSourceERisk.Rows)
                {
                    riskItem = new ERisk(
                                   Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())),
                                   row["ExcelID"].ToString(),
                                   row["Rname"].ToString(),
                                   row["RootCause"].ToString(),
                                   row["OtherRootCause"].ToString(),
                                   row["MitDesc"].ToString(),
                                   row["rkDesc"].ToString(),
                                   row["ImpactDirect"].ToString(),
                                   row["formula"].ToString(),
                                   row["forDesc"].ToString(),
                                   row["Impact"].ToString(),
                                   row["calcDescAfter"].ToString(),
                                   row["remarks"].ToString(),
                                   Convert.ToInt32(row["Status"].ToString()),
                                   Convert.ToInt32(row["ID_customerShare"].ToString()),
                                   Convert.ToInt32(row["IDcat"].ToString()),
                                   Convert.ToDouble(row["P"].ToString()),
                                   Convert.ToInt32(row["reStrategy"].ToString()),
                                   Convert.ToInt32(row["ID_riskActionOwner"].ToString()),
                                   Convert.ToDouble(row["pAfter"].ToString()),
                                   Convert.ToInt32(row["IDowner"].ToString()),
                                   Convert.ToInt32(row["ID_Phase"].ToString()),
                                   Convert.ToInt32(row["ID_WBS"].ToString()),
                                   Convert.ToInt32(row["ExpValueDays"].ToString()),
                                   Convert.ToInt32(row["ID_resp"].ToString()),
                                   Convert.ToInt32(row["IDOwnerDirect"].ToString()),
                                   Convert.ToInt32(row["expValueDaysAfter"].ToString()),
                                   Convert.ToInt32(row["BU"].ToString()),
                                   Convert.ToInt32(row["IDncc"].ToString()),
                                   Convert.ToInt32(row["OriginatingID"].ToString()),
                                   Convert.ToBoolean(row["RemovedItem"].ToString()),
                                   Convert.ToBoolean(row["Watchlist"].ToString()),
                                   Convert.ToBoolean(row["newChanges"].ToString()),
                                   Convert.ToBoolean(row["timeObjective"].ToString()),
                                   Convert.ToBoolean(row["costObjective"].ToString()),
                                   Convert.ToBoolean(row["costSatisfObjective"].ToString()),
                                   Convert.ToBoolean(row["safetyfObjective"].ToString()),
                                   Convert.ToBoolean(row["qualityObjective"].ToString()),
                                   Convert.ToDouble(row["MitCost"].ToString()),
                                   Convert.ToDouble(row["CostMitiImpact"].ToString()),
                                   Convert.ToDouble(row["rkBef"].ToString()),
                                   Convert.ToDouble(row["valAfterMiti"].ToString()),
                                   Convert.ToDateTime(row["creationdate"].ToString()),
                                   Convert.ToDateTime(row["updateDate"].ToString()),
                                   Convert.ToDateTime(row["mitDate"].ToString()),
                                   Convert.ToDateTime(row["mitiActDate"].ToString()),
                                   Convert.ToDateTime(row["DueDate"].ToString()),
                                   Convert.ToDateTime(row["ImpEndDate"].ToString())
                                   );
                    itemsList.add(riskItem);

                }
                return itemsList;
            }
            //OPPORTUNITIES
            else if (type.ToLower() == "opportunity")
            {
                connection.Open();
                string SQL = "SELECT * FROM rk_Opportunities";

                dataAdapterEOpportunity = new SqlDataAdapter(SQL, connection);
                dataSourceEOpportunity = new DataTable();
                dataAdapterEOpportunity.Fill(dataSourceEOpportunity);
                EProjectItem opportunityItem ;
                EProjectItemList itemsList = new EProjectItemList();

                foreach (DataRow row in dataSourceEOpportunity.Rows)
                {
                    opportunityItem = new EOpportunity(
                                   Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())),
                                   row["ExcelID"].ToString(),
                                   row["Name"].ToString(),
                                   row["oppDescription"].ToString(),
                                   Convert.ToInt32(row["Status"].ToString()),
                                   Convert.ToInt32(row["customerShareID"].ToString()),
                                   Convert.ToBoolean(row["removedItem"].ToString()),
                                   Convert.ToBoolean(row["watchlist"].ToString()),
                                   Convert.ToDateTime(row["creationdate"].ToString()),
                                   Convert.ToDateTime(row["updatedate"].ToString()),
                                   row["impactDescription"].ToString(),
                                   row["formula"].ToString(),
                                   row["formDesc"].ToString(),
                                   row["actions"].ToString(),
                                   row["Remarks"].ToString(),
                                   Convert.ToInt32(row["rootCauseCat"].ToString()),
                                   Convert.ToInt32(row["oppOwnerID"].ToString()),
                                   Convert.ToInt32(row["phaseID"].ToString()),
                                   Convert.ToInt32(row["responseID"].ToString()),
                                   Convert.ToInt32(row["oppActionOwnerID"].ToString()),
                                   Convert.ToInt32(row["DICatID"].ToString()),
                                   Convert.ToInt32(row["BU"].ToString()),
                                   Convert.ToBoolean(row["newChanges"].ToString()),
                                   Convert.ToDouble(row["costEstimateResponse"].ToString()),
                                   Convert.ToDouble(row["P"].ToString()),
                                   Convert.ToDouble(row["Pafter"].ToString()),
                                   Convert.ToDouble(row["monetValueAfter"].ToString()),
                                   Convert.ToDateTime(row["dateResponse"].ToString()),
                                   Convert.ToDateTime(row["startDate"].ToString()),
                                   Convert.ToDateTime(row["endDate"].ToString())
                                   );
                    itemsList.add(opportunityItem);
                }
                return itemsList;
            }
            //PROJECT IMPACTS
            else if (type.ToLower() == "projectimpact")
            {
                connection.Open();
                string SQL = "SELECT * FROM rk_ProjectImpacts";

                dataAdapterEProjectImpact = new SqlDataAdapter(SQL, connection);
                dataSourceEProjectImpact = new DataTable();
                dataAdapterEProjectImpact.Fill(dataSourceEProjectImpact);
                EProjectItem projImpactItem;
                EProjectItemList itemsList = new EProjectItemList();

                foreach (DataRow row in dataSourceEProjectImpact.Rows)
                {
                    projImpactItem = new EProjImpact(
                                   Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())),
                                   row["ExcelID"].ToString(),
                                   row["Name"].ToString(),
                                   row["impactDescription"].ToString(),
                                   Convert.ToInt32(row["status"].ToString()),
                                   Convert.ToInt32(row["ID_customerShare"].ToString()),
                                   Convert.ToBoolean(row["removeItem"].ToString()),
                                   Convert.ToBoolean(row["watchlist"].ToString()),
                                   Convert.ToDateTime(row["createdItem"].ToString()),
                                   Convert.ToDateTime(row["updatedate"].ToString()),
                                   row["Actions"].ToString(),
                                   row["Remarks"].ToString(),
                                   Convert.ToInt32(row["impactOwner"].ToString()),
                                   Convert.ToInt32(row["impactDays"].ToString()),
                                   Convert.ToInt32(row["respStrat"].ToString()),
                                   Convert.ToInt32(row["riskActionOwner"].ToString()),
                                   Convert.ToInt32(row["BU"].ToString()),
                                   Convert.ToInt32(row["IDncc"].ToString()),
                                   Convert.ToInt32(row["OriginatingID"].ToString()),
                                   Convert.ToBoolean(row["timeObjective"].ToString()),
                                   Convert.ToBoolean(row["costObjective"].ToString()),
                                   Convert.ToBoolean(row["costSatisfObjective"].ToString()),
                                   Convert.ToBoolean(row["safetyfObjective"].ToString()),
                                   Convert.ToBoolean(row["qualityObjective"].ToString()),
                                   Convert.ToBoolean(row["newChanges"].ToString()),
                                   Convert.ToInt32(row["P"].ToString()),
                                   Convert.ToInt32(row["Pafter"].ToString()),
                                   Convert.ToInt32(row["monetAfterTxt"].ToString()),
                                   Convert.ToInt32(row["costEstimRespPlan"].ToString()),
                                   Convert.ToDateTime(row["respPlanDate"].ToString()),
                                   Convert.ToDateTime(row["startDate"].ToString()),
                                   Convert.ToDateTime(row["endDate"].ToString())   
                                );
                    itemsList.add(projImpactItem);
                }
                return itemsList;
            }
            //ENTERPRISE RISKS
            else if (type.ToLower() == "enterpriserisk")
            {
                connection.Open();
                string SQL = "SELECT * FROM [rk_EnterpriseRisk]";

                dataAdapterEEnterpriseRisk = new SqlDataAdapter(SQL, connection);
                dataSourceEEnterpriseRisk = new DataTable();
                dataAdapterEEnterpriseRisk.Fill(dataSourceEEnterpriseRisk);
                EProjectItem enterpriseRiskItem;
                EProjectItemList itemsList = new EProjectItemList();

                foreach (DataRow row in dataSourceEEnterpriseRisk.Rows)
                {
                    enterpriseRiskItem = new EEntRisk(
                                   Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())),
                                   row["ExcelID"].ToString(),
                                   row["Name"].ToString(),
                                   row["ItemDescription"].ToString(),
                                   Convert.ToInt32(row["Status"].ToString()),
                                   Convert.ToInt32(row["CustomerShareID"].ToString()),
                                   Convert.ToBoolean(row["removedItem"].ToString()),
                                   Convert.ToBoolean(row["watchlist"].ToString()),
                                   Convert.ToDateTime(row["CreateDate"].ToString()),
                                   Convert.ToDateTime(row["UpdateDate"].ToString()),
                                   row["Actions"].ToString(),
                                   row["OtherComment"].ToString(),
                                   Convert.ToInt32(row["CategoryID"].ToString()),
                                   Convert.ToInt32(row["ItemOwnerID"].ToString()),
                                   Convert.ToInt32(row["ImpactID"].ToString()),
                                   Convert.ToInt32(row["ManageabilityID"].ToString()),
                                   Convert.ToInt32(row["PredictabilityID"].ToString()),
                                   Convert.ToInt32(row["ActionsOwner"].ToString()),
                                   Convert.ToDateTime(row["MitiActionsDate"].ToString())
                                );
                    itemsList.add(enterpriseRiskItem);
                }
                return itemsList;
            }
            //OTHER UNCERTAINTIES
            else if (type.ToLower() == "otheruncertainty")
            {
                connection.Open();
                string SQL = "SELECT * FROM [rk_OtherUncertainties]";

                dataAdapterEOtherUncertainties = new SqlDataAdapter(SQL, connection);
                dataSourceEOtherUncertainties = new DataTable();
                dataAdapterEOtherUncertainties.Fill(dataSourceEOtherUncertainties);
                EProjectItem otherUncertaintyItem;
                EProjectItemList itemsList = new EProjectItemList();

                foreach (DataRow row in dataSourceEOtherUncertainties.Rows)
                {
                    otherUncertaintyItem = new EUncertainty(
                                   Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())),
                                   row["ExcelID"].ToString(),
                                   row["Name"].ToString(),
                                   row["ItemDescription"].ToString(),
                                   Convert.ToInt32(row["Status"].ToString()),
                                   Convert.ToInt32(row["CustomerShareID"].ToString()),
                                   Convert.ToBoolean(row["removedItem"].ToString()),
                                   Convert.ToBoolean(row["watchlist"].ToString()),
                                   Convert.ToDateTime(row["CreateDate"].ToString()),
                                   Convert.ToDateTime(row["UpdateDate"].ToString()),
                                   row["Actions"].ToString(),
                                   row["OtherComment"].ToString(),
                                   Convert.ToInt32(row["CategoryID"].ToString()),
                                   Convert.ToInt32(row["ItemOwnerID"].ToString()),
                                   Convert.ToInt32(row["ImpactID"].ToString()),
                                   Convert.ToInt32(row["ManageabilityID"].ToString()),
                                   Convert.ToInt32(row["PredictabilityID"].ToString()),
                                   Convert.ToInt32(row["ActionsOwner"].ToString()),
                                   Convert.ToDateTime(row["MitiActionsDate"].ToString())
                                );
                    itemsList.add(otherUncertaintyItem);
                }
                return itemsList;
            }
            else
            {

                EProjectItemList itemsList = new EProjectItemList();
                return itemsList;
            }  
        }

        public Project getProject(int projectID)
        {
            throw new NotImplementedException();
        }

        public EProjectItemList getRemovedItems(int projectID, string month, string type)
        {
            //RISKS
            if (type.ToLower() == "risk")
            {
                connection.Open();
                string SQL = "SELECT * FROM rk_ROlog WHERE removeditem = 1";

                dataAdapterERisk = new SqlDataAdapter(SQL, connection);
                dataSourceERisk = new DataTable();
                dataAdapterERisk.Fill(dataSourceERisk);
                EProjectItem riskItem;
                EProjectItemList itemsList = new EProjectItemList();
                foreach (DataRow row in dataSourceERisk.Rows)
                {
                    riskItem = new ERisk(
                                   Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())),
                                   row["ExcelID"].ToString(),
                                   row["Rname"].ToString(),
                                   row["RootCause"].ToString(),
                                   row["OtherRootCause"].ToString(),
                                   row["MitDesc"].ToString(),
                                   row["rkDesc"].ToString(),
                                   row["ImpactDirect"].ToString(),
                                   row["formula"].ToString(),
                                   row["forDesc"].ToString(),
                                   row["Impact"].ToString(),
                                   row["calcDescAfter"].ToString(),
                                   row["remarks"].ToString(),
                                   Convert.ToInt32(row["Status"].ToString()),
                                   Convert.ToInt32(row["ID_customerShare"].ToString()),
                                   Convert.ToInt32(row["IDcat"].ToString()),
                                   Convert.ToDouble(row["P"].ToString()),
                                   Convert.ToInt32(row["reStrategy"].ToString()),
                                   Convert.ToInt32(row["ID_riskActionOwner"].ToString()),
                                   Convert.ToDouble(row["pAfter"].ToString()),
                                   Convert.ToInt32(row["IDowner"].ToString()),
                                   Convert.ToInt32(row["ID_Phase"].ToString()),
                                   Convert.ToInt32(row["ID_WBS"].ToString()),
                                   Convert.ToInt32(row["ExpValueDays"].ToString()),
                                   Convert.ToInt32(row["ID_resp"].ToString()),
                                   Convert.ToInt32(row["IDOwnerDirect"].ToString()),
                                   Convert.ToInt32(row["expValueDaysAfter"].ToString()),
                                   Convert.ToInt32(row["BU"].ToString()),
                                   Convert.ToInt32(row["IDncc"].ToString()),
                                   Convert.ToInt32(row["OriginatingID"].ToString()),
                                   Convert.ToBoolean(row["RemovedItem"].ToString()),
                                   Convert.ToBoolean(row["Watchlist"].ToString()),
                                   Convert.ToBoolean(row["newChanges"].ToString()),
                                   Convert.ToBoolean(row["timeObjective"].ToString()),
                                   Convert.ToBoolean(row["costObjective"].ToString()),
                                   Convert.ToBoolean(row["costSatisfObjective"].ToString()),
                                   Convert.ToBoolean(row["safetyfObjective"].ToString()),
                                   Convert.ToBoolean(row["qualityObjective"].ToString()),
                                   Convert.ToDouble(row["MitCost"].ToString()),
                                   Convert.ToDouble(row["CostMitiImpact"].ToString()),
                                   Convert.ToDouble(row["rkBef"].ToString()),
                                   Convert.ToDouble(row["valAfterMiti"].ToString()),
                                   Convert.ToDateTime(row["creationdate"].ToString()),
                                   Convert.ToDateTime(row["updateDate"].ToString()),
                                   Convert.ToDateTime(row["mitDate"].ToString()),
                                   Convert.ToDateTime(row["mitiActDate"].ToString()),
                                   Convert.ToDateTime(row["DueDate"].ToString()),
                                   Convert.ToDateTime(row["ImpEndDate"].ToString())
                                   );
                    itemsList.add(riskItem);

                }
                return itemsList;
            }
            //OPPORTUNITIES
            else if (type.ToLower() == "opportunity")
            {
                connection.Open();
                string SQL = "SELECT * FROM rk_Opportunities WHERE removeditem = 1";

                dataAdapterEOpportunity = new SqlDataAdapter(SQL, connection);
                dataSourceEOpportunity = new DataTable();
                dataAdapterEOpportunity.Fill(dataSourceEOpportunity);
                EProjectItem opportunityItem;
                EProjectItemList itemsList = new EProjectItemList();

                foreach (DataRow row in dataSourceEOpportunity.Rows)
                {
                    opportunityItem = new EOpportunity(
                                   Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())),
                                   row["ExcelID"].ToString(),
                                   row["Name"].ToString(),
                                   row["oppDescription"].ToString(),
                                   Convert.ToInt32(row["Status"].ToString()),
                                   Convert.ToInt32(row["customerShareID"].ToString()),
                                   Convert.ToBoolean(row["removedItem"].ToString()),
                                   Convert.ToBoolean(row["watchlist"].ToString()),
                                   Convert.ToDateTime(row["creationdate"].ToString()),
                                   Convert.ToDateTime(row["updatedate"].ToString()),
                                   row["impactDescription"].ToString(),
                                   row["formula"].ToString(),
                                   row["formDesc"].ToString(),
                                   row["actions"].ToString(),
                                   row["Remarks"].ToString(),
                                   Convert.ToInt32(row["rootCauseCat"].ToString()),
                                   Convert.ToInt32(row["oppOwnerID"].ToString()),
                                   Convert.ToInt32(row["phaseID"].ToString()),
                                   Convert.ToInt32(row["responseID"].ToString()),
                                   Convert.ToInt32(row["oppActionOwnerID"].ToString()),
                                   Convert.ToInt32(row["DICatID"].ToString()),
                                   Convert.ToInt32(row["BU"].ToString()),
                                   Convert.ToBoolean(row["newChanges"].ToString()),
                                   Convert.ToDouble(row["costEstimateResponse"].ToString()),
                                   Convert.ToDouble(row["P"].ToString()),
                                   Convert.ToDouble(row["Pafter"].ToString()),
                                   Convert.ToDouble(row["monetValueAfter"].ToString()),
                                   Convert.ToDateTime(row["dateResponse"].ToString()),
                                   Convert.ToDateTime(row["startDate"].ToString()),
                                   Convert.ToDateTime(row["endDate"].ToString())
                                   );
                    itemsList.add(opportunityItem);
                }
                return itemsList;
            }
            //PROJECT IMPACTS
            else if (type.ToLower() == "projectimpact")
            {
                connection.Open();
                string SQL = "SELECT * FROM rk_ProjectImpacts WHERE removeditem = 1";

                dataAdapterEProjectImpact = new SqlDataAdapter(SQL, connection);
                dataSourceEProjectImpact = new DataTable();
                dataAdapterEProjectImpact.Fill(dataSourceEProjectImpact);
                EProjectItem projImpactItem;
                EProjectItemList itemsList = new EProjectItemList();

                foreach (DataRow row in dataSourceEProjectImpact.Rows)
                {
                    projImpactItem = new EProjImpact(
                                   Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())),
                                   row["ExcelID"].ToString(),
                                   row["Name"].ToString(),
                                   row["impactDescription"].ToString(),
                                   Convert.ToInt32(row["status"].ToString()),
                                   Convert.ToInt32(row["ID_customerShare"].ToString()),
                                   Convert.ToBoolean(row["removeItem"].ToString()),
                                   Convert.ToBoolean(row["watchlist"].ToString()),
                                   Convert.ToDateTime(row["createdItem"].ToString()),
                                   Convert.ToDateTime(row["updatedate"].ToString()),
                                   row["Actions"].ToString(),
                                   row["Remarks"].ToString(),
                                   Convert.ToInt32(row["impactOwner"].ToString()),
                                   Convert.ToInt32(row["impactDays"].ToString()),
                                   Convert.ToInt32(row["respStrat"].ToString()),
                                   Convert.ToInt32(row["riskActionOwner"].ToString()),
                                   Convert.ToInt32(row["BU"].ToString()),
                                   Convert.ToInt32(row["IDncc"].ToString()),
                                   Convert.ToInt32(row["OriginatingID"].ToString()),
                                   Convert.ToBoolean(row["timeObjective"].ToString()),
                                   Convert.ToBoolean(row["costObjective"].ToString()),
                                   Convert.ToBoolean(row["costSatisfObjective"].ToString()),
                                   Convert.ToBoolean(row["safetyfObjective"].ToString()),
                                   Convert.ToBoolean(row["qualityObjective"].ToString()),
                                   Convert.ToBoolean(row["newChanges"].ToString()),
                                   Convert.ToInt32(row["P"].ToString()),
                                   Convert.ToInt32(row["Pafter"].ToString()),
                                   Convert.ToInt32(row["monetAfterTxt"].ToString()),
                                   Convert.ToInt32(row["costEstimRespPlan"].ToString()),
                                   Convert.ToDateTime(row["respPlanDate"].ToString()),
                                   Convert.ToDateTime(row["startDate"].ToString()),
                                   Convert.ToDateTime(row["endDate"].ToString())
                                );
                    itemsList.add(projImpactItem);
                }
                return itemsList;
            }
            //ENTERPRISE RISKS
            else if (type.ToLower() == "enterpriserisk")
            {
                connection.Open();
                string SQL = "SELECT * FROM [rk_EnterpriseRisk] WHERE removeditem = 1";

                dataAdapterEEnterpriseRisk = new SqlDataAdapter(SQL, connection);
                dataSourceEEnterpriseRisk = new DataTable();
                dataAdapterEEnterpriseRisk.Fill(dataSourceEEnterpriseRisk);
                EProjectItem enterpriseRiskItem;
                EProjectItemList itemsList = new EProjectItemList();

                foreach (DataRow row in dataSourceEEnterpriseRisk.Rows)
                {
                    enterpriseRiskItem = new EEntRisk(
                                   Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())),
                                   row["ExcelID"].ToString(),
                                   row["Name"].ToString(),
                                   row["ItemDescription"].ToString(),
                                   Convert.ToInt32(row["Status"].ToString()),
                                   Convert.ToInt32(row["CustomerShareID"].ToString()),
                                   Convert.ToBoolean(row["removedItem"].ToString()),
                                   Convert.ToBoolean(row["watchlist"].ToString()),
                                   Convert.ToDateTime(row["CreateDate"].ToString()),
                                   Convert.ToDateTime(row["UpdateDate"].ToString()),
                                   row["Actions"].ToString(),
                                   row["OtherComment"].ToString(),
                                   Convert.ToInt32(row["CategoryID"].ToString()),
                                   Convert.ToInt32(row["ItemOwnerID"].ToString()),
                                   Convert.ToInt32(row["ImpactID"].ToString()),
                                   Convert.ToInt32(row["ManageabilityID"].ToString()),
                                   Convert.ToInt32(row["PredictabilityID"].ToString()),
                                   Convert.ToInt32(row["ActionsOwner"].ToString()),
                                   Convert.ToDateTime(row["MitiActionsDate"].ToString())
                                );
                    itemsList.add(enterpriseRiskItem);
                }
                return itemsList;
            }
            //OTHER UNCERTAINTIES
            else if (type.ToLower() == "otheruncertainty")
            {
                connection.Open();
                string SQL = "SELECT * FROM [rk_OtherUncertainties] WHERE removeditem = 1";

                dataAdapterEOtherUncertainties = new SqlDataAdapter(SQL, connection);
                dataSourceEOtherUncertainties = new DataTable();
                dataAdapterEOtherUncertainties.Fill(dataSourceEOtherUncertainties);
                EProjectItem otherUncertaintyItem;
                EProjectItemList itemsList = new EProjectItemList();

                foreach (DataRow row in dataSourceEOtherUncertainties.Rows)
                {
                    otherUncertaintyItem = new EUncertainty(
                                   Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())),
                                   row["ExcelID"].ToString(),
                                   row["Name"].ToString(),
                                   row["ItemDescription"].ToString(),
                                   Convert.ToInt32(row["Status"].ToString()),
                                   Convert.ToInt32(row["CustomerShareID"].ToString()),
                                   Convert.ToBoolean(row["removedItem"].ToString()),
                                   Convert.ToBoolean(row["watchlist"].ToString()),
                                   Convert.ToDateTime(row["CreateDate"].ToString()),
                                   Convert.ToDateTime(row["UpdateDate"].ToString()),
                                   row["Actions"].ToString(),
                                   row["OtherComment"].ToString(),
                                   Convert.ToInt32(row["CategoryID"].ToString()),
                                   Convert.ToInt32(row["ItemOwnerID"].ToString()),
                                   Convert.ToInt32(row["ImpactID"].ToString()),
                                   Convert.ToInt32(row["ManageabilityID"].ToString()),
                                   Convert.ToInt32(row["PredictabilityID"].ToString()),
                                   Convert.ToInt32(row["ActionsOwner"].ToString()),
                                   Convert.ToDateTime(row["MitiActionsDate"].ToString())
                                );
                    itemsList.add(otherUncertaintyItem);
                }
                return itemsList;
            }
            else
            {

                EProjectItemList itemsList = new EProjectItemList();
                return itemsList;
            }
        }

        public EProjectItemList getWatchlistItems(int projectID, string month, string type)
        {
            //RISKS
            if (type.ToLower() == "risk")
            {
                connection.Open();
                string SQL = "SELECT * FROM rk_ROlog WHERE watchlist = 1";

                dataAdapterERisk = new SqlDataAdapter(SQL, connection);
                dataSourceERisk = new DataTable();
                dataAdapterERisk.Fill(dataSourceERisk);
                EProjectItem riskItem;
                EProjectItemList itemsList = new EProjectItemList();
                foreach (DataRow row in dataSourceERisk.Rows)
                {
                    riskItem = new ERisk(
                                   Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())),
                                   row["ExcelID"].ToString(),
                                   row["Rname"].ToString(),
                                   row["RootCause"].ToString(),
                                   row["OtherRootCause"].ToString(),
                                   row["MitDesc"].ToString(),
                                   row["rkDesc"].ToString(),
                                   row["ImpactDirect"].ToString(),
                                   row["formula"].ToString(),
                                   row["forDesc"].ToString(),
                                   row["Impact"].ToString(),
                                   row["calcDescAfter"].ToString(),
                                   row["remarks"].ToString(),
                                   Convert.ToInt32(row["Status"].ToString()),
                                   Convert.ToInt32(row["ID_customerShare"].ToString()),
                                   Convert.ToInt32(row["IDcat"].ToString()),
                                   Convert.ToDouble(row["P"].ToString()),
                                   Convert.ToInt32(row["reStrategy"].ToString()),
                                   Convert.ToInt32(row["ID_riskActionOwner"].ToString()),
                                   Convert.ToDouble(row["pAfter"].ToString()),
                                   Convert.ToInt32(row["IDowner"].ToString()),
                                   Convert.ToInt32(row["ID_Phase"].ToString()),
                                   Convert.ToInt32(row["ID_WBS"].ToString()),
                                   Convert.ToInt32(row["ExpValueDays"].ToString()),
                                   Convert.ToInt32(row["ID_resp"].ToString()),
                                   Convert.ToInt32(row["IDOwnerDirect"].ToString()),
                                   Convert.ToInt32(row["expValueDaysAfter"].ToString()),
                                   Convert.ToInt32(row["BU"].ToString()),
                                   Convert.ToInt32(row["IDncc"].ToString()),
                                   Convert.ToInt32(row["OriginatingID"].ToString()),
                                   Convert.ToBoolean(row["RemovedItem"].ToString()),
                                   Convert.ToBoolean(row["Watchlist"].ToString()),
                                   Convert.ToBoolean(row["newChanges"].ToString()),
                                   Convert.ToBoolean(row["timeObjective"].ToString()),
                                   Convert.ToBoolean(row["costObjective"].ToString()),
                                   Convert.ToBoolean(row["costSatisfObjective"].ToString()),
                                   Convert.ToBoolean(row["safetyfObjective"].ToString()),
                                   Convert.ToBoolean(row["qualityObjective"].ToString()),
                                   Convert.ToDouble(row["MitCost"].ToString()),
                                   Convert.ToDouble(row["CostMitiImpact"].ToString()),
                                   Convert.ToDouble(row["rkBef"].ToString()),
                                   Convert.ToDouble(row["valAfterMiti"].ToString()),
                                   Convert.ToDateTime(row["creationdate"].ToString()),
                                   Convert.ToDateTime(row["updateDate"].ToString()),
                                   Convert.ToDateTime(row["mitDate"].ToString()),
                                   Convert.ToDateTime(row["mitiActDate"].ToString()),
                                   Convert.ToDateTime(row["DueDate"].ToString()),
                                   Convert.ToDateTime(row["ImpEndDate"].ToString())
                                   );
                    itemsList.add(riskItem);

                }
                return itemsList;
            }
            //OPPORTUNITIES
            else if (type.ToLower() == "opportunity")
            {
                connection.Open();
                string SQL = "SELECT * FROM rk_Opportunities WHERE watchlist = 1";

                dataAdapterEOpportunity = new SqlDataAdapter(SQL, connection);
                dataSourceEOpportunity = new DataTable();
                dataAdapterEOpportunity.Fill(dataSourceEOpportunity);
                EProjectItem opportunityItem;
                EProjectItemList itemsList = new EProjectItemList();

                foreach (DataRow row in dataSourceEOpportunity.Rows)
                {
                    opportunityItem = new EOpportunity(
                                   Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())),
                                   row["ExcelID"].ToString(),
                                   row["Name"].ToString(),
                                   row["oppDescription"].ToString(),
                                   Convert.ToInt32(row["Status"].ToString()),
                                   Convert.ToInt32(row["customerShareID"].ToString()),
                                   Convert.ToBoolean(row["removedItem"].ToString()),
                                   Convert.ToBoolean(row["watchlist"].ToString()),
                                   Convert.ToDateTime(row["creationdate"].ToString()),
                                   Convert.ToDateTime(row["updatedate"].ToString()),
                                   row["impactDescription"].ToString(),
                                   row["formula"].ToString(),
                                   row["formDesc"].ToString(),
                                   row["actions"].ToString(),
                                   row["Remarks"].ToString(),
                                   Convert.ToInt32(row["rootCauseCat"].ToString()),
                                   Convert.ToInt32(row["oppOwnerID"].ToString()),
                                   Convert.ToInt32(row["phaseID"].ToString()),
                                   Convert.ToInt32(row["responseID"].ToString()),
                                   Convert.ToInt32(row["oppActionOwnerID"].ToString()),
                                   Convert.ToInt32(row["DICatID"].ToString()),
                                   Convert.ToInt32(row["BU"].ToString()),
                                   Convert.ToBoolean(row["newChanges"].ToString()),
                                   Convert.ToDouble(row["costEstimateResponse"].ToString()),
                                   Convert.ToDouble(row["P"].ToString()),
                                   Convert.ToDouble(row["Pafter"].ToString()),
                                   Convert.ToDouble(row["monetValueAfter"].ToString()),
                                   Convert.ToDateTime(row["dateResponse"].ToString()),
                                   Convert.ToDateTime(row["startDate"].ToString()),
                                   Convert.ToDateTime(row["endDate"].ToString())
                                   );
                    itemsList.add(opportunityItem);
                }
                return itemsList;
            }
            //PROJECT IMPACTS
            else if (type.ToLower() == "projectimpact")
            {
                connection.Open();
                string SQL = "SELECT * FROM rk_ProjectImpacts WHERE watchlist = 1";

                dataAdapterEProjectImpact = new SqlDataAdapter(SQL, connection);
                dataSourceEProjectImpact = new DataTable();
                dataAdapterEProjectImpact.Fill(dataSourceEProjectImpact);
                EProjectItem projImpactItem;
                EProjectItemList itemsList = new EProjectItemList();

                foreach (DataRow row in dataSourceEProjectImpact.Rows)
                {
                    projImpactItem = new EProjImpact(
                                   Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())),
                                   row["ExcelID"].ToString(),
                                   row["Name"].ToString(),
                                   row["impactDescription"].ToString(),
                                   Convert.ToInt32(row["status"].ToString()),
                                   Convert.ToInt32(row["ID_customerShare"].ToString()),
                                   Convert.ToBoolean(row["removeItem"].ToString()),
                                   Convert.ToBoolean(row["watchlist"].ToString()),
                                   Convert.ToDateTime(row["createdItem"].ToString()),
                                   Convert.ToDateTime(row["updatedate"].ToString()),
                                   row["Actions"].ToString(),
                                   row["Remarks"].ToString(),
                                   Convert.ToInt32(row["impactOwner"].ToString()),
                                   Convert.ToInt32(row["impactDays"].ToString()),
                                   Convert.ToInt32(row["respStrat"].ToString()),
                                   Convert.ToInt32(row["riskActionOwner"].ToString()),
                                   Convert.ToInt32(row["BU"].ToString()),
                                   Convert.ToInt32(row["IDncc"].ToString()),
                                   Convert.ToInt32(row["OriginatingID"].ToString()),
                                   Convert.ToBoolean(row["timeObjective"].ToString()),
                                   Convert.ToBoolean(row["costObjective"].ToString()),
                                   Convert.ToBoolean(row["costSatisfObjective"].ToString()),
                                   Convert.ToBoolean(row["safetyfObjective"].ToString()),
                                   Convert.ToBoolean(row["qualityObjective"].ToString()),
                                   Convert.ToBoolean(row["newChanges"].ToString()),
                                   Convert.ToInt32(row["P"].ToString()),
                                   Convert.ToInt32(row["Pafter"].ToString()),
                                   Convert.ToInt32(row["monetAfterTxt"].ToString()),
                                   Convert.ToInt32(row["costEstimRespPlan"].ToString()),
                                   Convert.ToDateTime(row["respPlanDate"].ToString()),
                                   Convert.ToDateTime(row["startDate"].ToString()),
                                   Convert.ToDateTime(row["endDate"].ToString())
                                );
                    itemsList.add(projImpactItem);
                }
                return itemsList;
            }
            //ENTERPRISE RISKS
            else if (type.ToLower() == "enterpriserisk")
            {
                connection.Open();
                string SQL = "SELECT * FROM [rk_EnterpriseRisk] WHERE watchlist = 1";

                dataAdapterEEnterpriseRisk = new SqlDataAdapter(SQL, connection);
                dataSourceEEnterpriseRisk = new DataTable();
                dataAdapterEEnterpriseRisk.Fill(dataSourceEEnterpriseRisk);
                EProjectItem enterpriseRiskItem;
                EProjectItemList itemsList = new EProjectItemList();

                foreach (DataRow row in dataSourceEEnterpriseRisk.Rows)
                {
                    enterpriseRiskItem = new EEntRisk(
                                   Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())),
                                   row["ExcelID"].ToString(),
                                   row["Name"].ToString(),
                                   row["ItemDescription"].ToString(),
                                   Convert.ToInt32(row["Status"].ToString()),
                                   Convert.ToInt32(row["CustomerShareID"].ToString()),
                                   Convert.ToBoolean(row["removedItem"].ToString()),
                                   Convert.ToBoolean(row["watchlist"].ToString()),
                                   Convert.ToDateTime(row["CreateDate"].ToString()),
                                   Convert.ToDateTime(row["UpdateDate"].ToString()),
                                   row["Actions"].ToString(),
                                   row["OtherComment"].ToString(),
                                   Convert.ToInt32(row["CategoryID"].ToString()),
                                   Convert.ToInt32(row["ItemOwnerID"].ToString()),
                                   Convert.ToInt32(row["ImpactID"].ToString()),
                                   Convert.ToInt32(row["ManageabilityID"].ToString()),
                                   Convert.ToInt32(row["PredictabilityID"].ToString()),
                                   Convert.ToInt32(row["ActionsOwner"].ToString()),
                                   Convert.ToDateTime(row["MitiActionsDate"].ToString())
                                );
                    itemsList.add(enterpriseRiskItem);
                }
                return itemsList;
            }
            //OTHER UNCERTAINTIES
            else if (type.ToLower() == "otheruncertainty")
            {
                connection.Open();
                string SQL = "SELECT * FROM [rk_OtherUncertainties] WHERE watchlist = 1";

                dataAdapterEOtherUncertainties = new SqlDataAdapter(SQL, connection);
                dataSourceEOtherUncertainties = new DataTable();
                dataAdapterEOtherUncertainties.Fill(dataSourceEOtherUncertainties);
                EProjectItem otherUncertaintyItem;
                EProjectItemList itemsList = new EProjectItemList();

                foreach (DataRow row in dataSourceEOtherUncertainties.Rows)
                {
                    otherUncertaintyItem = new EUncertainty(
                                   Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())),
                                   row["ExcelID"].ToString(),
                                   row["Name"].ToString(),
                                   row["ItemDescription"].ToString(),
                                   Convert.ToInt32(row["Status"].ToString()),
                                   Convert.ToInt32(row["CustomerShareID"].ToString()),
                                   Convert.ToBoolean(row["removedItem"].ToString()),
                                   Convert.ToBoolean(row["watchlist"].ToString()),
                                   Convert.ToDateTime(row["CreateDate"].ToString()),
                                   Convert.ToDateTime(row["UpdateDate"].ToString()),
                                   row["Actions"].ToString(),
                                   row["OtherComment"].ToString(),
                                   Convert.ToInt32(row["CategoryID"].ToString()),
                                   Convert.ToInt32(row["ItemOwnerID"].ToString()),
                                   Convert.ToInt32(row["ImpactID"].ToString()),
                                   Convert.ToInt32(row["ManageabilityID"].ToString()),
                                   Convert.ToInt32(row["PredictabilityID"].ToString()),
                                   Convert.ToInt32(row["ActionsOwner"].ToString()),
                                   Convert.ToDateTime(row["MitiActionsDate"].ToString())
                                );
                    itemsList.add(otherUncertaintyItem);
                }
                return itemsList;
            }
            else
            {

                EProjectItemList itemsList = new EProjectItemList();
                return itemsList;
            }
        }

        public void updateChangedItem(EProjectItem item)
        {
            throw new NotImplementedException();
        }

        public void updateItem(EProjectItem item, bool projectOwner, String type)
        {
            // IF USER IS PROJECT OWNER
            if (projectOwner == true)
            {

                // RISKS PROJECT OWNER UPDATE ///////////////////////////////////////////////////////////////////////////////////
                if (type.ToLower() == "risk")
                { 
                    try
                    {
                        // Cast EprojectItem to ERisk
                        ERisk riskItem = (ERisk)item;

                        // Opening connection and executing Queries
                        using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))                     
                        {
                            connection.Open();
                            command = new SqlCommand("UPDATE [rk_ROlog] SET updatedBy = 1 WHERE ID = " + riskItem.itemID.ToString(), connection);
                            command.ExecuteNonQuery();

                            string queryString = "UPDATE [rk_ROlog] SET " +
                                              "   [calcDescAfter] = '" +            riskItem.monetaryValueAfterDesc.ToString() +
                                              "', [expValueDaysAfter] = " +         riskItem.daysImpactAfter.ToString() +
                                              " , [ID_WBS] =" +                     riskItem.wbsID.ToString() +
                                              " , [IDcat] =" +                      riskItem.categoryID.ToString() +
                                              " , [RootCause]= '" +                 riskItem.mainRootCause.ToString() +
                                              "', [OtherRootCause]= '" +            riskItem.otherRootCause.ToString() +
                                              "', [reStrategy]= " +                 riskItem.respStratRootCauseID.ToString() +
                                              " , [ID_riskActionOwner] = " +        riskItem.actionOwnerRootCauseID.ToString() +
                                              " , [P] =" +                          riskItem.percentageBefore.ToString() +
                                              " , [MitDesc] = '" +                  riskItem.actionsRootCause.ToString() +
                                              "', [Mitdate] = " +                   riskItem.ResponseRootCauseDate.ToString() +
                                              " , [Mitcost] = " +                   riskItem.costRootCause.ToString() +
                                              " , [Pafter] =" +                     riskItem.percentageAfter.ToString() +
                                              " , [IDowner] =" +                    riskItem.riskOwnerID.ToString() +
                                              " , [RkDesc] ='" +                    riskItem.itemDescription.ToString() +
                                              "', [Rname] ='" +                     riskItem.itemName.ToString() +
                                              "', [ID_customerShare] =" +           riskItem.customerShareID.ToString() +
                                              " , [ExcelID] = " +                   riskItem.excelID.ToString() +
                                              " , [Status]= " +                     riskItem.itemStatusID.ToString() +
                                              " , [IDOwnerDirect] = " +             riskItem.actionOwnerImpactID.ToString()  +
                                              " , [ValAfterMiti]= " +               riskItem.monetaryValueAfter.ToString()  +
                                              " , [ExpValueDays]= " +               riskItem.daysImpactBefore.ToString()  +
                                              " , [MitiActDate]= " +                riskItem.ResponseImpactDate.ToString() +
                                              " , [ImpEndDate]= " +                 riskItem.impactEndDate.ToString() +
                                              " , [CostMitiImpact]= " +             riskItem.costImpact.ToString() +
                                              " , [Impact]= '" +                    riskItem.actionsImpact.ToString() +
                                              "', [ImpactDirect]= '" +              riskItem.impactDesc.ToString()  +
                                              "', [ID_resp]= " +                    riskItem.respStratImpactID.ToString() +
                                              " , [ID_phase]= " +                   riskItem.phaseID.ToString() +
                                              " , [DueDate]= " +                    riskItem.impactStartDate.ToString() +
                                              " , [formula]= '" +                   riskItem.formulaBefore.ToString()  +
                                              "', [forDesc]= '" +                   riskItem.formulaBeforeDesc.ToString()  +
                                              "', [BU]= " +                         riskItem.buRate.ToString()  +
                                              " , [Rkbef]= " +                      riskItem.monetaryValueBefore.ToString() +
                                              " , [Remarks]= '" +                   riskItem.remarks.ToString() +
                                              "', [IDncc]= " +                      riskItem.nccID.ToString() +
                                              " , [OriginatingID]= " +              riskItem.orgUnitID.ToString() +
                                              " , [timeObjective]= " +              riskItem.timeObjective.ToString() +
                                              " , [costObjective]= " +              riskItem.costObjective.ToString() +
                                              " , [qualityObjective]= " +           riskItem.qualityObjective.ToString() +
                                              " , [safetyfObjective]= " +           riskItem.safetyObjective.ToString()  +
                                              " , [costSatisfObjective]= " +        riskItem.customerSatisfObjective.ToString() +
                                              "   WHERE ID =" +                     riskItem.itemID.ToString();
                            command = new SqlCommand(queryString, connection);
                            command.ExecuteNonQuery();


                            command = new SqlCommand("UPDATE [rk_ROlog] SET updatedBy = 0 WHERE ID = " + riskItem.itemID.ToString(), connection);
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wront. Error Message: " + ex.Message);
                    }
                }



                // OPPORTUNITY PROJECT OWNER UPDATE ///////////////////////////////////////////////////////////////////////////////////
                if (type.ToLower() == "opportunity")
                {
                    try
                    {
                        // Cast EprojectItem to EOpportunity
                        EOpportunity oppItem = (EOpportunity)item;

                        // Opening connection and executing Queries
                        using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                        {
                            connection.Open();
                            command = new SqlCommand("UPDATE [rk_Opportunities] SET [updatedBy] = 1 WHERE ID = " + oppItem.itemID.ToString(), connection);
                            command.ExecuteNonQuery();

                            //EVALUATING FORMULABEFORE
                            DataTable dt = new DataTable();
                            double monetValueBefore = (double)dt.Compute(oppItem.formulaBefore.ToString(), "");

                            string queryString = "UPDATE [rk_Opportunities] SET " +
                                             "   [ExcelID] =" +                     oppItem.excelID.ToString() +
                                             " , [ExcelCode] = ' OPP" +             oppItem.excelID.ToString() +
                                             "', [Status] =" +                      oppItem.itemStatusID.ToString() +
                                             " , [Name] ='" +                       oppItem.itemName.ToString() +
                                             "', [createdate] =" +                  oppItem.createDate.ToString() +
                                             " , [updatedate] =" +                  oppItem.updateDate.ToString() +
                                             " , [customerShareID] =" +             oppItem.customerShareID.ToString() +
                                             " , [oppDescription] ='" +             oppItem.itemDescription.ToString() +
                                             "', [impactDescription] ='" +          oppItem.oppImpact.ToString() +
                                             "', [rootCauseCat] =" +                oppItem.oppTypeID.ToString() +
                                             " , [oppOwnerID] =" +                  oppItem.riskOwnerID.ToString() +
                                             " , [P] =" +                           oppItem.percentageBefore.ToString() +
                                             " , [phaseID] =" +                     oppItem.phaseID.ToString() +
                                             " , [formula] ='" +                    oppItem.formulaBefore.ToString() +
                                             "', [formDesc] ='" +                   oppItem.formulaBeforeDesc.ToString() +
                                             "', [responseID] =" +                  oppItem.respStratID.ToString() +
                                             " , [oppActionOwnerID] =" +            oppItem.actionOwnerID.ToString() +
                                             " , [actions] ='" +                    oppItem.actions.ToString() +
                                             "', [costEstimateResponse] =" +        oppItem.oppCost.ToString() +
                                             " , [dateResponse] =" +                oppItem.responseDate.ToString() +
                                             " , [PAfter] =" +                      oppItem.percentageAfter.ToString() +
                                             " , [startDate] =" +                   oppItem.responseStartDate.ToString() +
                                             " , [endDate] =" +                     oppItem.responseEndDate.ToString() +
                                             " , [monetValueAfter] =" +             oppItem.monetaryValueAfter.ToString() +
                                             " , [expMonetValueAfter] =" +          (oppItem.monetaryValueAfter * oppItem.percentageAfter).ToString() + // CALCULATING EXPECTED MONATERY VALUE AFTER
                                             " , [BU] =" +                          oppItem.buRate.ToString() +
                                             " , [Remarks] ='" +                    oppItem.remarks.ToString() +
                                             "', [DICatID] =" +                     oppItem.diCatID.ToString() +
                                             " , [monetValueBef] =" +               monetValueBefore.ToString() +
                                             " , [expMonetValueBef] =" +            (monetValueBefore * oppItem.percentageAfter).ToString() + // CALCULATING EXPECTED MONATERY VALUE BEFORE
                                             "   WHERE ID = " +                     oppItem.itemID.ToString();
                            command = new SqlCommand(queryString, connection);
                            command.ExecuteNonQuery();

                            command = new SqlCommand("UPDATE [rk_ROlog] SET updatedBy = 0 WHERE ID = " + oppItem.itemID.ToString(), connection);
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wront. Error Message: " + ex.Message);
                    }
                }

                // PROJECT IMPACT PROJECT OWNER UPDATE ///////////////////////////////////////////////////////////////////////////////////
                if (type.ToLower() == "projectimpact")
                {
                    try
                    {
                        // Cast EprojectItem to EProjImpact
                        EProjImpact projImpactItem = (EProjImpact)item;

                        // Opening connection and executing Queries
                        using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                        {
                            connection.Open();
                            command = new SqlCommand("UPDATE rk_projectImpacts SET UpdatedBy = 1 WHERE ID = " + projImpactItem.itemID.ToString(), connection);
                            command.ExecuteNonQuery();

                            //EVALUATING FORMULABEFORE
                            DataTable dt = new DataTable();
                            double monetValueBefore = (double)dt.Compute(projImpactItem.formulaBefore.ToString(), "");

                            string queryString = "UPDATE rk_projectImpacts SET " +
                                         "       [status] =" +               projImpactItem.itemStatusID.ToString() +
                                         " ," + "[name] ='" +                projImpactItem.itemName.ToString() +
                                         "'," + "[ID_customerShare] =" +     projImpactItem.customerShareID.ToString() +
                                         " ," + "[impactDescription] ='" +   projImpactItem.projImpactDesc.ToString() +
                                         "'," + "[TimeObjective] =" +        projImpactItem.timeObjective.ToString() +
                                         " ," + "[costObjective] =" +        projImpactItem.costObjective.ToString() +
                                         " ," + "[qualityObjective] =" +     projImpactItem.qualityObjective.ToString() +
                                         " ," + "[costSatisfObjective] =" +  projImpactItem.customerSatisfObjective.ToString() +
                                         " ," + "[safetyfObjective] =" +     projImpactItem.safetyObjective.ToString() +
                                         " ," + "[impactOwner] =" +          projImpactItem.projImpactOwnerID.ToString() +
                                         " ," + "[P] =" +                    projImpactItem.percentageBefore.ToString() +
                                         " ," + "[impactDays] =" +           projImpactItem.daysImpactBefore.ToString() +
                                         " ," + "[formula] ='" +             projImpactItem.formulaBefore.ToString() +
                                         "'," + "[calcDesc] ='" +            projImpactItem.formulaBeforeDesc.ToString() +
                                         "'," + "[respStrat] =" +            projImpactItem.respStratImpactID.ToString() +
                                         " ," + "[riskActionOwner] =" +      projImpactItem.actionOwnerImpactID.ToString() +
                                         " ," + "[Actions] ='" +             projImpactItem.actions.ToString() +
                                         "'," + "[costEstimRespPlan] =" +    projImpactItem.projImpactCost.ToString() +
                                         " ," + "[respPlanDate] =" +         projImpactItem.ResponseDate.ToString() +
                                         " ," + "[Pafter] =" +               projImpactItem.percentageAfter.ToString() +
                                         " ," + "[startDate] =" +            projImpactItem.impactStartDate.ToString() +
                                         " ," + "[endDate] =" +              projImpactItem.impactEndDate.ToString() +
                                         " ," + "[IDncc] =" +                projImpactItem.nccID.ToString() +
                                         " ," + "[OriginatingID] =" +        projImpactItem.orgUnitID.ToString() +
                                         " ," + "[Remarks] ='" +             projImpactItem.remarks.ToString() +
                                         "'," + "[BU] =" +                   projImpactItem.buRate.ToString() +
                                         " ," + "[monetAfterTxt] =" +        projImpactItem.monetValueAfter.ToString() +
                                         " ," + "[monetBeforeTxt] =" +       monetValueBefore.ToString() +
                                         " WHERE ID= " +                     projImpactItem.itemID.ToString(); 
                            command = new SqlCommand(queryString, connection);
                            command.ExecuteNonQuery();

                            command = new SqlCommand("UPDATE rk_projectImpacts SET UpdatedBy = 0 WHERE ID = " + projImpactItem.itemID.ToString(), connection);
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wront. Error Message: " + ex.Message);
                    }
                }


                // ENTERPRISE RISK PROJECT OWNER UPDATE ///////////////////////////////////////////////////////////////////////////////////
                if (type.ToLower() == "enterpriserisk")
                {
                    try
                    {
                        // Cast EprojectItem to EProjImpact
                        EEntRisk entRiskItem = (EEntRisk)item;

                        // Opening connection and executing Queries
                        using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                        {
                            string queryString = "UPDATE rk_EnterpriseRisk SET" +
                                                 "[Status] = " + entRiskItem.itemStatusID.ToString() + 
                                          " ," + "[Name] = '" + entRiskItem.itemName.ToString() + 
                                          "'," + "[CustomerShareID] = " + entRiskItem.customerShareID.ToString() + 
                                          " ," + "[ItemDescription] ='"+ entRiskItem.itemDescription.ToString() + 
                                          "'," + "[CategoryID] =" + entRiskItem.categoryID.ToString() + 
                                          " ," + "[ItemOwnerID] =" + entRiskItem.itemOwnerID.ToString() +
                                          " ," + "[ImpactID] =" + entRiskItem.impactID.ToString() +
                                          " ," + "[ManageabilityID] =" + entRiskItem.manageabilityID.ToString() +
                                          " ," + "[PredictabilityID] =" + entRiskItem.predictabilityID.ToString() +
                                          " ," + "[Actions] ='" + entRiskItem.itemActions.ToString() +
                                          "'," + "[MitiActionsDate] ='" + entRiskItem.ResponseDate.ToString() +
                                          "'," + "[OtherComment] ='" + entRiskItem.otherComment.ToString() +
                                          "'," + "[CreateDate] ='" + entRiskItem.createDate.ToString() +
                                          "'," + "[UpdateDate] ='" + entRiskItem.updateDate.ToString() +
                                          "'," + "[ActionsOwner] =" + entRiskItem.actionOwnerID.ToString() +
                                          "WHERE  ID = " + entRiskItem.itemStatusID.ToString();
                            command = new SqlCommand(queryString, connection);
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wront. Error Message: " + ex.Message);
                    }
                }

                // ENTERPRISE RISK PROJECT OWNER UPDATE ///////////////////////////////////////////////////////////////////////////////////
                if (type.ToLower() == "otheruncertainty")
                {
                    try
                    {
                        // Cast EprojectItem to EProjImpact
                        EUncertainty uncertaintyItem = (EUncertainty)item;

                        // Opening connection and executing Queries
                        using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                        {
                            string queryString = "UPDATE rk_EnterpriseRisk SET" +
                                                 "[Status] = " + uncertaintyItem.itemStatusID.ToString() +
                                          " ," + "[Name] = '" + uncertaintyItem.itemName.ToString() +
                                          "'," + "[CustomerShareID] = " + uncertaintyItem.customerShareID.ToString() +
                                          " ," + "[ItemDescription] ='" + uncertaintyItem.itemDescription.ToString() +
                                          "'," + "[CategoryID] =" + uncertaintyItem.categoryID.ToString() +
                                          " ," + "[ItemOwnerID] =" + uncertaintyItem.itemOwnerID.ToString() +
                                          " ," + "[ImpactID] =" + uncertaintyItem.impactID.ToString() +
                                          " ," + "[ManageabilityID] =" + uncertaintyItem.manageabilityID.ToString() +
                                          " ," + "[PredictabilityID] =" + uncertaintyItem.predictabilityID.ToString() +
                                          " ," + "[Actions] ='" + uncertaintyItem.itemActions.ToString() +
                                          "'," + "[MitiActionsDate] ='" + uncertaintyItem.ResponseDate.ToString() +
                                          "'," + "[OtherComment] ='" + uncertaintyItem.otherComment.ToString() +
                                          "'," + "[CreateDate] ='" + uncertaintyItem.createDate.ToString() +
                                          "'," + "[UpdateDate] ='" + uncertaintyItem.updateDate.ToString() +
                                          "'," + "[ActionsOwner] =" + uncertaintyItem.actionOwnerID.ToString() +
                                          "WHERE  ID = " + uncertaintyItem.itemStatusID.ToString();
                            command = new SqlCommand(queryString, connection);
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wront. Error Message: " + ex.Message);
                    }
                }

                // IF USER IS NOT PROJECT OWNER ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else
            {
                    // RISKS NOT PROJECT OWNER UPDATE
                    if (type.ToLower() == "risk")
                    {
                        try
                        {
                            // CAST EprojectItem to ERisk
                            ERisk riskItem = (ERisk)item;

                            // Opening connection and executing Queries
                            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                            {
                                string queryString = "UPDATE [rk_ROlog] SET " +
                                                  "   [calcDescAfter] = '" + riskItem.monetaryValueAfterDesc.ToString() +
                                                  "', [expValueDaysAfter] = " + riskItem.daysImpactAfter.ToString() +
                                                  " , [ID_WBS] =" + riskItem.wbsID.ToString() +
                                                  " , [IDcat] =" + riskItem.categoryID.ToString() +
                                                  " , [RootCause]= '" + riskItem.mainRootCause.ToString() +
                                                  "', [OtherRootCause]= '" + riskItem.otherRootCause.ToString() +
                                                  "', [reStrategy]= " + riskItem.respStratRootCauseID.ToString() +
                                                  " , [ID_riskActionOwner] = " + riskItem.actionOwnerRootCauseID.ToString() +
                                                  " , [P] =" + riskItem.percentageBefore.ToString() +
                                                  " , [MitDesc] = '" + riskItem.actionsRootCause.ToString() +
                                                  "', [Mitdate] = " + riskItem.ResponseRootCauseDate.ToString() +
                                                  " , [Mitcost] = " + riskItem.costRootCause.ToString() +
                                                  " , [Pafter] =" + riskItem.percentageAfter.ToString() +
                                                  " , [IDowner] =" + riskItem.riskOwnerID.ToString() +
                                                  " , [RkDesc] ='" + riskItem.itemDescription.ToString() +
                                                  "', [Rname] ='" + riskItem.itemName.ToString() +
                                                  "', [ID_customerShare] =" + riskItem.customerShareID.ToString() +
                                                  " , [ExcelID] = " + riskItem.excelID.ToString() +
                                                  " , [Status]= " + riskItem.itemStatusID.ToString() +
                                                  " , [IDOwnerDirect] = " + riskItem.actionOwnerImpactID.ToString() +
                                                  " , [ValAfterMiti]= " + riskItem.monetaryValueAfter.ToString() +
                                                  " , [ExpValueDays]= " + riskItem.daysImpactBefore.ToString() +
                                                  " , [MitiActDate]= " + riskItem.ResponseImpactDate.ToString() +
                                                  " , [ImpEndDate]= " + riskItem.impactEndDate.ToString() +
                                                  " , [CostMitiImpact]= " + riskItem.costImpact.ToString() +
                                                  " , [Impact]= '" + riskItem.actionsImpact.ToString() +
                                                  "', [ImpactDirect]= '" + riskItem.impactDesc.ToString() +
                                                  "', [ID_resp]= " + riskItem.respStratImpactID.ToString() +
                                                  " , [ID_phase]= " + riskItem.phaseID.ToString() +
                                                  " , [DueDate]= " + riskItem.impactStartDate.ToString() +
                                                  " , [formula]= '" + riskItem.formulaBefore.ToString() +
                                                  "', [forDesc]= '" + riskItem.formulaBeforeDesc.ToString() +
                                                  "', [BU]= " + riskItem.buRate.ToString() +
                                                  " , [Rkbef]= " + riskItem.monetaryValueBefore.ToString() +
                                                  " , [Remarks]= '" + riskItem.remarks.ToString() +
                                                  "', [IDncc]= " + riskItem.nccID.ToString() +
                                                  " , [OriginatingID]= " + riskItem.orgUnitID.ToString() +
                                                  " , [timeObjective]= " + riskItem.timeObjective.ToString() +
                                                  " , [costObjective]= " + riskItem.costObjective.ToString() +
                                                  " , [qualityObjective]= " + riskItem.qualityObjective.ToString() +
                                                  " , [safetyfObjective]= " + riskItem.safetyObjective.ToString() +
                                                  " , [costSatisfObjective]= " + riskItem.customerSatisfObjective.ToString() +
                                                  "   WHERE ID =" + riskItem.itemID.ToString();
                                command = new SqlCommand(queryString + riskItem.itemID.ToString(), connection);
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Something went wront. Error Message: " + ex.Message);
                        }
                    }
                    // OPPORTUNITY PROJECT NOT OWNER UPDATE///////////////////////////////////////////////////////////////////////////////////
                    if (type.ToLower() == "opportunity")
                    {
                        try
                        {
                            // Cast EprojectItem to EOpportunity
                            EOpportunity oppItem = (EOpportunity)item;

                            // Opening connection and executing Queries
                            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                            {
                                connection.Open();

                                //EVALUATING FORMULABEFORE
                                DataTable dt = new DataTable();
                                double monetValueBefore = (double)dt.Compute(oppItem.formulaBefore.ToString(), "");

                                string queryString = "UPDATE [rk_Opportunities] SET " +
                                                 "   [ExcelID] =" + oppItem.excelID.ToString() +
                                                 " , [ExcelCode] = ' OPP" + oppItem.excelID.ToString() +
                                                 "', [Status] =" + oppItem.itemStatusID.ToString() +
                                                 " , [Name] ='" + oppItem.itemName.ToString() +
                                                 "', [createdate] =" + oppItem.createDate.ToString() +
                                                 " , [updatedate] =" + oppItem.updateDate.ToString() +
                                                 " , [customerShareID] =" + oppItem.customerShareID.ToString() +
                                                 " , [oppDescription] ='" + oppItem.itemDescription.ToString() +
                                                 "', [impactDescription] ='" + oppItem.oppImpact.ToString() +
                                                 "', [rootCauseCat] =" + oppItem.oppTypeID.ToString() +
                                                 " , [oppOwnerID] =" + oppItem.riskOwnerID.ToString() +
                                                 " , [P] =" + oppItem.percentageBefore.ToString() +
                                                 " , [phaseID] =" + oppItem.phaseID.ToString() +
                                                 " , [formula] ='" + oppItem.formulaBefore.ToString() +
                                                 "', [formDesc] ='" + oppItem.formulaBeforeDesc.ToString() +
                                                 "', [responseID] =" + oppItem.respStratID.ToString() +
                                                 " , [oppActionOwnerID] =" + oppItem.actionOwnerID.ToString() +
                                                 " , [actions] ='" + oppItem.actions.ToString() +
                                                 "', [costEstimateResponse] =" + oppItem.oppCost.ToString() +
                                                 " , [dateResponse] =" + oppItem.responseDate.ToString() +
                                                 " , [PAfter] =" + oppItem.percentageAfter.ToString() +
                                                 " , [startDate] =" + oppItem.responseStartDate.ToString() +
                                                 " , [endDate] =" + oppItem.responseEndDate.ToString() +
                                                 " , [monetValueAfter] =" + oppItem.monetaryValueAfter.ToString() +
                                                 " , [expMonetValueAfter] =" + (oppItem.monetaryValueAfter * oppItem.percentageAfter).ToString() + // CALCULATING EXPECTED MONATERY VALUE AFTER
                                                 " , [BU] =" + oppItem.buRate.ToString() +
                                                 " , [Remarks] ='" + oppItem.remarks.ToString() +
                                                 "', [DICatID] =" + oppItem.diCatID.ToString() +
                                                 " , [monetValueBef] =" + monetValueBefore.ToString() +
                                                 " , [expMonetValueBef] =" + (monetValueBefore * oppItem.percentageAfter).ToString() + // CALCULATING EXPECTED MONATERY VALUE BEFORE
                                                 "   WHERE ID = " + oppItem.itemID.ToString();
                                command = new SqlCommand(queryString, connection);
                                command.ExecuteNonQuery();

                                connection.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Something went wront. Error Message: " + ex.Message);
                        }
                    }

                    // PROJECT IMPACT NOT PROJECT OWNER UPDATE ///////////////////////////////////////////////////////////////////////////////////
                    if (type.ToLower() == "projectimpact")
                    {
                        try
                        {
                            // Cast EprojectItem to EProjImpact
                            EProjImpact projImpactItem = (EProjImpact)item;

                            // Opening connection and executing Queries
                            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                            {
                                connection.Open();

                                //EVALUATING FORMULABEFORE
                                DataTable dt = new DataTable();
                                double monetValueBefore = (double)dt.Compute(projImpactItem.formulaBefore.ToString(), "");

                                string queryString = "UPDATE rk_projectImpacts SET " +
                                             "       [status] =" + projImpactItem.itemStatusID.ToString() +
                                             " ," + "[name] ='" + projImpactItem.itemName.ToString() +
                                             "'," + "[ID_customerShare] =" + projImpactItem.customerShareID.ToString() +
                                             " ," + "[impactDescription] ='" + projImpactItem.projImpactDesc.ToString() +
                                             "'," + "[TimeObjective] =" + projImpactItem.timeObjective.ToString() +
                                             " ," + "[costObjective] =" + projImpactItem.costObjective.ToString() +
                                             " ," + "[qualityObjective] =" + projImpactItem.qualityObjective.ToString() +
                                             " ," + "[costSatisfObjective] =" + projImpactItem.customerSatisfObjective.ToString() +
                                             " ," + "[safetyfObjective] =" + projImpactItem.safetyObjective.ToString() +
                                             " ," + "[impactOwner] =" + projImpactItem.projImpactOwnerID.ToString() +
                                             " ," + "[P] =" + projImpactItem.percentageBefore.ToString() +
                                             " ," + "[impactDays] =" + projImpactItem.daysImpactBefore.ToString() +
                                             " ," + "[formula] ='" + projImpactItem.formulaBefore.ToString() +
                                             "'," + "[calcDesc] ='" + projImpactItem.formulaBeforeDesc.ToString() +
                                             "'," + "[respStrat] =" + projImpactItem.respStratImpactID.ToString() +
                                             " ," + "[riskActionOwner] =" + projImpactItem.actionOwnerImpactID.ToString() +
                                             " ," + "[Actions] ='" + projImpactItem.actions.ToString() +
                                             "'," + "[costEstimRespPlan] =" + projImpactItem.projImpactCost.ToString() +
                                             " ," + "[respPlanDate] =" + projImpactItem.ResponseDate.ToString() +
                                             " ," + "[Pafter] =" + projImpactItem.percentageAfter.ToString() +
                                             " ," + "[startDate] =" + projImpactItem.impactStartDate.ToString() +
                                             " ," + "[endDate] =" + projImpactItem.impactEndDate.ToString() +
                                             " ," + "[IDncc] =" + projImpactItem.nccID.ToString() +
                                             " ," + "[OriginatingID] =" + projImpactItem.orgUnitID.ToString() +
                                             " ," + "[Remarks] ='" + projImpactItem.remarks.ToString() +
                                             "'," + "[BU] =" + projImpactItem.buRate.ToString() +
                                             " ," + "[monetAfterTxt] =" + projImpactItem.monetValueAfter.ToString() +
                                             " ," + "[monetBeforeTxt] =" + monetValueBefore.ToString() +
                                             " WHERE ID= " + projImpactItem.itemID.ToString();
                                command = new SqlCommand(queryString, connection);
                                command.ExecuteNonQuery();

                                connection.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Something went wront. Error Message: " + ex.Message);
                        }
                    }


                    // ENTERPRISE RISK NOT PROJECT OWNER UPDATE ///////////////////////////////////////////////////////////////////////////////////
                    if (type.ToLower() == "enterpriserisk")
                    {
                        try
                        {
                            // Cast EprojectItem to EProjImpact
                            EEntRisk entRiskItem = (EEntRisk)item;

                            // Opening connection and executing Queries
                            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                            {
                                string queryString = "UPDATE rk_EnterpriseRisk SET" +
                                                     "[Status] = " + entRiskItem.itemStatusID.ToString() +
                                              " ," + "[Name] = '" + entRiskItem.itemName.ToString() +
                                              "'," + "[CustomerShareID] = " + entRiskItem.customerShareID.ToString() +
                                              " ," + "[ItemDescription] ='" + entRiskItem.itemDescription.ToString() +
                                              "'," + "[CategoryID] =" + entRiskItem.categoryID.ToString() +
                                              " ," + "[ItemOwnerID] =" + entRiskItem.itemOwnerID.ToString() +
                                              " ," + "[ImpactID] =" + entRiskItem.impactID.ToString() +
                                              " ," + "[ManageabilityID] =" + entRiskItem.manageabilityID.ToString() +
                                              " ," + "[PredictabilityID] =" + entRiskItem.predictabilityID.ToString() +
                                              " ," + "[Actions] ='" + entRiskItem.itemActions.ToString() +
                                              "'," + "[MitiActionsDate] ='" + entRiskItem.ResponseDate.ToString() +
                                              "'," + "[OtherComment] ='" + entRiskItem.otherComment.ToString() +
                                              "'," + "[CreateDate] ='" + entRiskItem.createDate.ToString() +
                                              "'," + "[UpdateDate] ='" + entRiskItem.updateDate.ToString() +
                                              "'," + "[ActionsOwner] =" + entRiskItem.actionOwnerID.ToString() +
                                              "WHERE  ID = " + entRiskItem.itemStatusID.ToString();
                                command = new SqlCommand(queryString, connection);
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Something went wront. Error Message: " + ex.Message);
                        }
                    }

                    // ENTERPRISE RISK NOT PROJECT OWNER UPDATE ///////////////////////////////////////////////////////////////////////////////////
                    if (type.ToLower() == "otheruncertainty")
                    {
                        try
                        {
                            // Cast EprojectItem to EProjImpact
                            EUncertainty uncertaintyItem = (EUncertainty)item;

                            // Opening connection and executing Queries
                            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                            {
                                string queryString = "UPDATE rk_EnterpriseRisk SET" +
                                                     "[Status] = " + uncertaintyItem.itemStatusID.ToString() +
                                              " ," + "[Name] = '" + uncertaintyItem.itemName.ToString() +
                                              "'," + "[CustomerShareID] = " + uncertaintyItem.customerShareID.ToString() +
                                              " ," + "[ItemDescription] ='" + uncertaintyItem.itemDescription.ToString() +
                                              "'," + "[CategoryID] =" + uncertaintyItem.categoryID.ToString() +
                                              " ," + "[ItemOwnerID] =" + uncertaintyItem.itemOwnerID.ToString() +
                                              " ," + "[ImpactID] =" + uncertaintyItem.impactID.ToString() +
                                              " ," + "[ManageabilityID] =" + uncertaintyItem.manageabilityID.ToString() +
                                              " ," + "[PredictabilityID] =" + uncertaintyItem.predictabilityID.ToString() +
                                              " ," + "[Actions] ='" + uncertaintyItem.itemActions.ToString() +
                                              "'," + "[MitiActionsDate] ='" + uncertaintyItem.ResponseDate.ToString() +
                                              "'," + "[OtherComment] ='" + uncertaintyItem.otherComment.ToString() +
                                              "'," + "[CreateDate] ='" + uncertaintyItem.createDate.ToString() +
                                              "'," + "[UpdateDate] ='" + uncertaintyItem.updateDate.ToString() +
                                              "'," + "[ActionsOwner] =" + uncertaintyItem.actionOwnerID.ToString() +
                                              "WHERE  ID = " + uncertaintyItem.itemStatusID.ToString();
                                command = new SqlCommand(queryString, connection);
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Something went wront. Error Message: " + ex.Message);
                        }
                    }

                }
            }
        }

        public void updateNewItem(EProjectItem item)
        {
            throw new NotImplementedException();
        }

        public void updateProject(Project project)
        {
            throw new NotImplementedException();
        }
    }
}