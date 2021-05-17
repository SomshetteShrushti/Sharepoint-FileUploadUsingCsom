using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;

namespace UploadingFiletoSharepointLib
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //To upoload file from local machine to the sharepoint site.
           
            using (ClientContext ctx = new ClientContext("http://vm-021-tzc02/sites/CSOMSite/"))
            {
                FileCreationInformation fileCreationInformation = new FileCreationInformation();
                fileCreationInformation.Url = "EmployeeReport.xls";
                fileCreationInformation.Overwrite = true;
                fileCreationInformation.Content = System.IO.File.ReadAllBytes("EmployeeReport.xls");

                Web web = ctx.Web;
                List myLIB = web.Lists.GetByTitle("Documents");
                myLIB.RootFolder.Files.Add(fileCreationInformation);
                ctx.ExecuteQuery();
            }
            MessageBox.Show("File Uploaded");
        }
    }
}
