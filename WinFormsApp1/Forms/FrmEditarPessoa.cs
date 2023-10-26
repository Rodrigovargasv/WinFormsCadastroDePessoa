using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;
using WinForm.Desktop.Services.Interfaces;
using WinFormsApp1.Entites;

namespace WinForm.Desktop.Forms
{
    public partial class FrmEditarPessoa : Form
    {
        Pessoa pessoa;
        private readonly IPessoaService _pessoaService;
        private readonly IErroProvider _erroProvider;


        public FrmEditarPessoa(IPessoaService pessoaService, IErroProvider erroProvider)
        {
            InitializeComponent();
            pessoa = new Pessoa();
            _pessoaService = pessoaService;
            _erroProvider = erroProvider;
        }

        public void CarregarDadosGridPessoa(Pessoa pessoaDataGrid)
        {


            pessoa.Id = pessoaDataGrid.Id;
            pessoa.Nome = pessoaDataGrid.Nome;
            pessoa.Sobrenome = pessoaDataGrid.Sobrenome;
            pessoa.Data_Nascimento = pessoaDataGrid.Data_Nascimento;
            pessoa.Sexo = pessoaDataGrid.Sexo;


            textBox3.Text = pessoa.Id.ToString();
            textBox1.Text = pessoa.Nome;
            textBox2.Text = pessoa.Sobrenome;
            dateTimePicker1.Text = pessoa.Data_Nascimento.ToString("dd/MM/yyyy");

            if (pessoa.Sexo == "f")
                comboBox1.Text = "Feminimo";

            if (pessoa.Sexo == "m")
                comboBox1.Text = "Masculino";



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            try
            {

                pessoa.Nome = textBox1.Text.Trim();

                if (string.IsNullOrEmpty(pessoa.Nome) || string.IsNullOrWhiteSpace(pessoa.Nome))
                    _erroProvider.ErroProvider(textBox1, "Este campo é obrigatório");

                if (textBox1.Text.Length < 3)
                    _erroProvider.ErroProvider(textBox1, "Campo deve conter no mínimo 3 caracteres");


                else
                    _erroProvider.ClearError(textBox1);


            }
            catch
            {
                _erroProvider.ErroProvider(textBox1, "");
            }



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(textBox2.Text) && string.IsNullOrWhiteSpace(textBox2.Text))
                    _erroProvider.ErroProvider(textBox2, "Este campo é obrigatório");

                if (textBox2.Text.Length < 3)
                    _erroProvider.ErroProvider(textBox2, "Campo deve conter no mínimo 3 caracteres");


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
            if (dateTimePicker1.Value >= DateTime.Now)
                _erroProvider.ErroProvider(dateTimePicker1, "Data não pode ser igual a data atual");


            if (dateTimePicker1.Value >= DateTime.Now.AddYears(-18))
                _erroProvider.ErroProvider(dateTimePicker1, "O Usuário deve ter no mínino 18 anos");
            if (string.IsNullOrEmpty(dateTimePicker1.Value.ToString()))
                _erroProvider.ErroProvider(dateTimePicker1, "Este campo é obrigatório");
            else
            {
                _erroProvider.ClearError(dateTimePicker1);
                pessoa.Data_Nascimento = dateTimePicker1.Value;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Feminino")
                pessoa.Sexo = "f";

            if (comboBox1.SelectedItem.ToString() == "Masculino")
                pessoa.Sexo = "m";

            if (string.IsNullOrEmpty(comboBox1.Text))
                _erroProvider.ErroProvider(comboBox1, "Este campo é obrigatório");

            else
                _erroProvider.ClearError(comboBox1);
        }

        private void BtnSalvarAlteracaoPessoa_Click(object sender, EventArgs e)
        {

            try
            {


                if (ValidadationForms() == true)
                {

                    return;
                }
                else
                {

                    _pessoaService.UpdatePessoaAsync(pessoa);
                    this.Hide();


                }

            }
           
            catch
            {
                MessageBox.Show("Erro ao atulizar usuário");

            }

        }
        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public bool ValidadationForms()
        {


            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
                _erroProvider.ErroProvider(textBox1, "Este campo é obrigatório");

            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
                _erroProvider.ErroProvider(textBox2, "Este campo é obrigatório");

            if (string.IsNullOrEmpty(comboBox1.Text))
                _erroProvider.ErroProvider(comboBox1, "Este campo é obrigatório");


            if (dateTimePicker1.Value >= DateTime.Now.AddYears(-18))
                _erroProvider.ErroProvider(dateTimePicker1, "O usuário deve ter no mínimo 18 anos");

            else
                return false;


            return true;

        }


    }
}
