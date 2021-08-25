using System;
using System.Windows.Forms;

namespace TestTargetExeForm
{
    public partial class TestTargetForm : Form
    {
        public TestTargetForm()
        {
            InitializeComponent();
        }


        delegate bool ParseText(TextBox t, out decimal v);

        private void button1_Click(object sender, EventArgs e)
        {
            decimal lhv = 0;
            decimal rhv = 0;
            decimal result = 0;

            ParseText parseText = (TextBox textbox, out decimal value) =>
            {
                if (!decimal.TryParse(textbox.Text, out value))
                {
                    MessageBox.Show("数値を入力してください", "入力エラー");
                    textbox.SelectAll();
                    textbox.Focus();
                    return false;
                }
                return true;
            };

            textBox3.Text = "";

            if (!parseText(textBox1, out lhv))
            {
                return;
            }

            if (!parseText(textBox2, out rhv))
            {
                return;
            }

            if (rdoAdd.Checked)
            {
                result = lhv + rhv;
            }
            else if (rdoSub.Checked)
            {
                result = lhv - rhv;
            }
            else if (rdoMul.Checked)
            {
                result = lhv * rhv;
            }
            else if (rdoDiv.Checked)
            {
                if (rhv == 0)
                {
                    result = 0;
                }
                else
                {
                    result = lhv / rhv;
                }
                
            }

            textBox3.Text = result.ToString();
        }
    }
}
