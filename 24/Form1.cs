namespace _24
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool shod1 = false, shod2 = false;
        private double L1, R1, L2, R2;
        private void df_dx1()
        {
           if (Math.Abs(R1 / (2*Math.Pow(( 2 - (R1 * R1)), 1 / 2))) < 1)
            {
                shod1 = true;
            }
        }
        private void df_dx2()
        {
            //double FF = Math.Abs(4.0 / (3.0 * Math.Pow((4 * R2 + 4)* (4 * R2 + 4), 1 / 3)));
            if (Math.Abs((3 * R2 + 3) / (3 * Math.Pow(Math.Abs(4 * R2 + 4), (double)1 / 3)* (4 * R2 + 4) / Math.Abs(4 * R2 + 4))) < 1)
            {
                shod2 = true;
            }
            else
            {
                textBox3.Text = Convert.ToString(Math.Abs(4 / (3 * (Math.Pow(4 * R2 + 4, (2 / 3))))));
            }
        }

        private void x1()
        {
            R1 = Math.Pow(Math.Abs(4 * L2 + 4), (double)1 / 3) * (4 * L2 + 4) / Math.Abs(4 * L2 + 4);
        }
        private void x2()
        {
            R2 = Math.Sqrt(Math.Abs(2 - L1)) * (2 - L1) / Math.Abs(2 - L1);
        }
        private void x2_2()
        {
            R2 = Math.Sqrt(2 - R1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.R1 = Convert.ToDouble(textBox1.Text);
            this.R2 = Convert.ToDouble(textBox2.Text);
            df_dx1();
            df_dx2();
            if (shod1 & shod2)
            {
                if (radioButton1.Checked)
                {
                    do
                    {
                        L1 = R1;
                        L2 = R2;
                        x1();
                        x2();
                    } while ((Math.Sqrt(Math.Pow(L1 - R1, 2) + Math.Pow(L2 - R2, 2))) > 0.01);
                }
                else
                {
                    do
                    {
                        L1 = R1;
                        L2 = R2;
                        x1();
                        x2_2();
                    } while ((Math.Sqrt(Math.Pow(L1 - R1, 2) + Math.Pow(L2 - R2, 2))) > 0.01);
                }
                textBox4.Text = Convert.ToString(R2);
                textBox3.Text = Convert.ToString(R1);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
