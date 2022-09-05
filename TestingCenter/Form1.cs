using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SetUp;
using SetUp.BLL;
namespace TestingCenter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ctrlRetrieve_Click(object sender, EventArgs e)
        {
            ctrlGrid.DataSource = ScreensBLL.Retrieve("", "ACU", false);

            //ctrlGrid.DataSource = ModulesBLL.Retrieve("2", "ACU", false);
        }

        private void ctrlDelete_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(ModulesBLL.DeletePermanently("2"));

        }

        private void ctrlSave_Click(object sender, EventArgs e)
        {
            Module item = new Module
            {
                UniversityCode = "ACU",
                Description = "Academics",
                Url = "http://127.0.0.1/UniversityPortalWeb/Academics",
                Notes = "Module for Academics",
                CreatedOn = DateTime.Now,
                CreatedBy = "Ademola"
            };
            MessageBox.Show(ModulesBLL.Insert(item));

            //SetUp.Semesters item = new SetUp.Screen
            //{
            //    Code = "STUP027",
            //    UniversityCode = "ACU",
            //    S = 3,
            //    ScreenDescription = "Universities",
            //    Url = "http://127.0.0.1/UniversityPortalWeb/SetUp/Universities",
            //    CreatedOn = DateTime.Now,
            //    CreatedBy = "Ademola",
            //    Deleted = false
                
            //};
            //MessageBox.Show(ScreensBLL.Insert(item));
        }
    }
}
