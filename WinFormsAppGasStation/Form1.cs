namespace WinFormsAppGasStation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
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
            priceGasoline95= Convert.ToDouble(priceInformation[0]);
            priceGasoline97= Convert.ToDouble(priceInformation[1]);
            priceDiesel= Convert.ToDouble(priceInformation[2]);
            priceEuroDiesel= Convert.ToDouble(priceInformation[3]);
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
            progressBar1.Value=Convert.ToInt16(tankGasoline95);
            progressBar2.Value=Convert.ToInt16(tankGasoline97);
            progressBar3.Value=Convert.ToInt16(tankDiesel);
            progressBar4.Value=Convert.ToInt16(tankEuroDiesel);
            progressBar5.Value=Convert.ToInt16(tankLpg);
        }
        private void numericUpDownValue()
        {
            numericUpDown1.Maximum=decimal.Parse(tankGasoline95.ToString());
            numericUpDown2.Maximum=decimal.Parse(tankGasoline97.ToString());
            numericUpDown3.Maximum=decimal.Parse(tankDiesel.ToString());
            numericUpDown4.Maximum=decimal.Parse(tankEuroDiesel.ToString());
            numericUpDown5.Maximum=decimal.Parse(tankLpg.ToString());
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            progressBar1.Maximum = 1000;
            progressBar2.Maximum = 1000;
            progressBar3.Maximum = 1000;
            progressBar4.Maximum = 1000;
            progressBar5.Maximum = 1000;

            //Methods
            txtTankRead();
            txtTankWrite();
            txtPriceRead();
            txtPriceWrite();
            progressBarUpdate();
            numericUpDownValue();
        }
    }
}
