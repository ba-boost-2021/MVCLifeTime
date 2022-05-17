namespace BilgeAdam.MVCRocks.Models
{
    public class DropDownOptionViewModel
    {
        public DropDownOptionViewModel(List<Option> options)
        {
            Options = options;
        }
        public string Property { get; set; }
        public List<Option> Options { get; }

        public class Option
        {
            public string Value { get; set; }
            public string Text { get; set; }
        }
    }
}
