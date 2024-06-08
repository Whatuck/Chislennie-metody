using System.Windows.Forms;
using System.Runtime;
using System.Text.RegularExpressions;

namespace _15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int dimMatrix = 2;
            trackBar1.Value = dimMatrix;
            generate_matrix(trackBar1.Value);
        }

        void generate_matrix(int n)
        {
            int m = n + 1;
            dataGridView1.ColumnCount = m;
            dataGridView1.RowCount = n;
            for (int i = 0; i < m; i++)
            {
                dataGridView1.Columns[i].Width = (dataGridView1.Width - 3) / m;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int q = 1, n = trackBar1.Value;
            double s = 0;
            double[,] a = new double[n, n + 1];
            double[] x = new double[n];
            string patternInt = @"^\-?[0-9]+";
            bool chekInt = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    if (Regex.IsMatch(Convert.ToString(dataGridView1.Rows[i].Cells[j].Value), patternInt) & Convert.ToString(dataGridView1.Rows[i].Cells[j].Value) != null)
                    {
                        a[i, j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                    }
                    else
                    {
                        chekInt = false;
                    }
                    x[i] = 0;
                }
            }
            if (radioButton1.Checked & chekInt)
            {
                for (int k = 0; k < n; k++)
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n + 1; j++)
                        {
                            if (i > k & j > k)
                            {
                                a[i, j] = a[i, j] - ((a[i, k] * a[k, j]) / a[k, k]);
                            }
                        }
                for (int i = n - 1; i >= 0; i--)
                {
                    for (int j = n - 1; j >= 0; j--)
                    {
                        s += a[i, j] * x[j];
                    }
                    x[i] = Math.Round((1 / a[i, i]) * (a[i, n] - s));
                    s = 0;
                }
            }
            else if (radioButton2.Checked & chekInt)
            {//////////////////////////////////////
                for (int k = 0; k < n; k++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n + 1; j++)
                        {
                            if (i != k & j != k)
                            {
                                a[i, j] = a[i, j] - ((a[i, k] * a[k, j]) / a[k, k]);
                            }
                        }
                    }
                    for (int j = 0; j < n + 1; j++)
                        if (j != k)
                        {
                            a[k, j] = a[k, j] / a[k, k];
                        }
                    for (int i = 0; i < n; i++)
                        a[i, k] = 0;
                    a[k, k] = 1;
                }
                for (int i = n - 1; i >= 0; i--)
                {
                    x[i] = Math.Round((1 / a[i, i]) * a[i, n]);
                }
            }///////////////////////////////////////////
            if (chekInt)
            {
                textBox1.Text = "";
                for (int i = 0; i < n; i++)
                {
                    textBox1.Text += "X" + q + " = " + x[i].ToString() + "; ";
                    q++;
                }
            }
            else
            {
                textBox1.Text = "Один или несколько коэффицентов имеют не допустимое значение.";
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int dimMatrix = trackBar1.Value;
            generate_matrix(dimMatrix);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 4;
            trackBar1.Value = n;
            generate_matrix(trackBar1.Value);
            int[,] a = new int[n, n + 1];
            a[0, 0] = 2; a[0, 1] = 1; a[0, 2] = 3; a[0, 3] = 4; a[0, 4] = 29;
            a[1, 0] = 1; a[1, 1] = 3; a[1, 2] = -2; a[1, 3] = -1; a[1, 4] = -3;
            a[2, 0] = 4; a[2, 1] = -1; a[2, 2] = -1; a[2, 3] = 3; a[2, 4] = 11;
            a[3, 0] = 3; a[3, 1] = -2; a[3, 2] = 3; a[3, 3] = -2; a[3, 4] = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = Convert.ToString(a[i, j]);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
