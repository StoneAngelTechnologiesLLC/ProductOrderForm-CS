//John Pietrangelo CIS345 Tues/Thurs 9am <<<Late Submission>>>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderAppJohnPietrangelo
{
    public partial class OrederAppGUIForm : Form
    {
        private static double balance = 300.00;

        public OrederAppGUIForm()
        {
            InitializeComponent();
        }
        private void OrederAppGUIForm_Load(object sender, EventArgs e)
        {
            int colQty = 2;
            int bldQty = 8;
            int drkQty = 5;
            int insQty = 15;
            int dcfQty = 10;
            double colPrice = 10.50;
            double bldPrice = 13.00;
            double drkPrice = 15.95;
            double insPrice = 5.50;
            double dcfPrice = 9.99;
            DateTime date = DateTime.Now;
            orderDateLbl.Text = date.ToString("MM/dd/yyyy");
            orderTimeLbl.Text = date.ToString("HH:mm");
            colPriceLbl.Text = colPrice.ToString("C");
            bldPriceLbl.Text = bldPrice.ToString("C");
            drkPriceLbl.Text = drkPrice.ToString("C");
            insPriceLbl.Text = insPrice.ToString("C");
            dcfPriceLbl.Text = dcfPrice.ToString("C");
            colQtyLbl.Text = colQty.ToString();
            bldQtyLbl.Text = bldQty.ToString();
            drkQtyLbl.Text = drkQty.ToString();
            insQtyLbl.Text = insQty.ToString();
            dcfQtyLbl.Text = dcfQty.ToString();
            balanceLbl.Text = balance.ToString("C");
            colOrderQtyTxBx.Select();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            colSubTotalTxBx.Clear();
            bldSubTotalTxBx.Clear();
            drkSubTotalTxBx.Clear();
            insSubTotalTxBx.Clear();
            dcfSubTotalTxBx.Clear();
            colOrderQtyTxBx.Text = "0";
            bldOrderQtyTxBx.Text = "0";
            drkOrderQtyTxBx.Text = "0";
            insOrderQtyTxBx.Text = "0";
            dcfOrderQtyTxBx.Text = "0";
            cartTxBx.Clear();
        }

        private void addToCartBtn_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
           
            double colPrice = 10.50;
            double bldPrice = 13.00;
            double drkPrice = 15.95;
            double insPrice = 5.50;
            double dcfPrice = 9.99;
            int colOrderQty = Convert.ToInt32(colOrderQtyTxBx.Text);
            int colInStock = Convert.ToInt32(colQtyLbl.Text);
            int bldOrderQty = Convert.ToInt32(bldOrderQtyTxBx.Text);
            int bldInStock = Convert.ToInt32(bldQtyLbl.Text);
            int drkOrderQty = Convert.ToInt32(drkOrderQtyTxBx.Text);
            int drkInStock = Convert.ToInt32(drkQtyLbl.Text);
            int insOrderQty = Convert.ToInt32(insOrderQtyTxBx.Text);
            int insInStock = Convert.ToInt32(insQtyLbl.Text);
            int dcfOrderQty = Convert.ToInt32(dcfOrderQtyTxBx.Text);
            int dcfInStock = Convert.ToInt32(dcfQtyLbl.Text);
            double colSub = (colPrice * colOrderQty);
            double bldSub = (bldPrice * bldOrderQty);
            double drkSub = (drkPrice * drkOrderQty);
            double insSub = (insPrice * insOrderQty);
            double dcfSub = (dcfPrice * dcfOrderQty);
            double total = ((colSub) + (bldSub) + (drkSub) + (insSub) + (dcfSub));
            colSubTotalTxBx.Text = colSub.ToString("C");
            bldSubTotalTxBx.Text = bldSub.ToString("C");
            drkSubTotalTxBx.Text = drkSub.ToString("C");
            dcfSubTotalTxBx.Text = dcfSub.ToString("C");
            cartTxBx.Clear();
            cartTxBx.AppendText("\t   Current Order\n");
            cartTxBx.AppendText("Coffee Type\t  Order Quantity\n");
            cartTxBx.AppendText("-------------------------------------------\n");
            
            if (colOrderQty<=colInStock && bldOrderQty <= bldInStock && drkOrderQty <=drkInStock && insOrderQty<= insInStock && dcfOrderQty<= dcfInStock && total <= balance)
            {
                colSubTotalTxBx.Text = colSub.ToString("C");
                bldSubTotalTxBx.Text = bldSub.ToString("C");
                drkSubTotalTxBx.Text = drkSub.ToString("C");
                insSubTotalTxBx.Text = insSub.ToString("C");
                dcfSubTotalTxBx.Text = dcfSub.ToString("C");
                cartTxBx.AppendText(colLbl.Text);
                cartTxBx.AppendText("\t\t" + colOrderQtyTxBx.Text+"\n\n");
                cartTxBx.AppendText(bldLbl.Text);
                cartTxBx.AppendText("\t\t\t" + bldOrderQtyTxBx.Text+"\n\n");
                cartTxBx.AppendText(drkLbl.Text);
                cartTxBx.AppendText("\t\t" + drkOrderQtyTxBx.Text + "\n\n");
                cartTxBx.AppendText(colLbl.Text);
                cartTxBx.AppendText("\t\t" + insOrderQtyTxBx.Text + "\n\n");
                cartTxBx.AppendText(dcfLbl.Text);
                cartTxBx.AppendText("\t\t\t" + dcfOrderQtyTxBx.Text + "\n");
                cartTxBx.AppendText("------------------------------------------\n\n");
                cartTxBx.AppendText("            Grand Total: "+total.ToString("C"));
                cartTxBx.AppendText("------------------------------------------\n");
                cartTxBx.AppendText("\n        Date & Time of Purchase\n\n");
                cartTxBx.AppendText("          "+date.ToString("MM/dd/yyyy"+"     ") + date.ToString("HH:mm"));
            }
           else if ( total > balance )
            {
                MessageBox.Show("Error!!! Total Price Exceeds Your Current Balance");
                colOrderQtyTxBx.Text = "0";
                bldOrderQtyTxBx.Text = "0";
                drkOrderQtyTxBx.Text = "0";
                insOrderQtyTxBx.Text = "0";
                dcfOrderQtyTxBx.Text = "0";
                colSubTotalTxBx.Clear();
                bldSubTotalTxBx.Clear();
                drkSubTotalTxBx.Clear();
                insSubTotalTxBx.Clear();
                dcfSubTotalTxBx.Clear();
                cartTxBx.Clear();
            }
            else
            {
                MessageBox.Show("Error!!! Quanty Ordered Exceeds In-Stock Quantity Available");
                colOrderQtyTxBx.Text = "0";
                bldOrderQtyTxBx.Text = "0";
                drkOrderQtyTxBx.Text = "0";
                insOrderQtyTxBx.Text = "0";
                dcfOrderQtyTxBx.Text = "0";
                colSubTotalTxBx.Clear();
                bldSubTotalTxBx.Clear();
                drkSubTotalTxBx.Clear();
                insSubTotalTxBx.Clear();
                dcfSubTotalTxBx.Clear();
                cartTxBx.Clear();
            }
            

        }

        
       

        private void purchaseBtn_Click(object sender, EventArgs e)
        {
            double colPrice = 10.50;
            double bldPrice = 13.00;
            double drkPrice = 15.95;
            double insPrice = 5.50;
            double dcfPrice = 9.99;
            int colOrderQty = Convert.ToInt32(colOrderQtyTxBx.Text);
            int colInStock = Convert.ToInt32(colQtyLbl.Text);
            int bldOrderQty = Convert.ToInt32(bldOrderQtyTxBx.Text);
            int bldInStock = Convert.ToInt32(bldQtyLbl.Text);
            int drkOrderQty = Convert.ToInt32(drkOrderQtyTxBx.Text);
            int drkInStock = Convert.ToInt32(drkQtyLbl.Text);
            int insOrderQty = Convert.ToInt32(insOrderQtyTxBx.Text);
            int insInStock = Convert.ToInt32(insQtyLbl.Text);
            int dcfOrderQty = Convert.ToInt32(dcfOrderQtyTxBx.Text);
            int dcfInStock = Convert.ToInt32(dcfQtyLbl.Text);
            double colSub = (colPrice * colOrderQty);
            double bldSub = (bldPrice * bldOrderQty);
            double drkSub = (drkPrice * drkOrderQty);
            double insSub = (insPrice * insOrderQty);
            double dcfSub = (dcfPrice * dcfOrderQty);
            double total = ((colSub) + (bldSub) + (drkSub) + (insSub) + (dcfSub));
            double newBalance = (balance - total);
            int newColInStock = (Convert.ToInt32(colQtyLbl.Text) - colOrderQty);
            int newBldInStock = (Convert.ToInt32(bldQtyLbl.Text) - bldOrderQty);
            int newDrkInStock = (Convert.ToInt32(drkQtyLbl.Text) - drkOrderQty);
            int newInsInStock = (Convert.ToInt32(insQtyLbl.Text) - insOrderQty);
            int newDcfInStock = (Convert.ToInt32(dcfQtyLbl.Text) - dcfOrderQty);
            colQtyLbl.Text = newColInStock.ToString();
            bldQtyLbl.Text = newBldInStock.ToString();
            drkQtyLbl.Text = newDrkInStock.ToString();
            insQtyLbl.Text = newInsInStock.ToString();
            dcfQtyLbl.Text = newDcfInStock.ToString();
            colSubTotalTxBx.Clear();
            bldSubTotalTxBx.Clear();
            drkSubTotalTxBx.Clear();
            insSubTotalTxBx.Clear();
            dcfSubTotalTxBx.Clear();
            colOrderQtyTxBx.Text  = "0";
            bldOrderQtyTxBx.Text  = "0";
            drkOrderQtyTxBx.Text = "0";
            insOrderQtyTxBx.Text = "0";
            dcfOrderQtyTxBx.Text = "0";
            balance = newBalance;
            balanceLbl.Text = newBalance.ToString("C");
            cartTxBx.Clear();


        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
      
    }
}
