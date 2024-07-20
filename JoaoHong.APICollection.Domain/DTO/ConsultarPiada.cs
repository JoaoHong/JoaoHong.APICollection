using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoaoHong.APICollection.Domain.DTO
{
	public class ConsultarPiada
	{
		public string? Categoria { get; set; }
		public string? Idioma { get; set; }
		public string? Tipo { get; set; }
		public int Quantidade { get; set; }
	}
}
