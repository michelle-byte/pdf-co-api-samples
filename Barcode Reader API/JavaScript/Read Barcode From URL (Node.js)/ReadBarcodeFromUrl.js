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


var https = require("https");

// The authentication key (API Key).
// Get your own by registering at https://app.pdf.co/documentation/api
const API_KEY = "***********************************";


// Direct URL of source file to search barcodes in.
const SourceFileUrl = "https://bytescout-com.s3.amazonaws.com/files/demo-files/cloud-api/barcode-reader/sample.pdf";
// Comma-separated list of barcode types to search. 
// See valid barcode types in the documentation https://app.pdf.co/documentation/api/1.0/barcode/read_from_url.html
const BarcodeTypes = "Code128,Code39,Interleaved2of5,EAN13";
// Comma-separated list of page indices (or ranges) to process. Leave empty for all pages. Example: '0,2-5,7-'.
const Pages = "";


// Prepare request to `Barcode Reader` API endpoint
var queryPath = `/v1/barcode/read/from/url?types=${BarcodeTypes}&pages=${Pages}&url=${SourceFileUrl}`;
var reqOptions = {
    host: "api.pdf.co",
    path: encodeURI(queryPath),
    headers: {
        "x-api-key": API_KEY
    }
};
// Send request
https.get(reqOptions, (response) => {
    response.on("data", (d) => {
        // Parse JSON response
        var data = JSON.parse(d);
        
        if (data.error == false) {
            // Display found barcodes in console
            data.barcodes.forEach((element) => {
                console.log("Found barcode:");
                console.log("  Type: " + element.TypeName);
                console.log("  Value: " + element.Value);
                console.log("  Document Page Index: " + element.Page);
                console.log("  Rectangle: " + element.Rect);
                console.log("  Confidence: " + element.Confidence);
                console.log("");
            }, this);
        }
        else {
            // Service reported error
            console.log(data.message);
        }
    });
}).on("error", (e) => {
    // Request error
    console.error(e);
});
