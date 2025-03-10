﻿using System;
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
        //Project
        private DataTable dataSourceExecutionProject;
        private SqlDataAdapter dataAdapterExecutionProject;


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



        public void addItem(EProjectItem item, bool approval, String Type, int ProjectID, String userName)
        {
            //NOT A PROJECT OWNER
            if (approval == true)
            {
                //ADDING RISK
                if (Type == "risk")
                {
                    try
                    {
                        // Cast EprojectItem to ERisk
                        ERisk riskItem = (ERisk)item;

                        // Opening connection and executing Queries
                        using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                        {
                            connection.Open();
                            command = new SqlCommand("INSERT INTO [rk_NewRisk_Indiv] ([Rname],[IDproj],[IDchap],[itemtype],[addItemType],[UpdatedBy],[ExcelID],[REF_ID]) Values('" + riskItem.itemName.ToString() + "', " + ProjectID.ToString() + ", 1, 1, 'Individual Risk', 1," + riskItem.excelID.ToString() + ",1)", connection);
                            command.ExecuteNonQuery();

                            string queryString = "UPDATE [rk_NewRisk_Indiv] SET " +
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
                                              "', [Mitdate] = '" + riskItem.ResponseRootCauseDate.ToString("yyyy-MM-dd") +
                                              "', [Mitcost] = " + riskItem.costRootCause.ToString() +
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
                                              " , [MitiActDate]= '" + riskItem.ResponseImpactDate.ToString("yyyy-MM-dd") +
                                              "', [ImpEndDate]= '" + riskItem.impactEndDate.ToString("yyyy-MM-dd") +
                                              "', [CostMitiImpact]= " + riskItem.costImpact.ToString() +
                                              " , [Impact]= '" + riskItem.actionsImpact.ToString() +
                                              "', [ImpactDirect]= '" + riskItem.impactDesc.ToString() +
                                              "', [ID_resp]= " + riskItem.respStratImpactID.ToString() +
                                              " , [ID_phase]= " + riskItem.phaseID.ToString() +
                                              " , [DueDate]= '" + riskItem.impactStartDate.ToString("yyyy-MM-dd") +
                                              "', [formula]= '" + riskItem.formulaBefore.ToString() +
                                              "', [forDesc]= '" + riskItem.formulaBeforeDesc.ToString() +
                                              "', [BU]= " + riskItem.buRate.ToString() +
                                              " , [Rkbef]= " + riskItem.monetaryValueBefore.ToString() +
                                              " , [Remarks]= '" + riskItem.remarks.ToString() +
                                              "', [IDncc]= " + riskItem.nccID.ToString() +
                                              " , [OriginatingID]= " + riskItem.orgUnitID.ToString() +
                                              " , [timeObjective]= '" + riskItem.timeObjective.ToString() +
                                              "', [costObjective]= '" + riskItem.costObjective.ToString() +
                                              "', [qualityObjective]= '" + riskItem.qualityObjective.ToString() +
                                              "', [safetyfObjective]= '" + riskItem.safetyObjective.ToString() +
                                              "', [costSatisfObjective]= '" + riskItem.customerSatisfObjective.ToString() +
                                              "', [UserChan]= '" + userName +
                                              "'   WHERE ID = (SELECT MAX(ID) FROM [rk_NewRisk_Indiv] WHERE IDproj =" + ProjectID.ToString() + ")";
                            command = new SqlCommand(queryString, connection);
                            command.ExecuteNonQuery();


                            command = new SqlCommand("UPDATE [rk_NewRisk_Indiv] SET updatedBy = 0 WHERE ID = " + riskItem.itemID.ToString(), connection);
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wront, when trying to insert new risk. Error Message: " + ex.Message);
                    }
                }
            }
            //PROJECT OWNER
            else
            {
                //ADDING RISK
                if (Type == "risk")
                {
                    try
                    {
                        // Cast EprojectItem to ERisk
                        ERisk riskItem = (ERisk)item;

                        // Opening connection and executing Queries
                        using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                        {
                            connection.Open();
                            command = new SqlCommand("INSERT INTO[rk_ROlog]([Rname],[IDproj],[IDchap],[itemtype],[addItemType],[UpdatedBy],[ExcelID],[REF_ID]) Values('" + riskItem.itemName.ToString() + "', " + ProjectID.ToString() + ", 1, 1, 'Individual Risk', 1," + riskItem.excelID.ToString() + ",1)", connection);
                            command.ExecuteNonQuery();

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
                                              "', [Mitdate] = '" + riskItem.ResponseRootCauseDate.ToString("yyyy-MM-dd") +
                                              "', [Mitcost] = " + riskItem.costRootCause.ToString() +
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
                                              " , [MitiActDate]= '" + riskItem.ResponseImpactDate.ToString("yyyy-MM-dd") +
                                              "', [ImpEndDate]= '" + riskItem.impactEndDate.ToString("yyyy-MM-dd") +
                                              "', [CostMitiImpact]= " + riskItem.costImpact.ToString() +
                                              " , [Impact]= '" + riskItem.actionsImpact.ToString() +
                                              "', [ImpactDirect]= '" + riskItem.impactDesc.ToString() +
                                              "', [ID_resp]= " + riskItem.respStratImpactID.ToString() +
                                              " , [ID_phase]= " + riskItem.phaseID.ToString() +
                                              " , [DueDate]= '" + riskItem.impactStartDate.ToString("yyyy-MM-dd") +
                                              "', [formula]= '" + riskItem.formulaBefore.ToString() +
                                              "', [forDesc]= '" + riskItem.formulaBeforeDesc.ToString() +
                                              "', [BU]= " + riskItem.buRate.ToString() +
                                              " , [Rkbef]= " + riskItem.monetaryValueBefore.ToString() +
                                              " , [Remarks]= '" + riskItem.remarks.ToString() +
                                              "', [IDncc]= " + riskItem.nccID.ToString() +
                                              " , [OriginatingID]= " + riskItem.orgUnitID.ToString() +
                                              " , [timeObjective]= '" + riskItem.timeObjective.ToString() +
                                              "', [costObjective]= '" + riskItem.costObjective.ToString() +
                                              "', [qualityObjective]= '" + riskItem.qualityObjective.ToString() +
                                              "', [safetyfObjective]= '" + riskItem.safetyObjective.ToString() +
                                              "', [costSatisfObjective]= '" + riskItem.customerSatisfObjective.ToString() +
                                              "'   WHERE ID = (SELECT MAX(ID) FROM rk_ROlog WHERE IDproj =" + ProjectID.ToString() + ")";
                            command = new SqlCommand(queryString, connection);
                            command.ExecuteNonQuery();


                            command = new SqlCommand("UPDATE [rk_ROlog] SET updatedBy = 0 WHERE ID = " + riskItem.itemID.ToString(), connection);
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wront, when trying to insert new risk. Error Message: " + ex.Message);
                    }





                }
            }
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

        public EProjectItemList getFilterItems(int projectID, DateTime month, int field, int fieldValue)
        {
            String SQL = "";
            
            //PROJECT OWNER
            if (field == 0)
            {
                SQL = "SELECT * FROM rk_ROlog WHERE IDproj =" + projectID + " AND newChanges = 0 AND watchlist = 0 AND removedItem = 0 AND Month(createDate) =" + month.Month.ToString() + " AND Year(CreateDate) =" 
                      + month.Year.ToString() + " AND IDOWNER =" + fieldValue;
            }
            //ACTION OWNER
            else if(field == 1)
            {
                SQL = "SELECT * FROM rk_ROlog WHERE IDproj =" + projectID + " AND newChanges = 0 AND watchlist = 0 AND removedItem = 0 AND Month(createDate) =" + month.Month.ToString() + " AND Year(CreateDate) ="
                      + month.Year.ToString() + " AND IDOwnerDirect =" + fieldValue 
                      + " OR IDproj =" + projectID + " AND newChanges = 0 AND watchlist = 0 AND removedItem = 0 AND Month(createDate) =" + month.Month.ToString() + " AND Year(CreateDate) ="
                      + month.Year.ToString() + " AND ID_riskActionOwner =" + fieldValue + "";
            }
            //ROOT CAUSE CATEGORY
            else if(field == 2)
            {
                SQL = "SELECT * FROM rk_ROlog WHERE IDproj =" + projectID + " AND newChanges = 0 AND watchlist = 0 AND removedItem = 0 AND Month(createDate) =" + month.Month.ToString() + " AND Year(CreateDate) ="
                      + month.Year.ToString() + " AND IDcat =" + fieldValue;
            }

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
                               Convert.ToDateTime(row["createdItem"].ToString()),
                               Convert.ToDateTime(row["updateDate"].ToString()),
                               Convert.ToDateTime(row["mitDate"].ToString()),
                               Convert.ToDateTime(row["mitiActDate"].ToString()),
                               Convert.ToDateTime(row["DueDate"].ToString()),
                               Convert.ToDateTime(row["ImpEndDate"].ToString())
                               );
                itemsList.add(riskItem);
            }
            connection.Close();
            return itemsList;
        }

        public EProjectItemList getItems(int projectID, DateTime month, string type)
        {
            //RISKS
            if (type.ToLower() == "risk")
            {
                connection.Open();
                string SQL = "SELECT * FROM rk_ROlog WHERE IDproj =" + projectID + " AND newChanges = 0 AND watchlist = 0 AND removedItem = 0 AND Month(createDate) =" + month.Month.ToString() + " AND Year(CreateDate) =" + month.Year.ToString();

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
                                   Convert.ToDateTime(row["createdItem"].ToString()),
                                   Convert.ToDateTime(row["updateDate"].ToString()),
                                   Convert.ToDateTime(row["mitDate"].ToString()),
                                   Convert.ToDateTime(row["mitiActDate"].ToString()),
                                   Convert.ToDateTime(row["DueDate"].ToString()),
                                   Convert.ToDateTime(row["ImpEndDate"].ToString())
                                   );
                    itemsList.add(riskItem);
                }
                connection.Close();
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

        public ExecutionProject getExecutionProject(int projectID)
        {
            connection.Open();
            string SQL = "SELECT * FROM [rk_ProjectDetailView] WHERE ID =" + projectID;

            dataAdapterExecutionProject = new SqlDataAdapter(SQL, connection);
            dataSourceExecutionProject = new DataTable();
            dataAdapterExecutionProject.Fill(dataSourceExecutionProject);
            ExecutionProject execProject = null;

            foreach (DataRow row in dataSourceExecutionProject.Rows)
            {
                execProject = new ExecutionProject(
                                                   row["sap"].ToString(),
                                                   row["loa"].ToString(),
                                                   row["cpm"].ToString(),
                                                   row["pm"].ToString(),
                                                   row["prepBy"].ToString(),
                                                   row["updateby"].ToString(),
                                                   row["checkBy"].ToString(),
                                                   row["pname"].ToString(),
                                                   row["ownername"].ToString(),
                                                   Convert.ToInt32(row["ID"].ToString()),
                                                   Convert.ToInt32(row["IDUser"].ToString()),
                                                   Convert.ToInt32(row["segmentID"].ToString()),
                                                   Convert.ToInt32(row["scopeID"].ToString()),
                                                   Convert.ToInt32(row["WTGType"].ToString()),
                                                   Convert.ToInt32(row["noWTGs"].ToString()),
                                                   Convert.ToInt32(row["IDEntryCur"].ToString()),
                                                   Convert.ToInt32(row["FoundationTypeID"].ToString()),
                                                   Convert.ToInt32(row["harbourID"].ToString()),
                                                   Convert.ToInt32(row["BUIDCur"].ToString()),
                                                   Convert.ToInt32(row["RUIDCur"].ToString()),
                                                   Convert.ToDecimal(row["BUrate"].ToString()),
                                                   Convert.ToDecimal(row["RUrate"].ToString()),
                                                   Convert.ToDateTime(row["toc"].ToString()),
                                                   Convert.ToDateTime(row["prep_date"].ToString()),
                                                   Convert.ToDateTime(row["update_date"].ToString()),
                                                   Convert.ToDateTime(row["check_date"].ToString()),
                                                   Convert.ToDouble(row["BUcontract"].ToString()),
                                                   Convert.ToDouble(row["RUcontract"].ToString())
                                                  );

            }
            connection.Close();

            if (execProject == null)
            {
                MessageBox.Show("Something went wong");
                return null;
            }
            else
            {
                return execProject;
            }

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
                                              "', [Mitdate] = '" + riskItem.ResponseRootCauseDate.ToString("yyyy-MM-dd") +
                                              "', [Mitcost] = " + riskItem.costRootCause.ToString() +
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
                                              " , [MitiActDate]= '" + riskItem.ResponseImpactDate.ToString("yyyy-MM-dd") +
                                              "', [ImpEndDate]= '" + riskItem.impactEndDate.ToString("yyyy-MM-dd") +
                                              "', [CostMitiImpact]= " + riskItem.costImpact.ToString() +
                                              " , [Impact]= '" + riskItem.actionsImpact.ToString() +
                                              "', [ImpactDirect]= '" + riskItem.impactDesc.ToString() +
                                              "', [ID_resp]= " + riskItem.respStratImpactID.ToString() +
                                              " , [ID_phase]= " + riskItem.phaseID.ToString() +
                                              " , [DueDate]= '" + riskItem.impactStartDate.ToString("yyyy-MM-dd") +
                                              "', [formula]= '" + riskItem.formulaBefore.ToString() +
                                              "', [forDesc]= '" + riskItem.formulaBeforeDesc.ToString() +
                                              "', [BU]= " + riskItem.buRate.ToString() +
                                              " , [Rkbef]= " + riskItem.monetaryValueBefore.ToString() +
                                              " , [Remarks]= '" + riskItem.remarks.ToString() +
                                              "', [IDncc]= " + riskItem.nccID.ToString() +
                                              " , [OriginatingID]= " + riskItem.orgUnitID.ToString() +
                                              " , [timeObjective]= '" + riskItem.timeObjective.ToString() +
                                              "', [costObjective]= '" + riskItem.costObjective.ToString() +
                                              "', [qualityObjective]= '" + riskItem.qualityObjective.ToString() +
                                              "', [safetyfObjective]= '" + riskItem.safetyObjective.ToString() +
                                              "', [costSatisfObjective]= '" + riskItem.customerSatisfObjective.ToString() +
                                              "'   WHERE ID =" + riskItem.itemID.ToString();
                            command = new SqlCommand(queryString, connection);
                            command.ExecuteNonQuery();


                            command = new SqlCommand("UPDATE [rk_ROlog] SET updatedBy = 0 WHERE ID = " + riskItem.itemID.ToString(), connection);
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wront, when trying to update risk. Error Message: " + ex.Message);
                    }
                }
                // OPPORTUNITY PROJECT OWNER UPDATE ///////////////////////////////////////////////////////////////////////////////////
                else if (type.ToLower() == "opportunity")
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

                            command = new SqlCommand("UPDATE [rk_ROlog] SET updatedBy = 0 WHERE ID = " + oppItem.itemID.ToString(), connection);
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wront, when trying to update Opportunity. Error Message: " + ex.Message);
                    }
                }

                // PROJECT IMPACT PROJECT OWNER UPDATE ///////////////////////////////////////////////////////////////////////////////////
                else if (type.ToLower() == "projectimpact")
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

                            command = new SqlCommand("UPDATE rk_projectImpacts SET UpdatedBy = 0 WHERE ID = " + projImpactItem.itemID.ToString(), connection);
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wront, when trying to update Project Impact. Error Message: " + ex.Message);
                    }
                }


                // ENTERPRISE RISK PROJECT OWNER UPDATE ///////////////////////////////////////////////////////////////////////////////////
                else if (type.ToLower() == "enterpriserisk")
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
                        MessageBox.Show("Something went wront, when trying to save Enterprise Risk. Error Message: " + ex.Message);
                    }
                }

                // ENTERPRISE RISK PROJECT OWNER UPDATE ///////////////////////////////////////////////////////////////////////////////////
                else if (type.ToLower() == "otheruncertainty")
                {
                    try
                    {
                        // Cast EprojectItem to EProjImpact
                        EUncertainty uncertaintyItem = (EUncertainty)item;

                        // Opening connection and executing Queries
                        using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                        {
                            string queryString = "UPDATE rk_otheruncertainties SET" +
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
                        MessageBox.Show("Something went wront, when trying to update Other Uncertainty. Error Message: " + ex.Message);
                    }
                }
                // IF USER IS NOT PROJECT OWNER ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
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

                            connection.Open();
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
                                              "', [Mitdate] = '" + riskItem.ResponseRootCauseDate.ToString("yyyy-MM-dd") +
                                              "', [Mitcost] = " + riskItem.costRootCause.ToString() +
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
                                              " , [MitiActDate]= '" + riskItem.ResponseImpactDate.ToString("yyyy-MM-dd") +
                                              "', [ImpEndDate]= '" + riskItem.impactEndDate.ToString("yyyy-MM-dd") +
                                              "', [CostMitiImpact]= " + riskItem.costImpact.ToString() +
                                              " , [Impact]= '" + riskItem.actionsImpact.ToString() +
                                              "', [ImpactDirect]= '" + riskItem.impactDesc.ToString() +
                                              "', [ID_resp]= " + riskItem.respStratImpactID.ToString() +
                                              " , [ID_phase]= " + riskItem.phaseID.ToString() +
                                              " , [DueDate]= '" + riskItem.impactStartDate.ToString("yyyy-MM-dd") +
                                              "', [formula]= '" + riskItem.formulaBefore.ToString() +
                                              "', [forDesc]= '" + riskItem.formulaBeforeDesc.ToString() +
                                              "', [BU]= " + riskItem.buRate.ToString() +
                                              " , [Rkbef]= " + riskItem.monetaryValueBefore.ToString() +
                                              " , [Remarks]= '" + riskItem.remarks.ToString() +
                                              "', [IDncc]= " + riskItem.nccID.ToString() +
                                              " , [OriginatingID]= " + riskItem.orgUnitID.ToString() +
                                              " , [timeObjective]= '" + riskItem.timeObjective.ToString() +
                                              "', [costObjective]= '" + riskItem.costObjective.ToString() +
                                              "', [qualityObjective]= '" + riskItem.qualityObjective.ToString() +
                                              "', [safetyfObjective]= '" + riskItem.safetyObjective.ToString() +
                                              "', [costSatisfObjective]= '" + riskItem.customerSatisfObjective.ToString() +
                                              "'   WHERE ID =" + riskItem.itemID.ToString();
                            command = new SqlCommand(queryString, connection);
                            command.CommandTimeout = 500;
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wront. Error Message: " + ex.Message);
                    }
                }
                // OPPORTUNITY PROJECT NOT OWNER UPDATE///////////////////////////////////////////////////////////////////////////////////
                else if (type.ToLower() == "opportunity")
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
                else if (type.ToLower() == "projectimpact")
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
                else if (type.ToLower() == "enterpriserisk")
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
                else if (type.ToLower() == "otheruncertainty")
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


        public void updateNewItem(EProjectItem item)
        {
            throw new NotImplementedException();
        }

        public void updateProject(ExecutionProject project)
        {
            try
            {
                // Opening connection and executing Queries
                using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                {
                    string queryString = "UPDATE rk_Project SET " +
                                                               " sap = '" + project.sap + "'," +
                                                               " loa = '" + project.loa + "'," +
                                                               " cpm = '" + project.cpm + "'," +
                                                               " pm = '" + project.pm + "'," +
                                                               " prepby = '" + project.prepBy + "'," +
                                                               " toc = '" + project.toc.ToString("yyyy-MM-dd") + "'," +
                                                               " IDuser = " + project.ownerID.ToString() + "," +
                                                               " BUcontract = " + project.BUcontract.ToString() + "," +
                                                               " RUcontract = " + project.RUcontract.ToString() + "," +
                                                               " segmentID = " + project.segmentID.ToString() + "," +
                                                               " scopeID = " + project.scopeID.ToString() + "," +
                                                               " pname = '" + project.name + "'," +
                                                               " BUIDcur = " + project.BUCurID.ToString() + "," +
                                                               " RUIDcur = " + project.RUCurID.ToString() + "," +
                                                               " BUrate = " + project.BUrate.ToString().Replace(",", ".") + "," +
                                                               " RUrate = " + project.RUrate.ToString().Replace(",", ".") + "," +
                                                               " WTGtype = " + project.wtgID.ToString() + "," +
                                                               " noWTGs = " + project.numberWtgs.ToString() + "," +
                                                               " IDEntryCur = " + project.entryCurID.ToString() + "," +
                                                               " FoundationTypeID = " + project.foundationID.ToString() + "," +
                                                               " HarbourID = " + project.harbourID.ToString() +
                                        "WHERE ID = " + project.projectID;
                    command = new SqlCommand(queryString, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wront. Error Message: " + ex.Message);
            }
        }

        public void approveNewItem(int projectID, int newItemID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                string queryString = "INSERT INTO [rk_ROlog] ([IDproj],[Rname],[RkDesc],[BU],[Rkbef],[P],[IDdicat],[DueDate],[formula],[forDesc],[MitDesc],[Mitdate],[Mitcost],[Pafter],[Remarks],[IDstatus],[IDcat],[IDchap] "
                                    + ",[REF_ID],[createdItem],[IDncc],[Status],[OriginatingID],[IDowner],[owne],[watchlist],[RootCause],[Impact],[reStrategy],[ID_resp],[ID_phase],[ID_customerShare],[OtherRootCause],[ImpactDirect],[ExpValueDays] "
                                    + ",[MitiActDate],[ImpEndDate],[ValAfterMiti],[CostMitiImpact],[newChanges],[ID_riskActionOwner],[conseqBoolean],[conseqValueInDays],[conseqMonetValue],[conseqComment],[ID_conseqRespStrategy] ,[ID_conseqRiskActionOwner],[conseqActions],[conseqMitiToBeTaken],[conseqValueAfterMiti],[conseqMitiActionsDate],[conseqRiskDesc],[IDOwnerDirect],[PMpackage],[CPMpackage],[WPAMpackage],[CNPMpackage],[FPAMpackage],[CAMPpackage], [OSPAMpackage],[timeObjective], [costObjective], [qualityObjective], [safetyfObjective], [costSatisfObjective],[ExcelID]) "
                                    + "Values"
                                    + "( (SELECT IDproj FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ),(SELECT Rname FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT RkDesc FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ) "
                                    + ", (SELECT BU FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT Rkbef FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT P FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT IDdicat FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ) "
                                    + ", (SELECT DueDate FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT formula FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT forDesc FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ) "
                                    + ", (SELECT MitDesc FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT Mitdate FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT Mitcost FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ) "
                                    + ", (SELECT Pafter FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT Remarks FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " )"
                                    + ", 1 , (SELECT IDcat FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ) "
                                    + ", 1, (SELECT REF_ID FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ) " + ", (SELECT createdItem FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT IDncc FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT Status FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ) "
                                    + ", (SELECT OriginatingID FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT IDowner FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT owne FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + ") ,0, (SELECT RootCause FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ) "
                                    + ", (SELECT Impact FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT reStrategy FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ) "
                                    + ", (SELECT ID_resp FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT ID_phase FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ) "
                                    + ", (SELECT ID_customerShare FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ) "
                                    + ", (SELECT OtherRootCause FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT ImpactDirect FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ),(SELECT ExpValueDays FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + ")" + ""
                                    + ", (SELECT MitiActDate FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT ImpEndDate FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT ValAfterMiti FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT CostMitiImpact FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + ")" + ", 0,(SELECT ID_riskActionOwner FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT conseqBoolean FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + ")"
                                    + ", (SELECT conseqValueInDays FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT conseqMonetValue FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT conseqComment FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT ID_conseqRespStrategy FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + ")" + ", (SELECT ID_conseqRiskActionOwner FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ),(SELECT conseqActions FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ),(SELECT conseqMitiToBeTaken FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT conseqValueAfterMiti FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + " ), (SELECT conseqMitiActionsDate FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + ")" + ","
                                    + "  (SELECT conseqRiskDesc FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + "), " + "  (SELECT [IDOwnerDirect] FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + ")"
                                    + " ,(SELECT PMpackage FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + ")" + " , (SELECT CPMpackage FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + ")" + " , (SELECT WPAMpackage FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + ")" + " , (SELECT CNPMpackage FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + ")" + " , (SELECT FPAMpackage FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + ")" + " , (SELECT CAMPpackage FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + ")" + " , (SELECT OSPAMpackage FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + ")" + " , (SELECT timeObjective FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + ")" + " , (SELECT costObjective FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + ")" + " , (SELECT qualityObjective FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + ")" + " , (SELECT safetyfObjective FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + ")" + " , (SELECT costSatisfObjective FROM [rk_NewRisk_Indiv] WHERE  ID = " + newItemID + "),"
                                    + "(SELECT ISNULL(MAX(ExcelID)+1,5000) as ExcelID FROM rk_ROlog WHERE IDPROJ =" + projectID + "AND MONTH(createDate) = Month(getDate()) AND YEAR(getDate()) = Year(getDate()))" + ")";
                command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                queryString = "DELETE FROM rk_NewRisk_Indiv WHERE ID =" + newItemID;
                command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void declineNewItem(int projectID, int newItemID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                string queryString = "DELETE FROM rk_NewRisk_Indiv WHERE ID =" + newItemID;
                command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }













        public void approveChangedItem(int projectID, int changedItemID, int UpdatedColID, string newValueString, int newColumnID, string updatedColumntxt, int idOfChange)
        {
            Boolean Done = false;
            String ColToBeUpdated = "";

            if (UpdatedColID == 1)
            {
                ColToBeUpdated = "Status";
            }
            else if (UpdatedColID == 2)
            {
                ColToBeUpdated = "ID_customerShare";
            }
            else if (UpdatedColID == 3)
            {
                ColToBeUpdated = "IDowner";
            }
            else if (UpdatedColID == 4)
            {
                ColToBeUpdated = "P";
            }
            else if (UpdatedColID == 5)
            {
                ColToBeUpdated = "formula";
            }
            else if (UpdatedColID == 6)
            {
                ColToBeUpdated = "CostMitiImpact";
            }
            else if (UpdatedColID == 7)
            {
                ColToBeUpdated = "PAfter";
            }
            else if (UpdatedColID == 8)
            {
                ColToBeUpdated = "DueDate";
            }
            else if (UpdatedColID == 9)
            {
                ColToBeUpdated = "ImpEndDate";
            }
            else if (UpdatedColID == 10)
            {
                ColToBeUpdated = "BU";
            }
            else if (UpdatedColID == 11)
            {
                ColToBeUpdated = "ValAfterMiti";
            }
            else if (UpdatedColID == 12)
            {
                ColToBeUpdated = "OriginatingID";
            }
            else if (UpdatedColID == 13)
            {
                ColToBeUpdated = "Mitcost";
            }
            else if (UpdatedColID == 14)
            {
                ColToBeUpdated = "conseqMonetValue";
            }
            else if (UpdatedColID == 15)
            {
                ColToBeUpdated = "conseqValueAfterMiti";
            }
            else if (UpdatedColID == 16)
            {
                ColToBeUpdated = "IDncc";
            }
            else if (UpdatedColID == 17)
            {
                ColToBeUpdated = "conseqMitiToBeTaken";
            }
            else if (UpdatedColID == 18)
            {
                ColToBeUpdated = "conseqBoolean";
            }
            else if (UpdatedColID == 19)
            {
                ColToBeUpdated = "watchlist";
            }
            else if (UpdatedColID == 20)
            {
                ColToBeUpdated = "removedItem";
            }


            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                string queryString = "IF DATEDIFF(month,(SELECT MAX(createdate) FROM rk_ROlog WHERE ExcelID = (SELECT ExcelID FROM rk_ROlog WHERE ID = " + changedItemID + " AND IDproj= " + projectID + ") AND IDproj= " + projectID + "),(SELECT createdate FROM rk_ROlog WHERE ID = " + changedItemID + ")) < 0 "
                                   + " UPDATE RK_ROlog SET updatedBy = 1 WHERE ExcelID = (SELECT ExcelID FROM rk_ROlog WHERE ID = " + changedItemID + " AND IDproj= " + projectID + " )  AND CreateDate = (SELECT Max(createdate) FROM rk_ROlog WHERE ExcelID =  (SELECT ExcelID FROM rk_ROlog WHERE ID = " + changedItemID + " AND IDproj= " + projectID + " )  AND IDproj= " + projectID + " ) AND IDproj= " + projectID + "  "
                                   + " ELSE "
                                   + " UPDATE RK_ROlog SET updatedBy = 1 WHERE ID = " + changedItemID;
                command = new SqlCommand(queryString, connection);
                connection.Open();
                command.CommandTimeout = 120;
                command.ExecuteNonQuery();
                connection.Close();


                if (UpdatedColID == 8 || UpdatedColID == 9)
                {
                    queryString = "IF DATEDIFF(month,(SELECT MAX(createdate) FROM rk_ROlog WHERE ExcelID = (SELECT ExcelID FROM rk_ROlog WHERE ID = " + changedItemID + " AND IDproj= " + projectID
                                + ") AND IDproj= " + projectID + "),(SELECT createdate FROM rk_ROlog WHERE ID = " + projectID + ")) < 0 UPDATE rk_ROlog SET " + ColToBeUpdated + " = '" + newValueString
                                + "' WHERE ExcelID = (SELECT ExcelID FROM rk_ROlog WHERE ID = " + changedItemID + " AND IDproj= " + projectID
                                + " )  AND CreateDate = (SELECT Max(createdate) FROM rk_ROlog WHERE ExcelID =  (SELECT ExcelID FROM rk_ROlog WHERE ID = " + changedItemID + " AND IDproj= " + projectID
                                + " )  AND IDproj= " + projectID + " ) AND IDproj= " + projectID + " ELSE " + " UPDATE RK_ROlog SET " + ColToBeUpdated + " = '" + newValueString + "' WHERE ID = " + changedItemID;
                    command = new SqlCommand(queryString, connection);
                    connection.Open();
                    command.CommandTimeout = 120;
                    command.ExecuteNonQuery();
                    connection.Close();

                    Done = true;
                }


                if (Done == false)
                {
                    if (newColumnID == -1)
                    {
                        queryString = "IF DATEDIFF(month,(SELECT MAX(createdate) FROM rk_ROlog WHERE ExcelID = (SELECT ExcelID FROM rk_ROlog WHERE ID = " + changedItemID + " AND IDproj= " + projectID
                                    + ") AND IDproj= " + projectID + "),(SELECT createdate FROM rk_ROlog WHERE ID = " + changedItemID + ")) < 0 UPDATE rk_ROlog SET " + ColToBeUpdated
                                    + " = '" + newValueString + "' WHERE ExcelID = (SELECT ExcelID FROM rk_ROlog WHERE ID = " + changedItemID + " AND IDproj= " + projectID
                                    + " )  AND CreateDate = (SELECT Max(createdate) FROM rk_ROlog WHERE ExcelID =  (SELECT ExcelID FROM rk_ROlog WHERE ID = " + changedItemID
                                    + " AND IDproj= " + projectID + " )  AND IDproj= " + projectID + " ) AND IDproj= " + projectID + " ELSE "
                                    + " UPDATE RK_ROlog SET " + ColToBeUpdated + " = '" + newValueString + "' WHERE ID = " + changedItemID;
                        command = new SqlCommand(queryString, connection);
                        connection.Open();
                        command.CommandTimeout = 120;
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    else
                    {
                        queryString = "IF DATEDIFF(month,(SELECT MAX(createdate) FROM rk_ROlog WHERE ExcelID = (SELECT ExcelID FROM rk_ROlog WHERE ID = "
                                    + changedItemID + " AND IDproj= " + projectID + ") AND IDproj= " + projectID + "),(SELECT createdate FROM rk_ROlog WHERE ID = "
                                    + changedItemID + ")) < 0 " + " UPDATE RK_ROlog SET " + ColToBeUpdated + " = '" + newColumnID + "' WHERE ExcelID = (SELECT ExcelID FROM rk_ROlog WHERE ID = "
                                    + changedItemID + " AND IDproj= " + projectID + " )  AND CreateDate = (SELECT Max(createdate) FROM rk_ROlog WHERE ExcelID =  (SELECT ExcelID FROM rk_ROlog WHERE ID = "
                                    + changedItemID + " AND IDproj= " + projectID + " )  AND IDproj= " + projectID + " ) AND IDproj= " + projectID + "  "
                                    + " ELSE UPDATE RK_ROlog SET " + ColToBeUpdated + " = '" + newColumnID + "' WHERE ID = " + changedItemID;
                        command = new SqlCommand(queryString, connection);
                        connection.Open();
                        command.CommandTimeout = 120;
                        command.ExecuteNonQuery();
                        connection.Close();
                    }


                    if (UpdatedColID == 5)
                    {
                        double result = Convert.ToDouble(new DataTable().Compute(newValueString, null));

                        queryString = "IF DATEDIFF(month,(SELECT MAX(createdate) FROM rk_ROlog WHERE ExcelID = (SELECT ExcelID FROM rk_ROlog WHERE ID = "
                            + changedItemID + " AND IDproj= " + projectID + ") AND IDproj= " + projectID + "),(SELECT createdate FROM rk_ROlog WHERE ID = "
                            + changedItemID + ")) < 0 "
                            + " UPDATE RK_ROlog SET rkBef = " + result + " WHERE ExcelID = (SELECT ExcelID FROM rk_ROlog WHERE ID = "
                            + changedItemID + " AND IDproj= " + projectID + " )  AND CreateDate = (SELECT Max(createdate) FROM rk_ROlog WHERE ExcelID =  (SELECT ExcelID FROM rk_ROlog WHERE ID = "
                            + changedItemID + " AND IDproj= " + projectID + " )  AND IDproj= " + projectID + " ) AND IDproj= " + projectID + "  "
                            + " ELSE UPDATE RK_ROlog SET rkBef = " + result + " WHERE ID = " + changedItemID;
                        command = new SqlCommand(queryString, connection);
                        connection.Open();
                        command.CommandTimeout = 120;
                        command.ExecuteNonQuery();
                        connection.Close();
                    }

                    queryString = "IF DATEDIFF(month,(SELECT MAX(createdate) FROM rk_ROlog WHERE ExcelID = (SELECT ExcelID FROM rk_ROlog WHERE ID = " + changedItemID + " AND IDproj= "
                                + projectID + ") AND IDproj= " + projectID + "),(SELECT createdate FROM rk_ROlog WHERE ID = " + changedItemID + ")) < 0 "
                                + " UPDATE RK_ROlog SET updatedBy = 0 WHERE ExcelID = (SELECT ExcelID FROM rk_ROlog WHERE ID = " + changedItemID + " AND IDproj= " + projectID
                                + " )  AND CreateDate = (SELECT Max(createdate) FROM rk_ROlog WHERE ExcelID =  (SELECT ExcelID FROM rk_ROlog WHERE ID = " + changedItemID + " AND IDproj= "
                                + projectID + " )  AND IDproj= " + projectID + " ) AND IDproj= " + projectID + "  "
                                + " ELSE UPDATE RK_ROlog SET updatedBy = 0 WHERE ID = " + changedItemID;
                    command = new SqlCommand(queryString, connection);
                    connection.Open();
                    command.CommandTimeout = 120;
                    command.ExecuteNonQuery();
                    connection.Close();

                    queryString = "DELETE FROM RK_ROlog_SeparateItemsApproval WHERE IDChanges =" + changedItemID + " AND changedItem = '" + updatedColumntxt + "'";
                    command = new SqlCommand(queryString, connection);
                    connection.Open();
                    command.CommandTimeout = 120;
                    command.ExecuteNonQuery();
                    connection.Close();

                    queryString = "DELETE FROM rk_ROlogChanges WHERE ID =" + idOfChange;
                    command = new SqlCommand(queryString, connection);
                    connection.Open();
                    command.CommandTimeout = 120;
                    command.ExecuteNonQuery();
                    connection.Close();

                    queryString = "DISABLE TRIGGER [updateTriggerIndivRisk] ON rk_ROlog;";
                    command = new SqlCommand(queryString, connection);
                    connection.Open();
                    command.CommandTimeout = 120;
                    command.ExecuteNonQuery();
                    connection.Close();

                    queryString = "IF(SELECT COUNT(ID) FROM rk_ROlogChanges WHERE itemType = 1 AND ProjectID = " + projectID + " AND RiskID = " + changedItemID
                                 + ") = 0 UPDATE rk_ROlog SET newChanges = 0 WHERE IDproj = " + projectID + " AND ID IN (SELECT ID FROM rk_ROlog WHERE ExcelID = (SELECT ExcelID FROM rk_ROlog WHERE ID = "
                                 + changedItemID + ") AND IDproj = " + projectID + ")";
                    command = new SqlCommand(queryString, connection);
                    connection.Open();
                    command.CommandTimeout = 120;
                    command.ExecuteNonQuery();
                    connection.Close();

                    queryString = "ENABLE TRIGGER [updateTriggerIndivRisk] ON rk_ROlog;";
                    command = new SqlCommand(queryString, connection);
                    connection.Open();
                    command.CommandTimeout = 120;
                    command.ExecuteNonQuery();
                    connection.Close();

                    queryString = "IF(SELECT COUNT(ID) FROM rk_ROlogChanges WHERE ProjectID = " + projectID + " AND RiskID = "
                                  + changedItemID + ") = 0 DELETE FROM rk_ROlog_SeparateItemsApproval WHERE ChangedItemID =" + changedItemID;
                    command = new SqlCommand(queryString, connection);
                    connection.Open();
                    command.CommandTimeout = 120;
                    command.ExecuteNonQuery();
                    connection.Close();

                }

            }
        }

        public void declineChangedItem(int projectID, int changedItemID, int UpdatedColID, string newValueString, int newColumnID, string updatedColumntxt, int idOfChange)
        {
            String ColToBeUpdated = "";

            if (UpdatedColID == 1)
            {
                ColToBeUpdated = "Status";
            }
            else if (UpdatedColID == 2)
            {
                ColToBeUpdated = "ID_customerShare";
            }
            else if (UpdatedColID == 3)
            {
                ColToBeUpdated = "IDowner";
            }
            else if (UpdatedColID == 4)
            {
                ColToBeUpdated = "P";
            }
            else if (UpdatedColID == 5)
            {
                ColToBeUpdated = "formula";
            }
            else if (UpdatedColID == 6)
            {
                ColToBeUpdated = "CostMitiImpact";
            }
            else if (UpdatedColID == 7)
            {
                ColToBeUpdated = "PAfter";
            }
            else if (UpdatedColID == 8)
            {
                ColToBeUpdated = "DueDate";
            }
            else if (UpdatedColID == 9)
            {
                ColToBeUpdated = "ImpEndDate";
            }
            else if (UpdatedColID == 10)
            {
                ColToBeUpdated = "BU";
            }
            else if (UpdatedColID == 11)
            {
                ColToBeUpdated = "ValAfterMiti";
            }
            else if (UpdatedColID == 12)
            {
                ColToBeUpdated = "OriginatingID";
            }
            else if (UpdatedColID == 13)
            {
                ColToBeUpdated = "Mitcost";
            }
            else if (UpdatedColID == 14)
            {
                ColToBeUpdated = "conseqMonetValue";
            }
            else if (UpdatedColID == 15)
            {
                ColToBeUpdated = "conseqValueAfterMiti";
            }
            else if (UpdatedColID == 16)
            {
                ColToBeUpdated = "IDncc";
            }
            else if (UpdatedColID == 17)
            {
                ColToBeUpdated = "conseqMitiToBeTaken";
            }
            else if (UpdatedColID == 18)
            {
                ColToBeUpdated = "conseqBoolean";
            }
            else if (UpdatedColID == 19)
            {
                ColToBeUpdated = "watchlist";
            }
            else if (UpdatedColID == 20)
            {
                ColToBeUpdated = "removedItem";
            }


            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                string queryString = "UPDATE [rk_ROlog_SeparateItemsApproval] SET " + ColToBeUpdated + "= (SELECT " + ColToBeUpdated + " FROM rk_ROlog WHERE ID = " + changedItemID + ") WHERE changedItemID = " + changedItemID;
                command = new SqlCommand(queryString, connection);
                connection.Open();
                command.CommandTimeout = 120;
                command.ExecuteNonQuery();
                connection.Close();

                queryString = "DELETE FROM rk_ROlogChanges WHERE ID =" + idOfChange;
                command = new SqlCommand(queryString, connection);
                connection.Open();
                command.CommandTimeout = 120;
                command.ExecuteNonQuery();
                connection.Close();

                queryString = "IF DATEDIFF(month,(SELECT MAX(createdate) FROM rk_ROlog WHERE ExcelID = (SELECT ExcelID FROM rk_ROlog WHERE ID = " + changedItemID + " AND IDproj= " + projectID
                            + ") AND IDproj= " + projectID + "),(SELECT createdate FROM rk_ROlog WHERE ID = " + changedItemID + ")) < 0 " + " UPDATE RK_ROlog SET updatedBy = 0 WHERE " + ""
                            + "ExcelID = (SELECT ExcelID FROM rk_ROlog WHERE ID = " + changedItemID + " AND IDproj= " + projectID + " )  AND CreateDate = (SELECT Max(createdate) FROM" + ""
                            + " rk_ROlog WHERE ExcelID =  (SELECT ExcelID FROM rk_ROlog WHERE ID = " + changedItemID + " AND IDproj= " + projectID + " )  AND IDproj= "
                            + projectID + " ) AND IDproj= " + projectID + "  " + " ELSE " + " UPDATE RK_ROlog SET updatedBy = 0 WHERE ID = " + changedItemID;
                command = new SqlCommand(queryString, connection);
                connection.Open();
                command.CommandTimeout = 120;
                command.ExecuteNonQuery();
                connection.Close();

                queryString = "IF(SELECT COUNT(ID) FROM rk_ROlogChanges WHERE ProjectID = " + projectID + " AND RiskID = " + changedItemID + ") = 0 UPDATE rk_ROlog SET newChanges = 0 WHERE IDproj = " + projectID
                            + " AND ID = (SELECT MAX(ID) FROM rk_ROlog WHERE ExcelID = (SELECT ExcelID FROM rk_ROlog WHERE ID = " + changedItemID + ") AND IDproj = " + projectID + ")";
                command = new SqlCommand(queryString, connection);
                connection.Open();
                command.CommandTimeout = 120;
                command.ExecuteNonQuery();
                connection.Close();

                queryString = "IF(SELECT COUNT(ID) FROM rk_ROlogChanges WHERE ProjectID = " + projectID + " AND RiskID = " + changedItemID
                            + ") = 0 DELETE FROM rk_ROlog_SeparateItemsApproval WHERE ChangedItemID =" + changedItemID;
                command = new SqlCommand(queryString, connection);
                connection.Open();
                command.CommandTimeout = 120;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}