using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS.LoginSystem
{
    public partial class frmMainMenu : Form
    {
        NP_Cls NP = new NP_Cls(); private byte bLogOut = 0;
        private void _FrmShow(Form obj)
        {
            obj.MdiParent = this;
            obj.Show();
            if (obj.Name.Trim().Contains("MRPRun"))
            {
                obj.WindowState = FormWindowState.Maximized;
            }
            //obj.WindowState = FormWindowState.Maximized;
            obj.FormBorderStyle = FormBorderStyle.Fixed3D;
            obj.ControlBox = true;
            obj.BringToFront();
        }
        public frmMainMenu()
        {
            InitializeComponent();
            this.lblUser.Text = "Hi - " + NP_Cls.strUsr;
            this.lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", NP_Cls.cul);
        }
        private void frmMainMenu_Load(object sender, EventArgs e)
        {
              System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("Th-th");
              System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("Th-th");

              ManageMenu();
        }

        public void ManageMenu()
        {
            try
            {
                string[] strPer = NP_Cls.dsAuth.Tables[0].Rows[0]["Per"].ToString().Split(':');

                // Master
                if ((Convert.ToBoolean(strPer[0].ToString()) == false) && (Convert.ToBoolean(strPer[1].ToString()) == false) && (Convert.ToBoolean(strPer[2].ToString()) == false) && (Convert.ToBoolean(strPer[3].ToString()) == false) && (Convert.ToBoolean(strPer[4].ToString()) == false) && (Convert.ToBoolean(strPer[5].ToString()) == false) && (Convert.ToBoolean(strPer[6].ToString()) == false) && (Convert.ToBoolean(strPer[7].ToString()) == false) && (Convert.ToBoolean(strPer[8].ToString()) == false))
                {
                    this.dataMasterToolStripMenuItem.Visible = false;
                }
                else
                {
                    this.dataMasterToolStripMenuItem.Visible = true;
                    this.vendorMasterToolStripMenuItem.Visible = Convert.ToBoolean(strPer[0].ToString()); this.customerMasterToolStripMenuItem.Visible = Convert.ToBoolean(strPer[1].ToString()); this.currencyMasterToolStripMenuItem.Visible = Convert.ToBoolean(strPer[2].ToString()); this.plantMasterToolStripMenuItem.Visible = Convert.ToBoolean(strPer[3].ToString()); this.locationMasterToolStripMenuItem.Visible = Convert.ToBoolean(strPer[4].ToString()); this.materialGroupMasterToolStripMenuItem.Visible = Convert.ToBoolean(strPer[5].ToString()); this.unitOfMeasureMasterToolStripMenuItem.Visible = Convert.ToBoolean(strPer[6].ToString()); this.materialMasterToolStripMenuItem.Visible = Convert.ToBoolean(strPer[7].ToString()); this.departmentMasterToolStripMenuItem.Visible = Convert.ToBoolean(strPer[8].ToString());
                }


                // Authen
                if ((Convert.ToBoolean(strPer[9].ToString()) == false) && (Convert.ToBoolean(strPer[10].ToString()) == false))
                {
                    this.authToolStripMenuItem.Visible = false;
                }
                else
                {
                    this.authToolStripMenuItem.Visible = true;
                    this.employeeUserToolStripMenuItem.Visible = Convert.ToBoolean(strPer[9].ToString()); this.manageLevelToolStripMenuItem.Visible = Convert.ToBoolean(strPer[10].ToString());
                }
                
                // Puchasing
                if ((Convert.ToBoolean(strPer[11].ToString()) == false) && (Convert.ToBoolean(strPer[12].ToString()) == false))
                {
                    this.PurchasingToolStripMenuItem.Visible = false;
                }
                else { this.PurchasingToolStripMenuItem.Visible = true; this.vendorInfoRecordToolStripMenuItem.Visible = Convert.ToBoolean(strPer[11].ToString()); this.vendorSourceListToolStripMenuItem.Visible = Convert.ToBoolean(strPer[12].ToString()); }

                // Production
                if ((Convert.ToBoolean(strPer[13].ToString()) == false) && (Convert.ToBoolean(strPer[14].ToString()) == false) && (Convert.ToBoolean(strPer[15].ToString()) == false)
                     && (Convert.ToBoolean(strPer[16].ToString()) == false) && (Convert.ToBoolean(strPer[17].ToString()) == false)
                     && (Convert.ToBoolean(strPer[18].ToString()) == false))
                {
                    this.ProductionToolStripMenuItem.Visible = false;
                }
                else
                {
                    this.ProductionToolStripMenuItem.Visible = true;
                    this.workCenterMasterToolStripMenuItem.Visible = Convert.ToBoolean(strPer[13].ToString());
                    this.routingToolStripMenuItem1.Visible = Convert.ToBoolean(strPer[14].ToString());

                    this.productionOrderToolStripMenuItem.Visible = Convert.ToBoolean(strPer[15].ToString());
                    this.goodsIssueToolStripMenuItem.Visible = Convert.ToBoolean(strPer[16].ToString());
                    this.gRProductionToolStripMenuItem.Visible = Convert.ToBoolean(strPer[17].ToString());
                    this.productionCostToolStripMenuItem.Visible = Convert.ToBoolean(strPer[18].ToString());
                }

                //
                this.BOMToolStripMenuItem.Visible = Convert.ToBoolean(strPer[19].ToString());

                // Order 
                if ((Convert.ToBoolean(strPer[20].ToString()) == false) && (Convert.ToBoolean(strPer[21].ToString()) == false))
                {
                    this.pRPOToolStripMenuItem.Visible = false; this.pRToolStripMenuItem.Visible = false; this.pOToolStripMenuItem.Visible = false;
                }
                else { this.pRPOToolStripMenuItem.Visible = true; this.pRToolStripMenuItem.Visible = Convert.ToBoolean(strPer[20].ToString()); this.pOToolStripMenuItem.Visible = Convert.ToBoolean(strPer[21].ToString()); }

                // Goods
                if ((Convert.ToBoolean(strPer[22].ToString()) == false) && (Convert.ToBoolean(strPer[23].ToString()) == false))
                {
                    this.gRGRTToolStripMenuItem.Visible = false; this.gRToolStripMenuItem.Visible = false; this.gTToolStripMenuItem.Visible = false;
                }
                else
                {
                    this.gRGRTToolStripMenuItem.Visible = true; this.gRToolStripMenuItem.Visible = Convert.ToBoolean(strPer[22].ToString()); this.gTToolStripMenuItem.Visible = Convert.ToBoolean(strPer[23].ToString());
                }


                // SO 
                if ((Convert.ToBoolean(strPer[24].ToString()) == false) && (Convert.ToBoolean(strPer[25].ToString()) == false))
                {
                    this.sOToolStripMenuItem.Visible = false; this.sOToolStripMenuItem1.Visible = false; this.deliveryOrderDOToolStripMenuItem.Visible = false;
                }
                else { this.sOToolStripMenuItem.Visible = true; this.sOToolStripMenuItem1.Visible = Convert.ToBoolean(strPer[24].ToString()); this.deliveryOrderDOToolStripMenuItem.Visible = Convert.ToBoolean(strPer[25].ToString()); }

                this.mRPToolStripMenuItem.Visible = Convert.ToBoolean(strPer[24].ToString());

                //MRP
                if (Convert.ToBoolean(strPer[26].ToString()) == false)
                {
                    this.mRPToolStripMenuItem.Visible = false;
                }
                else
                {
                    this.mRPToolStripMenuItem.Visible = Convert.ToBoolean(strPer[26].ToString());
                }

                // Stock
                if ((Convert.ToBoolean(strPer[27].ToString()) == false) && (Convert.ToBoolean(strPer[28].ToString()) == false) && (Convert.ToBoolean(strPer[29].ToString()) == false))
                {
                    this.stockOverviewToolStripMenuItem.Visible = false; this.overviewToolStripMenuItem.Visible = false;
                    this.transferStockToolStripMenuItem.Visible = false; this.matrialMovementToolStripMenuItem.Visible = false;
                }
                else
                {
                    this.stockOverviewToolStripMenuItem.Visible = true;
                    this.overviewToolStripMenuItem.Visible = Convert.ToBoolean(strPer[27].ToString());
                    this.transferStockToolStripMenuItem.Visible = Convert.ToBoolean(strPer[28].ToString());
                    this.matrialMovementToolStripMenuItem.Visible = Convert.ToBoolean(strPer[29].ToString());
                }


                // Stock
                if ((Convert.ToBoolean(strPer[27].ToString()) == false) && (Convert.ToBoolean(strPer[28].ToString()) == false) && (Convert.ToBoolean(strPer[29].ToString()) == false))
                {
                    this.stockOverviewToolStripMenuItem.Visible = false; this.overviewToolStripMenuItem.Visible = false;
                    this.transferStockToolStripMenuItem.Visible = false; this.matrialMovementToolStripMenuItem.Visible = false;
                }
                else
                {
                    this.stockOverviewToolStripMenuItem.Visible = true; 
                    this.overviewToolStripMenuItem.Visible = Convert.ToBoolean(strPer[27].ToString());
                    this.transferStockToolStripMenuItem.Visible = Convert.ToBoolean(strPer[28].ToString()); 
                    this.matrialMovementToolStripMenuItem.Visible = Convert.ToBoolean(strPer[29].ToString());
                }

                //Approve 
                NP_Cls.AppBOM = Convert.ToByte(Convert.ToBoolean(strPer[30].ToString())); NP_Cls.AppPR = Convert.ToByte(Convert.ToBoolean(strPer[31].ToString()));
                NP_Cls.AppPO = Convert.ToByte(Convert.ToBoolean(strPer[32].ToString())); NP_Cls.AppSO = Convert.ToByte(Convert.ToBoolean(strPer[33].ToString()));
            }
            catch
            {
                NP.MSGB(NP_Cls.NPMgsStyle.WarningType, "You have not Perrmission to use this Program !!\nPlease contact your Administrator ..");
                Application.Exit(); return;
            }
         
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", NP_Cls.cul);
        }
        private void frmMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bLogOut == 1)
            {
                frmLogin frm = (frmLogin)Application.OpenForms["frmLogin"];
                frm.Show(); frm.BringToFront();
                e.Cancel = false;
            }
            else
            {
                if (NP.MSGB("Do you want to exit program ?") == DialogResult.Yes)
                {
                    frmLogin frm = (frmLogin)Application.OpenForms["frmLogin"];
                    frm.Close();
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        private void vendorMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new WMS.MasterData.frmVendorMaster());
        }
        private void currencyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new WMS.MasterData.frmCurrencyMaster());
        }
        private void customerMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new WMS.MasterData.frmCustomerMaster());
        }
        private void plantMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new WMS.MasterData.frmPlantMaster());
        }
        private void locationMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new WMS.MasterData.frmLocationMaster());
        }
        private void materialGroupMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new WMS.MasterData.frmMaterialGroupMaster());
        }
        private void unitOfMeasureMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new WMS.MasterData.frmUnitMaster());
        }
        private void materialMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new WMS.MasterData.frmMaterialMaster());
        }
        private void workCenterMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new WMS.MasterData.frmWorkCenterMaster());
        }
        private void vendorInfoRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new WMS.VendorTrans.frmVendorInfo());
        }
        private void vendorSourceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new WMS.VendorTrans.frmVendorSourceList());
        }
        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new WMS.BOM.frmBOMNew());
        }
        private void departmentMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new WMS.MasterData.frmDepartmentMaster());
        }
        private void employeeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new WMS.Authorization.frmEmpUserMaster());
        }
        private void routingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _FrmShow(new WMS.Routing.frmRounting());
        }
        private void workCenterMasterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            _FrmShow(new WMS.MasterData.frmWorkCenterMaster());
        }
        private void manageLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new WMS.Authorization.frmAuthLevel());
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NP.MSGB("Do you want to Log out ?") == DialogResult.Yes)
            {
                this.bLogOut = 1; this.Close();
            }
            else
            {
                this.bLogOut = 0;
                return;
            }
        }

        private void pRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new PR_PO.frmPR());
        }

        private void pOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new PR_PO.frmPO());
        }

        private void gRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new GRc_GRt.frmGoodsReceipt());
        }

        private void gTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new GRc_GRt.frmGoodsReturn());
        }

        private void sOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _FrmShow(new SaleTranSac.frmSaleOrder());
        }

        private void deliveryOrderDOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new SaleTranSac.frmDO());
        }

        private void mRPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new BOM.frmMRPRunningNew());
        }

        private void productionOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new SaleTranSac.frmPrdOrder());
        }

        private void gRProductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new SaleTranSac.frmGRProduction());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void goodsIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new SaleTranSac.frmGI());
        }

        private void overviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new Stock.frmStockOverView());
        }

        private void transferStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new Stock.frmTransferStatus());
        }

        private void productionCostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new Routing.frmProductionCost());
        }

        private void matrialMovementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new Stock.frmMaterialMovement());
        }

        private void ProdOrderNoJobItem_Click(object sender, EventArgs e)
        {
            _FrmShow(new SaleTranSac.frmBorrow());
        }


    }
}
