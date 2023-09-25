using System.Globalization;

namespace C_Mandatory1;

public class Standings
{

    public void reader()
    {
        using var reader = new StreamReader("Standings.csv");
        using (var csv = new CsvReader(this.reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<>();
        }
    }
    
    
    
}