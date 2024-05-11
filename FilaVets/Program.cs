using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilaVets
{
    class Program
    {
        static void Main(string[] args)
        {
            Paciente[] fila = new Paciente[10];
            int count = 0;
            char op;

            while (true)
            {
                Console.WriteLine("-------Bem vindo ao hospital-------");
                Console.WriteLine("O que você deseja fazer?\n 1. Cadastrar novo paciente\n 2.Atender paciente\n 3. Ver a fila\n 4. Sair");
                op = char.Parse(Console.ReadLine());

                switch (op)
                {
                    case '1':
                        Console.WriteLine("Insira o nome do paciente: ");
                        string nome = Console.ReadLine();

                        Console.WriteLine("Insira a idade do paciente: ");
                        int idade = int.Parse(Console.ReadLine());

                        Console.WriteLine("O paciente é preferencial?(sim/nao):");
                        bool preferencial = Console.ReadLine().ToLower() == "sim";
                        if (preferencial)
                        {
                            bool temPreferencial = false;
                            for (int i = 0; i < count; i++)
                            {
                                if (fila[i].Preferencial)
                                {
                                    temPreferencial = true;
                                    break;
                                }
                            }
                            if (!temPreferencial)
                            {
                                for (int i = count; i > 0; i--)
                                {
                                    fila[i] = fila[i - 1];
                                }
                                fila[0] = new Paciente(nome, idade, preferencial);
                            }
                            else
                            {
                                fila[count] = new Paciente(nome, idade, preferencial);
                            }

                        }
                        else
                        {
                            // Adiciona o paciente normal no final da fila
                            if (count < 10)
                            {
                                fila[count] = new Paciente(nome, idade, preferencial);
                                count++;
                            }
                            else
                            {
                                Console.WriteLine("Fila cheia. Paciente normal não adicionado.");
                            }
                        }
                        break;

                    case '2':
                        for (int i = 0; i < fila.Length - 1; i++)
                        {
                            fila[i] = fila[i + 1];
                        }

                        fila[fila.Length - 1] = 0;

                        break;

                    case '3':
                        Console.WriteLine("Fila atual:");
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine($"Nome: {fila[i].Nome}, Idade: {fila[i].Idade}, {(fila[i].Preferencial ? "Preferencial" : "Normal")}");
                        }

                        break;
                }
            }
        }
    }
}

