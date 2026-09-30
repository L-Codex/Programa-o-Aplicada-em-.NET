namespace Biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Criação dos objetos para testar as validações
            var alunoAutorizado = new Aluno { Nome = "Lucas", Matricula = "12345", QuantidadeEmprestimosAtivos = 2 };
            var alunoBloqueado = new Aluno { Nome = "Clara", Matricula = "67890", QuantidadeEmprestimosAtivos = 3 };
           
            var profAutorizado = new Professor { Nome = "Luis", Departamento = "Computação", QuantidadeEmprestimosAtivos = 4 };
            var profBloqueado = new Professor { Nome = "Ana", Departamento = "Matemática", QuantidadeEmprestimosAtivos = 6 };

            var visitante = new Visitante { Nome = "Pedro", Documento = "111.222.333-44" };

            object usuarioInvalido = null;
            object usuarioNaoClassificado = new object();
            
            Console.WriteLine("Testes de Empréstimo");
            Console.WriteLine(VerificarEmprestimo(usuarioInvalido));
            Console.WriteLine(VerificarEmprestimo(alunoAutorizado));
            Console.WriteLine(VerificarEmprestimo(alunoBloqueado));
            Console.WriteLine(VerificarEmprestimo(profAutorizado));
            Console.WriteLine(VerificarEmprestimo(profBloqueado));
            Console.WriteLine(VerificarEmprestimo(visitante));
            Console.WriteLine(VerificarEmprestimo(usuarioNaoClassificado));
        }
        public static string VerificarEmprestimo(Object obj)
        {
            //Switch Expression
            return obj switch
            {
                null => "Usuário inválido",
                // TYPE PATTERN (Aluno), PROPERTY PATTERN ({...}) e RELATIONAL PATTERN (< 3)
                Aluno { QuantidadeEmprestimosAtivos: < 3 } => "Empréstimo autorizado para aluno",
                Aluno { QuantidadeEmprestimosAtivos: >= 3 } => "Limite de empréstimos atingido para aluno",
                Professor { QuantidadeEmprestimosAtivos: < 5 } => "Empréstimo autorizado para professor",
                Professor { QuantidadeEmprestimosAtivos: >= 5 } => "Limite de empréstimos atingido para professor",
                // Type Pattern: Se o tipo for Visitante (não importa o estado das propriedades), cai aqui
                Visitante => "Visitantes não podem realizar empréstimos",
                // Discard Pattern: O "underline"(_) funciona como o antigo "default" do switch
                _ => "Usuário não classificado"
            };
        }
    }
}
