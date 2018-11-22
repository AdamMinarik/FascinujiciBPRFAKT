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

        public EProjectItemList getClosedItems(int projectID, string month)
        {
            throw new NotImplementedException();
        }

        public EProjectItemList getFilterItems(int projectID, string month, string field, string fieldValue)
        {
            throw new NotImplementedException();
        }

        public EProjectItemList getItems(int projectID, string month, string type)
        {
            throw new NotImplementedException();
            /*if (type.ToLower() == "risk")
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
                                   Convert.ToDateTime(row["createDate"].ToString()),
                                   Convert.ToDateTime(row["updateDate"].ToString()),
                                   Convert.ToDateTime(row["mitDate"].ToString()),
                                   Convert.ToDateTime(row["mitiActDate"].ToString()),
                                   Convert.ToDateTime(row["DueDate"].ToString()),
                                   Convert.ToDateTime(row["ImpEndDate"].ToString())
                                   );
                    itemsList.add(riskItem);

                }
            }
            else if(type.ToLower() == "opportunity")
            {
                connection.Open();
                string SQL = "SELECT * FROM rk_ROlog";

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
                                   Convert.ToDateTime(row["createDate"].ToString()),
                                   Convert.ToDateTime(row["updateDate"].ToString()),
                                   Convert.ToDateTime(row["mitDate"].ToString()),
                                   Convert.ToDateTime(row["mitiActDate"].ToString()),
                                   Convert.ToDateTime(row["DueDate"].ToString()),
                                   Convert.ToDateTime(row["ImpEndDate"].ToString())
                                   );
                    itemsList.add(opportunityItem);

                }
            }*/
        }

        public Project getProject(int projectID)
        {
            throw new NotImplementedException();
        }

        public EProjectItemList getRemovedItems(int projectID, string month)
        {
            throw new NotImplementedException();
        }

        public EProjectItemList getWatchlistItems(int projectID, string month)
        {
            throw new NotImplementedException();
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
