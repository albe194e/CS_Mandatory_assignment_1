using System.Globalization;
using C_Mandatory1;
using Microsoft.VisualBasic.FileIO;

public class FileHandler {
    
    public Round ReadRound(string fileName) {

        Round round = new Round();

        try {
            using TextFieldParser parser = new TextFieldParser(
                fileName + ".csv");
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            // Read and parse the CSV file line by line
            while (!parser.EndOfData)
            {
                var fields = parser.ReadFields();
                round.addMatch(fields[0], fields[1], fields[2]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return round;
    }

    public void WriteRound(string filePath, List<string[]> data)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (string[] row in data)
            {
                string line = string.Join(",", row);
                writer.WriteLine(line);
            }
        }
    }

    
}