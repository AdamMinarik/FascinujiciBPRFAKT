using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                                   Convert.ToInt32(row["OppOwnerCombo"].ToString()),
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
            else if (type.ToLower() == "otheruncertainties")
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
                                   Convert.ToInt32(row["OppOwnerCombo"].ToString()),
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
            else if (type.ToLower() == "otheruncertainties")
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
                                   Convert.ToInt32(row["OppOwnerCombo"].ToString()),
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
            else if (type.ToLower() == "otheruncertainties")
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
                                   Convert.ToInt32(row["OppOwnerCombo"].ToString()),
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
            else if (type.ToLower() == "otheruncertainties")
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

        public void updateItem(EProjectItem item, bool projectOwner)
        {
            throw new NotImplementedException();
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
