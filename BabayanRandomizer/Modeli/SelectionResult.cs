namespace BabayanRandomizer.Modeli
{
    // Результат одного выбора
    public class SelectionResult
    {
        public Option? SelectedOption { get; private set; }
        public DateTime SelectionTime { get; private set; }
        public int AvailableCount { get; private set; }
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }

        public SelectionResult(Option selected, int availableCount)
        {
            SelectedOption = selected;
            AvailableCount = availableCount;
            SelectionTime = DateTime.Now;
            IsSuccess = true;
            Message = $"Выбрано: \"{selected.Text}\"";
        }

        public SelectionResult(string message)
        {
            SelectedOption = null;
            AvailableCount = 0;
            SelectionTime = DateTime.Now;
            IsSuccess = false;
            Message = message;
        }

        public override string ToString()
        {
            if (IsSuccess)
                return $"V {Message} (из {AvailableCount}, в {SelectionTime:HH:mm:ss})";
            else
                return $"X {Message}";
        }
    }
}
