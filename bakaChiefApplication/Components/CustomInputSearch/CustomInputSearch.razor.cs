using System.Timers;
using Microsoft.AspNetCore.Components;

namespace bakaChiefApplication.Components.CustomInputSearch;

public partial class CustomInputSearch : CustomInputText.CustomInputText
{
    [Parameter] public EventCallback<string> OnInputCallback { get; set; }

    [Inject] public IConfiguration Configuration { get; set; }

    private System.Timers.Timer _timer;
    private string searchTerm;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        var searchDelay = Convert.ToDouble(Configuration["SearchDelay"]);
        var searchDelayTimeSpan = TimeSpan.FromSeconds(searchDelay);
        _timer = new System.Timers.Timer(searchDelayTimeSpan.TotalMilliseconds);
        _timer.Elapsed += InvokeOnInputCallback;
    }

    private void InvokeOnInputCallback(object sender, ElapsedEventArgs elapsedEventArgs)
    {
        _timer.Stop();
        if (OnInputCallback.HasDelegate) OnInputCallback.InvokeAsync(searchTerm);
    }

    private async void OnInput(ChangeEventArgs changeEventArgs)
    {
        searchTerm = changeEventArgs.Value.ToString();
        _timer.Stop();
        _timer.Start();
    }
}