using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desafio.GitHub.Site.Models
{
    public class ListarRepositoriosFavoritadosRetornoDto : BaseDto
    {
        public List<RepositoriosFavoritadosRetornoDto> RepositoriosFavoritados { get; set; }
    }
}