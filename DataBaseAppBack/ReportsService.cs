using System.Text.Json;
using FastReport;
using FastReport.Data;
using FastReport.Export.Image;

namespace DataBaseAppBack;

static class ReportsService
{
    public static JsonDataConnection conn {get; set;} 
    static ReportsService()
    {
        FastReport.Utils.RegisteredObjects.AddConnection(typeof(JsonDataConnection));
        //conn = new JsonDataConnection();
        //conn.ConnectionString = PATH + "data.json";
    }
    public static string PATH = $"{Environment.CurrentDirectory}\\Reports\\";
    public static async Task<int> ProductReport(string value)
    {
        try
        {
            var DBData = await DBTools.GetProducts(value);
            var json = JsonSerializer.Serialize(DBData);
            conn = new JsonDataConnection { Json = json };
            File.WriteAllText(PATH + "data.json", json);
            Report report = new Report();
            report.Load(PATH + "ProductReport.frx");
            //conn.CreateAllTables();
            report.Dictionary.Connections.Add(conn);
            report.SetParameterValue("MYPARAMETER", 1024);
            report.Prepare();
            var image = new ImageExport();
            image.ImageFormat = ImageExportFormat.Jpeg;
            image.JpegQuality = 90;
            image.Resolution = 72;
            image.SeparateFiles = false;
            report.Export(image, "ProductReport.jpg");
        }
        catch(Exception e)
        {
            Console.WriteLine("Huston we have a problem, " + e);
            return 0;
        }
        return 1;
    }
}
