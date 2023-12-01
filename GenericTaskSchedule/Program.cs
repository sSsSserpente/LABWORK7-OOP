// Generic TaskScheduler class
public class TaskScheduler<TTask, TPriority>
{
    private SortedDictionary<TPriority, Queue<TTask>> taskQueue;
    private TaskExecution<TTask> taskExecutor;

    public TaskScheduler(TaskExecution<TTask> taskExecutor)
    {
        this.taskExecutor = taskExecutor;
        this.taskQueue = new SortedDictionary<TPriority, Queue<TTask>>();
    }

    // Method to add a task with a specific priority
    public void AddTask(TTask task, TPriority priority)
    {
        if (!taskQueue.ContainsKey(priority))
        {
            taskQueue[priority] = new Queue<TTask>();
        }

        taskQueue[priority].Enqueue(task);
    }

    // Method to execute the next task with the highest priority
    public void ExecuteNext()
    {
        if (taskQueue.Count > 0)
        {
            var highestPriority = taskQueue.Keys.Max();
            var nextTask = taskQueue[highestPriority].Dequeue();

            Console.WriteLine($"Executing task with priority {highestPriority}: {nextTask}");
            taskExecutor(nextTask);

            if (taskQueue[highestPriority].Count == 0)
            {
                taskQueue.Remove(highestPriority);
            }
        }
        else
        {
            Console.WriteLine("No tasks in the queue.");
        }
    }
}

// Delegate for task execution
public delegate void TaskExecution<TTask>(TTask task);

class Program
{
    static void Main()
    {
        // Example usage

        // Creating a TaskScheduler for strings with int priorities
        TaskScheduler<string, int> taskScheduler = new TaskScheduler<string, int>(ExecuteTask);

        // Adding tasks with priorities
        taskScheduler.AddTask("Task1", 3);
        taskScheduler.AddTask("Task2", 1);
        taskScheduler.AddTask("Task3", 2);

        // Executing tasks with the highest priority
        taskScheduler.ExecuteNext();
        taskScheduler.ExecuteNext();
        taskScheduler.ExecuteNext();
        taskScheduler.ExecuteNext(); // No tasks remaining

        // Creating a TaskScheduler for integers with string priorities
        TaskScheduler<int, string> intTaskScheduler = new TaskScheduler<int, string>(ExecuteTask);

        // Adding tasks with priorities
        intTaskScheduler.AddTask(10, "High");
        intTaskScheduler.AddTask(20, "Low");
        intTaskScheduler.AddTask(30, "Medium");

        // Executing tasks with the highest priority
        intTaskScheduler.ExecuteNext();
        intTaskScheduler.ExecuteNext();
        intTaskScheduler.ExecuteNext();
        intTaskScheduler.ExecuteNext(); // No tasks remaining
    }

    // Task execution method
    static void ExecuteTask<T>(T task)
    {
        Console.WriteLine($"Executing task: {task}");
    }
}
