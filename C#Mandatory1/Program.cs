using System.Globalization;
using C_Mandatory1;
using Microsoft.VisualBasic.FileIO;

public class Program {
    
    static FileHandler fh = new FileHandler();
    static void Main()
    {
        
        //Part1 = 22 rounds, part2 = 10 rounds
        int[] format = {22,10};
        

        //Super league
        for (int i = 1; i < format[0] + 1; i++)
        {   
            ProcessRound(League.Super, Part.part1, i);
        }
        for (int i = 1; i < format[1] + 1; i++)
        {
            ProcessRound(League.Super, Part.part2, i);
        }

        //Nordic League
        for (int i = 1; i < format[0] + 1; i++)
        {   
            ProcessRound(League.Nordic, Part.part1, i);
        }
        for (int i = 1; i < format[1] + 1; i++)
        {
            ProcessRound(League.Nordic, Part.part2, i);
        }
        


        /*
        // Load and populate clubs from setup and teams file
        List<Club> clubs = LoadClubsFromFiles(); // Implement this function as per your file format.

        // Calculate winning streak for each club
        CalculateWinningStreak(clubs);

        // Sort the clubs using LINQ
        clubs = clubs.OrderByDescending(c => c.Points)
                     .ThenByDescending(c => c.GoalDifference)
                     .ThenByDescending(c => c.GoalsFor)
                     .ThenBy(c => c.GoalsAgainst)
                     .ThenBy(c => c.Name)
                     .ToList();

        // Display the current standings
        DisplayStandings(clubs);
        */
    }

    static void ProcessRound(League league, Part part, int currentRound) {

        Round round = fh.ReadRound("Files\\Rounds\\" + league + "\\" + part + "\\round" + currentRound);

        fh.WriteRound("Files\\Standings-" + league, round);

    }
    

     static void CalculateWinningStreak(List<Club> clubs)
     {
         foreach (var club in clubs)
         {
             // Implement logic to calculate the winning streak for each club
             // You can use the club's game results to determine the streak.
             // Store the streak as a list of 'W', 'D', 'L', or dashes.
             // Make sure to handle the case when there's no streak.
         }
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

    static List<Club> LoadClubsFromFiles()
    {
        return new List<Club>();
    }

}