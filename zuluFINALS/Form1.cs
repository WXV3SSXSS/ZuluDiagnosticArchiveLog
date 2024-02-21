using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zuluFINALS
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			object[] objects = new object[]{
   "1.\tОтсутствуют критические дефекты;",
   "2.\tКритические дефекты - до 5% от протяженности участка теплосети;",
   "3.\tКритические дефекты - от 5 до 10%протяженности участка теплосети;",
   "4.\tКритические дефекты - от 10% до 20% от протяженности  участка теплосети;",
   "5.\tКритические дефекты - более 20% от протяженности участка теплосети."
};
			comboBox1.Items.AddRange(objects);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DiagnosticArchiveLog log = new DiagnosticArchiveLog();
			try
			{
				string region = textBoxRegion.Text;
				DistrictEnum district = DistrictEnum.Ленинский;
				if (radioButton1.Checked)
				{
					district = DistrictEnum.Ленинский;
				}
				if (radioButton2.Checked)
				{
					district = DistrictEnum.Октябрьский;
				}
				DateTime dateOfExam = dateTimePicker1.Value;
				decimal regionLenght = Convert.ToDecimal(textBoxRegionLenght.Text);
				decimal diameter = Convert.ToDecimal(textBoxDiameter.Text);
				TypeOfPipelineEnum typeOfPipe = TypeOfPipelineEnum.Подающий;
				if (radioButton3.Checked)
				{
					typeOfPipe = TypeOfPipelineEnum.Подающий;
				}
				if (radioButton4.Checked)
				{
					typeOfPipe = TypeOfPipelineEnum.Обратный;
				}
				DateTime dateOfCommisioning = dateTimePicker2.Value;
				double coefficient = Convert.ToDouble(textBoxCoefficient.Text);
				int operatingTime = Convert.ToInt32(textBoxOperatingTime.Text);
				bool presenceOfSubcriticalDefects = true;
				if (radioButton5.Checked)
				{
					presenceOfSubcriticalDefects = true;
				}
				if (radioButton6.Checked)
				{
					presenceOfSubcriticalDefects = false;
				}
				bool presenceOfCriticalDefects = true;
				if (radioButton7.Checked)
				{
					presenceOfCriticalDefects = true;
				}
				if (radioButton8.Checked)
				{
					presenceOfCriticalDefects = false;
				}
				decimal lengthOfCriticalDefects = Convert.ToDecimal(textBoxLengthOfCriticalDefects.Text);
				int diagnosticResult = comboBox1.SelectedIndex;
				if (diagnosticResult == -1) { throw new Exception("unchecker combobox"); }
				string comment = textBoxComment.Text;
				string person = textBoxPerson.Text;
				log.Initialization(region, district, dateOfExam, regionLenght, diameter, typeOfPipe,
					dateOfCommisioning, coefficient, operatingTime, presenceOfSubcriticalDefects,
					presenceOfCriticalDefects, lengthOfCriticalDefects, diagnosticResult, comment, person);
				textBoxFinallScore.Text = log.FinallScore.ToString();
			}
			catch (Exception)
			{
				MessageBox.Show("Проверьте правильность данных");
			}
		}
	}
}
