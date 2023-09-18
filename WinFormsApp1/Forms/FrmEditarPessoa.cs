using System.Windows.Forms;
using WinForm.Desktop.Services.Interfaces;
using WinFormsApp1;
using WinFormsApp1.Entites;

namespace WinForm.Desktop.Forms
{
    public partial class FrmEditarPessoa : Form
    {
        private Pessoa pessoa;
        private readonly IPessoaService _pessoaService;
        private readonly IErroProvider _erroProvider;


        public FrmEditarPessoa(IPessoaService pessoaService, IErroProvider erroProvider)
        {
            InitializeComponent();
            pessoa = new Pessoa();
            _pessoaService = pessoaService;
            _erroProvider = erroProvider;
        }

        internal void CarregarDadosGridPessoa(Pessoa pessoaDataGrid)
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

        private void textBox2_TextChanged(object sender, EventArgs e)
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

        private void BtnSalvarAlteracaoPessoa_Click(object sender, EventArgs e)
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

                        _pessoaService.UpdatePessoaAsync(pessoa);
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
        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
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
