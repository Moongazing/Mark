using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using Moongazing.Mark.Models;

namespace Moongazing.Mark.Services;

public class PdfWatermarkService : IWatermark
{
    public void ApplyWatermark(string inputPath, string outputPath, WatermarkOptions options)
    {
        using var pdfReader = new PdfReader(inputPath);
        using var pdfWriter = new PdfWriter(outputPath);
        using var pdfDoc = new PdfDocument(pdfReader, pdfWriter);

        for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
        {
            var page = pdfDoc.GetPage(i);
            if (options.Type == WatermarkType.Text)
            {
                AddTextWatermark(page, options);
            }
            else if (options.Type == WatermarkType.Image)
            {
                AddImageWatermark(page, options);
            }
        }
    }

    private void AddTextWatermark(PdfPage page, WatermarkOptions options)
    {
        var pdfCanvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), page.GetDocument());
        pdfCanvas.SaveState();

        var color = new DeviceRgb(
            ConvertHexToColor(options.Color).R,
            ConvertHexToColor(options.Color).G,
            ConvertHexToColor(options.Color).B
        );

        pdfCanvas.SetColor(color, true);
        pdfCanvas.BeginText()
                 .SetFontAndSize(PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA), options.FontSize)
                 .MoveText(options.PositionX, options.PositionY)
                 .ShowText(options.Content)
                 .EndText();
        pdfCanvas.RestoreState();
    }

    private void AddImageWatermark(PdfPage page, WatermarkOptions options)
    {
        var pdfCanvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), page.GetDocument());
        pdfCanvas.SaveState();

        var imageData = ImageDataFactory.Create(options.Content);
        pdfCanvas.AddImageAt(imageData, options.PositionX, options.PositionY, true);

        pdfCanvas.RestoreState();
    }

    private static System.Drawing.Color ConvertHexToColor(string hex)
    {
        return System.Drawing.ColorTranslator.FromHtml(hex);
    }
}
