namespace BabayanRandomizer.Modeli
{
    public class SelectionResult
    {
        public Option? SelectedOption { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public SelectionResult(Option selected)
        {
            SelectedOption = selected;
            IsSuccess = true;
            Message = $"Выбрано: {selected.Text}";
        }

        public SelectionResult(string message)
        {
            SelectedOption = null;
            IsSuccess = false;
            Message = message;
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
