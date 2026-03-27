using Godot;
using System.Collections.Generic;
using GTNHTC;
using SuperLibrary;

public partial class DestinationManager : HFlowContainer
{
	private const string AspectControlPath = "res://Prefabs/Aspect.tscn";

	[Export] private MenuButton _aspectAdder;
	public HashSet<Aspectus> Destinations { get; } = [];
	public Dictionary<Aspectus, Control> AspectControls { get; } = [];

	private Dictionary<Aspectus, Texture2D> AspTex2DDict { get; } = [];
	private PackedScene _aspectControlPckS;

	public override void _Ready()
	{
		foreach ((Aspectus asp, string path) in AspectLibrary.AspTexPathDict)
		{
			AspTex2DDict.Add(asp, GD.Load<Texture2D>(path));
		}

		_aspectControlPckS = GD.Load<PackedScene>(AspectControlPath);

		_aspectAdder = GetNode<MenuButton>("Adder");
		_aspectAdder.GetPopup().IdPressed += AddAspect;
	}

	public delegate void AspectChangedEventHandler();
	public event AspectChangedEventHandler OnAspectChanged;

	private void AddAspect(long id)
	{
		if (id is >= 0)
		{
			Aspectus asp = (Aspectus)id;
			if (Destinations.Add(asp))
			{
				AspectDestButton button = new(asp){CustomMinimumSize = new(64, 64)};

				AspectControl aspc = _aspectControlPckS.Instantiate<AspectControl>();
				aspc.Aspect = asp;
				aspc.IconTex = AspTex2DDict[asp];

				button.OnPressed += RemoveAspect;
				button.AddChild(aspc);
				AddChild(button);
				MoveChild(button, GetChildCount() - 2);

				AspectControls.Add(asp, button);
				OnAspectChanged?.Invoke();
			}
		}
	}

	private void RemoveAspect(Aspectus aspect)
	{
		if (Destinations.Remove(aspect))
		{
			Control aspcon = AspectControls[aspect];
			AspectControls.Remove(aspect);
			aspcon.QueueFree();
			OnAspectChanged?.Invoke();
		}
	}
}
