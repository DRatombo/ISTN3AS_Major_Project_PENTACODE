using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cafe101;           // or your project's namespace
using RestaurantSystem; // if frmManageRecipes is in a different namespace

namespace Cafe101
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewOrder newOrder = new frmNewOrder();
            newOrder.Show();
        }

        private void mnuMenuItems_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is frmManageMenuItems)
                {
                    frm.BringToFront();
                    return;
                }
            }
            frmManageMenuItems frmMenu = new frmManageMenuItems();
           // frmMenu.MdiParent = this;
            frmMenu.Show();
        }

        private void mnuIngredients_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is frmManageIngredients)
                {
                    frm.BringToFront();
                    return;
                }
            }
            frmManageIngredients frmIng = new frmManageIngredients();
         //   frmIng.MdiParent = this;
            frmIng.Show();
        }

        private void mnuRecipes_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is frmManageRecipes)
                {
                    frm.BringToFront();
                    return;
                }
            }
            frmManageRecipes frmRecipe = new frmManageRecipes();
           // frmRecipe.MdiParent = this;
            frmRecipe.Show();
        }

        private void mnuCashiers_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is frmManageCashiers)
                {
                    frm.BringToFront();
                    return;
                }
            }
            frmManageCashiers frmCash = new frmManageCashiers();
          //  frmCash.MdiParent = this;
            frmCash.Show();
        }
    }
}
