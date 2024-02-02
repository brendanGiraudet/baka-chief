namespace bakaChiefApplication.Store.Recips.Actions;

public class RecipSearchByIdResultAction
{
    public Models.Recip Recip { get; }

    public RecipSearchByIdResultAction(Models.Recip recip)
    {
        Recip = recip;
    }
}