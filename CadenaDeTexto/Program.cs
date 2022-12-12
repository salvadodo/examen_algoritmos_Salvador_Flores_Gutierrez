using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadenaDeTexto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string EntradaTexto;
            string[] Palabras;
            Console.WriteLine("Escribe unas lineas de Texto");
            EntradaTexto = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Input: " + EntradaTexto);

            Palabras = EntradaTexto.Split(' ');
            string[] EntradaLimpia = new string[Palabras.Length];
            //int cantidad = 0;
            string json;
            string concate = "";

            for(int k=0; k<Palabras.Length; k++)
            {
                string sinChar = Palabras[k].Trim(new Char[] { '.', '"', ',', ':', ';', '-' });
                EntradaLimpia[k]=sinChar;
            }
            for (int i = 0; i < EntradaLimpia.Length; i++)
            {
                int[] cantidad = new int[EntradaLimpia.Length];
                cantidad[i] = 0;
                string actual = EntradaLimpia[i];
                for (int j = 0; j < EntradaLimpia.Length; j++)
                {
                    if (actual == EntradaLimpia[j])
                    {
                        cantidad[i] += 1;
                        concate += actual + ": " + cantidad[i] + ", ";
                    }
                }
            }
            json="{"+concate+"}";
            //bool tiene=EntradaTexto.Contains(Palabra);
            Console.WriteLine(json);
            Console.ReadKey();
        }
    }
}
