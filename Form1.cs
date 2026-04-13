using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza
{
    public partial class Form1 : Form
    {

        private bool _shouldUpdate = true;

        public Form1()
        {
            InitializeComponent();
        }

        float GetSelectedSizePrice()
        {

            if (rbSamll.Checked)
            {
                return Convert.ToSingle(rbSamll.Tag) * ((float)numericUpDown1.Value);
            }

            else if (rbMedium.Checked)
            {
                return Convert.ToSingle(rbMedium.Tag) * ((float)numericUpDown1.Value);
            }

            else 
            { 
                return Convert.ToSingle(rbLarge.Tag) * ((float)numericUpDown1.Value);
            }

        }

        float CalculateToppingsPrice()
        {

            float toppingsPrice = 0;

            if (chkExtraChees.Checked)
                toppingsPrice += Convert.ToSingle(chkExtraChees.Tag); 

            if (chkMushrooms.Checked)
                toppingsPrice += Convert.ToSingle(chkMushrooms.Tag); 

            if (chkTomatos.Checked)
                toppingsPrice += Convert.ToSingle(chkTomatos.Tag); 

            if (chkOnion.Checked)
                toppingsPrice += Convert.ToSingle(chkOnion.Tag); 

            if (chkOlives.Checked)
                toppingsPrice += Convert.ToSingle(chkOlives.Tag); 

            if (chkGreenPeppers.Checked)
                toppingsPrice += Convert.ToSingle(chkGreenPeppers.Tag); 

            return toppingsPrice;
  
        }

        float GetCrustPrice()
        {

            if (rbThinCrust.Checked)
            { 
                return Convert.ToSingle(rbThinCrust.Tag);
            }
           
            else
            { 
                return Convert.ToSingle(rbThickCrust.Tag); 
            }

        }

        float GetTotalPrice()
        {
            return (GetSelectedSizePrice() + CalculateToppingsPrice() + GetCrustPrice());
        }

        void UpDateTotalPrice()
        {
            lblTotalPrice.Text = "$" + GetTotalPrice().ToString();
        }

    
       void UpDateSize()
        {
            
            if (rbSamll.Checked)
                {lblSize.Text = "Small"; return; }

            if (rbMedium.Checked)
               {lblSize.Text = "Medium"; return; }

            if (rbLarge.Checked)
                {lblSize.Text = "Large"; return; }
        }

        void UpDateToppings()
        {
            
            string stoppings = "";

            if (chkExtraChees.Checked)
                stoppings += ", Extra Cheese";

            if (chkMushrooms.Checked)
                stoppings += ", Mushrooms";

            if (chkTomatos.Checked)
                stoppings += ", Tomatoes";

            if (chkOnion.Checked)
                stoppings += ", Onion";

            if (chkOlives.Checked)
                stoppings += ", Olives";

            if (chkGreenPeppers.Checked)
                stoppings += ", Green Peppers";

            if (stoppings.StartsWith(","))
            { stoppings = stoppings.Substring(1, stoppings.Length - 1).Trim(); }

            if (stoppings == "")
            { stoppings = "No Toppings"; };

            lblToppings.Text = stoppings;

        }

        void UpDateCrust()
        {
            
            if (rbThinCrust.Checked)
            { lblCrustType.Text = "Thin"; return; }

            if (rbThickCrust.Checked)
            { lblCrustType.Text = "Thick"; return; }

        }

        void UpDateWhereToEat()
        {

            if (rbEatIn.Checked)
            { lblWhereToEat.Text = "Eat in"; return; }

            if (rbTakeOut.Checked)
            { lblWhereToEat.Text = "Take out"; return; }

        }

        void UpDateAll()
        {
            UpDateSize();
            UpDateToppings();
            UpDateCrust();
            UpDateWhereToEat();
        }

        void Reset()
        {

            _shouldUpdate = false;

            // reset Groups
            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbCrustType.Enabled = true;
            gbWhereToEat.Enabled = true;

            // reset Size
            rbMedium.Checked = true;

            // reset Toppings
            chkExtraChees.Checked = false;
            chkOnion.Checked = false;
            chkMushrooms.Checked = false;
            chkOlives.Checked = false;
            chkTomatos.Checked = false;
            chkGreenPeppers.Checked = false;

            // reset CrustType
            rbThinCrust.Checked = true;

            // reset Where to Eat
            rbEatIn.Checked = true;

            // reset button
            btnOrderPizza.Enabled = true;

            _shouldUpdate = true;

            // Reset Numeric Up/Down
            numericUpDown1.Value = 1;
            numericUpDown1.Enabled = true;
            lbHowManyPizza.Enabled = true;

            // update UI ONCE
            UpDateAll();
            UpDateTotalPrice();

        }

        private void Size_CheckedChanged(object sender, EventArgs e)
        {
            
            if (_shouldUpdate && ((RadioButton)sender).Checked)
            {
                UpDateSize();
                UpDateTotalPrice();  
            }
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            if (_shouldUpdate && ((RadioButton)sender).Checked)
            {
                UpDateCrust();
                UpDateTotalPrice();
            }
        }

        private void rbThickCrust_CheckedChanged(object sender, EventArgs e)
        {
            if (_shouldUpdate && ((RadioButton)sender).Checked)
            {
                UpDateCrust();
                UpDateTotalPrice();
            }
        }

        private void Toppings_CheckedChanged(object sender, EventArgs e)
        {
            if (_shouldUpdate)
            {
                UpDateToppings();
                UpDateTotalPrice();
            }
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            if (_shouldUpdate && ((RadioButton)sender).Checked)
            {
                UpDateWhereToEat();
                UpDateTotalPrice();
            }
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            if (_shouldUpdate && ((RadioButton)sender).Checked)
            {
                UpDateWhereToEat();
                UpDateTotalPrice();
            }
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Confirm Order", "Order", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Placed Successfully", "Order", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnOrderPizza.Enabled = false;
                gbSize.Enabled = false;
                gbCrustType.Enabled = false;
                gbToppings.Enabled = false;
                gbWhereToEat.Enabled = false;
                numericUpDown1.Value = 1;
                numericUpDown1.Enabled = false;
                lbHowManyPizza.Enabled = false;
            }

            else
            {
                MessageBox.Show("UpDate your order", "Order", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpDateAll();
            UpDateTotalPrice();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpDateTotalPrice();
        }

        
    }


}
