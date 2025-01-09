namespace Moongazing.Mark.Models
{
    public class WatermarkOptions
    {
        public WatermarkType Type { get; set; }
        public string Content { get; set; } 
        public float Opacity { get; set; } = 0.5f; 
        public int PositionX { get; set; } = 0; 
        public int PositionY { get; set; } = 0; 
        public int FontSize { get; set; } = 12; 
        public string Color { get; set; } = "#000000"; 
    }
}