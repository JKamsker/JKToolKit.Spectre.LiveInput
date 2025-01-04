using Spectre.Console;
using Spectre.Console.Rendering;

namespace JKToolKit.Spectre.LiveInput;

/// <summary>
/// Provides access to the current state and layout of LiveInput.
/// </summary>
public class LiveInputContext
{
    public LiveInputState State { get; }
    public Layout Layout { get; }

    public EventHandler<LiveInputState> OnEnter;
    public EventHandler<LiveInputState> OnInputChanged;

    internal LiveInputContext(LiveInputState state, Layout layout)
    {
        State = state;
        Layout = layout;
        
        State.OnEnter += (_, s) => OnEnter?.Invoke(this, s);
        State.OnInputChanged += (_, s) => OnInputChanged?.Invoke(this, s);
    }
    
    internal bool RefreshRequested { get; private set; }
    
    public void Refresh()
    {
        // Table updated...
        RefreshRequested = true;
    }
    
    internal void ResetRefresh()
    {
        RefreshRequested = false;
    }

    public void UpdateTarget(IRenderable renderable)
    {
        Layout["Top"].Update(renderable);
    }
}
