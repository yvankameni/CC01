using CC01.BLL;
using CC01.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CC01.WindowsForms
{
    public partial class FrmEtudiantList : Form
    {
        private EtudiantBLO etudiantBLO;
        private Action Callbak;
        public FrmEtudiantList()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            etudiantBLO = new EtudiantBLO(ConfigurationManager.AppSettings["DbFolder"]);
        }

        public FrmEtudiantList(Action Callbak) : this()
        {
            this.Callbak = Callbak;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadData()
        {

            string value = txtSearch.Text.ToLower();
            var etudiants = etudiantBLO.GetBy(
                      x =>
                      x.First_Name.ToLower().Contains(value) ||
                      x.Last_Name.ToLower().Contains(value)
                  );

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = etudiants;
            lblRowCount.Text = $"{dataGridView1.RowCount} rows";
            dataGridView1.ClearSelection();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Form f = new FrmEtudiantEdit(loadData);
            f.Show();
        }

        private void FrmEtudiantList_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            loadData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
             List<EtudiantListPrint> items = new List<EtudiantListPrint>();
             for (int i = 0; i < dataGridView1.Rows.Count; i++)
             {
                 Etudiant E = dataGridView1.Rows[i].DataBoundItem as Etudiant;
                 items.Add(
                     new EtudiantListPrint(
                         E.First_Name,
                         E.Last_Name,
                         E.DateNais,
                         E.LieuNais,
                         E.Contact,
                         E.Email,
                         E.Photo,
                         E.CodeBar
                         )
                     );
             }
             Form f = new FrmPreview("ProductListRpt.rdlc", items);
             f.Show();
        }

        /*private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Choose a picture";
            ofd.Filter = " images files |*.jpg; *.jpeg;*.jpng;*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.ImageLocation = ofd.FileName;

            }
        }*/

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))

                loadData();
            else
                txtSearch.Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (
                    MessageBox.Show
                    (
                    "Do you really want to delete this product(s) ?",
                    "warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes
                    )
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        etudiantBLO.DeleteProduct(dataGridView1.SelectedRows[i].DataBoundItem as Etudiant);
                    }
                    loadData();
                }
            }
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
