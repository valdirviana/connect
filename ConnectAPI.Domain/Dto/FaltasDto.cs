using System;
using ConnectAPI.Domain.Base.Dto;

namespace ConnectAPI.Domain.Dto
{
    public class FaltasDto : EntidadeBaseDto
    {
        public DateTime Data { get; set; }
        public bool Justificada { get; set; }
        public int IdFuncionario { get; set; }
    }
}
