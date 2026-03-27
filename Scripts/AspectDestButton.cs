using Godot;
using GTNHTC;

public partial class AspectDestButton(Aspectus aspect) : Button
{
    public readonly Aspectus Aspect = aspect;

    public delegate void OnPressedEventHandler(Aspectus aspect);
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
