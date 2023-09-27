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
        Console.WriteLine("Super League");
        for (int i = 1; i < format[0] + 1; i++)
        {   
            rh.ProcessRound(League.Super, Part.part1, i);
            rh.ProcessRound(League.Nordic, Part.part1, i);
        }

        for (int i = 1; i < format[1] + 1; i++)
        {   
            rh.ProcessRound(League.Super, Part.part2, i);
            rh.ProcessRound(League.Nordic, Part.part2, i);
        } 

        standings.DisplayBy(League.Nordic, Sort.position);
    }  
}