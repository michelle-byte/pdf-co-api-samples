//*******************************************************************************************//
//                                                                                           //
// Download Free Evaluation Version From: https://bytescout.com/download/web-installer       //
//                                                                                           //
// Also available as Web API! Get Your Free API Key: https://app.pdf.co/signup               //
//                                                                                           //
// Copyright © 2017-2020 ByteScout, Inc. All rights reserved.                                //
// https://www.bytescout.com                                                                 //
// https://pdf.co                                                                            //
//                                                                                           //
//*******************************************************************************************//


using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ByteScoutWebApiExample
{
	class Program
	{
		// The authentication key (API Key).
		// Get your own by registering at https://app.pdf.co
		const String API_KEY = "***********************************";

		static void Main(string[] args)
		{
			// HTML template
			string template = File.ReadAllText(@".\invoice_template.html");
			// Data to fill the template
			string templateData = File.ReadAllText(@".\invoice_data.json");
			// Destination PDF file name
			string destinationFile = @".\result.pdf";

			// Create standard .NET web client instance
			WebClient webClient = new WebClient();

			// Set API Key
			webClient.Headers.Add("x-api-key", API_KEY);

			webClient.Headers.Add("Content-Type", "application/json");

			try
			{
                // URL for `HTML to PDF` API call
				string url = Uri.EscapeUriString(string.Format(
					"https://api.pdf.co/v1/pdf/convert/from/html?name={0}", 
					Path.GetFileName(destinationFile)));

				// Prepare requests params as JSON
				Dictionary<string, object> parameters = new Dictionary<string, object>();
				parameters.Add("name", Path.GetFileName(destinationFile));
				parameters.Add("html", template);
				parameters.Add("templateData", templateData);

				// Convert dictionary of params to JSON
				string jsonPayload = JsonConvert.SerializeObject(parameters);

                // Execute request
				string response = webClient.UploadString(url, jsonPayload);

	            // Parse JSON response
	            JObject json = JObject.Parse(response);

	            if (json["error"].ToObject<bool>() == false)
	            {
		            // Get URL of generated PDF file
		            string resultFileUrl = json["url"].ToString();

		            webClient.Headers.Remove("Content-Type"); // remove the header required for only the previous request

		            // Download the PDF file
					webClient.DownloadFile(resultFileUrl, destinationFile);

					Console.WriteLine("Generated PDF document saved as \"{0}\" file.", destinationFile);
	            }
	            else
	            {
		            Console.WriteLine(json["message"].ToString());
	            }
            }
            catch (WebException e)
            {
	            Console.WriteLine(e.ToString());
            }

			webClient.Dispose();


            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
		}
	}
}
