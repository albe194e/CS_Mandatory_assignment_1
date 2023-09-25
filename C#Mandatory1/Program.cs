using System.Globalization;
using C_Mandatory1;
using Microsoft.VisualBasic.FileIO;

public class Program {
    
    static FileHandler fh = new FileHandler();
    
    public static void Main()
    {

    
        //Part1 = 22 round, part2 = 10 round
        int[] format = {22,10};
        

        //Super League
        Console.WriteLine("Super League");
        for (int i = 1; i < format[0] + 1; i++)
        {   
            ProcessRound(League.Super, Part.part1, i);
        }
        for (int i = 1; i < format[1] + 1; i++)
        {
            ProcessRound(League.Super, Part.part2, i);
        }

        //Nordic League
        Console.WriteLine("Nordic League");
        for (int i = 1; i < format[0] + 1; i++)
        {   
            ProcessRound(League.Nordic, Part.part1, i);
        }
        for (int i = 1; i < format[1] + 1; i++)
        {
            ProcessRound(League.Nordic, Part.part2, i);
        }
        
    }

    static void ProcessRound(League league, Part part, int currentRound) {

        Round round = fh.ReadRound("Files\\Rounds\\" + league + "\\" + part + "\\round" + currentRound);

        fh.WriteRound("Files\\Standings-" + league, round);

    }

    static void DisplayStandings(List<Club> clubs)
    {
        int position = 1;
        foreach (var club in clubs)
        {
            string streak = new string(club.WinningStreak.ToArray());
            streak = string.IsNullOrEmpty(streak) ? "-" : streak;

            string line = $"{position++,-4} (Special Marking) {club.Name,-30} " +
                          $"{club.GamesPlayed,-4} {club.GamesWon,-4} {club.GamesDrawn,-4} " +
                          $"{club.GamesLost,-4} {club.GoalsFor,-4} {club.GoalsAgainst,-4} " +
                          $"{club.GoalDifference,-4} {club.Points,-4} {streak}";

            Console.WriteLine(line);
        }
    }

public void ResetStandings()
{
    // Reset Super League standings
    foreach (Club club in League.Super)
    {
        club.ResetStats();
    }
    League.Super.Fractions.Clear();
    League.Super.Fractions.Add(new Fraction("Upper"));
    League.Super.Fractions.Add(new Fraction("Lower"));

    // Reset Nordic League standings
    foreach (Team team in League.Nordic.Teams)
    {
        team.ResetStats();
    }
    League.Nordic.Fractions.Clear();
    League.Nordic.Fractions.Add(new Fraction("Upper"));
    League.Nordic.Fractions.Add(new Fraction("Lower"));
}

}


