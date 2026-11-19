using System;

namespace proyecto4
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculadora calc = new Calculadora();
            int opcion = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("  CALCULADORA DE EXPRESIONES MATEMÁTICAS  ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Validar expresión");
                Console.WriteLine("2. Convertir Infija a Postfija");
                Console.WriteLine("3. Evaluar expresión (Ej. (5+3)*2)");
                Console.WriteLine("4. Salir");
                Console.Write("\nSeleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("\nIngrese la expresión infija: ");
                            string expVal = Console.ReadLine();
                            if (calc.ValidarExpresion(expVal, out string msgError))
                            {
                                Console.WriteLine("\n¡La expresión es correcta!");
                            }
                            else
                            {
                                Console.WriteLine($"\n{msgError}");
                            }
                            break;

                        case 2:
                            Console.Write("\nIngrese la expresión infija: ");
                            string expInfija = Console.ReadLine();
                            if (calc.ValidarExpresion(expInfija, out string err))
                            {
                                string postfija = calc.InfijaAPostfija(expInfija);
                                Console.WriteLine($"\nExpresión Postfija: {postfija}");
                            }
                            else
                            {
                                Console.WriteLine($"\n{err}");
                            }
                            break;

                        case 3:
                            Console.Write("\nIngrese la expresión matemática: ");
                            string expresion = Console.ReadLine();
                            if (calc.ValidarExpresion(expresion, out string errorVal))
                            {
                                string post = calc.InfijaAPostfija(expresion);
                                Console.WriteLine($"Postfija: {post}");
                                double resultado = calc.EvaluarPostfija(post, out string errorEval);
                                if (string.IsNullOrEmpty(errorEval))
                                {
                                    Console.WriteLine($"Resultado = {resultado}");
                                }
                                else
                                {
                                    Console.WriteLine($"\n{errorEval}");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"\n{errorVal}");
                            }
                            break;

                        case 4:
                            Console.WriteLine("\nSaliendo del programa...");
                            break;

                        default:
                            Console.WriteLine("\nOpción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nPor favor ingrese un número válido.");
                }

                if (opcion != 4)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 4);
        }
    }
}