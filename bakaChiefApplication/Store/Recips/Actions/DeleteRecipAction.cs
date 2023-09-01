namespace bakaChiefApplication.Store.Recips.Actions
{
    public class DeleteRecipAction
    {
        public string RecipId { get; }

        public DeleteRecipAction(string recipId)
        {
            RecipId = recipId;
        }
    }
}
