using System;
using System.Threading.Tasks;

namespace DemoAsync
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var demo = new AsyncAwaitDemo();

            // Will not block the thread.
            // I can not get the result right now after end.
            var result = "";
            Task.Run(() =>
            {
                result = AsyncAwaitDemo.RunningOperation();
            });

            // Will block the thread until finished.
            var mainClass = new MainClass();
            mainClass.PrintResultsAsync();

            while (true)
            {
                Console.WriteLine("Main Thread...................");
            }
        }

        async void PrintResultsAsync()
        {
            System.Console.WriteLine(await AsyncAwaitDemo.GetResultAsync(5000));
            System.Console.WriteLine(await AsyncAwaitDemo.RunningOperationAsync());
        }
    }
}

public class AsyncAwaitDemo
{

    public static async Task<string> GetResultAsync(int delayTime)
    {
        await Task.Delay(delayTime);
        return "public static async Task<string> GetResultAsync(int delayTime)";
    }

    public static Task<string> RunningOperationAsync()
    {
        var result = new TaskCompletionSource<string>();
        var currentString = "";

        for (int counter = 0; counter < 50000; counter++)
        {
            Console.WriteLine(counter);
            currentString += counter.ToString() + " ";
            result.TrySetResult(currentString);
        }

        return result.Task;
    }

    public static string RunningOperation()
    {
        var currentString = "";

        for (int counter = 0; counter < 50000; counter++)
        {
            Console.WriteLine(counter);
            currentString += counter.ToString() + " ";
        }

        return currentString;
    }
}