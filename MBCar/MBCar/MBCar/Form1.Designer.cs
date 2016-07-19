namespace MBCar
{
    partial class Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.txt_ServerAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbb_DataBases = new System.Windows.Forms.ComboBox();
            this.cbb_DataTables = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt_GD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_FindGD = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Connect);
            this.groupBox1.Controls.Add(this.txt_Password);
            this.groupBox1.Controls.Add(this.txt_UserName);
            this.groupBox1.Controls.Add(this.txt_ServerAddress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 193);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接服务器";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(121, 160);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect.TabIndex = 6;
            this.btn_Connect.Text = "连接";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(89, 131);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(213, 21);
            this.txt_Password.TabIndex = 5;
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(89, 83);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(213, 21);
            this.txt_UserName.TabIndex = 4;
            // 
            // txt_ServerAddress
            // 
            this.txt_ServerAddress.Location = new System.Drawing.Point(89, 35);
            this.txt_ServerAddress.Name = "txt_ServerAddress";
            this.txt_ServerAddress.Size = new System.Drawing.Size(213, 21);
            this.txt_ServerAddress.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器地址";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(373, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "数据库";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(576, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "数据表";
            // 
            // cbb_DataBases
            // 
            this.cbb_DataBases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_DataBases.FormattingEnabled = true;
            this.cbb_DataBases.Location = new System.Drawing.Point(420, 25);
            this.cbb_DataBases.Name = "cbb_DataBases";
            this.cbb_DataBases.Size = new System.Drawing.Size(121, 20);
            this.cbb_DataBases.TabIndex = 3;
            this.cbb_DataBases.SelectedIndexChanged += new System.EventHandler(this.cbb_DataBases_SelectedIndexChanged);
            // 
            // cbb_DataTables
            // 
            this.cbb_DataTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_DataTables.FormattingEnabled = true;
            this.cbb_DataTables.Location = new System.Drawing.Point(623, 24);
            this.cbb_DataTables.Name = "cbb_DataTables";
            this.cbb_DataTables.Size = new System.Drawing.Size(121, 20);
            this.cbb_DataTables.TabIndex = 4;
            this.cbb_DataTables.SelectedIndexChanged += new System.EventHandler(this.cbb_DataTables_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(375, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(369, 134);
            this.dataGridView1.TabIndex = 5;
            // 
            // txt_GD
            // 
            this.txt_GD.Location = new System.Drawing.Point(72, 277);
            this.txt_GD.Name = "txt_GD";
            this.txt_GD.Size = new System.Drawing.Size(149, 21);
            this.txt_GD.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "工单号：";
            // 
            // btn_FindGD
            // 
            this.btn_FindGD.Location = new System.Drawing.Point(245, 275);
            this.btn_FindGD.Name = "btn_FindGD";
            this.btn_FindGD.Size = new System.Drawing.Size(75, 23);
            this.btn_FindGD.TabIndex = 8;
            this.btn_FindGD.Text = "查询";
            this.btn_FindGD.UseVisualStyleBackColor = true;
            this.btn_FindGD.Click += new System.EventHandler(this.btn_FindGD_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 352);
            this.Controls.Add(this.btn_FindGD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_GD);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbb_DataTables);
            this.Controls.Add(this.cbb_DataBases);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Name = "Login";
            this.Text = "测试";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.TextBox txt_ServerAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbb_DataBases;
        private System.Windows.Forms.ComboBox cbb_DataTables;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txt_GD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_FindGD;
    }
}

