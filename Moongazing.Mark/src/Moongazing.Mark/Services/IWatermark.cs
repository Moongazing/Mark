using Moongazing.Mark.Models;

public interface IWatermark
{
    void ApplyWatermark(string inputPath, string outputPath, WatermarkOptions options);
}
