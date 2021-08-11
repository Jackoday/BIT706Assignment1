using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIT706Assignment1
{
    public partial class FormHome : Form
    {
        private List<Account> myAccounts = new List<Account>();

        public FormHome()
        {
            InitializeComponent();
            CreateAccounts();
            DisplayAccounts();
        }

        private void LabelTitle_Click(object sender, EventArgs e)
        {

        }

        private void CreateAccounts()
        {
            myAccounts.Add(new Everyday());
            myAccounts.Add(new Investment(5, 2));
            myAccounts.Add(new Omni(5, 2, -500));
            myAccounts[0].Balance = 50;
            myAccounts[1].Balance = 277;
            myAccounts[2].Balance = 800;
        }

        private void DisplayAccounts()
        {
            listBoxAccounts.Items.Clear();

            foreach (Account acc in myAccounts)
            {
                listBoxAccounts.Items.Add(acc); //.NameAndBalance()
            }
            listBoxAccounts.SelectedIndex = 0;
        }

        private void ButtonLastTrans_Click(object sender, EventArgs e)
        {
            Account account = (Account)listBoxAccounts.SelectedItem;
            textBoxTransHistory.Text = account.GetLastTransaction();
        }

        private void ButtonDeposit_Click(object sender, EventArgs e)
        {
            Account account = (Account)listBoxAccounts.SelectedItem;
            account.Deposit(upDown.Value);
            textBoxTransHistory.Text = account.GetLastTransaction();
            upDown.Value = 0;
        }

        private void ButtonWithdraw_Click(object sender, EventArgs e)
        {
            Account account = (Account)listBoxAccounts.SelectedItem;
            account.Withdraw(upDown.Value);
            textBoxTransHistory.Text = account.GetLastTransaction();
            upDown.Value = 0;
        }

        private void ButtonAccountInfo_Click(object sender, EventArgs e)
        {
            Account account = (Account)listBoxAccounts.SelectedItem;
            MessageBox.Show(account.Details(), "Account info");
        }

        private void ButtonInterest_Click(object sender, EventArgs e)
        {
            Account account = (Account)listBoxAccounts.SelectedItem;
            account.Interest();
            textBoxTransHistory.Text = account.GetLastTransaction();
        }
    }
}