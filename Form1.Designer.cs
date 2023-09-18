namespace WinFormsApp1
{
    partial class FrmCadastroPessoa
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SairCadastro = new Button();
            CadastrarPessoa = new Button();
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // SairCadastro
            // 
            SairCadastro.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SairCadastro.BackColor = Color.Red;
            SairCadastro.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SairCadastro.ForeColor = SystemColors.ButtonHighlight;
            SairCadastro.Location = new Point(626, 3);
            SairCadastro.Name = "SairCadastro";
            SairCadastro.Size = new Size(75, 57);
            SairCadastro.TabIndex = 2;
            SairCadastro.Text = "Sair";
            SairCadastro.UseVisualStyleBackColor = false;
            SairCadastro.Click += SairCadastro_Click;
            // 
            // CadastrarPessoa
            // 
            CadastrarPessoa.Anchor = AnchorStyles.Left;
            CadastrarPessoa.BackColor = Color.ForestGreen;
            CadastrarPessoa.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point);
            CadastrarPessoa.ForeColor = SystemColors.ButtonHighlight;
            CadastrarPessoa.Location = new Point(10, 3);
            CadastrarPessoa.Name = "CadastrarPessoa";
            CadastrarPessoa.Size = new Size(78, 54);
            CadastrarPessoa.TabIndex = 1;
            CadastrarPessoa.Text = "Incluir";
            CadastrarPessoa.UseVisualStyleBackColor = false;
            CadastrarPessoa.Click += CadastrarPessoa_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(CadastrarPessoa);
            panel1.Controls.Add(SairCadastro);
            panel1.Location = new Point(2, 53);
            panel1.Name = "panel1";
            panel1.Size = new Size(713, 60);
            panel1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.ControlText;
            dataGridView1.Location = new Point(2, 131);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(713, 251);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(265, 9);
            label1.Name = "label1";
            label1.Size = new Size(201, 29);
            label1.TabIndex = 4;
            label1.Text = "Cadastro de Pessoa";
            label1.TextAlign = ContentAlignment.TopCenter;
            label1.UseMnemonic = false;
            // 
            // FrmCadastroPessoa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(716, 384);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "FrmCadastroPessoa";
            ShowInTaskbar = false;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SairCadastro;
        private Button CadastrarPessoa;
        private Panel panel1;
        private DataGridView dataGridView1;
        private Label label1;
    }
}