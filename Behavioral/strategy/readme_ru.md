Актуальная версия материала расположена по [адресу](https://couthyblog.xyz/pattiern-stratieghiia/)

* [Введение](#intro)
* [Примеры](#examples)
    * [Выбор элементов из последовательности целых чисел.](#selectors)
        * [C#](#selectorcsharpexample)
        * [Python](#selectorpythonexample)
        * [C](#selectorcexample)
* [Литература](#bibliography)

<a name="intro"></a>**Введение**
Необходимость паттерна "Стратегия" возникает, довольно часто, например:

* Когда вызывающий код не должен знать о деталях реализации используемого алгоритма.
* Когда во время работы программы необходимо подменять используемый алгоритм.

Данный паттерн является фундаметальным и многие из паттернов, которые будут рассмотрены в дальнейшем являются его частными случаями. Кроме того, любой ООП-программист применяет его каждый раз, когда использует наследование.

Ниже представлена UML-диаграмма данного паттерна.

![stragUml](https://couthyblog.xyz/content/images/2017/06/Strategy_Pattern_in_UML.png)

<a name="examples"></a>
Рассмотрим несколько задач, иллюстрирующих его применение (пока только одну ^_^'). 

<a name="selectors"></a>
##### Выбор элементов из последовательности целых чисел.
В данном примере воспользуемся паттерном "Стратегия" для реализация выборки элементов из последовательности целых чисел по следующим критериям:

* Выборка четных элементов
* Выборка нечетных элементов
* Выборка элементов из отрезка

**Реализации**
<a name="selectorcsharpexample"></a><details>
<summary>**C#**</summary>

Определим интерфейс для стратегии выбора элемента.
```csharp
public interface IIntegerSelector
{
    IEnumerable<int> Select(IEnumerable<int> source);
}
```

Стратегия выбора четных чисел.
```csharp
public class EvenNumbersSelector : IIntegerSelector
{
    public IEnumerable<int> Select(IEnumerable<int> source)
    {
        var sourceEnumerator = source.GetEnumerator();
        while (sourceEnumerator.MoveNext())
        {
            if (sourceEnumerator.Current % 2 == 0)
                yield return sourceEnumerator.Current;
        }

        // Or using Linq
        //return source.Where(el => el % 2 == 0);
    }
}
```

Стратегия выбора нечетных чисел.
```csharp
public class OddNumbersSelector : IIntegerSelector
{
    public IEnumerable<int> Select(IEnumerable<int> source)
    {
        var sourceEnumerator = source.GetEnumerator();
        while (sourceEnumerator.MoveNext())
        {
            if (sourceEnumerator.Current % 2 == 0)
                continue;
            yield return sourceEnumerator.Current;
        }
        
        // Or using Linq
        //return source.Where(el => el % 2 != 0);
    }
}
```

Стратегия выбора чисел из отрезка.
```csharp
public class NumbersFormRangeSelector : IIntegerSelector
{
    public int RangeStart { get; }
    public int RangeEnd { get; }

    public NumbersFormRangeSelector(int rangeStart, int rangeEnd)
    {
        if (rangeStart >= rangeEnd)
            throw new ArgumentOutOfRangeException();

        RangeStart = rangeStart;
        RangeEnd = rangeEnd;
    }

    public IEnumerable<int> Select(IEnumerable<int> source)
    {
        var sourceEnumerator = source.GetEnumerator();
        while (sourceEnumerator.MoveNext())
        {
            if (sourceEnumerator.Current >= RangeStart && sourceEnumerator.Current <= RangeEnd)
                yield return sourceEnumerator.Current;
        }
        
        // Or using Linq
        //return source.Where(el => el >= RangeStart && el <= RangeEnd);
    }
}
```

Используем реализованные стратегии.
```csharp
class Program
{
    public static void PrintSelectedElements(List<int> source, IIntegerSelector selector)
    {
        Console.WriteLine($"[{source.Select(el => el.ToString()).Aggregate((one, two) => one + ", " + two)}]");
        foreach (var element in selector.Select(source))
        {
            Console.WriteLine($"Selected element: {element}");
        }
    }

    static void Main(string[] args)
    {
        var sourceList = new List<int>() { 1, 2, 3, 4, 5, 6, -4, -1, -455, 2, 1, 456, 783, 12, 45, 90, 24 };

        Console.WriteLine("Selecting even numbers");
        PrintSelectedElements(sourceList, new EvenNumbersSelector());

        Console.WriteLine("Selecting odd numbers");
        PrintSelectedElements(sourceList, new OddNumbersSelector());

        Console.WriteLine("Selecting numbers in range [1, 20]");
        PrintSelectedElements(sourceList, new NumbersFormRangeSelector(1, 20));
    }
}
```
</details>
<a name="selectorpythonexample"></a><details>
<summary>**Python**</summary>

Определим базовый класс для стратегии выбора элемента.
```python
class BaseSelector:
    def select(self, source: list) -> list:
        pass
```

Стратегия выбора четных чисел.
```python
class EvenNumbersSelector(BaseSelector):
    def select(self, source: list) -> list:
        result = []
        for val in source:
            if val % 2 == 0:
                result.append(val)
        return result
```

Стратегия выбора нечетных чисел.
```python
from selectors.BaseSeletor import BaseSelector


class OddNumbersSelector(BaseSelector):
    def select(self, source: list) -> list:
        result = []
        for val in source:
            if val % 2 != 0:
                result.append(val)
        return result
```

Стратегия выбора чисел из отрезка.
```python
class NumbersFormRangeSelector(BaseSelector):
    segmentStart = 0
    segmentEnd = 0

    def __init__(self, segmentstart:int, segmentend:int):
        self.segmentStart = segmentstart
        self.segmentEnd = segmentend

        if self.segmentStart >= self.segmentEnd:
            raise ValueError()

    def select(self, source: list) -> list:
        result = []
        for val in source:
            if self.segmentStart <= val <= self.segmentEnd:
                result.append(val)
        return result
```

Используем реализованные стратегии.
```python
def print_selected_elements(source: list, strategy: BaseSelector):
    print(source)
    for val in strategy.select(source):
        print("Selected element: " + str(val))

sourceList = [1, 2, 3, 4, 5, 6, -4, -1, -455, 2, 1, 456, 783, 12, 45, 90, 24]

print("Selecting even numbers")
print_selected_elements(sourceList, EvenNumbersSelector())

print("Selecting odd numbers")
print_selected_elements(sourceList, OddNumbersSelector())

print("Selecting numbers in range [1, 20]")
print_selected_elements(sourceList, NumbersFormRangeSelector(1, 20))
```
</details>

<a name="selectorcexample"></a><details>
<summary>**C**</summary>

Определим тип для стратегии выбора элемента. Получается, конечно, не так изящно - приходится задавать самый общий случай и для выбора четных и нечетных чисел будет передаваться две неиспользуемые переменные. Есть ещё второй способ реализация паттерна стратегия с помощью изменения состояния<sup>[3](#myfootnote3)</sup>, но, на мой взгляд, текущий вариант всё же красивее.
```c
typedef int (*IntegerSelectorStrategy) (int*,int,int,int, int**);
```

Стратегия выбора четных чисел.
```c
int EvenNumbersSelector(int* source, int len, int unused1, int unused2, int** resultArray)
{
    int numberOfPassed = 0;
    for(int i=0; i<len; ++i)
    {
        if(source[i] % 2 == 0)
            numberOfPassed++;
    }

    (*resultArray) = (int*)malloc(numberOfPassed * sizeof(int));
    int* resultArrayPointerCopy = (*resultArray);

    for(int i=0; i<numberOfPassed; ++source)
    {
        if((*source) % 2 == 0)
        {
            (*resultArrayPointerCopy) = (*source);
            ++resultArrayPointerCopy;
            ++i;
        }
    }

    return numberOfPassed;
}
```

Стратегия выбора нечетных чисел.
```c
int OddNumbersSelector(int* source, int len, int unused1, int unused2, int** resultArray)
{
    int numberOfPassed = 0;
    for(int i=0; i<len; ++i)
    {
        if(source[i] % 2 != 0)
            numberOfPassed++;
    }

    (*resultArray) = (int*)malloc(numberOfPassed * sizeof(int));
    int* resultArrayPointerCopy = (*resultArray);

    for(int i=0; i<numberOfPassed; ++source)
    {
        if((*source) % 2 != 0)
        {
            (*resultArrayPointerCopy) = (*source);
            ++resultArrayPointerCopy;
            ++i;
        }
    }

    return numberOfPassed;
}
```

Стратегия выбора чисел из отрезка.
```c
int NumbersFormRangeSelector(int* source, int len, int segmentStart, int segmentEnd, int** resultArray)
{
    int numberOfPassed = 0;
    for(int i=0; i<len; ++i)
    {
        if(source[i] >= segmentStart && source[i] <= segmentEnd)
            numberOfPassed++;
    }

    (*resultArray) = (int*)malloc(numberOfPassed * sizeof(int));
    int* resultArrayPointerCopy = (*resultArray);

    for(int i=0; i<numberOfPassed; ++source)
    {
        if((*source) >= segmentStart && (*source) <= segmentEnd)
        {
            (*resultArrayPointerCopy) = (*source);
            ++resultArrayPointerCopy;
            ++i;
        }
    }

    return numberOfPassed;
}
```

Используем реализованные стратегии.
```c
void PrintSelectedElements(int* source, int len, int segmentStart, int segmentEnd, IntegerSelectorStrategy strategy)
{
    printf("[");
    for(int i=0;i<len-1;i++)
    {
        printf("%d, ", source[i]);
    }
    printf("%i]\n", source[len-1]);

    int* resultArray;
    int lenResultArray = (*strategy)(source, len, segmentStart, segmentEnd, &resultArray);

    for(int i=0;i<lenResultArray;i++)
    {
        printf("Selected element: %d \n", resultArray[i]);
    }
}

int main()
{
    int sourceArray[17] = { 1, 2, 3, 4, 5, 6, -4, -1, -455, 2, 1, 456, 783, 12, 45, 90, 24};

    printf("Selecting even numbers");
    PrintSelectedElements(sourceArray, 17, 0, 0, EvenNumbersSelector);

    printf("Selecting odd numbers");
    PrintSelectedElements(sourceArray, 17, 0, 0, OddNumbersSelector);

    printf("Selecting numbers in range [1, 20]");
    PrintSelectedElements(sourceArray, 17, 1, 20, NumbersFormRangeSelector);

    return 0;
}
```
</details>

Весь код использованный в проекте доступен на  [GitHub](https://github.com/stardreamer/patterns).

<a name="bibliography"></a>
Литература
---------------
<a name="myfootnote1">[1]</a>: [Strategy pattern. From Wikipedia](https://en.wikipedia.org/wiki/Strategy_pattern)
<a name="myfootnote2">[2]</a>: _Тепляков С._ Паттерны проектирования на платформе .NET &ndash; СПб.: Питер, 2015. — 28-37 c. 
<a name="myfootnote3">[3]</a>: [Patterns in C - Part 3: STRATEGY](http://www.adamtornhill.com/Patterns%20in%20C%203,%20STRATEGY.pdf)
<a name="myfootnote4">[4]</a>: [Design Patterns: Elements of Reusable Object-Oriented Software](https://en.wikipedia.org/wiki/Design_Patterns)