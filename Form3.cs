using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DoyoAMK
{
    public partial class FormVisorTablas : System.Windows.Forms.Form
    {
        private string nombreTablaVisualizada;
        public FormVisorTablas(string nombreTabla)
        {
            InitializeComponent();
            this.nombreTablaVisualizada = nombreTabla;
            try
            {
                SqlConnection coneccion = new SqlConnection("Data Source =.; Initial Catalog = DB_sipalki_data; Integrated Security = True");
                coneccion.Open();
                MessageBox.Show("Se ha conectado correctamente","Doyo AMK");
            }
            catch
            {
                MessageBox.Show("No se ha podido conectar con la BDD","Doyo AMK");

            }

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void FormVisorTablas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dB_sipalki_dataDataSet3.Disciplinas' Puede moverla o quitarla según sea necesario.
            this.disciplinasTableAdapter1.Fill(this.dB_sipalki_dataDataSet3.Disciplinas);
            // TODO: esta línea de código carga datos en la tabla 'dB_sipalki_dataDataSet1.armas_e_indumentaria' Puede moverla o quitarla según sea necesario.
            this.armas_e_indumentariaTableAdapter.Fill(this.dB_sipalki_dataDataSet1.armas_e_indumentaria);
            // TODO: esta línea de código carga datos en la tabla 'dB_sipalki_dataDataSet1.Disciplinas' Puede moverla o quitarla según sea necesario.
            this.disciplinasTableAdapter.Fill(this.dB_sipalki_dataDataSet1.Disciplinas);
            // TODO: esta línea de código carga datos en la tabla 'dB_sipalki_dataDataSet.alumnos' Puede moverla o quitarla según sea necesario.
            if (this.nombreTablaVisualizada == "Alumnos")
            {
                this.alumnosTableAdapter.Fill(this.dB_sipalki_dataDataSet.alumnos);
                this.dataGridView1.DataSource = "alumnosBindingSource";
            }
            else if (this.nombreTablaVisualizada == "Disciplinas")
            {
     
                this.dataGridView1.DataSource = "disciplinasBindingSource";
                this.disciplinasTableAdapter1.Fill(this.dB_sipalki_dataDataSet3.Disciplinas);
            }
            else if (this.nombreTablaVisualizada == "Inventario")
            {
                this.dataGridView1.DataSource = "armaseindumentariaBindingSource";
                this.armas_e_indumentariaTableAdapter.Fill(this.dB_sipalki_dataDataSet1.armas_e_indumentaria);
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }
    }
}
