using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reflection_aberta
{
    internal class Equipamento
    {
        public int Id { get; set; }

        [Exibir]
        public string Nome { get; set; }

        [Exibir]
        public string Fabricante { get; set; }

        public string NumeroSerie { get; set; }

        [Exibir]
        public double Valor { get; set; }

        [Exibir]
        public string Localizacao { get; set; }
    }
}
