using System;
using ConnectAPI.Domain.Base.Dto;

namespace ConnectAPI.Domain.Dto
{
    public class FuncionarioDto : EntidadeBaseDto
    {
        public string Nome { get; set; }
        public string Setor { get; set; }
        public string Cargo { get; set; }
        public DateTime DataAdmissao { get; set; }
        public decimal Salario { get; set; }
    }
}
