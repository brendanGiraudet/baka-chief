namespace bakaChiefApplication.Store.Recips.Actions
{
    public class DeleteRecipResultAction
    {
        public string RecipId { get; }

        public DeleteRecipResultAction(string recipId)
        {
            RecipId = recipId;
        }
    }
}
