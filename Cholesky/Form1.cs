using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cholesky
{
    public partial class Form1 : Form
    {
        int matrixSize;
        static int N;
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                matrixSize = int.Parse(tbInputNumber.Text);
            }
            catch
            {
                MessageBox.Show("Masukkan nilai dengan benar!");
                return;
            }
            tbInputNumber.Text = "";

            label6.Text = matrixSize.ToString() + " X " + matrixSize.ToString();

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();

            //jawaban
            //var colX1 = new DataGridViewColumn();
            //colX1.HeaderText = "answer";
            //colX1.CellTemplate = new DataGridViewTextBoxCell();
            //colX1.Width = 70;
            //dataGridView2.Columns.Add(colX1);

            //pertanyaan
            for (int i = 0; i < matrixSize; i++)
            {
                var column = new DataGridViewColumn();
                column.HeaderText = (i).ToString();
                column.CellTemplate = new DataGridViewTextBoxCell();
                column.Width = 30;
                dataGridView1.Columns.Add(column);

                if (i != matrixSize)
                {
                    dataGridView1.Rows.Add();
                }
            }

            //jawaban
            for (int i = 0; i < matrixSize; i++)
            {
                var colX1 = new DataGridViewColumn();
                colX1.HeaderText = (i).ToString();
                colX1.CellTemplate = new DataGridViewTextBoxCell();
                colX1.Width = 70;
                dataGridView2.Columns.Add(colX1);

                if (i != matrixSize)
                {
                    dataGridView2.Rows.Add();
                }
            }
            /*
            for (int j = 0; j < matrixSize; j++)
            {
                dataGridView1.Rows.Add();
            }*/

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("hahahaah");
            double[][] x_eq = new double[matrixSize][];
            //double[] y_eq = new double[matrixSize];
            double[][] L_eq = new double[matrixSize][];

            for (int i = 0; i < matrixSize; i++)
            {
                x_eq[i] = new double [matrixSize];
                L_eq[i] = new double[matrixSize];
                //r_eq[i] = 0;
                //y_eq[i] = double.Parse((string)dataGridView1.Rows[i].Cells[matrixSize].Value);
                for (int j = 0; j < matrixSize; j++)
                {
                    x_eq[i][j] = double.Parse((string)dataGridView1.Rows[i].Cells[j].Value);
                    Console.Write(x_eq[i][j] + "\t");
                }
                Console.WriteLine();
            }
            L_eq = Cholesky_method(x_eq);

            for(int i=0; i < matrixSize; i++)
            {
                for(int j = 0; j < matrixSize; j++)
                {
                    dataGridView2.Rows[i].Cells[j].Value = L_eq[i][j];
                    Console.Write(L_eq[i][j] + "\t");
                }
                Console.WriteLine();
            }


        }

        public static double[][] Cholesky_method (double [][] A)
        {
            //define the result variable
            double[][] _ret = new double[A.GetLength(0)][];
            for(int i=0; i<A.GetLength(0); i++)
            {
                _ret[i] = new double[A.GetLength(0)];
                for(int j=0; j<A.GetLength(0); j++)
                {
                    _ret[i][j] = 0.0;
                }
            }


            for(int i=0; i<A.GetLength(0); i++)
            {
                for (int k = 0; k<= i; k++)
                {

                    double sum = 0;
                    for (int j = 0; j < k; j++)
                    {
                        sum += _ret[i][j] * _ret[k][j];
                    }

                    if (i == k)
                    {
                        _ret[i][k] = Math.Sqrt(A[i][i] - sum);
                    }
                    else
                    {
                        _ret[i][k] = (1.0/_ret[k][k] *(A[i][k]-sum));
                    }
                }
            }
            return _ret;
        }


    }
}
