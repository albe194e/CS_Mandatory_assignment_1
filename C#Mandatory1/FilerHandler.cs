using System.Globalization;
using C_Mandatory1;
using CsvHelper;
using Microsoft.VisualBasic.FileIO;

public class FileHandler {
    public void ReadData()
    {
        var csvFileName =
            "C:\\Users\\Nikol\\RiderProjects\\CS_Mandatory_assignment_1\\C#Mandatory1\\Files\\Standings-Nordic.csv";

        // Create a list to store the CSV data
        var csvData = new List<string[]>();

        try
        {
            using (var parser = new TextFieldParser(csvFileName))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // Read and parse the CSV file line by line
                while (!parser.EndOfData)
                {
                    var fields = parser.ReadFields();
                    csvData.Add(fields);
                }
            }

            foreach (var row in csvData)
            {
                foreach (var field in row) Console.Write($"{field}\t");
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    
    
    public Round ReadRound(string fileName) {

        using StreamReader reader = new StreamReader(fileName + ".csv");
        using CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var matches = csv.GetRecords<Match>();

        Round round = new Round();

        foreach (Match match in matches)
        {
            round.addMatch(match.HomeTeam, match.AwayTeam, match.Result);
        }

        return round;
    }
}