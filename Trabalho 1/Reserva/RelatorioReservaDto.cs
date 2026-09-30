using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reserva
{
    public record RelatorioReservaDto(string NomeHospede,int NumeroQuarto,int QuantidadeDiarias,double ValorTotal,string Situacao);
}
