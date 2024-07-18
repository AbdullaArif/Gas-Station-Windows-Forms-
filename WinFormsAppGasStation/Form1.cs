namespace WinFormsAppGasStation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Variable
        double tankGasoline95 = 0, tankGasoline97 = 0, tankDiesel = 0, tankEuroDiesel = 0, tankLpg = 0;
        double addGasoline95 = 0, addGasoline97 = 0, addDiesel = 0, addEuroDiesel = 0, addLpg = 0;
        double priceGasoline95 = 0, priceGasoline97 = 0, priceDiesel = 0, priceEuroDiesel = 0, priceLpg = 0;
        double sellGasoline95 = 0, sellGasoline97 = 0, sellDiesel = 0, sellEuroDiesel = 0, sellLpg = 0;
        string[] tankInformation;
        string[] priceInformation;

        private void txtTankRead()
        {
            tankInformation = System.IO.File.ReadAllLines(Application.StartupPath + "\\tank.txt");
            tankGasoline95 = Convert.ToDouble(tankInformation[0]);
            tankGasoline97 = Convert.ToDouble(tankInformation[1]);
            tankDiesel = Convert.ToDouble(tankInformation[2]);
            tankEuroDiesel = Convert.ToDouble(tankInformation[3]);
            tankLpg = Convert.ToDouble(tankInformation[4]);
        }
        private void txtTankWrite()
        {
            label6.Text = tankGasoline95.ToString("N");
            label7.Text = tankGasoline97.ToString("N");
            label8.Text = tankDiesel.ToString("N");
            label9.Text = tankEuroDiesel.ToString("N");
            label10.Text = tankLpg.ToString("N");
        }
        private void txtPriceRead()
        {
            priceInformation = System.IO.File.ReadAllLines(Application.StartupPath + "\\price.txt");
            priceGasoline95 = Convert.ToDouble(priceInformation[0]);
            priceGasoline97 = Convert.ToDouble(priceInformation[1]);
            priceDiesel = Convert.ToDouble(priceInformation[2]);
            priceEuroDiesel = Convert.ToDouble(priceInformation[3]);
            priceLpg = Convert.ToDouble(priceInformation[4]);
        }
        private void txtPriceWrite()
        {
            label16.Text = priceGasoline95.ToString("N");
            label17.Text = priceGasoline97.ToString("N");
            label18.Text = priceDiesel.ToString("N");
            label19.Text = priceEuroDiesel.ToString("N");
            label20.Text = priceLpg.ToString("N");
        }
        private void progressBarUpdate()
        {
            progressBar1.Value = Convert.ToInt16(tankGasoline95);
            progressBar2.Value = Convert.ToInt16(tankGasoline97);
            progressBar3.Value = Convert.ToInt16(tankDiesel);
            progressBar4.Value = Convert.ToInt16(tankEuroDiesel);
            progressBar5.Value = Convert.ToInt16(tankLpg);
        }
        private void numericUpDownValue()
        {
            numericUpDown1.Maximum = decimal.Parse(tankGasoline95.ToString());
            numericUpDown2.Maximum = decimal.Parse(tankGasoline97.ToString());
            numericUpDown3.Maximum = decimal.Parse(tankDiesel.ToString());
            numericUpDown4.Maximum = decimal.Parse(tankEuroDiesel.ToString());
            numericUpDown5.Maximum = decimal.Parse(tankLpg.ToString());
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Progress Bar
            progressBar1.Maximum = 1000;
            progressBar2.Maximum = 1000;
            progressBar3.Maximum = 1000;
            progressBar4.Maximum = 1000;
            progressBar5.Maximum = 1000;

            //combobox
            string[] fuelType = { "Gasoline (95)", "Gasoline (97)", "Diesel", "Euro Diesel", "LPG" };
            comboBox1.Items.AddRange(fuelType);
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            //Numberic Up Down
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;

            numericUpDown1.DecimalPlaces = 2;
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown5.DecimalPlaces = 2;

            numericUpDown1.Increment = 0.1M;
            numericUpDown2.Increment = 0.1M;
            numericUpDown3.Increment = 0.1M;
            numericUpDown4.Increment = 0.1M;
            numericUpDown5.Increment = 0.1M;

            numericUpDown1.ReadOnly = true;
            numericUpDown2.ReadOnly = true;
            numericUpDown3.ReadOnly = true;
            numericUpDown4.ReadOnly = true;
            numericUpDown5.ReadOnly = true;

            tabPage1.Text = "Tank Information";
            tabPage2.Text = "Price Information";
            tabPage3.Text = "Sell";

            //Methods
            txtTankRead();
            txtTankWrite();
            txtPriceRead();
            txtPriceWrite();
            progressBarUpdate();
            numericUpDownValue();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                priceGasoline95 += (priceGasoline95 * Convert.ToDouble(textBox6.Text) / 100);
                priceInformation[0] = Convert.ToString(priceGasoline95);
            }
            catch (Exception)
            {
                textBox6.Text = "Error!";
            }
            try
            {
                priceGasoline97 += (priceGasoline97 * Convert.ToDouble(textBox7.Text) / 100);
                priceInformation[1] = Convert.ToString(priceGasoline97);
            }
            catch (Exception)
            {
                textBox7.Text = "Error!";
            }
            try
            {
                priceDiesel += (priceDiesel * Convert.ToDouble(textBox8.Text) / 100);
                priceInformation[2] = Convert.ToString(priceDiesel);
            }
            catch (Exception)
            {
                textBox8.Text = "Error!";
            }
            try
            {
                priceEuroDiesel += (priceEuroDiesel * Convert.ToDouble(textBox9.Text) / 100);
                priceInformation[3] = Convert.ToString(priceEuroDiesel);
            }
            catch (Exception)
            {
                textBox9.Text = "Error!";
            }
            try
            {
                priceLpg += (priceLpg * Convert.ToDouble(textBox10.Text) / 100);
                priceInformation[4] = Convert.ToString(priceLpg);
            }
            catch (Exception)
            {
                textBox10.Text = "Error!";
            }
            System.IO.File.WriteAllLines(Application.StartupPath + "\\price.txt", priceInformation);
            txtPriceRead();
            txtPriceRead();
            progressBarUpdate();
            numericUpDownValue();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                addGasoline95 = Convert.ToDouble(textBox1.Text);
                if (double.TryParse(textBox1.Text, out addGasoline95))
                {
                    if (addGasoline95 <= 0 || tankGasoline95 + addGasoline95 > 1000)
                        textBox1.Text = "Error!!";
                    else
                        tankInformation[0] = (tankGasoline95 + addGasoline95).ToString();
                }
                else
                {
                    textBox1.Text = "Error!!";
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = "Error!!";
            }

            try
            {
                addGasoline97 = Convert.ToDouble(textBox2.Text);
                if (double.TryParse(textBox2.Text, out addGasoline97))
                {
                    if (addGasoline97 <= 0 || tankGasoline97 + addGasoline97 > 1000)
                        textBox2.Text = "Error!!";
                    else
                        tankInformation[1] = (tankGasoline97 + addGasoline97).ToString();
                }
                else
                {
                    textBox2.Text = "Error!!";
                }
            }
            catch (Exception ex)
            {
                textBox2.Text = "Error!!";

            }

            try
            {
                addDiesel = Convert.ToDouble(textBox3.Text);
                if (double.TryParse(textBox3.Text, out addDiesel))
                {
                    if (addDiesel <= 0 || tankDiesel + addDiesel > 1000)
                        textBox3.Text = "Error!!";
                    else
                        tankInformation[2] = (tankDiesel + addDiesel).ToString();
                }
                else
                {
                    textBox3.Text = "Error!!";
                }
            }
            catch (Exception ex)
            {
                textBox3.Text = "Error!!";

            }

            try
            {
                addEuroDiesel = Convert.ToDouble(textBox4.Text);
                if (double.TryParse(textBox4.Text, out addEuroDiesel))
                {
                    if (addEuroDiesel <= 0 || tankEuroDiesel + addEuroDiesel > 1000)
                        textBox4.Text = "Error!!";
                    else
                        tankInformation[3] = (tankEuroDiesel + addEuroDiesel).ToString();
                }
                else
                {
                    textBox4.Text = "Error!!";
                }
            }
            catch (Exception ex)
            {
                textBox4.Text = "Error!!";

            }

            try
            {
                addLpg = Convert.ToDouble(textBox5.Text);
                if (double.TryParse(textBox5.Text, out addLpg))
                {
                    if (addLpg <= 0 || tankLpg + addLpg > 1000)
                        textBox5.Text = "Error!!";
                    else
                        tankInformation[4] = (tankLpg + addLpg).ToString();
                }
                else
                {
                    textBox5.Text = "Error!!";
                }
            }
            catch (Exception ex)
            {
                textBox5.Text = "Error!!";

            }
            System.IO.File.WriteAllLines(Application.StartupPath + "\\tank.txt", tankInformation);
            txtTankRead();
            txtTankRead();
            progressBarUpdate();
            numericUpDownValue();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Gasoline (95)")
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "Gasoline (97)")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "Diesel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "Euro Diesel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = true;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "LPG")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = true;
            }
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            label29.Text = "___________";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sellGasoline95= double.Parse(numericUpDown1.Value.ToString());
            sellGasoline97= double.Parse(numericUpDown2.Value.ToString());
            sellDiesel = double.Parse(numericUpDown3.Value.ToString());
            sellEuroDiesel= double.Parse(numericUpDown4.Value.ToString());
            sellLpg = double.Parse(numericUpDown5.Value.ToString());

            if (numericUpDown1.Enabled == true)
            {
                tankGasoline95 -= sellGasoline95;
                label29.Text=Convert.ToString(sellGasoline95*priceGasoline95);
            }
            else if (numericUpDown2.Enabled == true)
            {
                tankGasoline97 -= sellGasoline97;
                label29.Text = Convert.ToString(sellGasoline97 * priceGasoline97);
            }
            else if (numericUpDown3.Enabled == true)
            {
                tankDiesel -= sellDiesel;
                label29.Text = Convert.ToString(sellDiesel * priceDiesel);
            }
            else if (numericUpDown4.Enabled == true)
            {
                tankEuroDiesel -= sellEuroDiesel;
                label29.Text = Convert.ToString(sellEuroDiesel * priceEuroDiesel);
            }
            else if (numericUpDown4.Enabled == true)
            {
                tankLpg -= sellLpg;
                label29.Text = Convert.ToString(sellLpg * priceLpg);
            }

            tankInformation[0] = Convert.ToString(tankGasoline95);
            tankInformation[1] = Convert.ToString(tankGasoline95);
            tankInformation[2]=Convert.ToString(tankDiesel);
            tankInformation[3]=Convert.ToString(tankEuroDiesel);
            tankInformation[4] = Convert.ToString(tankLpg);

            System.IO.File.WriteAllLines(Application.StartupPath + "\\tank.txt",tankInformation);
            txtTankRead();
            txtTankWrite();
            progressBarUpdate();
            numericUpDownValue();

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;

        }
    }
}
