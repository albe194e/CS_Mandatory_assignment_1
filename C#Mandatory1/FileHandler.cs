using Microsoft.VisualBasic.FileIO;
using CsvHelper;
using System.Globalization;

using C_Mandatory1;

public class FileHandler {


    public static TextFieldParser GetNewReader(string filepath){

        TextFieldParser parser = new TextFieldParser(filepath + ".csv")
        {
            TextFieldType = FieldType.Delimited
        };
        parser.SetDelimiters(",");

        return parser;
    }

    public static void ResetStandings(string filePath)
    {

        List<Club> defaultStandings = new List<Club>();
        try
        {
            using TextFieldParser parser = GetNewReader(filePath);

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

        Console.WriteLine(defaultStandings.Count);

        StreamWriter writer = new StreamWriter(filePath + ".csv");
        CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

        csvWriter.WriteRecords(defaultStandings);

        csvWriter.Dispose();
        writer.Dispose();

    }


}