'*******************************************************************************************'
'                                                                                           '
' Download Free Evaluation Version From:     https://bytescout.com/download/web-installer   '
'                                                                                           '
' Also available as Web API! Get free API Key https://app.pdf.co/signup                     '
'                                                                                           '
' Copyright © 2017-2020 ByteScout, Inc. All rights reserved.                                '
' https://www.bytescout.com                                                                 '
' https://www.pdf.co                                                                        '
'*******************************************************************************************'


Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module Module1

	' The authentication key (API Key).
	' Get your own by registering at https://app.pdf.co
	Const API_KEY As String = "***********************************"

	' Source file name
	const SourceFile as string = ".\sample.pdf"
	' Comma-separated list of barcode types to search. 
	' See valid barcode types in the documentation https://apidocs.pdf.co
	Const BarcodeTypes As String = "Code128,Code39,Interleaved2of5,EAN13"
	' Comma-separated list of page indices (or ranges) to process. Leave empty for all pages. Example: '0,2-5,7-'.
	Const Pages As String = ""

	Sub Main()

		' Create standard .NET web client instance
		Dim webClient As WebClient = New WebClient()

		' Set API Key
		webClient.Headers.Add("x-api-key", API_KEY)

		' 1. RETRIEVE THE PRESIGNED URL TO UPLOAD THE FILE.
		' * If you already have a direct file URL, skip to the step 3.

		' Prepare URL for `Get Presigned URL` API call
		Dim query As string = Uri.EscapeUriString(string.Format(
			"https://api.pdf.co/v1/file/upload/get-presigned-url?contenttype=application/octet-stream&name={0}", 
			Path.GetFileName(SourceFile)))

		Try
			' Execute request
			Dim response As string = webClient.DownloadString(query)

			' Parse JSON response
			Dim json As JObject = JObject.Parse(response)

			If json("error").ToObject(Of Boolean) = False Then
				' Get URL to use for the file upload
				Dim uploadUrl As string = json("presignedUrl").ToString()
				' Get URL of uploaded file to use with later API calls
				Dim uploadedFileUrl As string = json("url").ToString()

				' 2. UPLOAD THE FILE TO CLOUD.

				webClient.Headers.Add("content-type", "application/octet-stream")
				webClient.UploadFile(uploadUrl, "PUT", SourceFile) ' You can use UploadData() instead if your file is byte array or Stream

				' Set JSON content type
				webClient.Headers.Add("Content-Type", "application/json")

				Dim url As String = "https://api.pdf.co/v1/barcode/read/from/url"

				' Prepare requests params as JSON
				' See documentation: https : //apidocs.pdf.co
				Dim parameters As New Dictionary(Of String, Object)
				parameters.Add("types", BarcodeTypes)
				parameters.Add("pages", Pages)
				parameters.Add("url", uploadedFileUrl)

				' Convert dictionary of params to JSON
				Dim jsonPayload As String = JsonConvert.SerializeObject(parameters)

				' Execute POST request with JSON payload
				response = webClient.UploadString(url, jsonPayload)

				' Parse JSON response
				json = JObject.Parse(response)

				If json("error").ToObject(Of Boolean) = False Then
				
					' Display found barcodes in console
					For Each token As JToken In json("barcodes")
						Console.WriteLine("Found barcode:")
						Console.WriteLine("  Type: " + token("TypeName").ToString())
						Console.WriteLine("  Value: " + token("Value").ToString())
						Console.WriteLine("  Document Page Index: " + token("Page").ToString())
						Console.WriteLine("  Rectangle: " + token("Rect").ToString())
						Console.WriteLine("  Confidence: " + token("Confidence").ToString())
						Console.WriteLine()
					Next

				Else 
					Console.WriteLine(json("message").ToString())
				End If

			End If
			
		Catch ex As WebException
			Console.WriteLine(ex.ToString())
		End Try

		webClient.Dispose()


		Console.WriteLine()
		Console.WriteLine("Press any key...")
		Console.ReadKey()

	End Sub

End Module
