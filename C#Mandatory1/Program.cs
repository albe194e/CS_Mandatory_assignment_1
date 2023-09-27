using System.Globalization;
using C_Mandatory1;
using Microsoft.VisualBasic.FileIO;

public class Program {
    
    static readonly RoundHandler rh = new RoundHandler();
    static readonly Standings standings = new Standings();
    
    public static void Main()
    {   

        standings.Reset(League.Super);
        standings.Reset(League.Nordic);
    
        //Part1 = 22 round, part2 = 10 round
        int[] format = {22,10};
        

        //Super League
        for (int i = 1; i < format[0] + 1; i++)
        {   
            rh.ProcessRound(League.Super, Part.part1, i);
            rh.ProcessRound(League.Nordic, Part.part1, i);
        }

        /*
        for (int i = 1; i < format[1] + 1; i++)
        {   
            rh.ProcessRound(League.Super, Part.part2, i);
            rh.ProcessRound(League.Nordic, Part.part2, i);
        } 
        */

        bool keepGoing = true;
        League league = League.Super;
        while(keepGoing) {
            
            Console.WriteLine("\nCurrent League: " + league);
            Console.WriteLine("Display standings by?" +
            "\n(0) Change League" +
            "\n(1) Position" +
            "\n(2) Games won" +
            "\n(3) Goals for");

            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 0:
                    league = (league == League.Super) ? League.Nordic : League.Super;
                    break;
                case 1:
                    standings.DisplayBy(league, Sort.position);
                    break;
                case 2:
                    standings.DisplayBy(league, Sort.gamesWon);
                    break;
                case 3:
                    standings.DisplayBy(league, Sort.goalsFor);
                    break;
                default:
                    Console.WriteLine("That sorting is not implemented yet");
                    break;
            }
        }
    }  
}