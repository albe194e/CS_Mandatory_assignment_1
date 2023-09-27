using Microsoft.VisualBasic.FileIO;
using CsvHelper;
using C_Mandatory1;
using System.Globalization;

public class FileHandler {


    public static List<string[]> readFile (string filepath) {

        List<string[]> data = new List<string[]>();

        try {
            using TextFieldParser parser = GetNewReader(filepath);

            // Read and parse the CSV file line by line
            while (!parser.EndOfData)
            {   
                if (parser.LineNumber == 1) {
                    //Will ignore the headers
                    parser.ReadFields();
                    continue;
                }

                data.Add(parser.ReadFields());
            }
        }
        catch (Exception ex)
        {   
            
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return data;
    }
    public static TextFieldParser GetNewReader(string filepath){

        TextFieldParser parser = new TextFieldParser(filepath + ".csv")
        {
            TextFieldType = FieldType.Delimited
        };
        parser.SetDelimiters(",");

        return parser;
    }

    
}