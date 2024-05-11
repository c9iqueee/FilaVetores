using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilaVets
{
    class Paciente
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public bool Preferencial { get; set; }

        public Paciente(string nome, int idade, bool preferencial)
        {
            Nome = nome;
            Idade = idade;
            Preferencial = preferencial;
        }
    }
}
