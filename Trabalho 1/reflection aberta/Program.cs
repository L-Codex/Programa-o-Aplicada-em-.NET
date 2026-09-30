using System.Reflection;

namespace reflection_aberta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var meuEquipamento = new Equipamento
            {
                Id = 101,
                Nome = "Servidor",
                Fabricante = "Dell",
                NumeroSerie = "SRV-999999",
                Valor = 15000,
                Localizacao = "Data Center"
            };

            ExibirDadosAberto(meuEquipamento);
            ExibirDadosControlado(meuEquipamento);
        }
        public static void ExibirDadosAberto(object objeto)
        {
            Console.WriteLine("--- Reflection Aberta ---");
            Type tipo = objeto.GetType();

            PropertyInfo[] propriedades = tipo.GetProperties();

            foreach (var prop in propriedades)
            {
                var valor = prop.GetValue(objeto);
                Console.WriteLine($"{prop.Name}: {valor}");
            }
            Console.WriteLine();
        }
        public static void ExibirDadosControlado(object objeto)
        {
            Console.WriteLine("--- Reflection Controlada ---");
            Type tipo = objeto.GetType(); 
            PropertyInfo[] propriedades = tipo.GetProperties();

            foreach (var prop in propriedades)
            {
                var atributo = prop.GetCustomAttribute<ExibirAttribute>();

                if (atributo != null)
                {
                    var valor = prop.GetValue(objeto); //[cite: 1]
                    Console.WriteLine($"{prop.Name}: {valor}");
                }
            }
            Console.WriteLine();
        }
    }

}
