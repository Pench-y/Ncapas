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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void loguearse(String usuario, String password)
        {
            try
            {
                using (CrCrudEntities2 db = new CrCrudEntities2())
                {
                    
                    
                    byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(password);
                    byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
                    String contrasena = Convert.ToBase64String(tmpHash);
                    var lista = db.usuarios.Where(C => C.nombre_usuario == usuario && C.pass == contrasena);

                    if (lista.Count() == 1)
                    {
                        foreach (var Datos in lista.ToList())
                        {
                            if (Datos.rol == "admin")
                            {
                                MessageBox.Show("Bienvenido " + Datos.nombre_completo);
                            
                                Form admin = new Admin();
                                admin.Show();

                                this.Hide();
                            }
                            else if (Datos.rol == "user")
                            {
                                MessageBox.Show("Bienvenido " + Datos.nombre_completo);

                               Form home = new Home(Datos.id);
                               home.Show();

                                this.Hide();

                            }
                            else
                            {
                                MessageBox.Show("No se le ha asignado ningún rol al usuario");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña invalidos ", "alert");
                    }

                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Error = " + i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String usuario = Campo1.Text;
            String password = Campo2.Text;
            loguearse(usuario,password);    
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Vista.Registro registro = new Vista.Registro();
            registro.Show();
        }
    }
}
