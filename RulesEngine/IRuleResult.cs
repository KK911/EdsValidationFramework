namespace RulesEngine
{
    public interface IRuleResult
    {
        string Name { get; set; }
        bool Result { get; }
    }
}