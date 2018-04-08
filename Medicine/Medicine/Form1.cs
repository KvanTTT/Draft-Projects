using System;
using System.Windows.Forms;

namespace Medicine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void rbSex_CheckedChanged(object sender, EventArgs e)
        {
            double value;
            value = ((RadioButton)sender).Name == nameof(rbMale) ? 1.25 : 1.05;
            tbK.Text = value.ToString();
        }

        private void btnCalculateKreatinin_Click(object sender, EventArgs e)
        {
            double k;
            if (!double.TryParse(tbK.Text, out k))
            {
                MessageBox.Show("Параметр k задан некорректно");
                return;
            }

            double age;
            if (!double.TryParse(tbAge.Text, out age))
            {
                MessageBox.Show("Возраст задан некорректно");
                return;
            }

            double weight;
            if (!double.TryParse(tbWeight.Text, out weight))
            {
                MessageBox.Show("Масса задана некорректно");
                return;
            }

            double kreatinin;
            if (!double.TryParse(tbKreatinin.Text, out kreatinin))
            {
                MessageBox.Show("Значение креатинино задано некорректно");
                return;
            }

            double kreatininClearance = (k * (140 - age) * weight) / kreatinin;
            tbKreatininClearance.Text = kreatininClearance.ToString();

            double auc;
            if (!double.TryParse(tbAUC.Text, out auc))
            {
                MessageBox.Show("Значение AUC задано некорректно");
            }

            double karboplatinDose = auc * (kreatininClearance + 25);
            tbKarboplatinDose.Text = karboplatinDose.ToString();
        }
    }
}
