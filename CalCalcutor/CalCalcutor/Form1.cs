using NutritionLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalCalcutor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void chkMuscleGain_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMuscleGain.Checked)
            {
                chkWeightLoss.Checked = false;
                chkMaintenance.Checked = false;
            }
        }

        private void chkWeightLoss_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWeightLoss.Checked)
            {
                chkMuscleGain.Checked = false;
                chkMaintenance.Checked = false;
            }
        }

        private void chkMaintenance_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMaintenance.Checked)
            {
                chkMuscleGain.Checked = false;
                chkWeightLoss.Checked = false;
            }
        }

        private void chkMale_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMale.Checked)
            {
                chkFemale.Checked = false;
            }
        }

        private void chkFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFemale.Checked)
            {
                chkMale.Checked = false;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем данные из полей
                double height = double.Parse(txtHeight.Text);
                int age = int.Parse(txtAge.Text);
                double weight = 70; // Можно добавить поле для веса

                // Определяем цель расчета
                Goal goal;
                if (chkMuscleGain.Checked)
                    goal = Goal.MuscleGain;
                else if (chkWeightLoss.Checked)
                    goal = Goal.WeightLoss;
                else
                    goal = Goal.Maintenance;

                // Определяем пол
                Gender gender = chkMale.Checked ? Gender.Male : Gender.Female;

                // Уровень активности (можно добавить поле для выбора)
                double activityLevel = 1.55;

                // Вычисление значений
                var result = CalorieCalculator.CalculateDailyIntake(gender, weight, height, age, activityLevel, goal);

                // Вывод результата
                MessageBox.Show($"Калории: {result.Calories}\nБелки: {result.Proteins} г\nЖиры: {result.Fats} г\nУглеводы: {result.Carbs} г",
                    "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ввода данных! Проверьте правильность значений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
