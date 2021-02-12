using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desafio.GitHub.Site.Models
{
    public class RepositorioRetornoDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public DateTime Updated_At { get; set; }
        public string Dono { get; set; }
    }
}