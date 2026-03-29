using Godot;
using GTNHTC;

public partial class AspectDestButton(Aspect aspect) : Button
{
    public readonly Aspect Aspect = aspect;

    public delegate void OnPressedEventHandler(Aspect aspect);
    public event OnPressedEventHandler OnPressed;

    public override void _Ready()
    {
        ButtonDown += ButtonDownProcessor;
    }

    private void ButtonDownProcessor()
    {
        OnPressed.Invoke(Aspect);
    }
}
