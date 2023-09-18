using System.ComponentModel;
using System.Windows.Forms;
using WinFormsApp1.Entites;
using WinFormsApp1.Interfaces;
using WinFormsApp1.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {

        private Pessoa pessoa;

        private readonly IPessoaService _pessoaService;

        private readonly IErroProvider _erroProvider;


        public Form2()
        {

            InitializeComponent();
            pessoa = new Pessoa();

        }

        public Form2(IPessoaService pessoaService, IErroProvider erroProvider)
        {
            InitializeComponent();
            pessoa = new Pessoa();
            _pessoaService = pessoaService;
            _erroProvider = erroProvider;

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            try
            {

                pessoa.Nome = textBox1.Text.Trim();

                if (string.IsNullOrEmpty(pessoa.Nome) || string.IsNullOrWhiteSpace(pessoa.Nome))
                {
                    ValidadationForms();
                }
                else
                {
                    _erroProvider.ClearError(textBox1);
                }

            }
            catch
            {
                _erroProvider.ErroProvider(textBox1, "");
            }

        }


        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

            try
            {

                if (string.IsNullOrEmpty(textBox2.Text) && string.IsNullOrWhiteSpace(textBox2.Text))
                {

                    _erroProvider.ErroProvider(textBox2, "Campo é de preechimento Obrigatorio");
                }

                else
                {

                    _erroProvider.ClearError(textBox2);
                    pessoa.Sobrenome = textBox2.Text.Trim();
                }

            }
            catch
            {

                _erroProvider.ErroProvider(textBox1, "Este campo é obrigatório");
            }

        }



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            pessoa.Data_Nascimento = dateTimePicker1.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem.ToString() == "Feminino")
            {
                pessoa.Sexo = "f";
            }
            if (comboBox1.SelectedItem.ToString() == "Masculino")
            {
                pessoa.Sexo = "m";
            }
            else
            {
                _erroProvider.ErroProvider(comboBox1, "Este campo é obrigatório");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                try
                {


                    if (ValidadationForms() == true)
                    {

                        return;
                    }
                    else
                    {

                        Thread.Sleep(1000);

                        _pessoaService.CreatePessoaAsync(pessoa);

                        this.Hide();

                    }

                }
                catch
                {
                    MessageBox.Show("Valores invalidos");

                }

            }
            catch
            {
                MessageBox.Show("asdas");

            }


        }

        public bool ValidadationForms()
        {

            var date = DateTime.Now.ToString("yyyy/MM/dd");

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(comboBox1.Text) && dateTimePicker1.Value < Convert.ToDateTime(date))

            {
                _erroProvider.ClearError(textBox2);
                _erroProvider.ClearError(textBox2);
                _erroProvider.ClearError(dateTimePicker1);
                _erroProvider.ClearError(comboBox1);

                return false;
            }

            else
            {

                _erroProvider.ErroProvider(textBox1, "Campo tem preenchimento obrigatorio");
                _erroProvider.ErroProvider(textBox2, "Campo tem preenchimento obrigatorio");
                _erroProvider.ErroProvider(comboBox1, "Este campo é obrigatório");
                _erroProvider.ErroProvider(dateTimePicker1, "A data deve ser menor que a data atual");

            }

            return true;

        }


    }
}