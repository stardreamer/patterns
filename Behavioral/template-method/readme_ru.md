Актуальная версия материала расположена по [адресу](https://couthyblog.xyz/pattiern-shablonnyi-mietod/)
#### Паттерн "Шаблонный метод" (Template Method<sup>[1](#myfootnote1)</sup>)

**Содержание**

* [Введение](#intro)
* [Примеры](#examples)
    * [Генерация имени в различных языках.](#namegenerators)
        * [C#](#generatorcsharpexample)
        * [Python](#generatorpythonexample)
* [Литература](#bibliography)

<a name="intro"></a>**Введение**
Необходимость паттерна "Шаблонный метод" возникает

* Когда известен общий ход работы алгоритма, однако, реализация каждого из его этапов может различаться..

По сути паттерн шаблонный метод яявляется частным случаем стратегии с тем отличием, что в случае шаблонного метода подменяется не сам алгоритм, а только детали его реализации. Классический подход к реализации этого паттерна заключается в выделении базового класса с шаблонным методом, детали реализации которого описываются в наследниках базового класса. Именно эта реализация будет использоваться в следующем примере, но существуют и другие способы реализации этого паттерна, например в C# это можно сделать с помощью делегатов (подробно это описано в [[2, с. 40]](#myfootnote2)).

Ниже представлена UML-диаграмма данного паттерна.

![stragUml](/content/images/2017/06/Strategy_Pattern_in_UML.png)

<a name="examples"></a>

<a name="namegenerators"></a>
##### Генерация имени в различных языках.
В данном примере воспользуемся паттерном "Шаблонный метод" для генерации имени в следующих языках:

* Английски.
* Русский.
* Немецкий.

**Реализации**
<a name="generatorcsharpexample"></a><details>
<summary>C#</summary>

Базовый класс генерации имен. Шаблонный метод тут - `GetName`. Методы `GenerateFirstName` и `GenerateSurname` отвечают за детали реализации алгоритма генерации имён.
```csharp
public enum Gender
{
    Male,
    Female
}

public abstract class BaseNameGenerator
{
    protected  Random _random = new Random();

    private Gender GetRandomGender()
    {
        switch(_random.Next(0, 2))
        {
            case 0:
                return Gender.Male;
            case 1:
                return Gender.Female;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    protected abstract string GenerateFirstName(Gender gender);

    protected abstract string GenerateSurname(Gender gender);

    public string GetName()
    {
        var gender = GetRandomGender();
        return $"{GenerateFirstName(gender)}  {GenerateSurname(gender)}";
    }
}
```
Генерация русских имён.
```csharp
public class RussianNameGenerator : BaseNameGenerator
{
    private readonly string[] _firstMaleNames = new string[] { "Антон", "Олег", "Роман", "Виктор" };
    private readonly string[] _firstFemaleNames = new string[] { "Виктория", "Светлана", "Катерина", "Ольга" };
    private readonly string[] _secondNames = new string[] { "Петров", "Семенов", "Иванов", "Борисов" };

    protected override string GenerateFirstName(Gender gender)
    {
        switch (gender)
        {
            case Gender.Male:
                return _firstMaleNames[_random.Next(0, _firstMaleNames.Length)];
            case Gender.Female:
                return _firstFemaleNames[_random.Next(0, _firstFemaleNames.Length)];
            default:
                throw new ArgumentOutOfRangeException();
        }

    }

    protected override string GenerateSurname(Gender gender)
    {
        switch (gender)
        {
            case Gender.Male:
                return _secondNames[_random.Next(0, _secondNames.Length)];
            case Gender.Female:
                return $"{_secondNames[_random.Next(0, _secondNames.Length)]}а";
            default:
                throw new ArgumentOutOfRangeException();
        }

    }
}
```
Генерация английских имён.
```csharp
public class EnglishNameGenerator: BaseNameGenerator
{
    private readonly string[] _firstMaleNames = new string[] { "Jim", "Richard", "Ted", "Robert", "Danny" };
    private readonly string[] _firstFemaleNames = new string[] { "Kate", "Susan", "Victoria", "Diana" };
    private readonly string[] _secondNames = new string[] { "Smith", "Black", "Robinson", "Rand" };

    protected override string GenerateFirstName(Gender gender)
    {
        switch (gender)
        {
            case Gender.Male:
                return _firstMaleNames[_random.Next(0, _firstMaleNames.Length)];
            case Gender.Female:
                return _firstFemaleNames[_random.Next(0, _firstFemaleNames.Length)];
            default:
                throw new ArgumentOutOfRangeException();
        }

    }

    protected override string GenerateSurname(Gender gender)
    {
        return _secondNames[_random.Next(0, _secondNames.Length)];
    }
}
```
Генерация немецких имён.
```csharp
public class GermanNameGenerator : BaseNameGenerator
{
    private readonly string[] _firstMaleNames = new string[] { "Hans", "Heinz", "Horst", "Andreas" };
    private readonly string[] _firstFemaleNames = new string[] { "Anna", "Elke", "Birgit", "Stefanie" };
    private readonly string[] _secondNames = new string[] { "Müller", "Schröder", "Hartmann", "Schulze" };

    protected override string GenerateFirstName(Gender gender)
    {
        switch (gender)
        {
            case Gender.Male:
                return _firstMaleNames[_random.Next(0, _firstMaleNames.Length)];
            case Gender.Female:
                return _firstFemaleNames[_random.Next(0, _firstFemaleNames.Length)];
            default:
                throw new ArgumentOutOfRangeException();
        }

    }

    protected override string GenerateSurname(Gender gender)
    {
        return _secondNames[_random.Next(0, _secondNames.Length)];
    }
}
```
Используем реализованную функциональность.
```csharp
private static void PrintRandomName(BaseNameGenerator generator)
{
    Console.WriteLine($"Generated name: {generator.GetName()}");
}

static void Main(string[] args)
{
    Console.OutputEncoding = Encoding.UTF8;

    Console.WriteLine($"Generating russian name.");
    PrintRandomName(new RussianNameGenerator());
    Console.WriteLine($"Generating english name.");
    PrintRandomName(new EnglishNameGenerator());
    Console.WriteLine($"Generating german name.");
    PrintRandomName(new GermanNameGenerator());
}
```
Пример работы программы
```
Generating russian name.
Generated name: Виктор  Иванов
Generating english name.
Generated name: Danny  Robinson
Generating german name.
Generated name: Andreas  Hartmann
```
</details>
<a name="generatorpythonexample"></a><details>
<summary>Python</summary>

Базовый класс генерации имен. Шаблонный метод тут - `get_name`. Методы `generate_first_name` и `generate_surname` отвечают за детали реализации алгоритма генерации имён.
```python
class Gender(Enum):
    MALE = 1
    FEMALE = 2


class BaseNameGenerator:
    @staticmethod
    def get_random_gender() -> Gender:
        if random.randint(1, 2) == 1:
            return Gender.MALE
        return Gender.FEMALE

    def generate_first_name(self, gender: Gender) -> str:
        pass

    def generate_surname(self, gender: Gender) -> str:
        pass

    def get_name(self)-> str:
        gender = self.get_random_gender()
        return self.generate_first_name(gender) + " " + self.generate_surname(gender)
```
Генерация русских имён.
```python
class RussianNameGenerator(BaseNameGenerator):
    __first_male_names = ["Антон", "Олег", "Роман", "Виктор"]
    __first_female_names = ["Виктория", "Светлана", "Катерина", "Ольга"]
    __surnames = ["Петров", "Семенов", "Иванов", "Борисов"]

    def generate_first_name(self, gender: Gender) -> str:
        if gender == Gender.MALE:
            return self.__first_male_names[random.randint(0, len(self.__first_male_names)-1)]
        return self.__first_female_names[random.randint(0, len(self.__first_female_names)-1)]

    def generate_surname(self, gender: Gender) -> str:
        if gender == Gender.MALE:
            return self.__surnames[random.randint(0, len(self.__surnames)-1)]
        return self.__surnames[random.randint(0, len(self.__surnames)-1)]+"а"
```
Генерация английских имён.
```python
class EnglishNameGenerator(BaseNameGenerator):
    __first_male_names = ["Jim", "Richard", "Ted", "Robert", "Danny"]
    __first_female_names = ["Kate", "Susan", "Victoria", "Diana"]
    __surnames = ["Smith", "Black", "Robinson", "Rand"]

    def generate_first_name(self, gender: Gender) -> str:
        if gender == Gender.MALE:
            return self.__first_male_names[random.randint(0, len(self.__first_male_names)-1)]
        return self.__first_female_names[random.randint(0, len(self.__first_female_names)-1)]

    def generate_surname(self, gender: Gender) -> str:
        return self.__surnames[random.randint(0, len(self.__surnames)-1)]
```
Генерация немецких имён.
```python
class GermanNameGenerator(BaseNameGenerator):
    __first_male_names = ["Hans", "Heinz", "Horst", "Andreas"]
    __first_female_names = ["Anna", "Elke", "Birgit", "Stefanie"]
    __surnames = ["Müller", "Schröder", "Hartmann", "Schulze"]

    def generate_first_name(self, gender: Gender) -> str:
        if gender == Gender.MALE:
            return self.__first_male_names[random.randint(0, len(self.__first_male_names)-1)]
        return self.__first_female_names[random.randint(0, len(self.__first_female_names)-1)]

    def generate_surname(self, gender: Gender) -> str:
        return self.__surnames[random.randint(0, len(self.__surnames)-1)]
```

Используем реализованную функциональность.
```python
def print_random_name(generator: BaseNameGenerator):
    print(generator.get_name())

print("Generating russian name.")
print_random_name(RussianNameGenerator())
print("Generating english name.")
print_random_name(EnglishNameGenerator())
print("Generating german name.")
print_random_name(GermanNameGenerator())
```
Пример работы программы
```
Generating russian name.
Светлана Петрова
Generating english name.
Robert Rand
Generating german name.
Horst Schröder
```
</details>


Весь код использованный в проекте доступен на [GitHub](https://github.com/stardreamer/patterns).

<a name="bibliography"></a>
Литература
---------------
<a name="myfootnote1">[1]</a>: [Template Method Design Pattern](https://sourcemaking.com/design_patterns/template_method)

<a name="myfootnote2">[2]</a>: _Тепляков С._ Паттерны проектирования на платформе .NET &ndash; СПб.: Питер, 2015. — 37-57 c. 

<a name="myfootnote4">[4]</a>: [Design Patterns: Elements of Reusable Object-Oriented Software](https://en.wikipedia.org/wiki/Design_Patterns)