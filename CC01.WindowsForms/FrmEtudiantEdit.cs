using CC01.BLL;
using CC01.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CC01.WindowsForms
{
    public partial class FrmEtudiantEdit : Form
    {

        private Action Callback;

        private Etudiant oldetudiant;
        private string CodeBar;

        public FrmEtudiantEdit()
        {
            InitializeComponent();
        }
        public FrmEtudiantEdit(Etudiant etudiant, Action callBack) : this(callBack)
        {
            this.oldetudiant = etudiant;
            txtFirst_name.Text = etudiant.First_Name;
            txtLast_name.Text = etudiant.Last_Name;
            txtDateNais.Text = etudiant.DateNais;
            txtLieu.Text = etudiant.LieuNais;
            txtContact.Text = etudiant.Contact;
            txtEmail.Text = etudiant.Email;
            pictureBox1.Image = etudiant.Photo != null ? Image.FromStream(new MemoryStream(etudiant.Photo)) : null;
        }
        public FrmEtudiantEdit(Action callback) : this()
        {
            this.Callback = callback;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Etudiant etudiant = new Etudiant(txtFirst_name.Text, txtLast_name.Text,
             txtDateNais.Text, txtLieu.Text, txtContact.Text, txtEmail.Text, null, null);
            EtudiantBLO etudiantBLO = new EtudiantBLO(ConfigurationManager.AppSettings["DbFolder"]);
            etudiantBLO.CreateEtudiant(etudiant);  

            MessageBox.Show
               (
               "Save done",
               "Confimation",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information
               );
            if (Callback != null)
                Callback();
            txtFirst_name.Clear();
            txtLast_name.Clear();
            txtDateNais.Clear();
            txtLieu.Clear();
            txtContact.Clear();
            txtEmail.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Choose a picture";
            ofd.Filter = " images files |*.jpg; *.jpeg;*.jpng;*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofd.FileName;

            }
        }
      

        
        }
    }

