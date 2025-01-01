using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace ConsoleApp9
{
    namespace BattleShips
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Vítejte v hře Lodě!");
                Console.WriteLine("Hra spočívá v tipování míst kde se může nacházet loď o velikosti 1 čtverce");
                Console.WriteLine("Hra začíná nastavením velikosti hracího pole");
                Console.WriteLine("Poté počítač vygeneruje počet lodí a vy zadáváte souřadnice X a Y kde si myslíte že se loď nachází");
                Console.WriteLine("Není povoleno zadávat jakákoliv písmena a dále není povoleno zadávat stejná čísla znovu");
                Console.WriteLine("Hra končí pokud uhádnete všechna políčka, nebo pokud hru vzáte");
                Console.WriteLine("Vzdání hry uděláte pomocí napsání čísla 9999");
                Console.WriteLine("Pokud chcete zobrazit výsledky z minulé hry, napište 8888");
                Console.WriteLine("");
                while (true)
                {


                    // Zadání rozměru hrací plochy
                    Console.WriteLine("Zadejte šířku hrací plochy, nebo zobrazte výsledek stisknutím 8888:");


                    int width = 0;
                    while (!int.TryParse(Console.ReadLine(), out width) || width <= 0)//načte řetězec z konzoly, který uživatel zadal, a pak se pokusí převést tento řetězec na celé číslo typu int
                    {
                        Console.WriteLine("Neplatný vstup, zadejte prosím číslo které je větší než 0:");
                      
                    }
                    if (width == 8888)
                    {
                        Process.Start("notepad.exe", "C:\\Users\\Lukáš Bechný\\source\\repos\\ConsoleApp9\\promenne.txt");
                        Environment.Exit(0);
                    }


                    Console.WriteLine("Zadejte výšku hrací plochy:");
                    int height = 0;
                    while (!int.TryParse(Console.ReadLine(), out height) || height <= 0)// načte řetězec z konzoly, který uživatel zadal, a pak se pokusí převést tento řetězec na celé číslo typu int
                    {
                        Console.WriteLine("Neplatný vstup, zadejte prosím číslo které je větší než 0:");
                    }
                    Console.WriteLine("Rozměr hrací plochy: " + width + " x " + height);



                    // Generování počtu lodí podle rozměru plochy
                    int numberOfShips = (int)(width * height / 5.0); // Generování počtu lodí podle rozměru plochy v poměru 1/5

                    Console.WriteLine("Na hrací ploše se nachází " + numberOfShips + " lodí.");
                    // Zobrazení průběhu hry
                    if (numberOfShips >= 1)
                    {
                        Console.WriteLine("Hra začíná, střílejte na souřadnice x a y:");

                        // implementace hry 
                        int shotsFired = 0;
                        int shipsSunk = 0;
                       
                        int[,] matice = new int[1000, 2]; //matice pro kontrolu čísel
                        int i = 0;
                        while (shipsSunk < numberOfShips)
                        {
                            Console.WriteLine("Zadejte souřadnici x(pokud chcete vzdát, zadejte číslo 9999):");
                            int osaX = 0;
                            int x;
                            int osaY = 0;
                            int y;
                            int pomocnapromena = 0;

                          

                            while (!int.TryParse(Console.ReadLine(), out osaX))//načte řetězec z konzole, který uživatel zadal, a pak se pokusí převést tento řetězec na celé číslo typu int
                            {
                                Console.WriteLine("Neplatný vstup, zadejte prosím číslo pro X(pokud chcete vzdát, zadejte číslo 9999):");
                            }

                            int vstup = osaX;
                            if (vstup == 9999)//opuštění programu
                            {
                                Environment.Exit(0); 
                            }

                            x = osaX - 1;

                            Console.WriteLine("Zadejte souřadnici y:");



                            while (!int.TryParse(Console.ReadLine(), out osaY))//načte řetězec z konzole, který uživatel zadal, a pak se pokusí převést tento řetězec na celé číslo typu int
                            {
                                Console.WriteLine("Neplatný vstup, zadejte prosím číslo pro Y:");
                            }
                         
                            y = osaY - 1;




                            
                            


                            if (i > 0 && matice[i - 1, 0] == osaX && matice[i - 1, 1] == osaY)//kontrolní bod
                               
                            {
                                Console.WriteLine("Neplatný vstup, zadejte prosím číslo, které je odlišné od předchozího:");
                                
                                continue;
                            }
                            for (int j = 0; j < i - 1; j++)
                            {
                                if (matice[j, 0] == osaX && matice[j, 1] == osaY)
                                {
                                    Console.WriteLine("Neplatný vstup, zadejte prosím číslo, které ještě nebylo použito:");
                                    pomocnapromena = 1;
                                    continue;
                                }
                                
                            }
                            matice[i, 0] = osaX;
                            matice[i, 1] = osaY;
                            i++;


                            if (x < 0 || x >= width || y < 0 || y >= height)// Konkrétně se podmínka kontroluje, zda x je menší než 0, nebo větší nebo rovno největší šířce plátna,  nebo zda y je menší než 0, nebo větší nebo rovno největší výšce plátna (height).
                            {
                                Console.WriteLine("Souřadnice mimo hrací plochu, zadejte jiné souřadnice");
                                continue;
                            }



                            if(pomocnapromena==0)
                            {
                                Random random = new Random();  // Náhodně vygenerujeme, zda jste trefili loď
                            int hit = random.Next(3);
                            
                            if (hit == 1)
                            {
                                Console.WriteLine("Zásah!");
                                shipsSunk++;
                                    
                            }
                            else
                            {
                                Console.WriteLine("Mimo!");
                            }
                                shotsFired++;
                            }

                            if (shotsFired == (int)(width * height))
                            {
                                Console.WriteLine("Lodě tě porazily haha, nevěš hlavu :):");
                                break;
                            }

                        }

                        if (shipsSunk == numberOfShips)
                        {
                            Console.WriteLine("Vyhráli jste! Střelili jste " + shotsFired + " krát.");

                            string data = $"{shotsFired}\n";
                            System.IO.File.WriteAllText(@"C:\Users\Lukáš Bechný\source\repos\ConsoleApp9\promenne.txt", data);
                            Console.WriteLine("Proměnné byly uloženy do souboru.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("zadali jste příliš malé pole, příšte zedejte pole o velikosti 5:");
                    }
                    Console.WriteLine("Pro opětovné spuštění hry stiskněte 1, pro konec stiskněte 0:");
                    int restart = int.Parse(Console.ReadLine());
                    if (restart == 0)
                    {
                        break;
                    }
                }
            }
        }

    }
}
