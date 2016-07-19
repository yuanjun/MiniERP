using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CCWin;
using Lib.DAL;

namespace MBCar
{
    public partial class Login : Form
    {

        private MySqlConnection conn;
        private DataTable table;
        private MySqlDataAdapter dataAdapter;
        private MySqlCommandBuilder sqlComBuilder;

        public Login()
        {
            InitializeComponent();
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            string connStr = string.Format("server={0}; user id={1}; password={2}; database=mbcar; pooling=false",txt_ServerAddress.Text,txt_UserName.Text,txt_Password.Text);

            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                MessageBox.Show("链接成功");

                //获得数据库列表
                List<string> cmd = new List<string>();
                cmd.Add("SHOW DATABASES");
                List<string> list = getDataList(cmd);

                //清空下拉框
                cbb_DataBases.Items.Clear();
                //增加下拉框列表
                foreach(string str in list)
                {
                    cbb_DataBases.Items.Add(str);
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("没有找到数据库：" + ex.Message);
            }
        }

        private List<string> getDataList(List<string> cmdList)
        {
            List<string> result = new List<string>();

            //SQ数据读取器
            MySqlDataReader dataReader = null;

            //SQL命令执行器
            MySqlCommand sqlCmd = new MySqlCommand();

            // 设置SQL命令执行器的连接
            sqlCmd.Connection = conn;

            try
            {
                // 执行的SQL命令  
                foreach (string cmd in cmdList)
                {
                    sqlCmd.CommandText = cmd;
                    sqlCmd.ExecuteNonQuery();
                }
                //     
                dataReader = sqlCmd.ExecuteReader();

                while (dataReader.Read())
                {
                    string strDbName = dataReader.GetString(0);

                    result.Add(strDbName);
                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("读取数据失败：" + ex.Message);
            }
            finally
            {
                if(dataReader !=  null)
                {
                    dataReader.Close();
                }
            }

            return result;
        }

        private void cbb_DataBases_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 获得数据库列表  
            List<string> cmdList = new List<string>();
            cmdList.Add("USE " + cbb_DataBases.SelectedItem.ToString());
            cmdList.Add("SHOW TABLES");
            List<string> list = getDataList(cmdList);

            // 清空数据表列表              
            cbb_DataTables.Items.Clear();
            // 增加下拉框列表              
            foreach (string str in list)
                cbb_DataTables.Items.Add(str);
        }

        private void cbb_DataTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 获得数据表名称              
            string tableName = cbb_DataTables.SelectedItem.ToString();
            // 设置数据桥              
            dataAdapter = new MySqlDataAdapter("Select * from " + tableName, conn);
            // DataSet              
            sqlComBuilder = new MySqlCommandBuilder(dataAdapter);
            // 建立数据表              
            table = new DataTable(tableName);
            // 填充数据表到数据桥              
            dataAdapter.Fill(table);
            // 指定数据源              
            dataGridView1.DataSource = table;
        }

        private void btn_FindGD_Click(object sender, EventArgs e)
        {
            StringBuilder sqlText = new StringBuilder("select company_id from company_d");
            //string id = DBHelper.
            string id = null;
            DataTable dt = DBHelper.ExecuteQueryDT(sqlText.ToString());
            if(dt != null)
            {

                if(dt.Rows.Count > 0)
                {
                    id = dt.Rows[0][0].ToString();
                }
            }

            this.txt_GD.Text = id;
        }
    }
}
