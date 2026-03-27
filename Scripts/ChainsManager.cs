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
            {Aspectus.Aqua, [Aspectus.Aqua, Aspectus.Victus, Aspectus.Tempestas]},
            {Aspectus.Ignis, [Aspectus.Potentia, Aspectus.Gelum, Aspectus.Lux]},
            {Aspectus.Terra, [Aspectus.Vitreus, Aspectus.Victus]},
            {Aspectus.Aer, [Aspectus.Motus, Aspectus.Vacuos, Aspectus.Tempestas, Aspectus.Lux]},
            {Aspectus.Permutatio, [Aspectus.Ordo, Aspectus.Perditio]}, // compound-2
            {Aspectus.Potentia, [Aspectus.Ordo, Aspectus.Ignis]},
            {Aspectus.Vitreus, [Aspectus.Ordo, Aspectus.Terra]},
            {Aspectus.Motus, [Aspectus.Ordo, Aspectus.Aer, Aspectus.Vinculum]},
            {Aspectus.Venenum, [Aspectus.Perditio, Aspectus.Aqua]},
            {Aspectus.Gelum, [Aspectus.Perditio, Aspectus.Ignis]},
            {Aspectus.Vacuos, [Aspectus.Perditio, Aspectus.Aer, Aspectus.Tempus]},
            {Aspectus.Victus, [Aspectus.Aqua, Aspectus.Terra, Aspectus.Sano, Aspectus.Mortuus]},
            {Aspectus.Tempestas, [Aspectus.Aqua, Aspectus.Aer]},
            {Aspectus.Lux, [Aspectus.Ignis, Aspectus.Aer]},
            {Aspectus.Tempus, [Aspectus.Ordo, Aspectus.Vacuos]}, // compound-3
            {Aspectus.Sano, [Aspectus.Ordo, Aspectus.Victus]},
            {Aspectus.Vinculum, [Aspectus.Perditio, Aspectus.Motus]},
            {Aspectus.Mortuus, [Aspectus.Perditio, Aspectus.Victus]},
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
        List<List<Aspectus>> chains = [];
        _allChains = [];

        foreach (Aspectus begin in beginnings)
        {
            GD.Print($"Starting as {begin}");
            ChainRecurse([begin], length + 1);
        }

        foreach (List<Aspectus> chain in _allChains)
        {
            if (endings.Contains(chain[^1]))
            {
                chains.Add(chain);
            }
        }
        return chains;
    }

    private List<List<Aspectus>> _allChains = [];
    private void ChainRecurse(List<Aspectus> chain, int remlength)
    {
        if (remlength == 0)
        {
            GD.Print("Ending this chain");
            _allChains.Add(chain);
        }
        else
        {
            foreach(Aspectus end in _aspg.GetEdges(chain[^1]))
            {
                GD.Print($"Continuing as {end}");
                List<Aspectus> augChain = [.. chain];
                augChain.Add(end);
                ChainRecurse(augChain, remlength - 1);
            }
        }
    }
}
