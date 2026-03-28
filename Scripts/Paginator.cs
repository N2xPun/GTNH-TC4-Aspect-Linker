using Godot;
using System;
using System.Linq;

public partial class Paginator : Control
{
    [Export] private ChainsManager ChainsManager { get; set; }
    [Export] private LineEdit PageNumberDisplay { get; set; }
    [Export] private Label TotalPagesDisplay { get; set; }
    [Export] private Button Leftmost { get; set; }
    [Export] private Button Left { get; set; }
    [Export] private Button Right { get; set; }
    [Export] private Button Rightmost { get; set; }

    public int TotalPages = 1;
    public int PageNumber { get; private set; } = 1;

    public override void _Ready()
    {
        ChainsManager.OnUpdateChain += MoveLeftmost;

        Leftmost.ButtonDown += MoveLeftmost;
        Left.ButtonDown += MoveLeft;
        Right.ButtonDown += MoveRight;
        Rightmost.ButtonDown += MoveRightmost;

        PageNumberDisplay.TextSubmitted += DirectOpenPage;
    }

    public delegate void OnChangePageEventHandler();
    public event OnChangePageEventHandler OnChangePage;

    private void MoveLeftmost()
    {
        PageNumber = 1;
        UpdateDisplay();
        OnChangePage.Invoke();
    }

    private void MoveLeft()
    {
        if (PageNumber > 1)
        {
            PageNumber--;
            UpdateDisplay();
            OnChangePage.Invoke();
        }
    }

    private void MoveRight()
    {
        if (PageNumber < TotalPages)
        {
            PageNumber++;
            UpdateDisplay();
            OnChangePage.Invoke();
        }
    }

    private void MoveRightmost()
    {
        PageNumber = TotalPages;
        UpdateDisplay();
        OnChangePage.Invoke();
    }

    private void DirectOpenPage(string newtext)
    {
        if (newtext.All(char.IsNumber))
        {
            int page = newtext.ToInt();
            if (page >= 1 && page <= TotalPages)
            {
                PageNumber = page;
                OnChangePage.Invoke();
            }
        }
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        PageNumberDisplay.Text = $"{PageNumber}";
        TotalPagesDisplay.Text = $"{TotalPages} Pages";
    }
}
