## How to get invoice info from uploaded file for invoice parser API in C# using PDF.co Web API

### How to get invoice info from uploaded file for invoice parser API in C#: Step By Step Instructions

This page displays the step-by-step instructions and algorithm of how to get invoice info from uploaded file and how to apply it in your application. PDF.co Web API helps with invoice parser API in C#. PDF.co Web API is the Web API with a set of tools for documents manipulation, data conversion, data extraction, splitting and merging of documents. Includes image recognition, built-in OCR, barcode generation and barcode decoders to decode bar codes from scans, pictures and pdf.

C# code snippet like this for PDF.co Web API works best when you need to quickly implement invoice parser API in your C# application. For implementation of this functionality, please copy and paste the code below into your app using code editor. Then compile and run your app. Writing C# application mostly includes various stages of the software development so even if the functionality works please check it with your data and the production environment.

Trial version of ByteScout is available for free download from our website. This and other source code samples for C# and other programming languages are available.

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

##### **ByteScoutWebApiExample.csproj:**
    
```
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{1E1C2C34-017E-4605-AE2B-55EA3313BE51}</ProjectGuid>
    <OutputType>Exe</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>ByteScoutWebApiExample</RootNamespace>
    <AssemblyName>ByteScoutWebApiExample</AssemblyName>
    <TargetFrameworkVersion>v4.6</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Newtonsoft.Json, Version=10.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed, processorArchitecture=MSIL">
      <HintPath>packages\Newtonsoft.Json.10.0.3\lib\net40\Newtonsoft.Json.dll</HintPath>
      <Private>True</Private>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.Core" />
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data" />
    <Reference Include="System.Xml" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Program.cs" />
    <Compile Include="Properties\AssemblyInfo.cs" />
  </ItemGroup>
  <ItemGroup>
    <None Include="packages.config" />
    <Content Include="sample.pdf">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </Content>
  </ItemGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>
```

<!-- code block end -->    

<!-- code block begin -->

##### **ByteScoutWebApiExample.sln:**
    
```

Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 2013
VisualStudioVersion = 12.0.40629.0
MinimumVisualStudioVersion = 10.0.40219.1
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ByteScoutWebApiExample", "ByteScoutWebApiExample.csproj", "{1E1C2C34-017E-4605-AE2B-55EA3313BE51}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{1E1C2C34-017E-4605-AE2B-55EA3313BE51}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{1E1C2C34-017E-4605-AE2B-55EA3313BE51}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{1E1C2C34-017E-4605-AE2B-55EA3313BE51}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{1E1C2C34-017E-4605-AE2B-55EA3313BE51}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
EndGlobal

```

<!-- code block end -->    

<!-- code block begin -->

##### **Program.cs:**
    
```
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
		
		// Source PDF file to get information
		const string SourceFile = @".\sample.pdf";
		
		static void Main(string[] args)
		{
			// Create standard .NET web client instance
			WebClient webClient = new WebClient();

			// Set API Key
			webClient.Headers.Add("x-api-key", API_KEY);

			// 1. RETRIEVE THE PRESIGNED URL TO UPLOAD THE FILE.
			// * If you already have a direct file URL, skip to the step 3.
			
			// Prepare URL for `Get Presigned URL` API call
			string query = Uri.EscapeUriString(string.Format(
				"https://api.pdf.co/v1/file/upload/get-presigned-url?contenttype=application/octet-stream&name={0}", 
				Path.GetFileName(SourceFile)));

			try
			{
				// Execute request
				string response = webClient.DownloadString(query);

				// Parse JSON response
				JObject json = JObject.Parse(response);

				if (json["error"].ToObject<bool>() == false)
				{
					// Get URL to use for the file upload
					string uploadUrl = json["presignedUrl"].ToString();
					string uploadedFileUrl = json["url"].ToString();

					// 2. UPLOAD THE FILE TO CLOUD.

					webClient.Headers.Add("content-type", "application/octet-stream");
					webClient.UploadFile(uploadUrl, "PUT", SourceFile); // You can use UploadData() instead if your file is byte[] or Stream
					
					// 3. GET INFORMATION FROM UPLOADED FILE

					// URL for `Invoice Parser` API call
					var url = "https://api.pdf.co/v1/pdf/invoiceparser";

					// Prepare requests params as JSON
					Dictionary<string, object> parameters = new Dictionary<string, object>();
					parameters.Add("url", uploadedFileUrl);
					parameters.Add("inline", true);

					// Convert dictionary of params to JSON
					string jsonPayload = JsonConvert.SerializeObject(parameters);

					// Execute POST request with JSON payload
					response = webClient.UploadString(url, jsonPayload);

					// Parse JSON response
					json = JObject.Parse(response);

					if (json["error"].ToObject<bool>() == false)
					{
						// Display PDF document information
						foreach (JToken token in json["body"])
						{
							JProperty property = (JProperty) token;
							Console.WriteLine("{0}: {1}", property.Name, property.Value);
						}
					}
					else
					{
						Console.WriteLine(json["message"].ToString());
					}
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
			Console.WriteLine("Press any key...");
			Console.ReadKey();
		}
	}
}

```

<!-- code block end -->    

<!-- code block begin -->

##### **packages.config:**
    
```
<?xml version="1.0" encoding="utf-8"?>
<packages>
  <package id="Newtonsoft.Json" version="10.0.3" targetFramework="net40" />
</packages>
```

<!-- code block end -->