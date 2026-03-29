using Godot;
using GTNHTC;

public partial class AspectControl : Control
{
    public Aspect Aspect;
    public Texture2D IconTex;
    public TextureRect Icon { get; private set; }

    public override void _Ready()
    {
        Icon = GetNode<TextureRect>("Icon");
        Icon.Texture = IconTex;
    }
}
