namespace Reserva
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var reservaEntidade = new Reserva
            {
                Id = 1001,
                NomeHospede = "Lucas Moreira",
                NumeroQuarto = 405,
                QuantidadeDiarias = 5,
                ValorDiaria = 250.00,
                StatusInterno = "Pagamento Pendente",
                ObservacaoInterna = "Cliente solicitou vista para o mar"
            };
            
            var relatorioDto = Mapear(reservaEntidade);

            ExibirRelatorio(relatorioDto);
        }
        public static RelatorioReservaDto Mapear(Reserva reserva)
        {
            double valorTotalCalculado = reserva.QuantidadeDiarias * reserva.ValorDiaria;

            string situacaoDefinida = "Reserva confirmada";

            return new RelatorioReservaDto(
                reserva.NomeHospede,
                reserva.NumeroQuarto,
                reserva.QuantidadeDiarias,
                valorTotalCalculado,
                situacaoDefinida
            );
        }
        public static void ExibirRelatorio(RelatorioReservaDto relatorio)
        {
            Console.WriteLine("--- Relatório da Reserva ---");
            Console.WriteLine($"Hóspede: {relatorio.NomeHospede}");
            Console.WriteLine($"Quarto: {relatorio.NumeroQuarto}");
            Console.WriteLine($"Quantidade de Diárias: {relatorio.QuantidadeDiarias}");
            Console.WriteLine($"Valor Total: {relatorio.ValorTotal:C}");
            Console.WriteLine($"Situação: {relatorio.Situacao}");
        }
    }
}
