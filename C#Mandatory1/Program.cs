using System.Globalization;
using C_Mandatory1;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualBasic.FileIO;

public class Program {
    
    
     static void Main()
    {
        FileHandler fh = new FileHandler();
        fh.ReadData();
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