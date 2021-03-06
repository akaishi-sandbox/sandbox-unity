using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

using Google.Apis.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

/*
https://developers.google.com/sheets/quickstart/dotnet#step_3_set_up_the_sample
 */
public class SheetTest
{
    // If modifying these scopes, delete your previously saved credentials
    // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
    static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
    static string ApplicationName = "Google Sheets API .NET Quickstart";

    public static void Sheets()
    {
        ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
        {
            return true;
        };
        UserCredential credential;

        using (var stream =
            new FileStream("client_secret_848620337278-gpm2leidd6st3es22dhu58p3l8s1cf4l.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read))
        {
            string credPath = System.Environment.GetFolderPath(
                System.Environment.SpecialFolder.Personal);
            credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");

            // var serializer = JsonSerializer.Create(new JsonSerializerSettings
            // {
            //     NullValueHandling = NullValueHandling.Ignore,
            //     MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            //     ContractResolver = new NewtonsoftJsonContractResolver(),
            // });
            // using (var streamReader = new StreamReader(stream))
            // {
            //     serializer.Deserialize(streamReader, typeof(GoogleClientSecrets));
            // }


            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream).Secrets,
                Scopes,
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true)).Result;
            UnityEngine.Debug.Log($"Credential file saved to: {credPath}");
        }

        // Create Google Sheets API service.
        var service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName,
        });

        // Define request parameters.
        String spreadsheetId = "12q5pVQxUPzwbFbv6t25kNAVn-jlW4nWI_hdpKCYAEUs";
        String range = "主人公（女性）!A2:E";
        SpreadsheetsResource.ValuesResource.GetRequest request =
                service.Spreadsheets.Values.Get(spreadsheetId, range);

        // Prints the names and majors of students in a sample spreadsheet:
        // https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit
        ValueRange response = request.Execute();
        IList<IList<Object>> values = response.Values;
        if (values != null && values.Count > 0)
        {
            foreach (var row in values)
            {
                // Print columns A and E, which correspond to indices 0 and 4.
                UnityEngine.Debug.Log($"{row.ElementAtOrDefault(0)}, {row.ElementAtOrDefault(1)}");
            }
        }
        else
        {
            UnityEngine.Debug.Log("No data found.");
        }



    }
}
