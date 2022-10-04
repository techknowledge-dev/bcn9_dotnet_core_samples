using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csDataSetCoreSample
{
    public partial class frmMain : Form
    {
        static BtLib.Ddf d;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            try
            {
                d = new BtLib.Ddf(@"btrv:///demodata");
                BtLib.Record r = d.GetRecord("person");
                r.Open();
                DataSet ds = r.GetDataSet();
                dg.DataSource = ds.Tables["person"];
                r.Close();
                r.Dispose();
                d.Dispose();
            }
            catch (System.Exception er)
            {
                System.Diagnostics.Debug.WriteLine(er.ToString());
            }
        }
    }
}
