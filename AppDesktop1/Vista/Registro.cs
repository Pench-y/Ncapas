using AppDesktop1.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDesktop1.Vista
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           using (CrCrudEntities2 db = new CrCrudEntities2())
            {
                byte[] tmpSource;
                byte[] tmpHash;

                usuarios lista = new usuarios();
                lista.nombre_usuario = textBox1.Text;
                lista.nombre_completo = textBox2.Text;
                tmpSource = ASCIIEncoding.ASCII.GetBytes(textBox3.Text);
                tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
                lista.pass = Convert.ToBase64String(tmpHash);
                lista.rol = textBox4.Text;
                
                db.usuarios.Add(lista);
                db.SaveChanges();
                this.Close();
                Vista.Login Log = new Vista.Login();
            }
        }
    }
}
