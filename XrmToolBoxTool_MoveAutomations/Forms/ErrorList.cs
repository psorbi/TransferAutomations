using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBoxTool_MoveAutomations.AppCode;

namespace XrmToolBoxTool_MoveAutomations.Forms
{
    public partial class ErrorList : Form
    {
        public ErrorList()
        {
            InitializeComponent();
        }

        private void ErrorList_Load(object sender, EventArgs e)
        {

            ListView listView = new ListView();

            listView = lvErrors;
            listView.Items.Clear();

            foreach (KeyValuePair<string, string> error in ErrorHandling.Errors)
            {
                ListViewItem item = new ListViewItem();
                item.Text = error.Key;
                item.SubItems.Add(error.Value);

                listView.Items.Add(item);
            }

        }
    }
}
