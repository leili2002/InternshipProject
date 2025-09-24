namespace ConsoleApp1.Program;
using System;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Namava.Internship.Core.Interface;
using Namava.Internship.Core.Solvers;
using Namava.Internship.Core.Factory;


public class Program
{
    public static void Main()
    {
// 1. Setup DI container
        var services = new ServiceCollection();

// Register solvers
        services.AddTransient<ISolver, BruteForceSolver>();
        services.AddTransient<ISolver, TwoPointerFastSortSolver>();
        services.AddTransient<ISolver, TwoPointerLowSpaceSortSolver>();
        services.AddTransient<ISolver, HashMapSolver>();

// Register factory
        services.AddSingleton<SolverFactory>();

// Build provider
        var provider = services.BuildServiceProvider();

// 2. Resolve factory
        var factory = provider.GetRequiredService<SolverFactory>();

// 3. User input
        Console.WriteLine("Enter array elements (comma separated):");
        int[] nums = Array.ConvertAll(Console.ReadLine().Split(','), int.Parse);

        Console.WriteLine("Enter target number:");
        int target = int.Parse(Console.ReadLine());

        Console.WriteLine("Choose a solver by name:");
        foreach (string name in factory.GetAvailableSolvers())
            Console.WriteLine(name);

        string choiceName = Console.ReadLine();

// 4. Run chosen solver
        try
        {
            ISolver solver = factory.GetSolver(choiceName);

            Stopwatch stopwatch = Stopwatch.StartNew();
            var results = solver.TwoSum(nums, target);
            stopwatch.Stop();

            Console.WriteLine($"{solver.Name} Results:");
            foreach (var pair in results)
                Console.WriteLine($"({pair[0]},{pair[1]})");

            Console.WriteLine($"Execution Time: {stopwatch.Elapsed.TotalMilliseconds} ms");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}