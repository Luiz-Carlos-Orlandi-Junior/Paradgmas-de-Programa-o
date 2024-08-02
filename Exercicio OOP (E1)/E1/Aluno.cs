using System;
namespace E1
{
    public class Universidade
    {
        // Método normal
        public void Ensino()
        {
            Console.WriteLine("Método de ensino");
        }

        // Método sobreescrita
        public class Guardar
        {
            public virtual void Finalidade()
            {
                Console.WriteLine("Mochila (Armazenar)");
            }
        }

        // Para executar a sobrescrita do método Finalidade que está no objeto pai, utilizamos o override
        public class GuardarMateriais : Guardar
        {
            public override void Finalidade()
            {
                base.Finalidade();
                Console.WriteLine("Manter os materiais organizados");
            }
        }

        // Método sobrecarga
        public virtual void SomIntervalo()
        {
            Console.WriteLine("Todos para o intervalo");
        }


        // Assinaturas
        public void AbrirMochila()
        {
            Console.WriteLine("Mochila está sendo aberta...");
        }

        public bool AbrirMochila(string mochila)
        {
            Console.WriteLine($"Abrindo a mochila {mochila}");
            return true;
        }

        // Construtor padrão
        public class Universitario
        {
            // Atributos
            private string Sobrenome { get; set; }

            // Propriedades
            public string Nome { get; set; }

            public Universitario(string nome)
            {
                Nome = nome;
            }

            public void Estudar()
            {
                Console.WriteLine($"{Nome} está estudando.");
            }
        }

        // Classe filha (sub classe)
        public class Patrimonio : Universidade
        {
            private string _numeracao;
            private string _nome;

            public string Nome
            {
                get { return _nome; }
                set { _nome = value; }
            }

            public string Numeracao
            {
                get { return _numeracao; }
                set { _numeracao = value; }
            }

            public void ExibirPatrimonio()
            {
                Console.WriteLine($"Patrimônio: {Nome}, Cor: {Numeracao}");
            }
        }
    }
}
