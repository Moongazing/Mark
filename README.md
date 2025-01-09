Here’s a detailed README.md for your PDF Watermarker project:

# PDF Watermarker

A versatile and reusable library for adding watermarks (text or image) to PDF files. This library is designed for CLI, GUI, and integration as a NuGet package. It supports advanced features such as transparency, positioning, and batch processing.

---

## Features
- **Text and Image Watermarks**: Add text or image-based watermarks to PDF files.
- **Customizations**:
  - Transparency settings
  - Adjustable position
  - Text font size and color
- **Batch Processing**: Handle multiple PDF files at once.
- **Extendable Architecture**: Built with flexibility to support CLI, GUI, or direct library integration.
- **NuGet Support**: Package the library for use in other .NET projects.

---

## Requirements
- .NET 6 or higher
- NuGet Packages:
  - [iText7](https://www.nuget.org/packages/itext7): For PDF manipulation.
  - [CommandLineParser](https://www.nuget.org/packages/CommandLineParser): For parsing CLI arguments.

---

## Installation
Install the required NuGet packages in your project:
```bash
Install-Package itext7
Install-Package CommandLineParser

Usage
As a CLI Tool

    Compile the PdfWatermarker.CLI project.

    Run the application from the terminal with arguments:

    dotnet PdfWatermarker.CLI.dll --input "input.pdf" --output "output.pdf" --type "Text" --content "Confidential"

    Available Arguments:
        --input or -i: Input PDF file path (required).
        --output or -o: Output PDF file path (required).
        --type or -t: Watermark type (Text or Image, required).
        --content or -c: Watermark content (text or image file path, required).
        --opacity or -p: Watermark transparency (optional, default: 0.5).
        --positionX: X-coordinate for watermark (optional, default: 0).
        --positionY: Y-coordinate for watermark (optional, default: 0).

As a Library

    Import the library into your project:

using Moongazing.Mark;

var service = new PdfWatermarkService();
var options = new WatermarkOptions
{
    Type = WatermarkType.Text,
    Content = "Confidential",
    Opacity = 0.5f,
    PositionX = 200,
    PositionY = 300,
    FontSize = 18,
    Color = "#FF0000"
};

service.ApplyWatermark("input.pdf", "output.pdf", options);

For image-based watermarks:

    options.Type = WatermarkType.Image;
    options.Content = "watermark.png";

Example CLI Usage

dotnet PdfWatermarker.CLI.dll --input "report.pdf" --output "watermarked.pdf" --type "Text" --content "Top Secret" --opacity 0.8 --positionX 100 --positionY 500

Contributing

Contributions are welcome! Feel free to open issues, suggest features, or submit pull requests.
License

This project is licensed under the MIT License.
