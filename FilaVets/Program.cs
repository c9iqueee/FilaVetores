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
                Console.WriteLine("-------Seja bem vindo ao nosso hospital-------\n\n\n");
                Console.WriteLine("O que você deseja fazer?\n 1. Cadastrar novo paciente\n 2. Atender paciente\n 3. Ver a fila\n q. Sair");
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
                            int index = 0;
                            while (index < count && fila[index]?.Preferencial == true)
                            {
                                index++;
                            }

                            if (index < count)
                            {
                                for (int i = count; i > index; i--)
                                {
                                    fila[i] = fila[i - 1];
                                }
                                fila[index] = new Paciente(nome, idade, preferencial);
                                count++;
                            }
                            else if (count < 10)
                            {
                                fila[count++] = new Paciente(nome, idade, preferencial);
                            }
                            else
                            {
                                Console.WriteLine("Fila cheia. Paciente preferencial não adicionado.\n");
                            }
                        }
                        else
                        {
                            // Adiciona o paciente normal no final da fila
                            if (count < 10)
                            {
                                fila[count++] = new Paciente(nome, idade, preferencial);
                                Console.WriteLine("Paciente adicionado.\n");
                            }
                            else
                            {
                                Console.WriteLine("Fila cheia. Paciente normal não adicionado.\n");
                            }
                        }
                        break;


                    case '2':

                        if (count > 0)
                        {
                            for (int i = 0; i < count - 1; i++)
                            {
                                fila[i] = fila[i + 1];
                            }

                            fila[count - 1] = null;
                            count--; // Reduz o contador da fila pacientes

                            Console.WriteLine("Paciente atendido.\n");

                        }
                        else
                        {
                            Console.WriteLine("Não há pacientes na fila para atender.\n");
                        }
                        
                        break;


                    case '3':
                        Console.WriteLine("Fila atual:");
                        Console.WriteLine($"Número atual de pacientes na fila: {count}\n");
                        for (int i = 0; i < count; i++)
                        {
                            if (fila[i] != null)
                            {
                                Console.WriteLine($"Paciente {i + 1}: Nome: {fila[i].Nome} | Idade: {fila[i].Idade} | {(fila[i].Preferencial ? "Preferencial" : "Normal")}");
                            }
                            else
                            {
                                Console.WriteLine($"Paciente {i + 1}: Vazio");
                            }
                        }
                        Console.WriteLine("\n");
                        break;


                    case 'q':
                        Console.WriteLine("Fechando programa...");
                        Console.ReadKey(); 
                        return;

                }
            }
        }
    }
}

