﻿

namespace WinFormsApp1.Entites
{
    public class Pessoa
    {
      

        public int? Id { get;  set; }
        public string? Nome { get;  set; }

        public string? Sobrenome { get;  set; }

        public DateTime Data_Nascimento { get; set; } = DateTime.Now.AddYears(-18);

        public string? Sexo { get; set; }






    }
}