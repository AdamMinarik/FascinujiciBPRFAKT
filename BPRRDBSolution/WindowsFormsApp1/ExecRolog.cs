using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;


namespace WindowsFormsApp1
{
    public partial class ExecRolog : Form
    {
        private ERisk riskItem;
        private SqlConnectionStringBuilder connectionString;
        private DataTable dataSourceERisk;
        private SqlDataAdapter dataAdapterERisk;


        public ExecRolog()
        {
            InitializeComponent();
            setERiskItem();

            MessageBox.Show(riskItem.ToString());
        }

        public void setLocationLabel(String value)
        {
            locationLabel.Text = value;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void createItemButton_Click(object sender, EventArgs e)
        {
            if (this.createRiskButton.Visible == false)
            {
                this.createRiskButton.Visible = true;
                //System.Threading.Thread.Sleep(20);
                this.createPIButton.Visible = true;
                //System.Threading.Thread.Sleep(20);
                this.createOppButton.Visible = true;
                //System.Threading.Thread.Sleep(20);
                this.createERButton.Visible = true;
                //System.Threading.Thread.Sleep(20);
                this.createOUButton.Visible = true;
            }
            else
            {
                this.createOUButton.Visible = false;
                System.Threading.Thread.Sleep(20);
                this.createERButton.Visible = false;
                System.Threading.Thread.Sleep(20);
                this.createOppButton.Visible = false;
                System.Threading.Thread.Sleep(20);
                this.createPIButton.Visible = false;
                System.Threading.Thread.Sleep(20);
                this.createRiskButton.Visible = false;
            }
        }

        private void overviewButton_Click(object sender, EventArgs e)
        {

        }




        private void setERiskItem()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "riskdbsserver.database.windows.net";
            builder.UserID = "superuser@riskdbsserver";
            builder.Password = "Greenpear@1";
            builder.InitialCatalog = "[EW_Risk_Test]";
            connectionString = builder;

            SqlConnection connection = new SqlConnection(connectionString.ConnectionString);
            connection.Open();
            string SQL = "SELECT * FROM rk_ROlog WHERE ID = 3";
          
            dataAdapterERisk = new SqlDataAdapter(SQL, connection);
            dataSourceERisk = new DataTable();
            dataAdapterERisk.Fill(dataSourceERisk);

            foreach (DataRow row in dataSourceERisk.Rows)
            {
                // TODO : Assign data to constructor from the Query

                MessageBox.Show(row["Rname"].ToString());

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


                //Console.WriteLine(Convert.ToInt64(Convert.ToDecimal(row["ID"].ToString())));
                //Console.WriteLine(row["ExcelID"].ToString());
                //Console.WriteLine(row["Rname"].ToString());
                //Console.WriteLine(row["RootCause"].ToString());
                //Console.WriteLine(row["OtherRootCause"].ToString());
                //Console.WriteLine(row["MitDesc"].ToString());
                //Console.WriteLine(row["rkDesc"].ToString());
                //Console.WriteLine(row["ImpactDirect"].ToString());
                //Console.WriteLine(row["formula"].ToString());
                //Console.WriteLine(row["forDesc"].ToString());
                //Console.WriteLine(row["Impact"].ToString());
                //Console.WriteLine(row["calcDescAfter"].ToString());
                //Console.WriteLine(row["remarks"].ToString());
                //Console.WriteLine(Convert.ToInt32(row["Status"].ToString()));
                //Console.WriteLine(Convert.ToInt32(row["ID_customerShare"].ToString()));
                //Console.WriteLine(Convert.ToInt32(row["IDcat"].ToString()));
                //Console.WriteLine(Convert.ToDouble(row["P"].ToString()));
                //Console.WriteLine(Convert.ToInt32(row["reStrategy"].ToString()));
                //Console.WriteLine(Convert.ToInt32(row["ID_riskActionOwner"].ToString()));
                //Console.WriteLine(Convert.ToDouble(row["pAfter"].ToString()));
                //Console.WriteLine(Convert.ToInt32(row["IDowner"].ToString()));
                //Console.WriteLine(Convert.ToInt32(row["ID_Phase"].ToString()));
                //Console.WriteLine(Convert.ToInt32(row["ID_WBS"].ToString()));
                //Console.WriteLine(Convert.ToInt32(row["ExpValueDays"].ToString()));
                //Console.WriteLine(Convert.ToInt32(row["ID_resp"].ToString()));
                //Console.WriteLine(Convert.ToInt32(row["IDOwnerDirect"].ToString()));
                //Console.WriteLine(Convert.ToInt32(row["expValueDaysAfter"].ToString()));
                //Console.WriteLine(Convert.ToInt32(row["BU"].ToString()));
                //Console.WriteLine(Convert.ToInt32(row["IDncc"].ToString()));
                //Console.WriteLine(Convert.ToInt32(row["OriginatingID"].ToString()));
                //Console.WriteLine(Convert.ToBoolean(row["timeObjective"].ToString()));
                //Console.WriteLine(Convert.ToBoolean(row["costObjective"].ToString()));
                //Console.WriteLine(Convert.ToBoolean(row["costSatisfObjective"].ToString()));
                //Console.WriteLine(Convert.ToBoolean(row["safetyfObjective"].ToString()));
                //Console.WriteLine(Convert.ToBoolean(row["qualityObjective"].ToString()));
                //Console.WriteLine(Convert.ToDouble(row["MitCost"].ToString()));
                //Console.WriteLine(Convert.ToDouble(row["rkBef"].ToString()));
                //Console.WriteLine(Convert.ToDouble(row["valAfterMiti"].ToString()));
                //Console.WriteLine(Convert.ToDateTime(row["createDate"].ToString()));
                //Console.WriteLine(Convert.ToDateTime(row["updateDate"].ToString()));
                //Console.WriteLine(Convert.ToDateTime(row["mitDate"].ToString()));
                //Console.WriteLine(Convert.ToDateTime(row["mitiActDate"].ToString()));
                //Console.WriteLine(Convert.ToDateTime(row["DueDate"].ToString()));
                //Console.WriteLine(Convert.ToDateTime(row["ImpEndDate"].ToString()));


            }

            connection.Close();
        }
    }


    
}
