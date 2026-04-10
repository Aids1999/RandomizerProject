using BabayanRandomizer.Modeli;
using BabayanRandomizer.Interfejsy;
using BabayanRandomizer.Servisy;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("=== Randomizer ===\n");

// Инициализация
var history = new SelectionHistory();
IRandomSelection service = new RandomizerService(history);
IOptionList<Option> list = new OptionList("Что поесть сегодня?");

// Добавление данных
list.Add(new Option("Пицца"));
list.Add(new Option("Суши"));
list.Add(new Option("Бургер"));
list.Add(new Option("Шаурма"));
list.Add(new Option("Паста"));

Console.WriteLine($"Всего вариантов: {list.Count}\n");
foreach (var opt in list.GetAll())
    Console.WriteLine($"  {opt}");

// Редактирование и удаление
list.Edit(0, new Option("Пицца Маргарита"));
list.RemoveAt(1);

Console.WriteLine($"\nВариантов после правок: {list.Count}");
foreach (var opt in list.GetAll())
    Console.WriteLine($"  {opt}");

Console.WriteLine("\n— Рандом —");

var result1 = service.PickRandom(list.GetAll());
Console.WriteLine($"Результат 1: {result1}");

// Выбор без повторов
var result2 = service.PickRandom(list.GetAll());
Console.WriteLine($"Результат 2: {result2}");

// Очистка списка
list.ClearAll();
Console.WriteLine($"\nПосле очистки: {list.Count}");

// Вывод истории
Console.WriteLine($"\n— История ({history.Count} зап.) —");
foreach (var entry in history.GetAll())
    Console.WriteLine($"  {entry}");

Console.WriteLine("\n=== Готово! ===");
