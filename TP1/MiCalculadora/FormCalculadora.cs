using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            cmbOperador.Text = "+";
        }

        #region "Botones"
        /// <summary>
        /// Borra los datos de txtNumero1, txtNumero1, lblResultado, cmbOperador.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Hace la operacion entre dos numeros y lo muestra en lblResultado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string operador = cmbOperador.Text;
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = true;
        }

        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Convierte el resultado de la operacion ,situado en lblResultado, en binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if(lblResultado.Text != "")
            {
                lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
                btnConvertirABinario.Enabled = false;
                btnConvertirADecimal.Enabled = true;
            }
        }

        /// <summary>
        /// Convierte el resultado de la operacion ,situado en lblResultado, en decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "")
            {
                lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
                btnConvertirABinario.Enabled = true;
                btnConvertirADecimal.Enabled = false;
            }      
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Borra los datos de txtNumero1, txtNumero1, lblResultado, cmbOperador.
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperador.Text = "";
        }

        /// <summary>
        /// Hace una operacion entre dos numeros.
        /// Operadores permitidos: +(Suma), -(Resta), *(Multiplicacion), /(Division).
        /// </summary>
        /// <param name="numero1">Tipo string - Primer operando</param>
        /// <param name="numero2">Tipo string - Segundo operando</param>
        /// <param name="operador">Tipo string - Operador</param>
        /// <returns>Tipo double - Retorna el resultado de la operacion</returns>
        private static double Operar(string numero1,string numero2,string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            return Calculadora.Operar(num1, num2, operador);
        }
        #endregion

        #region "Eventos"
        /// <summary>
        /// Permite ingresar solamente numeros y un solo punto para decimales en txtNumero1 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumero1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo acepta un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Permite ingresar solamente numeros en txtNumero2 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumero2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo acepta un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// No permite escribir en cmbOperador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbOperador_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// En el se confirma la salida del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult salir = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.OKCancel);

            if (salir == DialogResult.OK)
            {
                e.Cancel = false;
            }
            else if(salir == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
        
        /// <summary>
        /// Llamo al metodo Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
        #endregion

    }
}
