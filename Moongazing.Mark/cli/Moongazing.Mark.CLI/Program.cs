
using CommandLine;
using Moongazing.Mark.Models;
using Moongazing.Mark.Services;

class Program
{
    public class WatermarkArguments
    {
        [Option('i', "input", Required = true, HelpText = "Input PDF file path.")]
        public string InputFile { get; set; }

        [Option('o', "output", Required = true, HelpText = "Output PDF file path.")]
        public string OutputFile { get; set; }

        [Option('t', "type", Required = true, HelpText = "Watermark type: Text or Image.")]
        public WatermarkType WatermarkType { get; set; }

        [Option('c', "content", Required = true, HelpText = "Watermark content (text or image path).")]
        public string Content { get; set; }
    }

    static void Main(string[] args)
    {
        Parser.Default.ParseArguments<WatermarkArguments>(args)
            .WithParsed(opts =>
            {
                var service = new PdfWatermarkService();
                var options = new WatermarkOptions
                {
                    Type = opts.WatermarkType,
                    Content = opts.Content,
                };
                service.ApplyWatermark(opts.InputFile, opts.OutputFile, options);
            });
    }
}
