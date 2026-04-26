using Avalonia.Controls;
using Avalonia.Interactivity;
using BabayanRandomizer.Modeli;
using BabayanRandomizer.Interfejsy;
using BabayanRandomizer.Servisy;

namespace BabayanRandomizer;

public partial class MainWindow : Window
{
    private readonly SelectionHistory _history;
    private readonly IRandomSelection _service;
    private readonly IOptionList<Option> _list;

    public MainWindow()
    {
        InitializeComponent();

        _history = new SelectionHistory();
        _service = new RandomizerService(_history);
        _list = new OptionList("Что поесть сегодня?");

        _list.Add(new Option("Пицца"));
        _list.Add(new Option("Суши"));
        _list.Add(new Option("Бургер"));
        _list.Add(new Option("Шаурма"));
        _list.Add(new Option("Паста"));

        RefreshOptions();
    }

    private void RefreshOptions()
    {
        OptionsList.ItemsSource = _list.GetAll().Select(o => o.Text).ToList();
    }

    private void RefreshHistory()
    {
        HistoryList.ItemsSource = _history.GetAll().Select(r => r.Message).ToList();
    }

    private void AddOption(object? sender, RoutedEventArgs e)
    {
        var text = InputField.Text?.Trim();
        if (!string.IsNullOrEmpty(text))
        {
            _list.Add(new Option(text));
            InputField.Text = "";
            RefreshOptions();
        }
    }

    private void RemoveOption(object? sender, RoutedEventArgs e)
    {
        int index = OptionsList.SelectedIndex;
        if (index >= 0)
        {
            _list.RemoveAt(index);
            RefreshOptions();
        }
    }

    private void PickRandom(object? sender, RoutedEventArgs e)
    {
        var result = _service.PickRandom(_list.GetAll());
        ResultLabel.Text = $"Результат: {result.Message}";
        RefreshHistory();
    }

    private void ClearAll(object? sender, RoutedEventArgs e)
    {
        _list.ClearAll();
        RefreshOptions();
        ResultLabel.Text = "Результат: —";
    }
}
