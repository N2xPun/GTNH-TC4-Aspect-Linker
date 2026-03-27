using Godot;
using GTNHTC;
using SuperLibrary;
using System.Collections.Generic;

public partial class ChainsManager : Control
{
    private const string AspectChainPath = "res://Prefabs/AspectChain.tscn";
    private const string AspectControlPath = "res://Prefabs/Aspect.tscn";

    [Export] private VBoxContainer ChainsDisplay { get; set; }
    [Export] private DestinationManager Starts { get; set; }
    [Export] private DestinationManager Ends { get; set; }
    [Export] private SpinBox LengthSelector { get; set; }

    private PackedScene _aspectChainPckS;
    private PackedScene _aspectControlPckS;

    private Dictionary<Aspectus, Texture2D> AspTex2DDict { get; } = [];

    private List<List<Aspectus>> _chains = [];

    private readonly AspectGraph _aspg = new()
    {
        EdgesList =
        {
            {Aspectus.Ordo, [Aspectus.Permutatio, Aspectus.Potentia, Aspectus.Vitreus, Aspectus.Motus, Aspectus.Tempus, Aspectus.Sano]}, // primal-1
            {Aspectus.Perditio, [Aspectus.Permutatio, Aspectus.Venenum, Aspectus.Gelum, Aspectus.Vacuos, Aspectus.Vinculum, Aspectus.Mortuus]},
            {Aspectus.Aqua, [Aspectus.Aqua, Aspectus.Victus, Aspectus.Tempestas, Aspectus.Limus]},
            {Aspectus.Ignis, [Aspectus.Potentia, Aspectus.Gelum, Aspectus.Lux]},
            {Aspectus.Terra, [Aspectus.Vitreus, Aspectus.Victus, Aspectus.Metallum, Aspectus.Iter, Aspectus.Herba]},
            {Aspectus.Aer, [Aspectus.Motus, Aspectus.Vacuos, Aspectus.Tempestas, Aspectus.Lux, Aspectus.Volatus, Aspectus.Arbor]},
            {Aspectus.Permutatio, [Aspectus.Ordo, Aspectus.Perditio]}, // compound-2
            {Aspectus.Potentia, [Aspectus.Ordo, Aspectus.Ignis, Aspectus.Praecantatio, Aspectus.Radio]},
            {Aspectus.Vitreus, [Aspectus.Ordo, Aspectus.Terra, Aspectus.Metallum]},
            {Aspectus.Motus, [Aspectus.Ordo, Aspectus.Aer, Aspectus.Vinculum, Aspectus.Iter, Aspectus.Volatus, Aspectus.Bestia]},
            {Aspectus.Venenum, [Aspectus.Perditio, Aspectus.Aqua]},
            {Aspectus.Gelum, [Aspectus.Perditio, Aspectus.Ignis]},
            {Aspectus.Vacuos, [Aspectus.Perditio, Aspectus.Aer, Aspectus.Tempus, Aspectus.Praecantatio]},
            {Aspectus.Victus, [Aspectus.Aqua, Aspectus.Terra, Aspectus.Sano, Aspectus.Mortuus, Aspectus.Limus, Aspectus.Herba, Aspectus.Bestia]},
            {Aspectus.Tempestas, [Aspectus.Aqua, Aspectus.Aer]},
            {Aspectus.Lux, [Aspectus.Ignis, Aspectus.Aer, Aspectus.Radio]},
            {Aspectus.Tempus, [Aspectus.Ordo, Aspectus.Vacuos]}, // compound-3
            {Aspectus.Sano, [Aspectus.Ordo, Aspectus.Victus]},
            {Aspectus.Vinculum, [Aspectus.Perditio, Aspectus.Motus]},
            {Aspectus.Mortuus, [Aspectus.Perditio, Aspectus.Victus]},
            {Aspectus.Limus, [Aspectus.Aqua, Aspectus.Victus]},
            {Aspectus.Metallum, [Aspectus.Terra, Aspectus.Vitreus]},
            {Aspectus.Iter, [Aspectus.Terra, Aspectus.Motus]},
            {Aspectus.Herba, [Aspectus.Terra, Aspectus.Victus, Aspectus.Arbor]},
            {Aspectus.Volatus, [Aspectus.Aer, Aspectus.Motus]},
            {Aspectus.Arbor, [Aspectus.Aer, Aspectus.Herba]},
            {Aspectus.Praecantatio, [Aspectus.Potentia, Aspectus.Vacuos]},
            {Aspectus.Radio, [Aspectus.Potentia, Aspectus.Lux]},
            {Aspectus.Bestia, [Aspectus.Motus, Aspectus.Victus]},
            {Aspectus.Primordium, [Aspectus.Motus, Aspectus.Vacuos]},
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

        Starts.OnAspectChanged += DisplayChains;
        Ends.OnAspectChanged += DisplayChains;
        LengthSelector.ValueChanged += _ => DisplayChains();
    }

    private void DisplayChains()
    {
        UpdateChains(Starts.Destinations, Ends.Destinations, Mathf.RoundToInt(LengthSelector.Value));

        foreach (Node chain in ChainsDisplay.GetChildren())
        {
            chain.QueueFree();
        }

        foreach (List<Aspectus> chain in _chains)
        {
            Control aspectChain = _aspectChainPckS.Instantiate<Control>();

            foreach (Aspectus aspect in chain)
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
