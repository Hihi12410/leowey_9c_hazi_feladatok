using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;

namespace csillag_marcell_9c
{
    internal class Program
    {
        class Test {

            private decimal x_;
            private decimal y_;
            private decimal z_;

            private int x;
            private int y;
            private int z;
            
            private int conv;

            private bool init = false;

            private char[,] matrix = new char[,] { };
            

            private void uj_matrix() {

                int lenX = (x+z);
                int lenY = (y+z);

                matrix = new char[lenY, lenX];


                for (int k = 0; k < z; k++){

                    for (int i = 0; i < y; i++)
                    {
                        for (int j = 0; j < x; j++)
                        {
                            matrix[i+k, j+k] = k.ToString().Last();
                        }

                    }

                }

            }

            private void rend_matrix() {
                
                if (!init) return;

                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor= ConsoleColor.DarkGray;
                Console.WriteLine("======================Kiszámított értékek======================\n\n");
                Console.BackgroundColor= ConsoleColor.Black;
                int lenX = x+z;
                int lenY = y+z;


                for (int i = 0; i < lenY; i++)
                {
                    for (int j = 0; j < lenX; j++)
                    {

                        if (matrix[i, j] != '\0')
                        {
                            Console.ForegroundColor = (ConsoleColor)(((int)matrix[i,j] % 14)+1);
                            Console.BackgroundColor = (ConsoleColor)(((int)matrix[i, j] % 14)+1);
                            Console.Write("{0}{1}", matrix[i, j], matrix[i, j]);
                            
                        }
                        else {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write("  ");
                        
                        }
                        
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write('\n');

                }

                Console.ForegroundColor= ConsoleColor.White;

                Console.WriteLine("[{0} {1} {2}]", x,y,z);
                Console.WriteLine("[{0} {1} {2}]\n", x_, y_, z_);

                Console.WriteLine("Felület : {0} / 10^{1} [m]\n", 2 * (x_*y_+x_*z_+y_*z_), Math.Log10(conv));
                Console.WriteLine("Térfogat : {0} / 10^{1} [m^3]\n", x_*y_*z_, Math.Log10(conv));
                Console.WriteLine("Testátló : {0} / 10^{1} [m]\n", Math.Round(Math.Sqrt((double)(x_*x_+y_*y_+z_*z_)), 2), Math.Log10(conv));
            }

            public void Rend_matrix() {
                
                if (!init) return;
                rend_matrix();            
            
            }


            public Test(int x_meret,int y_meret, int z_meret, int conv_) {

                init = false;

                x_ = x_meret;
                y_ = y_meret;
                z_ = z_meret;

                x = (int)x_;
                y = (int)y_;
                z = (int)z_;

                conv = conv_;

                uj_matrix();

                init = true;
            
            }

            public Test() {

                init = false;

                x = 5;
                y = 5;
                z = 5;

                x = (int)x_;
                y = (int)y_;
                z = (int)z_;

                conv = 1;

                uj_matrix();

                init = true;
            
            }

            public void program() {

                init = false;

                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("======================Négyzet alapú hasáb======================");
                Console.WriteLine("Mértékegység ? (m/dm/cm/mm) : ");
                switch (Console.ReadLine().ToLower()) {
                    case "m": goto default;
                    case "dm": conv = 10; break;
                    case "cm": conv = 100; break;
                    case "mm": conv = 1000; break;
                    default: conv = 1; break;
                }
                Console.WriteLine("A szorzó mennyisége : x{0}\n", conv);

                Console.WriteLine("Méretek!");
                Console.WriteLine("X méret (Valós szám) : ");
                if (!decimal.TryParse(Console.ReadLine(), out x_)) {

                    x_ = 5;
                    Console.WriteLine("Sajnos helytelen számot adtál meg! X mostani értéke : {0}", x);

                }
                Console.WriteLine("Y méret (Pozitív egész szám) : ");
                if (!decimal.TryParse((Console.ReadLine()), out y_))
                {

                    y_ = 5;
                    Console.WriteLine("Sajnos helytelen számot adtál meg! Y mostani értéke : {0}", y);

                }
                Console.WriteLine("Z méret (Pozitív egész szám) : ");
                if (!decimal.TryParse(Console.ReadLine(), out z_))
                {

                    z_ = 5;
                    Console.WriteLine("Sajnos helytelen számot adtál meg! Z mostani értéke : {0}", z);

                }

                Console.WriteLine("\n{0}  {1}  {2}", x_,y_,z_);

                x = (int)x_;
                y = (int)y_;
                z = (int)z_;

                Console.WriteLine("{0}  {1}  {2}\n", x, y, z);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Nyomjon meg egy billentyűt a folytatáshoz!");
                Console.ReadKey();

                init = true;
                uj_matrix();
                rend_matrix();
                


            }
        
        }

        static void Main(string[] args)
        {
            Test test = new Test();
            while (true) {

                test.program();
                Console.Write("\n\nA program bezárásához nyomja meg a ctrl+c gombokat, vagy lépjen ki az ablakból\n\n");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Nyomjon meg egy billentyűt a folytatáshoz!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ReadKey();
                Console.Clear();
                
            }

        }
    }
}
