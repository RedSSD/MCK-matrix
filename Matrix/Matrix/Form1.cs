using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix
{
    public partial class Form1 : Form
    {
        int Rows1, Rows2;
        int Columns1, Columns2;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a matrix in dataGridView
        /// </summary>
        /// <param name="length">textbox with column quantity</param>
        /// <param name="matrix">dataGridView to change</param>
        void CreateMatrix(TextBox length, ref DataGridView matrix)
        {
            matrix.Columns.Clear();
            matrix.Rows.Clear();
            
            int matrixLength = Convert.ToInt32(length.Text);
            for (int i = 1;i<=matrixLength;i++) { matrix.Columns.Add("", ""); }
            
        }

        /// <summary>
        /// Gets data from dataGridView and sets it to array
        /// </summary>
        /// <param name="matrix">dataGridView</param>
        /// <param name="arr">arr to set</param>
        void GetData(DataGridView matrix, ref int[,] arr)
        {
            for (int i = 0; i < matrix.RowCount-1; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    arr[i, j] = Convert.ToInt32( matrix.Rows[i].Cells[j].Value);
                }
            }

        }

        /// <summary>
        /// Main fuction with matrix calculation
        /// </summary>
        /// <param name="m1">1st matrix</param>
        /// <param name="m2">2nd matrix</param>
        /// <returns></returns>
        string CalculateMatrix(int[,] m1, int[,] m2)
        {
            int m = Columns1;
            int[,] result = new int[Rows1, Columns2];

            for (int i = 0; i < Rows1; i++)
            {
                for (int j = 0; j < Columns2; j++)
                {
                    int sum = 0;
                    for (int t = 0; t < m; t++)
                    {
                        sum += m1[i, t] * m2[t, j];
                    }
                    result[i, j] = sum;
                }
            }

            string TO_RETURN = "";
            for (int i = 0; i < Rows1; i++)
            {
                
                for (int j = 0; j < Columns2; j++)
                {
                    TO_RETURN += $"{result[i, j]}  ";
                    
                }
                TO_RETURN += "\n";
                
            }
            return TO_RETURN;
        }

        /// <summary>
        /// Button to calculate answer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Rows1 = dataGridView1.RowCount - 1;
            Rows2 = dataGridView2.RowCount - 1;
            Columns1 = dataGridView1.ColumnCount;
            Columns2 = dataGridView2.ColumnCount;

            int[,] m1 = new int[Rows1, Columns1];
            int[,] m2 = new int[Rows2, Columns2];

            GetData(dataGridView1, ref m1);
            GetData(dataGridView2, ref m2);

            label1.Text = CalculateMatrix(m1, m2);
         

        }

        /// <summary>
        /// Button to create matrixes in dataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            CreateMatrix(textBox1, ref dataGridView1);
            CreateMatrix(textBox2, ref dataGridView2);
        }
    }
}
