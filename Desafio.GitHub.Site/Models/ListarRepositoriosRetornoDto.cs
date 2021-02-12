using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desafio.GitHub.Site.Models
{
    public class ListarRepositoriosRetornoDto : BaseDto
    {
        public List<RepositorioRetornoDto> repositorios { get; set; }
    }
}