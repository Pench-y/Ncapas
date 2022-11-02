using AppDesktop1.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDesktop1.Vista
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dvgClientes.Rows[dvgClientes.CurrentRow.Index].Cells[0].Value.ToString());

            Form producto = new Productos(id);
            producto.Show();


            /*this.Hide();*/
        }

        private void Admin_Load(object sender, EventArgs e)
        {

            using (CrCrudEntities2 db = new CrCrudEntities2())
            {
                
                var listado = from b in db.usuarios
                              select new {b.id, b.nombre_completo, b.rol};
                dvgClientes.DataSource = listado.ToList();
            }
        }
    }
}
