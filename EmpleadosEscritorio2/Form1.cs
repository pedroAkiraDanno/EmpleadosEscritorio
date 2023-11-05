using System;
using System.Data;
using System.Windows.Forms;
using EmpleadosEscritorio2.datos;
using EmpleadosEscritorio2.modelo;

namespace EmpleadosEscritorio2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDocumento.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un documento válido");
            }
            else if (txtNombres.Text.Trim().Length < 5)
            {
                MessageBox.Show("Debe ingresar un nombre mas largo");
            }
            else
            {
                try
                {
                    Empleado em = new Empleado();
                    em.Apellidos = txtApellidos.Text.Trim().ToUpper();
                    em.Nombres = txtNombres.Text.Trim().ToUpper();
                    em.Direccion = txtDireccion.Text.Trim().ToUpper();
                    em.Documento = txtDocumento.Text.Trim();
                    em.Edad = Convert.ToInt32(txtEdad.Text.Trim());
                    em.Fecha_nacimiento = txtFechaNacimiento.Value.Year + "-" + txtFechaNacimiento.Value.Month + "-" + txtFechaNacimiento.Value.Day;

                    if (EmpleadoCAD.guardar(em))
                    {
                        llenarGrid();
                        limpiarCampos();
                        MessageBox.Show("Empleado guardado correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un empleado con este documento");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void llenarGrid()
        {
            DataTable datos = EmpleadoCAD.listar();
            if (datos == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }else
            {
                dgLista.DataSource = datos.DefaultView;
            }

        }

        private void limpiarCampos()
        {
            txtApellidos.Text = "";
            txtNombres.Text = "";
            txtDireccion.Text = "";
            txtDocumento.Text = "";
            txtEdad.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        bool consultado = false;
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtDocumento.Text.Trim()== "")
            {
                MessageBox.Show("Debe ingresar un documento");
            } else
            {
                Empleado em = EmpleadoCAD.consultar(txtDocumento.Text.Trim());
                if (em == null)
                {
                    MessageBox.Show("No existe el empleado con documento " + txtDocumento.Text);
                    limpiarCampos();
                    consultado = false;
                } else
                {
                    txtApellidos.Text = em.Apellidos;
                    txtNombres.Text = em.Nombres;
                    txtDireccion.Text = em.Direccion;
                    txtDocumento.Text = em.Documento;
                    txtEdad.Text = em.Edad.ToString();
                    txtFechaNacimiento.Text = em.Fecha_nacimiento;
                    consultado = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (consultado == false)
            {
                MessageBox.Show("Debe consultar algun empleado primero");
            }
            else if (txtDocumento.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un documento válido");
            }
            else if (txtNombres.Text.Trim().Length < 5)
            {
                MessageBox.Show("Debe ingresar un nombre mas largo");
            }
            else
            {
                try
                {
                    Empleado em = new Empleado();
                    em.Apellidos = txtApellidos.Text.Trim().ToUpper();
                    em.Nombres = txtNombres.Text.Trim().ToUpper();
                    em.Direccion = txtDireccion.Text.Trim().ToUpper();
                    em.Documento = txtDocumento.Text.Trim();
                    em.Edad = Convert.ToInt32(txtEdad.Text.Trim());
                    em.Fecha_nacimiento = txtFechaNacimiento.Value.Year + "-" + txtFechaNacimiento.Value.Month + "-" + txtFechaNacimiento.Value.Day;

                    if (EmpleadoCAD.actualizar(em))
                    {
                        llenarGrid();
                        limpiarCampos();
                        MessageBox.Show("Empleado actualizado correctamente");
                        consultado = false;
                    }
                    else
                    {
                        MessageBox.Show("No se actualizó");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (consultado == false)
            {
                MessageBox.Show("Debe consultar algun empleado primero");
            }
            else if (txtDocumento.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un documento válido");
            }
            else if (DialogResult.Yes == MessageBox.Show(null, "Realmente desea eliminar el registro?", "Confirmación", MessageBoxButtons.YesNo))
            {
                try
                {
                    if (EmpleadoCAD.eliminar(txtDocumento.Text.Trim()))
                    {
                        llenarGrid();
                        limpiarCampos();
                        MessageBox.Show("Empleado eliminado correctamente");
                        consultado = false;
                    }
                    else
                    {
                        MessageBox.Show("No se elimino el empleado");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
