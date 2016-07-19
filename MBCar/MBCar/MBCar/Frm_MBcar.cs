using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace MBCar
{
    public partial class Frm_MBCar : Form
    {

        //收银
        private Frm_Cashier frm_Cashier = null;

        //会员
        private Frm_Members frm_Members = null;

        //维修美容
        private Frm_Maintenance frm_Maintenance = null;

        //保险
        private Frm_Insurance frm_Insurance = null;

        //回访和满意度
        private Frm_ReturnToVisit frm_ReturnToVisit = null;


        public Frm_MBCar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 收银
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripItem_Cashier_Click(object sender, EventArgs e)
        {
            if(frm_Cashier == null || frm_Cashier.IsDisposed)
            {
                frm_Cashier = new Frm_Cashier();
            }

            frm_Cashier.TopLevel = false;
            frm_Cashier.Dock = DockStyle.Fill;
            frm_Cashier.Show(this.dockPnlForm, DockState.Document);
        }

        /// <summary>
        /// 会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripItem_Member_Click(object sender, EventArgs e)
        {
            if(frm_Members == null || frm_Members.IsDisposed)
            {
                frm_Members = new Frm_Members();
            }

            frm_Members.TopLevel = false;
            frm_Members.Dock = DockStyle.Fill;
            frm_Members.Show(this.dockPnlForm, DockState.Document);
        }

        /// <summary>
        /// 维修美容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripItem_Maintenance_Click(object sender, EventArgs e)
        {
            if (frm_Maintenance == null || frm_Maintenance.IsDisposed)
            {
                frm_Maintenance = new Frm_Maintenance();
            }

            frm_Maintenance.TopLevel = false;
            frm_Maintenance.Dock = DockStyle.Fill;
            frm_Maintenance.Show(this.dockPnlForm, DockState.Document);
        }

        /// <summary>
        /// 保险
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripItem_Insurance_Click(object sender, EventArgs e)
        {
            if (frm_Insurance == null || frm_Insurance.IsDisposed)
            {
                frm_Insurance = new Frm_Insurance();
            }

            frm_Insurance.TopLevel = false;
            frm_Insurance.Dock = DockStyle.Fill;
            frm_Insurance.Show(this.dockPnlForm, DockState.Document);
        }

        /// <summary>
        /// 回访及满意度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripItem_ReturnVisit_Click(object sender, EventArgs e)
        {
            if (frm_ReturnToVisit == null || frm_ReturnToVisit.IsDisposed)
            {
                frm_ReturnToVisit = new Frm_ReturnToVisit();
            }

            frm_ReturnToVisit.TopLevel = false;
            frm_ReturnToVisit.Dock = DockStyle.Fill;
            frm_ReturnToVisit.Show(this.dockPnlForm, DockState.Document);
        }

        /// <summary>
        /// 退出主窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripItem_Exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
