using System;
using ConnectAPI.Domain.Base.Model;

namespace ConnectAPI.Domain.Model
{
    public class Funcionario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Setor { get; set; }
        public string Cargo { get; set; }
        public DateTime DataAdmissao { get; set; }
        public decimal Salario { get; set; }
    }
}
