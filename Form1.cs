using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoJG
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            RealizarOperacion(Matriz.Sumar);
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {
            RealizarOperacion(Matriz.Restar);
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            RealizarOperacionMulti(Matriz.Multiplicar);
        }

        private void RealizarOperacion(Func<Matriz, Matriz, Matriz> operacion)
        {
            try
            {
                Matriz matriz1 = ObtenerMatriz(txtMatriz1.Text);
                Matriz matriz2 = ObtenerMatriz(txtMatriz2.Text);

                if (matriz1.Filas != matriz2.Filas || matriz1.Columnas != matriz2.Columnas)
                {
                    MessageBox.Show("Las matrices deben tener las mismas dimenciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }


                MostrarMatriz(operacion(matriz1, matriz2));
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, introduce matrices válidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RealizarOperacionMulti(Func<Matriz, Matriz, Matriz> operacion)
        {
            try
            {
                Matriz matriz1 = ObtenerMatriz(txtMatriz1.Text);
                Matriz matriz2 = ObtenerMatriz(txtMatriz2.Text);

                if (matriz1.Columnas != matriz2.Filas)
                {
                    MessageBox.Show("El número de columnas de la primera matriz debe ser igual al número de filas de la segunda matriz.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }


                MostrarMatriz(operacion(matriz1, matriz2));
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, introduce matrices válidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Matriz ObtenerMatriz(string textoMatriz)
        {
            string[] filas = textoMatriz.Trim().Split('\n');
            int filasMatriz = filas.Length;
            int columnasMatriz = filas[0].Trim().Split(' ').Length;
            Matriz matriz = new Matriz(filasMatriz, columnasMatriz);

            for (int i = 0; i < filasMatriz; i++)
            {
                string[] valores = filas[i].Trim().Split(' ');
                for (int j = 0; j < columnasMatriz; j++)
                {
                    matriz[i, j] = int.Parse(valores[j]);
                }
            }

            return matriz;
        }

        private void MostrarMatriz(Matriz matriz)
        {
            txtResultado.Clear();
            for (int i = 0; i < matriz.Filas; i++)
            {
                for (int j = 0; j < matriz.Columnas; j++)
                {
                    txtResultado.Text += matriz[i, j] + " ";
                }
                txtResultado.Text += Environment.NewLine;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtMatriz1.Clear();
            txtMatriz2.Clear();
            txtResultado.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}







