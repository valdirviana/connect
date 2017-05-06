using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectAPI.Domain.Base.Dto;
using ConnectAPI.Domain.Base.Model;

namespace ConnectAPI.Domain.Dto
{
    public class FeriasDto : EntidadeBaseDto
    {
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int IdFuncionario { get; set; }
    }
}
