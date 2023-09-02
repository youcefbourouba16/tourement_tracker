using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tourament_library;
using Tourament_library.Models;

namespace TrackerUi
{
    public partial class creatPrize : Form
    {
        IPrizeRequester callingForm;
        public creatPrize(IPrizeRequester caller, int i)
        {
            InitializeComponent(i);
            callingForm = caller;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidatForm())
            {
                PrizeModel prizeModel1 = new PrizeModel(
                    placeNumberValue.Text,
                    placeNameValue.Text,
                    prizePercentageValue.Text,
                    PrizeAmountValue.Text);

                globalConfig.Connections.createPrize(prizeModel1);
                callingForm.prizeComplete(prizeModel1);
                this.Close();
                //placeNameValue.Text = "";
                //placeNumberValue.Text = "";
                //prizePercentageValue.Text = "0";
                //PrizeAmountValue.Text = "0";



            }
            else MessageBox.Show("please!! verify your form. ");
        }
        private bool ValidatForm()
        {
            int placeNumber;
            bool validLogic = true;
            bool ValidationPlaceNumber = int.TryParse(placeNumberValue.Text, out placeNumber);
            if (!ValidationPlaceNumber && placeNumber <= 0)
            {
                validLogic = false;
            }
            if (placeNameValue == null)
            {
                validLogic = false;
            }
            decimal prizeAmount;
            double prizePercentage;
            bool ValidationPrizeAmount = decimal.TryParse(PrizeAmountValue.Text, out prizeAmount);
            bool ValidationPrizePercentage = double.TryParse(prizePercentageValue.Text, out prizePercentage);
            if (!ValidationPrizeAmount || !ValidationPrizePercentage)
            {
                validLogic = false;
            }
            if (prizeAmount < 0 || prizePercentage < 0)
            {
                validLogic = false;
            }

            if (prizePercentage > 100)
            {
                validLogic = false;
            }
            return validLogic;


        }

        private void creatPrize_Load(object sender, EventArgs e)
        {

        }
        
    }
}
