using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;

namespace Tu_będzie_program_na_LAB_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("        Witamy w przychodni!        ");
            Console.WriteLine("------------------------------------");

            Random random = new Random();
            Queue<int> Kolejka = new Queue<int>();
            Queue<int> Temp = new Queue<int>();

            Kolejka.Enqueue(10054);
            Kolejka.Enqueue(10064);
            Kolejka.Enqueue(10024);

            bool przerwanie = true;
            while (przerwanie == true)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("1 - Rejestracja Pacjenta            ");
                Console.WriteLine("2 - Przyjęcie pacjenta przez lekarza");
                Console.WriteLine("3 - Przyjęcie wszystkich pacjentów  ");
                Console.WriteLine("0 - Wyjście z przychodni            ");
                Console.WriteLine("------------------------------------");
                int decyzja = int.Parse(Console.ReadLine());

                switch (decyzja)
                {
                    case 1:
                        Console.WriteLine("Proszę podać numer pacjenta, pierwsza liczba oznacza priorytet pacjenta");
                        int pacjent = int.Parse(Console.ReadLine());
                        int priorytet = (int)(pacjent * 0.0001);
                        Console.WriteLine("Priorytet pacjenta: " + priorytet);

                        while ((int)(Kolejka.Peek() * 0.0001) > priorytet)
                        {
                            Temp.Enqueue(Kolejka.Dequeue());
                        }
                        Temp.Enqueue(pacjent);
                        while (Kolejka.Count > 0)
                        {
                            Temp.Enqueue(Kolejka.Dequeue());
                        }

                        while (Temp.Count > 0)
                        {
                            Kolejka.Enqueue(Temp.Dequeue());
                        }
                        Console.WriteLine("Pomyślnie zarejestrowano pacjenta!\n");
                        break;

                    case 2:
                        Console.WriteLine($"Wizyta pacjenta {Kolejka.Peek()} ... Proszę czekać");
                        Thread.Sleep(random.Next(1000, 5000));
                        Console.WriteLine($"Wizyta pacjenta {Kolejka.Dequeue()} zakończona!\n");
                        break;
                    case 3:
                        while (Kolejka.Count > 0)
                        {
                            Console.WriteLine($"Wizyta pacjenta {Kolejka.Peek()} ... Proszę czekać");
                            Thread.Sleep(random.Next(1000, 5000));
                            Console.WriteLine($"Wizyta pacjenta {Kolejka.Dequeue()} zakończona!\n");
                        }
                        break;

                    case 0:
                        przerwanie = false;
                        break;
                    default:
                        Console.WriteLine("Coś poszło nie tak, prosimy spróbować ponownie.");
                        break;
                }
            }
        }
    }
}
