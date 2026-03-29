using Godot;
using GTNHTC;
using SuperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class ChainsManager : Control
{
    private const string AspectChainPath = "res://Prefabs/AspectChain.tscn";
    private const string AspectControlPath = "res://Prefabs/Aspect.tscn";

    [Export] private Paginator Paginator { get; set; }
    [Export] private VBoxContainer ChainsDisplay { get; set; }
    [Export] private DestinationManager Starts { get; set; }
    [Export] private DestinationManager Ends { get; set; }
    [Export] private SpinBox LengthSelector { get; set; }
    [Export] private OptionButton SortSelector { get; set; }

    private PackedScene _aspectChainPckS;
    private PackedScene _aspectControlPckS;

    private Dictionary<Aspectus, Texture2D> AspTex2DDict { get; } = [];

    private List<List<Aspectus>> _chains = [];

    private readonly AspectGraph _aspg = new()
    {
        EdgesList =
        {
            {Aspectus.Ordo, [Aspectus.Permutatio, Aspectus.Potentia, Aspectus.Vitreus, Aspectus.Motus, Aspectus.Tempus, Aspectus.Sano]}, // primal-1
            {Aspectus.Perditio, [Aspectus.Permutatio, Aspectus.Venenum, Aspectus.Gelum, Aspectus.Vacuos, Aspectus.Vinculum, Aspectus.Mortuus, Aspectus.Vitium]},
            {Aspectus.Aqua, [Aspectus.Venenum, Aspectus.Victus, Aspectus.Tempestas, Aspectus.Limus]},
            {Aspectus.Ignis, [Aspectus.Potentia, Aspectus.Gelum, Aspectus.Lux, Aspectus.Infernus, Aspectus.Cognitio]},
            {Aspectus.Terra, [Aspectus.Vitreus, Aspectus.Victus, Aspectus.Metallum, Aspectus.Iter, Aspectus.Herba]},
            {Aspectus.Aer, [Aspectus.Motus, Aspectus.Vacuos, Aspectus.Tempestas, Aspectus.Lux, Aspectus.Volatus, Aspectus.Arbor, Aspectus.Auram, Aspectus.Sensus]},
            {Aspectus.Permutatio, [Aspectus.Ordo, Aspectus.Perditio]}, // compound-2
            {Aspectus.Potentia, [Aspectus.Ordo, Aspectus.Ignis, Aspectus.Praecantatio, Aspectus.Radio]},
            {Aspectus.Vitreus, [Aspectus.Ordo, Aspectus.Terra, Aspectus.Metallum, Aspectus.Caelum]},
            {Aspectus.Motus, [Aspectus.Ordo, Aspectus.Aer, Aspectus.Vinculum, Aspectus.Iter, Aspectus.Volatus, Aspectus.Bestia, Aspectus.Primordium, Aspectus.Exanimis]},
            {Aspectus.Venenum, [Aspectus.Perditio, Aspectus.Aqua]},
            {Aspectus.Gelum, [Aspectus.Perditio, Aspectus.Ignis]},
            {Aspectus.Vacuos, [Aspectus.Perditio, Aspectus.Aer, Aspectus.Tempus, Aspectus.Praecantatio, Aspectus.Primordium, Aspectus.Tenebrae, Aspectus.Fames, Aspectus.Superbia, Aspectus.Alienis, Aspectus.Gula]},
            {Aspectus.Victus, [Aspectus.Aqua, Aspectus.Terra, Aspectus.Sano, Aspectus.Mortuus, Aspectus.Limus, Aspectus.Herba, Aspectus.Bestia, Aspectus.Fames, Aspectus.Spiritus]},
            {Aspectus.Tempestas, [Aspectus.Aqua, Aspectus.Aer]},
            {Aspectus.Lux, [Aspectus.Ignis, Aspectus.Aer, Aspectus.Radio, Aspectus.Tenebrae, Aspectus.Astrum]},
            {Aspectus.Tempus, [Aspectus.Ordo, Aspectus.Vacuos]}, // compound-3
            {Aspectus.Sano, [Aspectus.Ordo, Aspectus.Victus]},
            {Aspectus.Vinculum, [Aspectus.Perditio, Aspectus.Motus]},
            {Aspectus.Mortuus, [Aspectus.Perditio, Aspectus.Victus, Aspectus.Exanimis, Aspectus.Spiritus]},
            {Aspectus.Limus, [Aspectus.Aqua, Aspectus.Victus]},
            {Aspectus.Metallum, [Aspectus.Terra, Aspectus.Vitreus, Aspectus.Caelum, Aspectus.Magneto]},
            {Aspectus.Iter, [Aspectus.Terra, Aspectus.Motus, Aspectus.Magneto]},
            {Aspectus.Herba, [Aspectus.Terra, Aspectus.Victus, Aspectus.Arbor]}, // compound-4
            {Aspectus.Volatus, [Aspectus.Aer, Aspectus.Motus, Aspectus.Superbia]},
            {Aspectus.Arbor, [Aspectus.Aer, Aspectus.Herba]},
            {Aspectus.Praecantatio, [Aspectus.Potentia, Aspectus.Vacuos, Aspectus.Vitium, Aspectus.Infernus, Aspectus.Auram]},
            {Aspectus.Radio, [Aspectus.Potentia, Aspectus.Lux]},
            {Aspectus.Bestia, [Aspectus.Motus, Aspectus.Victus]},
            {Aspectus.Primordium, [Aspectus.Motus, Aspectus.Vacuos, Aspectus.Astrum]},
            {Aspectus.Tenebrae, [Aspectus.Vacuos, Aspectus.Lux, Aspectus.Alienis]},
            {Aspectus.Fames, [Aspectus.Vacuos, Aspectus.Victus, Aspectus.Gula]},
            {Aspectus.Vitium, [Aspectus.Perditio, Aspectus.Praecantatio]}, // compound-5
            {Aspectus.Infernus, [Aspectus.Ignis, Aspectus.Praecantatio]},
            {Aspectus.Auram, [Aspectus.Aer, Aspectus.Praecantatio]},
            {Aspectus.Caelum, [Aspectus.Vitreus, Aspectus.Metallum]},
            {Aspectus.Exanimis, [Aspectus.Motus, Aspectus.Mortuus]},
            {Aspectus.Superbia, [Aspectus.Vacuos, Aspectus.Volatus]},
            {Aspectus.Spiritus, [Aspectus.Victus, Aspectus.Mortuus, Aspectus.Cognitio, Aspectus.Sensus]},
            {Aspectus.Cognitio, [Aspectus.Ignis, Aspectus.Spiritus]}, // compound-6
            {Aspectus.Sensus, [Aspectus.Aer, Aspectus.Spiritus]},
            {Aspectus.Alienis, [Aspectus.Vacuos, Aspectus.Tenebrae]},
            {Aspectus.Gula, [Aspectus.Vacuos, Aspectus.Fames]},
            {Aspectus.Astrum, [Aspectus.Lux, Aspectus.Primordium]},
            {Aspectus.Magneto, [Aspectus.Metallum, Aspectus.Iter]},
        }  
    };

    public override void _Ready()
    {
        foreach ((Aspectus asp, string path) in AspectLibrary.AspTexPathDict)
        {
            AspTex2DDict.Add(asp, GD.Load<Texture2D>(path));
        }

        _aspectChainPckS = GD.Load<PackedScene>(AspectChainPath);
        _aspectControlPckS = GD.Load<PackedScene>(AspectControlPath);

        Starts.OnAspectChanged += UpdateChainsHelper;
        Ends.OnAspectChanged += UpdateChainsHelper;
        LengthSelector.ValueChanged += _ => UpdateChainsHelper();

        Paginator.OnChangePage += DisplayChains;
        SortSelector.ItemSelected += SortChains;
    }

    private static int ChainComplexComparer(List<Aspectus> x, List<Aspectus> y)
    {
        int sumx = 0, sumy = 0;
        foreach (Aspectus aspx in x)
        {
            sumx += AspectLibrary.AspComplexity[aspx];
        }
        foreach (Aspectus aspy in y)
        {
            sumy += AspectLibrary.AspComplexity[aspy];
        }
        return sumy - sumx;
    }

    private static int ChainUniquenessComparer(List<Aspectus> x, List<Aspectus> y)
    {
        Dictionary<Aspectus, int> fx = ChainAspectFrequency(x), fy = ChainAspectFrequency(y);
        if (fx.Count == fy.Count)
        {
            int ux = fx.Count * fx.Values.Max() - fx.Values.Sum();
            int uy = fy.Count * fy.Values.Max() - fy.Values.Sum();
            return ux - uy;
        }
        else
        {
            return fy.Count - fx.Count;
        }
    }

    private static Dictionary<Aspectus, int> ChainAspectFrequency(List<Aspectus> x)
    {
        Dictionary<Aspectus, int> freq = [];
        foreach(Aspectus aspect in x)
        {
            if (!freq.TryAdd(aspect, 1))
            {
                freq[aspect]++;
            }
        }
        return freq;
    }

    private static int ChainSimpleUniqueComparer(List<Aspectus> x, List<Aspectus> y)
    {
        int ucomp = ChainUniquenessComparer(x, y);
        if (ucomp == 0)
        {
            return ChainComplexComparer(y, x);
        }
        else
        {
            return ucomp;
        }
    }

    private void SortChains(long id)
    {
        switch (id)
        {
            case 0:
                _chains.Sort(ChainUniquenessComparer);
                DisplayChains();
                break;
            case 1:
                _chains.Sort(ChainComplexComparer);
                DisplayChains();
                break;
            case 2:
                _chains.Sort(ChainSimpleUniqueComparer);
                DisplayChains();
                break;
            default:
                return;
        }
    }

    private void UpdateChainsHelper()
    {
        UpdateChains(Starts.Destinations, Ends.Destinations, Mathf.RoundToInt(LengthSelector.Value));
        SortChains(SortSelector.Selected);
        Paginator.TotalPages = _chains.Count / 9 + 1;
        OnUpdateChain.Invoke();
    }
    public delegate void OnUpdateChainEventHandler();
    public event OnUpdateChainEventHandler OnUpdateChain;

    private void DisplayChains()
    {
        foreach (Node chain in ChainsDisplay.GetChildren())
        {
            chain.QueueFree();
        }

        int endingIndex = 9 * Paginator.PageNumber;
        for (int i = endingIndex - 9; i < endingIndex && i < _chains.Count; i++)
        {
            Control aspectChain = _aspectChainPckS.Instantiate<Control>();

            foreach (Aspectus aspect in _chains[i])
            {
                AspectControl aspc = _aspectControlPckS.Instantiate<AspectControl>();
                aspc.Aspect = aspect;
                aspc.IconTex = AspTex2DDict[aspect];
                aspectChain.AddChild(aspc);
            }

            ChainsDisplay.AddChild(aspectChain);
        }
    }

    public void UpdateChains(HashSet<Aspectus> beginnings, HashSet<Aspectus> endings, int length)
    {
        _chains = CalculateChains(beginnings, endings, length);
    }

    private List<List<Aspectus>> CalculateChains(HashSet<Aspectus> beginnings, HashSet<Aspectus> endings, int length)
    {
        _allChains = [];

        foreach (Aspectus begin in beginnings)
        {
            ChainRecurse([begin], length + 1, endings);
        }
        return _allChains;
    }

    private List<List<Aspectus>> _allChains = [];
    private void ChainRecurse(List<Aspectus> chain, int remlength, HashSet<Aspectus> targ)
    {
        if (remlength == 0)
        {
            if (targ.Contains(chain[^1]))
            {
                _allChains.Add(chain);    
            }
        }
        else
        {
            foreach(Aspectus end in _aspg.GetEdges(chain[^1]))
            {
                List<Aspectus> augChain = [.. chain];
                augChain.Add(end);
                ChainRecurse(augChain, remlength - 1, targ);
            }
        }
    }
}
