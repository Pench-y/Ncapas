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
    public partial class Form2 : Form
    {
        public int? id;
        public int ide;
        datos lista = null;

        public Form2(int ide,int? id = null)
        {
            InitializeComponent();
            this.ide = ide;
            this.id = id;
            if (id != null) 
            {
                cargarDatosFormulario();
            }
            

            
        }

        private void cargarDatosFormulario()
        {
            using (CrCrudEntities2 db = new CrCrudEntities2())
            {
                lista = db.datos.Find(id);
                textBox1.Text = lista.producto;
                textBox2.Text = lista.valor.ToString(); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (CrCrudEntities2 db = new CrCrudEntities2())
            {
                if (id == null)
                {
                    lista = new datos();
                }
                                 
                lista.producto = textBox1.Text;
                lista.valor = int.Parse(textBox2.Text);
                lista.fk_usuarios = ide;
                if(id == null)
                {
                    db.datos.Add(lista);
                }
                else
                {
                    db.Entry(lista).State = System.Data.Entity.EntityState.Modified;
                }

                db.datos.Add(lista);
                db.SaveChanges();
                this.Close();
            }
        }
    }
}
