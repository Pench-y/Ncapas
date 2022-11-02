using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppDesktop1.Modelo;


namespace AppDesktop1
{
    public partial class Home : Form
    {
        public int ide;

        public Home(int ide)
        {
            InitializeComponent();
            this.ide = ide;
        }

        private void GoLogin_Click(object sender, EventArgs e)
        {
            Form login = new Vista.Login();
                login.Show();
            

            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void obtenerDatos()
        {
            using (CrCrudEntities2 db = new CrCrudEntities2())
            {
                var listado = from b in db.datos
                              select new {b.id,b.producto,b.valor,b.fk_usuarios};
                dataGridView1.DataSource = listado.ToList();
                foreach (int vt in listado.Select(d => d.valor))
                {
                    textBox1.Text += vt.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int? id = null;
            Vista.Form2 formCrea = new Vista.Form2(ide,id);
            formCrea.ShowDialog();
            obtenerDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            if(id != null)
            {
                Vista.Form2 edit = new Vista.Form2(ide,id);
                edit.ShowDialog();
                obtenerDatos();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            if (id != null)
            {
                using (CrCrudEntities2 db = new CrCrudEntities2())
                {
                    datos listado = db.datos.Find(id);
                    db.datos.Remove(listado);
                    db.SaveChanges();
                }
                obtenerDatos();
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Home_Load(object sender, EventArgs e)
        {
            obtenerDatos();
        }
    }
}
