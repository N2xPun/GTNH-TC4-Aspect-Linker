using System.Collections.Generic;
using GTNHTC;

public class AspectGraph
{
    public Dictionary<Aspect, HashSet<Aspect>> EdgesList = [];

    public bool AddAspect(Aspect aspect)
    {
        return EdgesList.TryAdd(aspect, []);
    }

    public bool AddEdge(Aspect start, Aspect end)
    {
        if (EdgesList.TryGetValue(start, out var endings) && EdgesList.ContainsKey(end))
        {
            return endings.Add(end);
        }
        return false;
    }

    public bool RemoveAspect(Aspect aspect)
    {
        foreach ((_, var endings) in EdgesList)
        {
            endings.Remove(aspect);
        }
        return EdgesList.Remove(aspect);
    }

    public bool RemoveEdge(Aspect start, Aspect end)
    {
        if (EdgesList.TryGetValue(start, out var endings) && EdgesList.ContainsKey(end))
        {
            return endings.Remove(end);
        }
        return false;
    }

    public HashSet<Aspect> GetEdges(Aspect aspect)
    {
        return EdgesList[aspect];
    }

    public bool TryGetEdges(Aspect aspect, out HashSet<Aspect> var)
    {
        return EdgesList.TryGetValue(aspect, out var);
    }
}
