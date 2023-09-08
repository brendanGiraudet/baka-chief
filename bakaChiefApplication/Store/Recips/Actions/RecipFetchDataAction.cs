namespace bakaChiefApplication.Store.Recips.Actions
{
    public class RecipFetchDataAction
    {
        public string RecipId { get; }

        public RecipFetchDataAction(string recipId)
        {
            RecipId = recipId;
        }
    }
}
