using Avalonia.Controls;
using Avalonia.Interactivity;
using BabayanRandomizer.Modeli;
using BabayanRandomizer.Interfejsy;
using BabayanRandomizer.Servisy;
using BabayanRandomizer.Commands;
using System.Linq;

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
        
        // Паттерн Стратегия: создаем и передаем стратегию в сервис
        var strategy = new PureRandomStrategy();
        _service = new RandomizerService(_history, strategy);
        
        _list = new OptionList("Что поесть сегодня?");

        // Паттерн Наблюдатель: подписываемся на изменения моделей
        _list.OnOptionsChanged += RefreshOptions;
        _history.OnHistoryChanged += RefreshHistory;

        // Начальные данные
        _list.Add(new Option("Пицца"));
        _list.Add(new Option("Суши"));
        _list.Add(new Option("Бургер"));
        _list.Add(new Option("Шаурма"));
        _list.Add(new Option("Паста"));
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
        // Паттерн Команда: инкапсулируем действие добавления
        var command = new AddOptionCommand(_list, text);
        command.Execute();
        
        InputField.Text = "";
        // RefreshOptions() больше не нужен здесь, сработает событие
    }

    private void RemoveOption(object? sender, RoutedEventArgs e)
    {
        int index = OptionsList.SelectedIndex;
        // Паттерн Команда: инкапсулируем действие удаления
        var command = new RemoveOptionCommand(_list, index);
        command.Execute();
    }

    private void PickRandom(object? sender, RoutedEventArgs e)
    {
        // Паттерн Команда: инкапсулируем выбор рандома
        var command = new PickRandomCommand(_service, _list, result => 
        {
            ResultLabel.Text = $"Результат: {result.Message}";
        });
        command.Execute();
    }

    private void ClearAll(object? sender, RoutedEventArgs e)
    {
        // Паттерн Команда: инкапсулируем очистку
        var command = new ClearOptionsCommand(_list);
        command.Execute();
        
        ResultLabel.Text = "Результат: —";
    }
}
