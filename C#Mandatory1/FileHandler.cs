using Microsoft.VisualBasic.FileIO;
using CsvHelper;
using C_Mandatory1;
using System.Globalization;

public class FileHandler {


    public static TextFieldParser GetNewReader(string filepath){

        TextFieldParser parser = new TextFieldParser(filepath + ".csv")
        {
            TextFieldType = FieldType.Delimited
        };
        parser.SetDelimiters(",");

        return parser;
    }

 public void ResetStandings(string filePath)
    {
        StreamWriter writer = new StreamWriter(filePath + ".csv");
        CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

        List<Club> defaultStandings = new List<Club>();
        try
        {
            using TextFieldParser parser = new TextFieldParser(filePath + ".csv");
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            // Read and parse the CSV file line by line
            while (!parser.EndOfData)
            {
                if (parser.LineNumber == 1)
                {
                    //Will ignore the headers
                    parser.ReadFields();
                    continue;
                }
                var fields = parser.ReadFields();
                Club club = new Club(fields[2]);
                defaultStandings.Add(club);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        csvWriter.WriteRecords(defaultStandings);

        csvWriter.Dispose();
        writer.Dispose();

    }


}