using System;
using System.Windows.Forms;

namespace CalculadorA_c
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string operador;
        double visor, mem, num1, num2;

        private void reset()
        {
            operador = "";
            visor = mem = num1 = num2 = 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            reset();
        }

        bool limpar = true;

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void mostra()
        {
            label1.Text = Math.Abs(visor).ToString();
            if (mem != 0) memory.Visible = false; else memory.Visible = true;
            if (visor < 0) minus.Visible = false; else minus.Visible = true;
            if (label1.Text.Length > 9) label1.Text = label1.Text.Substring(0, 9);
        }

        private void calcula()
        {
            if (num2 == 0) num2 = visor;
            if (operador == "+") visor = num1 + num2;
            else if (operador == "-") visor = num1 - num2;
            else if (operador == "×") visor = num1 * num2;
            else if (operador == "÷") visor = num1 / num2;
            mostra();
            num1 = visor;
            visor = 0;
            limpar = true;
        }


        private void Clicar(object sender, EventArgs e)
        {
            if (limpar) { label1.Text = ""; limpar = false; }
            string botao = ((Button)sender).Tag.ToString();
            switch (botao)
            {
                case "MRC": visor = mem; mostra(); break;
                case "M-": mem -= visor; mostra(); break;
                case "M+": mem += visor; mostra(); break;
                case "√": visor = Math.Sqrt(visor); mostra(); break;
                case "OFF": reset(); label1.Text = ""; break;
                case "AC": reset(); mostra(); break;
                case "C": visor = 0; mostra(); break;
                case "+/-": visor = -visor; mostra(); break;
                case "%": visor = visor / 100 * num1; mostra(); break;
                case "+":
                case "-":
                case "×":
                case "÷":
                    {
                        if (num1 == 0) num1 = visor;
                        else calcula();
                        operador = botao;
                        visor = 0;
                        limpar = true;
                        break;
                    }
                case "=": calcula(); break;
                case ".": if (!label1.Text.Contains(",")) label1.Text += ","; break;
                default:
                    {
                        label1.Text += botao;
                        visor = Convert.ToDouble(label1.Text);
                        mostra();
                        break;
                    }
            }
        }
    }
}