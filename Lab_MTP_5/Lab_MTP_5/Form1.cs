using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Lab_MTP_5
{
    public partial class Form1 : Form
    {
        String string_conectare = "Provider=Microsoft.ACE.OLEDB.12.0; Data source=" + Application.StartupPath + "\\database.accdb;User ID=Admin;Password=;"; 
        string sql = "SELECT * FROM Studenti"; 
        OleDbConnection conexiune; 
        OleDbCommand comanda; 
        OleDbDataAdapter adaptor; 
        OleDbCommandBuilder construire_comenzi; 
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            conexiune = new OleDbConnection(string_conectare); 
            conexiune.Open();
            comanda = new OleDbCommand(sql, conexiune);
            dt = new DataTable();
            adaptor = new OleDbDataAdapter(comanda); 
            adaptor.Fill(dt);
            construire_comenzi = new OleDbCommandBuilder(adaptor);
            bindingSource1.DataSource = dt; 
            bindingSource1.Position = 0; 
            // legarea proprietății Text a casutei txtMatricol la campul Nr_matricol 
            textMatricol.DataBindings.Add(new Binding("Text",bindingSource1,"Nr_matricol",true));
            textNume.DataBindings.Add(new Binding("Text", bindingSource1, "Nume", true));
            textPrenume.DataBindings.Add(new Binding("Text", bindingSource1, "Prenume", true));
            dateTimePicker1.DataBindings.Add(new Binding("Text", bindingSource1, "Data_nasterii", true));
            comboFacultate.DataBindings.Add(new Binding("Text", bindingSource1, "Facultate", true));
            comboGrupa.DataBindings.Add(new Binding("Text", bindingSource1, "Grupa", true));
            comboNota1.DataBindings.Add(new Binding("Text", bindingSource1, "Nota1", true));
            comboNota2.DataBindings.Add(new Binding("Text", bindingSource1, "Nota2", true));
            comboNota3.DataBindings.Add(new Binding("Text", bindingSource1, "Nota3", true));
            comboNota4.DataBindings.Add(new Binding("Text", bindingSource1, "Nota4", true));
            comboNota5.DataBindings.Add(new Binding("Text", bindingSource1, "Nota5", true));

            bindingNavigator1.BindingSource = bindingSource1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if(bindingSource1.Count > 0)
            {
                DeleteDialog stergere = new DeleteDialog();
                if (stergere.ShowDialog(this) == DialogResult.OK)
                {
                    bindingSource1.RemoveCurrent();
                }
                else
                {

                }
                stergere.Dispose();
            }
            else
            {
                MessageBox.Show("Baza de date nu contine niciun student!","Atentie!");
            }
            
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }

        private void toolStripSeparator4_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string text = textMatricol.Text;
            bindingSource1.EndEdit(); 
            adaptor.Update(dt);
        }

        private void renuntareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.CancelEdit();
            groupBox1.Enabled = false;
        }

        private void Editare_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Cautare search = new Cautare(dt);
            search.Show();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            //float nota1 = com
        }
    }
}
