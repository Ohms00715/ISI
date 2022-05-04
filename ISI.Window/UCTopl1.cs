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
    public partial class UCTopl1 : UserControl
    {
        //public MDI fMdi = (MDI)this.ParentForm.MdiParent;

        public UCTopl1()
        {
            InitializeComponent();
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public MAS101SuppilerForm _MAS101SuppilerForm { get; set; }
        private void BTSup_Click(object sender, EventArgs e)
        {
            
            MDI fMdi = (MDI)this.ParentForm.MdiParent;
            if (fMdi != null)
            {
               
                fMdi.callMdiChild("MAS100");
               
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MDI fMdi = (MDI)this.ParentForm.MdiParent;
            if (fMdi != null)
            {
                fMdi.callMdiChild("MAS200");
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MDI fMdi = (MDI)this.ParentForm.MdiParent;
            if (fMdi != null)
            {
                fMdi.callMdiChild("MAS300");
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            MDI fMdi = (MDI)this.ParentForm.MdiParent;
            if (fMdi != null)
            {
                fMdi.callMdiChild("MAS400");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MDI fMdi = (MDI)this.ParentForm.MdiParent;
            if (fMdi != null)
            {
                fMdi.callMdiChild("MAS500");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MDI fMdi = (MDI)this.ParentForm.MdiParent;
            if (fMdi != null)
            {
                fMdi.callMdiChild("MAS600");
            }
        }

        private void BTISI_Click(object sender, EventArgs e)
        {
            MDI fMdi = (MDI)this.ParentForm.MdiParent;
            if (fMdi != null)
            {
                fMdi.callMdiChild("TRN201");
            }
        }

        private void toolStripContainer1_Click(object sender, EventArgs e)
        {

        }

        private void panelT_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
