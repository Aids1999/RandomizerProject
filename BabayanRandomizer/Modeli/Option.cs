namespace BabayanRandomizer.Modeli
{
    public class Option
    {
        public string Text { get; set; }
        public bool IsSelected { get; set; }

        public Option(string text)
        {
            Text = text;
            IsSelected = false;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
