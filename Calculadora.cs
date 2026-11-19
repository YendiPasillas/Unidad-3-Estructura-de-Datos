using proyecto4;
using System;
using System.Collections.Generic;

namespace proyecto4
{
    public class Calculadora
    {
        private int ObtenerJerarquia(char operador)
        {
            switch (operador)
            {
                case '^': return 3;
                case '*':
                case '/':
                case '%': return 2;
                case '+':
                case '-': return 1;
                default: return 0;
            }
        }

        public bool ValidarExpresion(string expresion, out string mensajeError)
        {
            mensajeError = "";
            int parentesis = 0;

            foreach (char c in expresion)
            {
                if (c == '(') parentesis++;
                else if (c == ')')
                {
                    parentesis--;
                    if (parentesis < 0)
                    {
                        mensajeError = "Error: Paréntesis de cierre ')' sin apertura correspondiente.";
                        return false;
                    }
                }
            }

            if (parentesis > 0)
            {
                mensajeError = "Error: Paréntesis de apertura '(' sin cerrar.";
                return false;
            }

            return true;
        }

        public string InfijaAPostfija(string infija)
        {
            Pila pila = new Pila();
            string postfija = "";

            foreach (char c in infija)
            {
                if (c == ' ') continue;

                if (char.IsLetterOrDigit(c))
                {
                    postfija += c + " ";
                }
                else if (c == '(')
                {
                    pila.Apilar(c);
                }
                else if (c == ')')
                {
                    while (!pila.Vacia() && pila.ObtenerTope() != '(')
                    {
                        postfija += pila.Desapilar() + " ";
                    }
                    if (!pila.Vacia())
                    {
                        pila.Desapilar();
                    }
                }
                else if ("+-*/%^".Contains(c))
                {
                    while (!pila.Vacia() && ObtenerJerarquia(pila.ObtenerTope()) >= ObtenerJerarquia(c))
                    {
                        postfija += pila.Desapilar() + " ";
                    }
                    pila.Apilar(c);
                }
            }

            while (!pila.Vacia())
            {
                postfija += pila.Desapilar() + " ";
            }

            return postfija.Trim();
        }

        public double EvaluarPostfija(string postfija, out string error)
        {
            error = "";
            Stack<double> pilaEval = new Stack<double>();
            string[] tokens = postfija.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string token in tokens)
            {
                if (double.TryParse(token, out double numero))
                {
                    pilaEval.Push(numero);
                }
                else if (token.Length == 1 && "+-*/%^".Contains(token[0]))
                {
                    if (pilaEval.Count < 2)
                    {
                        error = "Error matemático: Faltan operandos.";
                        return 0;
                    }

                    double b = pilaEval.Pop();
                    double a = pilaEval.Pop();
                    double resultado = 0;

                    switch (token[0])
                    {
                        case '+': resultado = a + b; break;
                        case '-': resultado = a - b; break;
                        case '*': resultado = a * b; break;
                        case '/':
                            if (b == 0)
                            {
                                error = "Error matemático: División entre cero.";
                                return 0;
                            }
                            resultado = a / b;
                            break;
                        case '%':
                            if (b == 0)
                            {
                                error = "Error matemático: Módulo por cero.";
                                return 0;
                            }
                            resultado = a % b;
                            break;
                        case '^': resultado = Math.Pow(a, b); break;
                    }
                    pilaEval.Push(resultado);
                }
            }

            if (pilaEval.Count == 1)
            {
                return pilaEval.Pop();
            }
            else
            {
                error = "Error: Expresión mal formada.";
                return 0;
            }
        }
    }
}
