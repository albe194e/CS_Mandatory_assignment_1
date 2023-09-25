using System.Globalization;
using C_Mandatory1;

using Microsoft.VisualBasic.FileIO;

public class Program {
    
    static FileHandler fh = new FileHandler();
    
    public static void Main(string[] args)    {
        
        //SetUpTeams();

        //Part1 = 22 round, part2 = 10 round
        int[] format = {22,10};
        
        //Nordic League
        Console.WriteLine("Nordic League");
        for (int i = 1; i < format[0]; i++)
        {   
            
            ProcessRound(League.Nordic, i);
            
        }

        //Super league
        Console.WriteLine("Super League");
        for (int i = 1; i < format[0]; i++)
        {   
            
            ProcessRound(League.Super, i);
            
        }
        
    


    }

    static void SetUpTeams()
    {
        List<Club> nordicClubs = new List<Club>();
        List<Club> superClubs = new List<Club>();

        // Read Nordic League teams
        using (TextFieldParser parser = new TextFieldParser("Files/Leagues/Nordic/teams.csv"))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                nordicClubs.Add(new Club(fields[0], 0, 0, 0, 0, 0, 0, new List<char>()));
            }
        }

        // Read Super League teams
        using (TextFieldParser parser = new TextFieldParser("Files/Leagues/Super/teams.csv"))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                superClubs.Add(new Club(fields[0], 0, 0, 0, 0, 0, 0, new List<char>()));
            }
        }

        // Do something with the lists of clubs
    }

    static void ProcessRound(League league, int currentRound) {

        Round round = fh.ReadRound("Files\\Rounds\\" + league + "\\part1\\round" + currentRound);

            foreach (Match match in round.Matches)
            {
                Console.WriteLine(match.HomeTeam + "::" + match.AwayTeam + "::" + match.Result);

            }
    }

    

     static void CalculateWinningStreak(List<Club> clubs, List<Round> rounds)
     {
         foreach (var club in clubs)
         {
            int currentStreak = 0;
            int maxStreak = 0;

            foreach (var round in rounds)
            {
                foreach (var match in round.Matches)
                {
                    if (match.HomeTeam == club.Name || match.AwayTeam == club.Name)
                    {
                        bool isWin = false;

                        if (match.HomeTeam == club.Name && match.Result.StartsWith("2-0"))
                        {
                            isWin = true;
                        }
                        else if (match.AwayTeam == club.Name && match.Result.EndsWith("2-0"))
                        {
                            isWin = true;
                        }

                        if (isWin)
                        {
                            currentStreak++;

                            if (currentStreak > maxStreak)
                            {
                                maxStreak = currentStreak;
                            }
                        }
                        else
                        {
                            currentStreak = 0;
                        }
                    }
                }
            }

            club.WinningStreak = new List<char>(maxStreak.ToString());
        
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

}