using System.Timers;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.CustomInputSearch;

public partial class CustomInputSearch : CustomInputText.CustomInputText
{
    [Parameter] public EventCallback<string> OnInputCallback { get; set; }

    [Inject] public IConfiguration? Configuration { get; set; }

    private System.Timers.Timer _timer = new System.Timers.Timer();
    private string searchTerm = string.Empty;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        var delay = Configuration?["SearchDelay"] ?? "10";

        var searchDelay = Convert.ToDouble(delay);

        var searchDelayTimeSpan = TimeSpan.FromSeconds(searchDelay);

        _timer.Interval = searchDelayTimeSpan.TotalMilliseconds;

        _timer.Elapsed += InvokeOnInputCallback;
    }

    private void InvokeOnInputCallback(object? sender, ElapsedEventArgs elapsedEventArgs)
    {
        _timer.Stop();
        
        if (OnInputCallback.HasDelegate) OnInputCallback.InvokeAsync(searchTerm);
    }

    private async void OnInput(ChangeEventArgs changeEventArgs)
    {
        searchTerm = changeEventArgs.Value?.ToString() ?? string.Empty;
        
        _timer.Stop();
        
        _timer.Start();

        await Task.CompletedTask;
    }
}