namespace BabayanRandomizer.Modeli
{
    // Один вариант для выбора
    public class Option
    {
        public Guid Id { get; private set; }
        public string Text { get; set; }
        public bool IsSelected { get; set; }
        public DateTime CreatedAt { get; private set; }

        public Option(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Текст не может быть пустым!", nameof(text));

            Id = Guid.NewGuid();
            Text = text.Trim();
            IsSelected = false;
            CreatedAt = DateTime.Now;
        }

        public void MarkAsSelected()
        {
            IsSelected = true;
        }

        public void ResetSelection()
        {
            IsSelected = false;
        }

        public override string ToString()
        {
            return $"[{(IsSelected ? "v" : " ")}] {Text}";
        }
    }
}
