## How to parse from url for document parser API in Java using PDF.co Web API PDF.co Web API is the Web API with a set of tools for documents manipulation, data conversion, data extraction, splitting and merging of documents. Includes image recognition, built-in OCR, barcode generation and barcode decoders to decode bar codes from scans, pictures and pdf.

## REQUEST FREE TECH SUPPORT

[Click here to get in touch](https://bytescout.zendesk.com/hc/en-us/requests/new?subject=PDF.co%20Web%20API%20Question)

or just send email to [support@bytescout.com](mailto:support@bytescout.com?subject=PDF.co%20Web%20API%20Question) 

## ON-PREMISE OFFLINE SDK 

[Get Your 60 Day Free Trial](https://bytescout.com/download/web-installer?utm_source=github-readme)
[Explore Documentation](https://bytescout.com/documentation/index.html?utm_source=github-readme)
[Explore Source Code Samples](https://github.com/bytescout/ByteScout-SDK-SourceCode/)
[Sign Up For Online Training](https://academy.bytescout.com/)


## ON-DEMAND REST WEB API

[Get your API key](https://app.pdf.co/signup?utm_source=github-readme)
[Security](https://pdf.co/security)
[Explore Web API Documentation](https://apidocs.pdf.co?utm_source=github-readme)
[Explore Web API Samples](https://github.com/bytescout/ByteScout-SDK-SourceCode/tree/master/PDF.co%20Web%20API)

## VIDEO REVIEW

[https://www.youtube.com/watch?v=NEwNs2b9YN8](https://www.youtube.com/watch?v=NEwNs2b9YN8)




<!-- code block begin -->

##### **Main.java:**
    
```
package com.company;

import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
import com.google.gson.JsonPrimitive;
import okhttp3.*;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

public class Main {
    // The authentication key (API Key).
    // Get your own by registering at https://app.pdf.co/documentation/api
    final static String API_KEY = "***********************************";

    public static void main(String[] args) throws IOException {
        // Source PDF file
        final String SourceFileUrl = "https://bytescout-com.s3.amazonaws.com/files/demo-files/cloud-api/document-parser/MultiPageTable.pdf";
        // PDF document password. Leave empty for unprotected documents.
        final String Password = "";
        // Destination JSON file name
        final Path DestinationFile = Paths.get(".\\result.json");

        // Template text. Use Document Parser SDK (https://bytescout.com/products/developer/documentparsersdk/index.html)
        // to create templates.
        // Read template from file:
        String templateText = new String(Files.readAllBytes(Paths.get(".\\MultiPageTable-template1.yml")), StandardCharsets.UTF_8);

        // Create HTTP client instance
        OkHttpClient webClient = new OkHttpClient();

        // PARSE UPLOADED PDF DOCUMENT
        ParseDocument(webClient, API_KEY, DestinationFile, Password, SourceFileUrl, templateText);
    }

    public static void ParseDocument(OkHttpClient webClient, String apiKey, Path destinationFile,
                                     String password, String uploadedFileUrl, String templateText) throws IOException {
        // Prepare POST request body in JSON format
        JsonObject jsonBody = new JsonObject();
        jsonBody.add("url", new JsonPrimitive(uploadedFileUrl));
        jsonBody.add("template", new JsonPrimitive(templateText));

        RequestBody body = RequestBody.create(MediaType.parse("application/json"), jsonBody.toString());

        // Prepare request to `Document Parser` API
        Request request = new Request.Builder()
                .url("https://api.pdf.co/v1/pdf/documentparser")
                .addHeader("x-api-key", API_KEY) // (!) Set API Key
                .addHeader("Content-Type", "application/json")
                .post(body)
                .build();

        // Execute request
        Response response = webClient.newCall(request).execute();

        if (response.code() == 200) {
            // Parse JSON response
            JsonObject json = new JsonParser().parse(response.body().string()).getAsJsonObject();

            boolean error = json.get("error").getAsBoolean();
            if (!error) {
                // Get URL of generated JSON file
                String resultFileUrl = json.get("url").getAsString();

                // Download JSON file
                downloadFile(webClient, resultFileUrl, destinationFile.toFile());

                System.out.printf("Generated JSON file saved as \"%s\" file.", destinationFile.toString());
            } else {
                // Display service reported error
                System.out.println(json.get("message").getAsString());
            }
        } else {
            // Display request error
            System.out.println(response.code() + " " + response.message());
        }
    }

    public static void downloadFile(OkHttpClient webClient, String url, File destinationFile) throws IOException {
        // Prepare request
        Request request = new Request.Builder()
                .url(url)
                .build();
        // Execute request
        Response response = webClient.newCall(request).execute();

        byte[] fileBytes = response.body().bytes();

        // Save downloaded bytes to file
        OutputStream output = new FileOutputStream(destinationFile);
        output.write(fileBytes);
        output.flush();
        output.close();

        response.close();
    }
}

```

<!-- code block end -->