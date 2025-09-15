//Form1.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace HelpR
{
    public partial class Form1 : Form
    {
        Font montseratReg;
        Font montseratSemiBold;

        int riskSelected = 0;
        int probSelected = 0;

        Question[] questions1 = new Question[] { new Question("Появились ли трудности в приеме на работу нового сотрудника?", 1),
                                                    new Question("Не смогли принять кандидата на работу?", 2),
                                                    new Question("Пришлось сократить вакансию?", 6),
                                                    new Question("Пришлось выплачивать другой организации компенсацию за обучение сотрудника?", 5) };
        Question[] questions2 = new Question[] { new Question("Появились ли трудности в приеме на работу нового сотрудника?", 1),
                                                    new Question("Не смогли принять кандидата на работу?", 2),
                                                    new Question("Пришлось сократить вакансию?", 6),
                                                    new Question("Возникли проблемы при передаче сведений в пенсионный фонд?", 4) };
        Question[] questions3 = new Question[] { new Question("Возникли проблемы при передаче сведений в ОЦОР?", 1),
                                                    new Question("Возникли ли трудности в выплате заработной платы?", 5),
                                                    new Question("Пришлось ли платить штраф за просрочку выплаты заработной платы?", 6),
                                                    new Question("Необходимо ли обеспечить работнику неполный рабочий день и особые условия труда из-за инвалидности?", 1),
                                                    new Question("Необходимо ли искать нового кандидата из-за беременности новогосотрудника?", 2)};
        Question[] questions4 = new Question[] { new Question("Приняли ли на работу сотрудника, который не справляется со своими задачами?", 6),
                                                    new Question("Оказывает ли новый сотрудник негативное влияние на работу отдела?", 3),
                                                    new Question("Появились ли претензии от начальника отдела?", 3),
                                                    new Question("Появилась ли необходимость в увольнении нового сотрудника?", 1) };

        class Question
        {
            string question;
            int cost;

            public Question(string q, int c)
            {
                question = q;
                cost = c;
            }

            public string getQuestion()
            {
                return question;
            }
            public int getCost()
            {
                return cost;
            }
        }

        public Form1()
        {
            InitializeComponent();
            startPanel.BringToFront();

        }

        private void Form1_Resize(object sender, EventArgs e)
        {

            float scaleFactor = Math.Min(this.ClientSize.Width / 800f, this.ClientSize.Height / 450f);

            float newFontSize = Math.Max(18f, Math.Min(48f, 12 * scaleFactor));
            float newFontSizeBtn = Math.Max(12f, Math.Min(40f, 10 * scaleFactor));
            float newFontSizeLbRisk = Math.Max(10f, Math.Min(14f, 12 * scaleFactor));
            float newFontSizeCbRisk = Math.Max(8f, Math.Min(12f, 12 * scaleFactor));
            float newFontSizeRbRisk = Math.Max(8f, Math.Min(12f, 12 * scaleFactor));

            title_lb.Font = new Font(title_lb.Font.FontFamily, newFontSize, FontStyle.Bold);
            start_btn.Font = new Font(title_lb.Font.FontFamily, newFontSizeBtn);
            cR_lb.Font = new Font(title_lb.Font.FontFamily, newFontSizeLbRisk);
            risk1_rb.Font = new Font(title_lb.Font.FontFamily, newFontSizeRbRisk);
            risk2_rb.Font = new Font(title_lb.Font.FontFamily, newFontSizeRbRisk);
            risk3_rb.Font = new Font(title_lb.Font.FontFamily, newFontSizeRbRisk);
            risk4_rb.Font = new Font(title_lb.Font.FontFamily, newFontSizeRbRisk);
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            startPanel.Visible = false;
            firstPanel.Visible = true;
            firstPanel.BringToFront();
        }

        private void next3rdPage_btn_Click(object sender, EventArgs e)
        {
            if (risk1_rb.Checked)
            {
                riskSelected = 1;
            }
            else if (risk2_rb.Checked)
            {
                riskSelected = 2;
            }
            else if (risk3_rb.Checked)
            {
                riskSelected = 3;
            }
            else if (risk4_rb.Checked)
            {
                riskSelected = 4;
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите риск.");
                return;
            }

            if (isHap1_rb.Checked)
            {
                probSelected = 1;
            }
            else if (isHap2_rb.Checked)
            {
                probSelected = 2;
            }
            else if (isHap3_rb.Checked)
            {
                probSelected = 3;
            }
            else if (isHap4_rb.Checked)
            {
                probSelected = 4;
            }
            else if (isHap5_rb.Checked)
            {
                probSelected = 5;
            }
            else
            {
                MessageBox.Show("Пожалуйста, укажите случалось ли это раньше.");
                return;
            }

            
            if (riskSelected == 1)
            {
                firstPanel.Visible = false;
                secondPanel_questions1.Visible = true;
                secondPanel_questions1.BringToFront();
            }
            else if (riskSelected == 2) 
            {
                q1_q1_lb.Text = "Появились ли трудности в приеме на работу нового сотрудника?";
                q2_q1_lb.Text = "Не смогли принять кандидата на работу?";
                q3_q1_lb.Text = "Пришлось сократить вакансию?";
                q4_q1_lb.Text = "Возникли проблемы при передаче сведений в пенсионный фонд?";
                firstPanel.Visible = false;
                secondPanel_questions1.Visible = true;
                secondPanel_questions1.BringToFront();
            }
            else if (riskSelected == 3)
            {
                panel1.Visible = true;
                q_dop_lb.Text = "Возникли проблемы при передаче сведений в ОЦОР?";
                q1_q1_lb.Text = "Возникли ли трудности в выплате заработной платы?";
                q2_q1_lb.Text = "Пришлось ли платить штраф за просрочку выплаты заработной платы?";
                q3_q1_lb.Text = "Необходимо ли обеспечить работнику неполный рабочий день и особые условия труда из-за инвалидности?";
                q4_q1_lb.Text = "Необходимо ли искать нового кандидата из-за беременности новогосотрудника?";
                firstPanel.Visible = false;
                secondPanel_questions1.Visible = true;
                secondPanel_questions1.BringToFront();
            }
            else if(riskSelected == 4)
            {
                q1_q1_lb.Text = "Приняли ли на работу сотрудника, который не справляется со своими задачами?";
                q2_q1_lb.Text = "Оказывает ли новый сотрудник негативное влияние на работу отдела?";
                q3_q1_lb.Text = "Появились ли претензии от начальника отдела?";
                q4_q1_lb.Text = "Появилась ли необходимость в увольнении нового сотрудника?";
                firstPanel.Visible = false;
                secondPanel_questions1.Visible = true;
                secondPanel_questions1.BringToFront();
            }

        }

/*        private void return1_lb_Click(object sender, EventArgs e)
        {
            secondPanel_questions1.Visible = false;
            firstPanel.Visible = true;
            firstPanel.BringToFront();
        }

        private void return1_q1_lb_Click(object sender, EventArgs e)
        {
            secondPanel_questions1.Visible = false;
            firstPanel.Visible = true;
            firstPanel.BringToFront();
        }*/

        private void theEnd_q1_btn_Click(object sender, EventArgs e)
        {
            //secondPanel_questions1.Visible = false;
            //secondPanel_questions1.Visible = false;
/*            if ((!yes_q1_q1_rb.Checked && no_q1_q1_rb.Checked) || (yes_q1_q1_rb.Checked && !no_q1_q1_rb.Checked))
            {
                MessageBox.Show("Пожалуйста, ответьте на вопросы.");
                return;
            }
            else if ((!yes_q2_q1_rb.Checked && no_q2_q1_rb.Checked) || (yes_q2_q1_rb.Checked && !no_q2_q1_rb.Checked))
            {
                MessageBox.Show("Пожалуйста, ответьте на вопросы.");
                return;
            }
            else if ((!yes_q3_q1_rb.Checked && no_q3_q1_rb.Checked) || (yes_q3_q1_rb.Checked && !no_q3_q1_rb.Checked))
            {
                MessageBox.Show("Пожалуйста, ответьте на вопросы.");
                return;
            }
            else if ((!yes_q4_q1_rb.Checked && no_q4_q1_rb.Checked) || (yes_q4_q1_rb.Checked && !no_q2_q1_rb.Checked))
            {
                MessageBox.Show("Пожалуйста, ответьте на вопросы.");
                return;
            }*/
            if (riskSelected == 1)
            {
                MessageBox.Show(riskLevel(q1Sum()*num()));
                firstPanel.Visible = false;
                secondPanel_questions1.Visible = false;
                startPanel.Visible = true;
                startPanel.BringToFront();
                ResetAllRadioButtons(this);
            }
            if (riskSelected == 2)
            {
                MessageBox.Show(riskLevel(q2Sum() * num()));
                firstPanel.Visible = false;
                secondPanel_questions1.Visible = false;
                startPanel.Visible = true;
                startPanel.BringToFront();
                ResetAllRadioButtons(this);
            }
            if (riskSelected == 3) 
            {
                MessageBox.Show(riskLevel(q3Sum() * num()));
                firstPanel.Visible = false;
                secondPanel_questions1.Visible = false;
                startPanel.Visible = true;
                startPanel.BringToFront();
                ResetAllRadioButtons(this);
            }
            if (riskSelected == 4) 
            {
                MessageBox.Show(riskLevel(q3Sum() * num()));
                firstPanel.Visible = false;
                secondPanel_questions1.Visible = false;
                startPanel.Visible = true;
                startPanel.BringToFront();
                ResetAllRadioButtons(this);
                panel1.Visible = false;
            }
            //theEnd_panel.Visible = true;
        }

        private int q1Sum()
        {
            int sum = 0;
            if (yes_q1_q1_rb.Checked)
            {
                sum += 1;
            }
            if (yes_q2_q1_rb.Checked)
            {
                sum += 2;
            }
            if (yes_q3_q1_rb.Checked)
            {
                sum += 6;
            }
            if (yes_q4_q1_rb.Checked)
            {
                sum += 5;
            }
            return sum;
        }

        private int q2Sum() 
        {
            int sum = 0;
            if (yes_q1_q1_rb.Checked)
            {
                sum += 1;
            }
            if (yes_q2_q1_rb.Checked)
            {
                sum += 2;
            }
            if (yes_q3_q1_rb.Checked)
            {
                sum += 6;
            }
            if (yes_q4_q1_rb.Checked)
            {
                sum += 4;
            }
            return sum;
        }
        private int q3Sum()
        {
            int sum = 0;
            if (yes_q1_q1_rb.Checked)
            {
                sum += 5;
            }
            if (yes_q2_q1_rb.Checked)
            {
                sum += 6;
            }
            if (yes_q3_q1_rb.Checked)
            {
                sum += 1;
            }
            if (yes_q4_q1_rb.Checked)
            {
                sum += 2;
            }
            if (yes_dop_rb.Checked)
            {
                sum += 1;
            }
            return sum;
        }
        private int q4Sum()
        {
            int sum = 0;
            if (yes_q1_q1_rb.Checked)
            {
                sum += 6;
            }
            if (yes_q2_q1_rb.Checked)
            {
                sum += 3;
            }
            if (yes_q3_q1_rb.Checked)
            {
                sum += 3;
            }
            if (yes_q4_q1_rb.Checked)
            {
                sum += 1;
            }
            return sum;
        }

        private string riskLevel(int sum)
        {
            

            if (sum < 7)
            {
                return "Уровень риска: Приемлемый\nВыделение дополнительных ресурсов необязательно.";
            }
            else if (sum >= 7 && sum < 14) {
                return "Уровень риска: Значимый\nНеобходимо усилить контроль и сократить интервалы между мониторингами.";
            }
            else if(sum >= 14)
            {
                return "Уровень риска: Значимый\nНеобходимо немедленно принять меры воздействия на риск и выделить значительные ресурсы!";
            }
            return "Error";
        }


        private int num()
        {
            if (isHap1_rb.Checked)
            {
                return 1;
            }
            else if (isHap2_rb.Checked)
            {
                return 2;
            }
            else if (isHap3_rb.Checked)
            {
                return 3;

            }
            else if (isHap4_rb.Checked)
            {
                return 4;
            }
            else if (isHap5_rb.Checked)
            {
                return 5;
            }
            return 0;
        }

        private void ResetAllRadioButtons(Control control)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl is RadioButton radioButton)
                {
                    radioButton.Checked = false;
                }

                if (ctrl.HasChildren)
                {
                    ResetAllRadioButtons(ctrl);
                }
            }
        }


    }
}
