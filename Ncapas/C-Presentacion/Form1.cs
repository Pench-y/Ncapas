using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C_Negocio;

namespace C_Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Metodo para llenar el datagridview
        private void listar()
        {
            try
            {
                dgvDatos.DataSource = Negocio_Alumno.Listar();
                this.formato();
                lblTotal.Text = "Total registro: " + Convert.ToString(dgvDatos.Rows.Count);
                this.limpiar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        //Metodo para darle formato al datagried
        private void formato()
        {
            dgvDatos.Columns[0].Visible = false;//Seleccionar
            dgvDatos.Columns[1].Visible = false;//Id
            dgvDatos.Columns[2].Width = 200; //Nombre
            dgvDatos.Columns[3].Width = 200; //Apellido
            dgvDatos.Columns[4].Width = 70; //Edad
            dgvDatos.Columns[5].Visible = false; //Estado
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.listar();
        }

        //Metodo para buscar los registros
        private void Buscar()
        {
            try
            {
                dgvDatos.DataSource = Negocio_Alumno.Buscar(txtBuscar.Text);
                this.formato();
                lblTotal.Text = "Total registro: " + Convert.ToString(dgvDatos.Rows.Count);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        //Metodo limpiar campos
        private void limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEdad.Clear();
            btnInsertar.Visible = true;
            btnActulizar.Visible = false;
            error.Clear();

            dgvDatos.Columns[0].Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            btnEliminar.Visible = false;
            chkSeleccionar.Checked = false;
        }

        //Metodo control de mensaje error
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Control de Alumnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MensajeOk(String Mensaje)
        {
            MessageBox.Show(Mensaje, "Control de Alumnos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                //Validaciones
                if(txtNombre.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos del registro, estos serán marcados");
                    error.SetError(txtNombre,"Ingrese el nombre del alumno");
                    return;
                }
                if (txtApellido.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos del registro, estos serán marcados");
                    error.SetError(txtApellido, "Ingrese el apelldio del alumno");
                    return;
                }
                if (txtEdad.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos del registro, estos serán marcados");
                    error.SetError(txtEdad, "Ingrese la edad del alumno");
                    return;
                }

                //Envio informacion a la capa de negocios
                respuesta = Negocio_Alumno.Insertar(txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtEdad.Text));
                if (respuesta.Equals("OK"))
                {
                    this.MensajeOk("Se inserto de forma correcta el registro");
                    this.limpiar();
                    this.listar();
                }
                else
                {
                    this.MensajeError(respuesta);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

       private void btnCancelar_Click(object sender, EventArgs e)
        {
          this.limpiar();
          //tabG.SelectedIndex = 0;
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.limpiar();
                btnActulizar.Visible = true;
                btnInsertar.Visible = false;
                txtId.Text = Convert.ToString(dgvDatos.CurrentRow.Cells["Id"].Value);
                txtNombre.Text = Convert.ToString(dgvDatos.CurrentRow.Cells["Nombre"].Value);
                txtApellido.Text = Convert.ToString(dgvDatos.CurrentRow.Cells["Apellido"].Value);
                txtEdad.Text = Convert.ToString(dgvDatos.CurrentRow.Cells["Edad"].Value);
                //tabG.SelectedIndex = 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione desde la celda nombre");
            }
        }

        private void btnActulizar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                //Validaciones
                if (txtId.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos del registro, estos serán marcados");
                    error.SetError(txtId, "Ingrese el id del alumno");
                    return;
                }
                if (txtNombre.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos del registro, estos serán marcados");
                    error.SetError(txtNombre, "Ingrese el nombre del alumno");
                    return;
                }
                if (txtApellido.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos del registro, estos serán marcados");
                    error.SetError(txtApellido, "Ingrese el apelldio del alumno");
                    return;
                }
                if (txtEdad.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos del registro, estos serán marcados");
                    error.SetError(txtEdad, "Ingrese la edad del alumno");
                    return;
                }
                //Envio informacion a la capa de negocios
                respuesta = Negocio_Alumno.Actualizar(Convert.ToInt32(txtId.Text), txtNombre.Text, txtApellido.Text, Convert.ToInt32(txtEdad.Text));
                if (respuesta.Equals("OK"))
                {
                    this.MensajeOk("Se actualizo de forma correcta el registro");
                    this.limpiar();
                    this.listar();
                }
                else
                {
                    this.MensajeError(respuesta);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                dgvDatos.Columns[0].Visible = true;
                btnActivar.Visible = true;
                btnDesactivar.Visible = true;
                btnEliminar.Visible = true;
            }
            else
            {
                dgvDatos.Columns[0].Visible = false;
                btnActivar.Visible = false;
                btnDesactivar.Visible = false;
                btnEliminar.Visible = false;
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dgvDatos.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dgvDatos.Rows[e.RowIndex].Cells["Seleccionar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                string respuesta = "";
                int codigo;
                Opcion = MessageBox.Show("Realmente desea eliminar el registro del alumno", "Control de Alumnos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(Opcion == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[1].Value);
                            respuesta = Negocio_Alumno.Eliminar(codigo);
                            if (respuesta.Equals("ok"))
                            {
                                this.MensajeOk("Se eliminó el registro: "+ Convert.ToString(row.Cells[2].Value) + "" + Convert.ToString(row.Cells[3].Value));
                            }
                            else
                            {
                                this.MensajeError(respuesta);
                            }
                        }
                    }
                    this.listar();
                }               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                string respuesta = "";
                int codigo;
                Opcion = MessageBox.Show("Realmente desea activar el registro del alumno", "Control de Alumnos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[1].Value);
                            respuesta = Negocio_Alumno.Activar(codigo);
                            if (respuesta.Equals("ok"))
                            {
                                this.MensajeOk("Se activo el registro: " + Convert.ToString(row.Cells[2].Value) + "" + Convert.ToString(row.Cells[3].Value));
                            }
                            else
                            {
                                this.MensajeError(respuesta);
                            }
                        }
                    }
                    this.listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                string respuesta = "";
                int codigo;
                Opcion = MessageBox.Show("Realmente desea desactivar el registro del alumno", "Control de Alumnos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[1].Value);
                            respuesta = Negocio_Alumno.Desactivar(codigo);
                            if (respuesta.Equals("ok"))
                            {
                                this.MensajeOk("Se desactivo el registro: " + Convert.ToString(row.Cells[2].Value) + "" + Convert.ToString(row.Cells[3].Value));
                            }
                            else
                            {
                                this.MensajeError(respuesta);
                            }
                        }
                    }
                    this.listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
