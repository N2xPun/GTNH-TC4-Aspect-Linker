using Godot;
using GTNHTC;
using SuperLibrary;
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

    private Dictionary<Aspect, Texture2D> AspTex2DDict { get; } = [];

    private List<List<Aspect>> _chains = [];

    private readonly AspectGraph _aspg = new()
    {
        EdgesList =
        {
            {Aspect.Ordo, [Aspect.Permutatio, Aspect.Potentia, Aspect.Vitreus, Aspect.Motus, Aspect.Tempus, Aspect.Sano, Aspect.Aequalitas, Aspect.Instrumentum]}, // primal-1
            {Aspect.Perditio, [Aspect.Permutatio, Aspect.Venenum, Aspect.Gelum, Aspect.Vacuos, Aspect.Vinculum, Aspect.Mortuus, Aspect.Vitium, Aspect.Strontio]},
            {Aspect.Aqua, [Aspect.Venenum, Aspect.Victus, Aspect.Tempestas, Aspect.Limus]},
            {Aspect.Ignis, [Aspect.Potentia, Aspect.Gelum, Aspect.Lux, Aspect.Infernus, Aspect.Cognitio, Aspect.Telum, Aspect.Ira]},
            {Aspect.Terra, [Aspect.Vitreus, Aspect.Victus, Aspect.Metallum, Aspect.Iter, Aspect.Herba, Aspect.Perfodio, Aspect.Tutamen]},
            {Aspect.Aer, [Aspect.Motus, Aspect.Vacuos, Aspect.Tempestas, Aspect.Lux, Aspect.Volatus, Aspect.Arbor, Aspect.Auram, Aspect.Sensus]},
            {Aspect.Permutatio, [Aspect.Ordo, Aspect.Perditio]}, // compound-2
            {Aspect.Potentia, [Aspect.Ordo, Aspect.Ignis, Aspect.Praecantatio, Aspect.Radio, Aspect.Electrum]},
            {Aspect.Vitreus, [Aspect.Ordo, Aspect.Terra, Aspect.Metallum, Aspect.Caelum]},
            {Aspect.Motus, [Aspect.Ordo, Aspect.Aer, Aspect.Vinculum, Aspect.Iter, Aspect.Volatus, Aspect.Bestia, Aspect.Primordium, Aspect.Exanimis, Aspect.Machina]},
            {Aspect.Venenum, [Aspect.Perditio, Aspect.Aqua]},
            {Aspect.Gelum, [Aspect.Perditio, Aspect.Ignis]},
            {Aspect.Vacuos, [Aspect.Perditio, Aspect.Aer, Aspect.Tempus, Aspect.Praecantatio, Aspect.Primordium, Aspect.Tenebrae, Aspect.Fames, Aspect.Superbia, Aspect.Alienis, Aspect.Gula]},
            {Aspect.Victus, [Aspect.Aqua, Aspect.Terra, Aspect.Sano, Aspect.Mortuus, Aspect.Limus, Aspect.Herba, Aspect.Bestia, Aspect.Fames, Aspect.Spiritus]},
            {Aspect.Tempestas, [Aspect.Aqua, Aspect.Aer]},
            {Aspect.Lux, [Aspect.Ignis, Aspect.Aer, Aspect.Radio, Aspect.Tenebrae, Aspect.Astrum]},
            {Aspect.Tempus, [Aspect.Ordo, Aspect.Vacuos]}, // compound-3
            {Aspect.Sano, [Aspect.Ordo, Aspect.Victus]},
            {Aspect.Vinculum, [Aspect.Perditio, Aspect.Motus, Aspect.Desidia]},
            {Aspect.Mortuus, [Aspect.Perditio, Aspect.Victus, Aspect.Exanimis, Aspect.Spiritus, Aspect.Corpus]},
            {Aspect.Limus, [Aspect.Aqua, Aspect.Victus]},
            {Aspect.Metallum, [Aspect.Terra, Aspect.Vitreus, Aspect.Caelum, Aspect.Magneto]},
            {Aspect.Iter, [Aspect.Terra, Aspect.Motus, Aspect.Magneto, Aspect.Gloria, Aspect.Tabernus]},
            {Aspect.Herba, [Aspect.Terra, Aspect.Victus, Aspect.Arbor, Aspect.Messis]}, // compound-4
            {Aspect.Volatus, [Aspect.Aer, Aspect.Motus, Aspect.Superbia]},
            {Aspect.Arbor, [Aspect.Aer, Aspect.Herba]},
            {Aspect.Praecantatio, [Aspect.Potentia, Aspect.Vacuos, Aspect.Vitium, Aspect.Infernus, Aspect.Auram]},
            {Aspect.Radio, [Aspect.Potentia, Aspect.Lux]},
            {Aspect.Bestia, [Aspect.Motus, Aspect.Victus, Aspect.Corpus, Aspect.Humanus, Aspect.Pannus]},
            {Aspect.Primordium, [Aspect.Motus, Aspect.Vacuos, Aspect.Astrum]},
            {Aspect.Tenebrae, [Aspect.Vacuos, Aspect.Lux, Aspect.Alienis]},
            {Aspect.Fames, [Aspect.Vacuos, Aspect.Victus, Aspect.Gula, Aspect.Invidia, Aspect.Luxuria, Aspect.Lucrum]},
            {Aspect.Vitium, [Aspect.Perditio, Aspect.Praecantatio, Aspect.Vesania]}, // compound-5
            {Aspect.Infernus, [Aspect.Ignis, Aspect.Praecantatio]},
            {Aspect.Auram, [Aspect.Aer, Aspect.Praecantatio]},
            {Aspect.Caelum, [Aspect.Vitreus, Aspect.Metallum]},
            {Aspect.Exanimis, [Aspect.Motus, Aspect.Mortuus]},
            {Aspect.Superbia, [Aspect.Vacuos, Aspect.Volatus]},
            {Aspect.Spiritus, [Aspect.Victus, Aspect.Mortuus, Aspect.Cognitio, Aspect.Sensus, Aspect.Desidia]},
            {Aspect.Cognitio, [Aspect.Ignis, Aspect.Spiritus, Aspect.Aequalitas, Aspect.Strontio, Aspect.Humanus, Aspect.Vesania]}, // compound-6
            {Aspect.Sensus, [Aspect.Aer, Aspect.Spiritus, Aspect.Invidia]},
            {Aspect.Alienis, [Aspect.Vacuos, Aspect.Tenebrae]},
            {Aspect.Gula, [Aspect.Vacuos, Aspect.Fames]},
            {Aspect.Astrum, [Aspect.Lux, Aspect.Primordium]},
            {Aspect.Magneto, [Aspect.Metallum, Aspect.Iter]},
            {Aspect.Aequalitas, [Aspect.Ordo, Aspect.Cognitio]}, // compound-7
            {Aspect.Strontio, [Aspect.Perditio, Aspect.Cognitio]},
            {Aspect.Corpus, [Aspect.Mortuus, Aspect.Bestia, Aspect.Luxuria]},
            {Aspect.Desidia, [Aspect.Vinculum, Aspect.Spiritus]}, // compound-8
            {Aspect.Humanus, [Aspect.Bestia, Aspect.Cognitio, Aspect.Instrumentum, Aspect.Perfodio, Aspect.Messis, Aspect.Gloria, Aspect.Lucrum]}, // compound-10
            {Aspect.Invidia, [Aspect.Fames, Aspect.Sensus]},
            {Aspect.Instrumentum, [Aspect.Ordo, Aspect.Humanus, Aspect.Telum, Aspect.Tutamen, Aspect.Machina, Aspect.Pannus]}, // compound-11
            {Aspect.Perfodio, [Aspect.Terra, Aspect.Humanus]},
            {Aspect.Luxuria, [Aspect.Fames, Aspect.Corpus]},
            {Aspect.Vesania, [Aspect.Vitium, Aspect.Cognitio]},
            {Aspect.Telum, [Aspect.Ignis, Aspect.Instrumentum, Aspect.Ira]}, // compound-12
            {Aspect.Tutamen, [Aspect.Terra, Aspect.Instrumentum, Aspect.Tabernus]},
            {Aspect.Ira, [Aspect.Ignis, Aspect.Telum]}, // compound-13
            {Aspect.Machina, [Aspect.Motus, Aspect.Instrumentum, Aspect.Electrum]},
            {Aspect.Messis, [Aspect.Herba, Aspect.Humanus]},
            {Aspect.Gloria, [Aspect.Iter, Aspect.Humanus]},
            {Aspect.Lucrum, [Aspect.Fames, Aspect.Humanus]}, // compound-14
            {Aspect.Electrum, [Aspect.Potentia, Aspect.Machina]}, // compound-15
            {Aspect.Tabernus, [Aspect.Iter, Aspect.Tutamen]},
            {Aspect.Pannus, [Aspect.Bestia, Aspect.Instrumentum]},
        }  
    };

    public override void _Ready()
    {
        foreach ((Aspect asp, string path) in AspectLibrary.AspTexPathDict)
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

    private static int ChainComplexComparer(List<Aspect> x, List<Aspect> y)
    {
        int sumx = 0, sumy = 0;
        foreach (Aspect aspx in x)
        {
            sumx += AspectLibrary.AspComplexity[aspx];
        }
        foreach (Aspect aspy in y)
        {
            sumy += AspectLibrary.AspComplexity[aspy];
        }
        return sumy - sumx;
    }

    private static int ChainUniquenessComparer(List<Aspect> x, List<Aspect> y)
    {
        Dictionary<Aspect, int> fx = ChainAspectFrequency(x), fy = ChainAspectFrequency(y);
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

    private static Dictionary<Aspect, int> ChainAspectFrequency(List<Aspect> x)
    {
        Dictionary<Aspect, int> freq = [];
        foreach(Aspect aspect in x)
        {
            if (!freq.TryAdd(aspect, 1))
            {
                freq[aspect]++;
            }
        }
        return freq;
    }

    private static int ChainSimpleUniqueComparer(List<Aspect> x, List<Aspect> y)
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

            foreach (Aspect aspect in _chains[i])
            {
                AspectControl aspc = _aspectControlPckS.Instantiate<AspectControl>();
                aspc.Aspect = aspect;
                aspc.IconTex = AspTex2DDict[aspect];
                aspectChain.AddChild(aspc);
            }

            ChainsDisplay.AddChild(aspectChain);
        }
    }

    public void UpdateChains(HashSet<Aspect> beginnings, HashSet<Aspect> endings, int length)
    {
        _chains = CalculateChains(beginnings, endings, length);
    }

    private List<List<Aspect>> CalculateChains(HashSet<Aspect> beginnings, HashSet<Aspect> endings, int length)
    {
        _allChains = [];

        foreach (Aspect begin in beginnings)
        {
            ChainRecurse([begin], length + 1, endings);
        }
        return _allChains;
    }

    private List<List<Aspect>> _allChains = [];
    private void ChainRecurse(List<Aspect> chain, int remlength, HashSet<Aspect> targ)
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
            foreach(Aspect end in _aspg.GetEdges(chain[^1]))
            {
                List<Aspect> augChain = [.. chain];
                augChain.Add(end);
                ChainRecurse(augChain, remlength - 1, targ);
            }
        }
    }
}
