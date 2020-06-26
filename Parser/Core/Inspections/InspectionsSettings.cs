namespace Parser.Core.Inspections
{
    class InspectionsSettings : IParserSettings
    {
        public InspectionsSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }
        public string BaseUrl { get; set; } = "https://inspections.gov.ua/inspection/all-unplanned";
        public string Prefix { get; set; } = "page{CurrentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set ; }
      

    }
}
