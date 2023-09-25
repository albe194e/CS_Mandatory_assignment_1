using Microsoft.VisualBasic.FileIO;
using CsvHelper;

public class FileHandler {


    public static TextFieldParser GetNewReader(string filepath){

        TextFieldParser parser = new TextFieldParser(filepath + ".csv")
        {
            TextFieldType = FieldType.Delimited
        };
        parser.SetDelimiters(",");

        return parser;
    }

}