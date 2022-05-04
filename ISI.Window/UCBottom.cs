using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISI.Window
{
    public partial class UCBottom : UserControl
    {
        public UCBottom()
        {
            InitializeComponent();
        }

       

        private void BTQC_Click(object sender, EventArgs e)
        {
            MDI fMdi = (MDI)this.ParentForm.MdiParent;
            if (fMdi != null)
            {
                fMdi.callMdiChild("REP103");

            }
        }

        private void BTISO_Click(object sender, EventArgs e)
        {
            MDI fMdi = (MDI)this.ParentForm.MdiParent;
            if (fMdi != null)
            {
                fMdi.callMdiChild("REP105");

            }
        }

        private void BTDef_Click(object sender, EventArgs e)
        {
            MDI fMdi = (MDI)this.ParentForm.MdiParent;
            if (fMdi != null)
            {
                fMdi.callMdiChild("REP104");

            }
        }

        private void BTStatus_Click(object sender, EventArgs e)
        {
            MDI fMdi = (MDI)this.ParentForm.MdiParent;
            if (fMdi != null)
            {
                fMdi.callMdiChild("REP106");

            }
        }

        private void BTMat_Click(object sender, EventArgs e)
        {
            MDI fMdi = (MDI)this.ParentForm.MdiParent;
            if (fMdi != null)
            {
                fMdi.callMdiChild("REP102");

            }
        }

        private void BTSup_Click(object sender, EventArgs e)
        {
            MDI fMdi = (MDI)this.ParentForm.MdiParent;
            if (fMdi != null)
            {
                fMdi.callMdiChild("REP101");
                
            }
        }

        private void BTISIRE_Click(object sender, EventArgs e)
        {
            MDI fMdi = (MDI)this.ParentForm.MdiParent;
            if (fMdi != null)
            {
                fMdi.callMdiChild("REP107");
            }
        }
    }
}
