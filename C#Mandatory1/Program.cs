using System.Globalization;
using C_Mandatory1;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualBasic.FileIO;

public class Program {
    
    
     static void Main()
    {
        string csvFilePath = "C:\\Users\\Nikol\\RiderProjects\\CS_Mandatory_assignment_1\\C#Mandatory1\\Files\\Standings-Nordic.csv";

        // Create a list to store the CSV data
        // Create a list to store the CSV data
        List<string[]> csvData = new List<string[]>();

        try
        {
            using (TextFieldParser parser = new TextFieldParser(csvFilePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // Read and parse the CSV file line by line
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    csvData.Add(fields);
                }
            }

            // Now, 'csvData' contains the CSV content as a list of string arrays,
            // where each string array represents a row of data.

            // You can process the data as needed, e.g., iterate through rows and columns.
            foreach (var row in csvData)
            {
                foreach (var field in row)
                {
                    Console.Write($"{field}\t");
                }
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
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
        string csvFilePath = "Teams-Nordic.csv";

        // Create a list to store the CSV data
        List<string[]> csvData = new List<string[]>();

        try
        {
            using (TextFieldParser parser = new TextFieldParser(csvFilePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // Read and parse the CSV file line by line
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    csvData.Add(fields);
                }
            }

            // Now, 'csvData' contains the CSV content as a list of string arrays,
            // where each string array represents a row of data.

            // You can process the data as needed, e.g., iterate through rows and columns.
            foreach (var row in csvData)
            {
                foreach (var field in row)
                {
                    Console.Write($"{field}\t");
                }
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return new List<Club>();
    }

}