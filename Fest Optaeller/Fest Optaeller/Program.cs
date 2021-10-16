using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest_Optaeller
{
    class Program
    {
        static void Main(string[] args)
        {
            LoopLines();

            PrintResults();

            Console.ReadKey();
        }

        static int groupPeople = 0;
        static int groupGirls = 0;

        static int totalPeople = 0;
        static int totalGirls = 0; // -

        static int beerEnjoyers = 0; // ! e
        static int neutralBeer = 0;  // # n
        static int beerRefusers = 0; // ¤ r

        static void LoopLines()
        {
            string[] lines = GetTxtLines.ReadTxtLines();

            bool stopCount = false;

            foreach (string line in lines)
            {
                if (line != "" && line[0] == '.')
                    stopCount = !stopCount;

                else if (line != "" && line[0] == '/')
                    ;
                else if (!stopCount && line != "")
                {
                    CountLine(line);
                }
                else if (!stopCount && groupPeople > 0)
                {
                    PrintGroupStats();
                    ResetGroupStats();
                }

                Console.WriteLine(line);
            }
        }

        static void CountLine(string line)
        {
            bool leaveLoop = false;
            while (line.Length > 0 && !leaveLoop)
            {
                switch (line[0])
                {
                    case ' ':
                        line = line.Substring(1);
                        break;

                    case '-':
                        groupGirls++;
                        line = line.Substring(1);
                        break;

                    case '!':
                        beerEnjoyers++;
                        line = line.Substring(1);
                        break;
                    case '#':
                        neutralBeer++;
                        line = line.Substring(1);
                        break;
                    case '¤':
                        beerRefusers++;
                        line = line.Substring(1);
                        break;

                    default:
                        leaveLoop = true;
                        break;
                }
            }
            groupPeople++;
        }

        static void PrintGroupStats()
        {
            Console.WriteLine($"{groupPeople} -{groupGirls}");
        }

        static void ResetGroupStats()
        {
            totalPeople += groupPeople;
            totalGirls += groupGirls;

            groupPeople = 0;
            groupGirls = 0;
        }

        static void PrintResults()
        {
            string f = string.Format("{0:0.00}", 100f * totalGirls / totalPeople);

            Console.WriteLine($"{totalPeople} -{totalGirls} {f}%");
            Console.WriteLine($"Beer enjoyers: {beerEnjoyers}");
            Console.WriteLine($"Neutral beer: {neutralBeer}");
            Console.WriteLine($"Beer refusers: {beerRefusers}");
        }
    }
}
