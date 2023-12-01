// Generic Criteria delegate
public delegate bool Criteria<T>(T item);

// Generic Repository class
public class Repository<T>
{
    private List<T> items;

    public Repository()
    {
        items = new List<T>();
    }

    // Method to add an item to the repository
    public void Add(T item)
    {
        items.Add(item);
    }

    // Method to find items based on the given criteria
    public List<T> Find(Criteria<T> criteria)
    {
        List<T> result = new List<T>();

        foreach (T item in items)
        {
            if (criteria(item))
            {
                result.Add(item);
            }
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        // Example usage

        // Creating a repository of integers
        Repository<int> intRepository = new Repository<int>();

        // Adding some integers to the repository
        intRepository.Add(5);
        intRepository.Add(10);
        intRepository.Add(15);
        intRepository.Add(20);

        // Defining criteria to find even numbers
        Criteria<int> evenCriteria = x => x % 2 == 0;

        // Finding and displaying even numbers
        List<int> evenNumbers = intRepository.Find(evenCriteria);
        Console.WriteLine("Even Numbers:");
        foreach (int number in evenNumbers)
        {
            Console.WriteLine(number);
        }

        // Creating a repository of strings
        Repository<string> stringRepository = new Repository<string>();

        // Adding some strings to the repository
        stringRepository.Add("apple");
        stringRepository.Add("banana");
        stringRepository.Add("orange");
        stringRepository.Add("grape");

        // Defining criteria to find strings starting with 'a'
        Criteria<string> startsWithACriteria = s => s.StartsWith("a", StringComparison.OrdinalIgnoreCase);

        // Finding and displaying strings starting with 'a'
        List<string> startsWithAStrings = stringRepository.Find(startsWithACriteria);
        Console.WriteLine("\nStrings starting with 'a':");
        foreach (string str in startsWithAStrings)
        {
            Console.WriteLine(str);
        }
    }
}
