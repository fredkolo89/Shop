namespace DecisionTree
{
    public class PlayFootball
    {
        public Outlook Outlook { get; set; }
        public Temperature Temperature { get; set; }
        public Humidity Humidity { get; set; }
        public Windy Windy { get; set; }
        public bool Decision { get; set; }

     
    }

    public enum Outlook
    {
        Overcats,
        Sunny,
        Rainy
    }

    public enum Temperature
    {
        Hot,
        Mild,
        Cold
    }

    public enum Humidity
    {
        High,
        Normal
        
    }

    public enum Windy
    {
        Strong,
        Weak
    }
}