namespace Namava.Internship.Core.Factory;
using Interface;
using System;
using System.Collections.Generic;
using System.Linq; // For ToDictionary() and ToList()


public class SolverFactory
{
    private readonly Dictionary<string, ISolver> _solvers;

    public SolverFactory(IEnumerable<ISolver> solvers)
    {
// Build dictionary once from solvers provided by IoC
        _solvers = solvers.ToDictionary(
            s => s.Name,
            s => s,
            StringComparer.OrdinalIgnoreCase // case-insensitive lookup
        );
    }

    public ISolver GetSolver(string name)
    {
        if (_solvers.TryGetValue(name, out var solver))
            return solver;

        throw new ArgumentException($"Solver '{name}' not found.");
    }

    public List<string> GetAvailableSolvers() => _solvers.Keys.ToList();
}