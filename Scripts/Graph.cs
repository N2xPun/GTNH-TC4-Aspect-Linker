using System.Collections.Generic;
using GTNHTC;

public class AspectGraph
{
    public Dictionary<Aspectus, HashSet<Aspectus>> EdgesList = [];

    public bool AddAspect(Aspectus aspect)
    {
        return EdgesList.TryAdd(aspect, []);
    }

    public bool AddEdge(Aspectus start, Aspectus end)
    {
        if (EdgesList.TryGetValue(start, out var endings) && EdgesList.ContainsKey(end))
        {
            return endings.Add(end);
        }
        return false;
    }

    public bool RemoveAspect(Aspectus aspect)
    {
        foreach ((_, var endings) in EdgesList)
        {
            endings.Remove(aspect);
        }
        return EdgesList.Remove(aspect);
    }

    public bool RemoveEdge(Aspectus start, Aspectus end)
    {
        if (EdgesList.TryGetValue(start, out var endings) && EdgesList.ContainsKey(end))
        {
            return endings.Remove(end);
        }
        return false;
    }

    public HashSet<Aspectus> GetEdges(Aspectus aspect)
    {
        return EdgesList[aspect];
    }

    public bool TryGetEdges(Aspectus aspect, out HashSet<Aspectus> var)
    {
        return EdgesList.TryGetValue(aspect, out var);
    }
}
