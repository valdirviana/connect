using System;
using ConnectAPI.Domain.Base.Model;

namespace ConnectAPI.Domain.Model
{
    public class Faltas : EntidadeBase
    {
        public DateTime Data { get; set; }
        public bool Justificada { get; set; }
        public int IdFuncionario { get; set; }
    }
}
