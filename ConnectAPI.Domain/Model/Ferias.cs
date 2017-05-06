using System;
using ConnectAPI.Domain.Base.Model;

namespace ConnectAPI.Domain.Model
{
    public class Ferias : EntidadeBase
    {
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int IdFuncionario { get; set; }
    }
}
