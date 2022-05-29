namespace BilgeAdam.Common.Contracts
{
    public class RegionalParameters
    {
        public RegionalParameters()
        {
            ExcludedCategories = new List<int>();
        }
        public List<int> ExcludedCategories { get; set; }

        public void Setup(string culture)
        {
            switch (culture)
            {
                case "tr-TR":
                    ExcludedCategories.Add(9);
                    ExcludedCategories.Add(10);
                    break;
            }
        }
    }
}
