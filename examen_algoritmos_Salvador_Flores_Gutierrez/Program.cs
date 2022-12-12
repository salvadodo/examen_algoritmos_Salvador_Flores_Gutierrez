using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen_algoritmos_Salvador_Flores_Gutierrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int PuntosAlice=0;
            int PuntosBob=0;
            int[] a=new int[3];
            int[] b=new int[3];

            for(int i = 0; i <= a.Length; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("Ingrese Puntos en CLARIDAD DEL PROBLEMA para Alice ");
                    a[i] = Convert.ToInt32(Console.ReadLine());
                    if (0 <= a[i] && a[i]<=100)
                    {
                        Console.WriteLine("Puntos en CLARIDAD DEL PROBLEMA " + a[i]);
                    }
                    else
                    {
                        Console.WriteLine("Ingrese un valor entre 1 y 100");
                        a[i] = Convert.ToInt32(Console.ReadLine());
                    }
                }
                if (i == 1)
                {
                    Console.WriteLine("Ingrese Puntos en ORIGINALIDAD para Alice ");
                    a[i] = Convert.ToInt32(Console.ReadLine());
                    if (0 <= a[i] && a[i] <= 100)
                    {
                        Console.WriteLine("Puntos en ORIGINALIDAD " + a[i]);
                    }
                    else
                    {
                        Console.WriteLine("Ingrese un valor entre 1 y 100");
                        a[i] = Convert.ToInt32(Console.ReadLine());
                    }
                }
                if (i == 2)
                {
                    Console.WriteLine("Ingrese Puntos en DIFICULTAD para Alice ");
                    a[i] = Convert.ToInt32(Console.ReadLine());
                    if (0 <= a[i] && a[i] <= 100)
                    {
                        Console.WriteLine("Puntos en DIFICULTAD " + a[i]);
                    }
                    else
                    {
                        Console.WriteLine("Ingrese un valor entre 1 y 100");
                        a[i] = Convert.ToInt32(Console.ReadLine());
                    }
                }
            }
            for (int i = 0; i <= b.Length; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("Ingrese Puntos en CLARIDAD DEL PROBLEMA para Bob ");
                    b[i] = Convert.ToInt32(Console.ReadLine());
                    if (0 <= b[i] && b[i] <= 100)
                    {
                        Console.WriteLine("Puntos en CLARIDAD DEL PROBLEMA " + b[i]);
                    }
                    else
                    {
                        Console.WriteLine("Ingrese un valor entre 1 y 100");
                        b[i] = Convert.ToInt32(Console.ReadLine());
                    }
                }
                if (i == 1)
                {
                    Console.WriteLine("Ingrese Puntos en ORIGINALIDAD para Bob ");
                    b[i] = Convert.ToInt32(Console.ReadLine());
                    if (0 <= b[i] && b[i] <= 100)
                    {
                        Console.WriteLine("Puntos en ORIGINALIDAD " + b[i]);
                    }
                    else
                    {
                        Console.WriteLine("Ingrese un valor entre 1 y 100");
                        b[i] = Convert.ToInt32(Console.ReadLine());
                    }
                }
                if (i == 2)
                {
                    Console.WriteLine("Ingrese Puntos en DIFICULTAD para Bob ");
                    b[i] = Convert.ToInt32(Console.ReadLine());
                    if (0 <= b[i] && b[i] <= 100)
                    {
                        Console.WriteLine("Puntos en DIFICULTAD " + b[i]);
                    }
                    else
                    {
                        Console.WriteLine("Ingrese un valor entre 1 y 100");
                        b[i] = Convert.ToInt32(Console.ReadLine());
                    }
                }
            }
            if (a[0] > b[0])
            {
                PuntosAlice += 1;
            }
            else if (b[0] > a[0])
            {
                PuntosBob += 1;
            }
            else
            {
                PuntosAlice += 0;
                PuntosBob += 0;
            }
            if (a[1] > b[1])
            {
                PuntosAlice += 1;
            }
            else if (b[1] > a[1])
            {
                PuntosBob += 1;
            }
            else
            {
                PuntosAlice += 0;
                PuntosBob += 0;
            }
            if (a[2] > b[2])
            {
                PuntosAlice += 1;
            }
            else if (b[2] > a[2])
            {
                PuntosBob += 1;
            }
            else
            {
                PuntosAlice += 0;
                PuntosBob += 0;
            }
            //PuntosAlice = a[0] + a[1] + a[2];
            //PuntosBob = b[0] + b[1] + b[2];
            Console.WriteLine("Los puntos de Alice son " + PuntosAlice);
            Console.WriteLine("Los puntos de Bob son " + PuntosBob);

            //Console.WriteLine(a[0] + a[1] + a[2]);
            //Console.WriteLine(b[0] + b[1] + b[2]);
            Console.ReadLine();
        }
    }
}
