// Generic FunctionCache class
public class FunctionCache<TKey, TResult>
{
    private Dictionary<TKey, CacheItem<TResult>> cache;
    private Func<TKey, TResult> function;

    public FunctionCache(Func<TKey, TResult> function)
    {
        this.function = function;
        this.cache = new Dictionary<TKey, CacheItem<TResult>>();
    }

    // Method to get the result from the cache or compute it if not present
    public TResult GetOrCompute(TKey key, TimeSpan expiration)
    {
        if (cache.TryGetValue(key, out var cacheItem) && cacheItem.IsValid(expiration))
        {
            Console.WriteLine($"Cache hit for key: {key}");
            return cacheItem.Value;
        }

        Console.WriteLine($"Cache miss for key: {key}");

        TResult result = function(key);
        cache[key] = new CacheItem<TResult>(result, DateTime.Now);

        return result;
    }

    // Inner class to represent cache items with expiration time
    private class CacheItem<TValue>
    {
        public TValue Value { get; }
        public DateTime ExpirationTime { get; }

        public CacheItem(TValue value, DateTime expirationTime)
        {
            Value = value;
            ExpirationTime = expirationTime;
        }

        // Method to check if the cache item is still valid based on the expiration time
        public bool IsValid(TimeSpan expiration)
        {
            return DateTime.Now - ExpirationTime < expiration;
        }
    }
}

class Program
{
    static void Main()
    {
        // Example usage

        // Function to square an integer
        Func<int, int> squareFunction = x =>
        {
            Console.WriteLine($"Computing square for {x}");
            return x * x;
        };

        // Creating a FunctionCache with expiration time of 2 seconds
        FunctionCache<int, int> squareCache = new FunctionCache<int, int>(squareFunction);

        // First call, should compute the result
        int result1 = squareCache.GetOrCompute(5, TimeSpan.FromSeconds(2));
        Console.WriteLine($"Result 1: {result1}");

        // Second call with the same key, should use the cached result
        int result2 = squareCache.GetOrCompute(5, TimeSpan.FromSeconds(2));
        Console.WriteLine($"Result 2: {result2}");

        // Wait for 3 seconds to let the cache expire
        System.Threading.Thread.Sleep(3000);

        // Third call after expiration, should compute the result again
        int result3 = squareCache.GetOrCompute(5, TimeSpan.FromSeconds(2));
        Console.WriteLine($"Result 3: {result3}");
    }
}
