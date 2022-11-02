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
    public partial class Productos : Form
    {
        public int ide;
        public Productos(int ide)
        {
            InitializeComponent();
            this.ide = ide;
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            using (CrCrudEntities2 db = new CrCrudEntities2())
            {
                var listado = db.datos.Where(C => C.fk_usuarios == ide);
                /*var listado = from b in db.datos
                              select new { b.id, b.producto, b.valor, b.fk_usuarios };*/
                dataGridView1.DataSource = listado.ToList();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
