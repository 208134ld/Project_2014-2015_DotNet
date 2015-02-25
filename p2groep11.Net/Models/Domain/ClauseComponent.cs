namespace p2groep11.Net.Models.Domain
{
    public abstract class ClauseComponent
    {
        public abstract void Add(ClauseComponent clauseComponent);
        public abstract void Remove(ClauseComponent clauseComponent);
        public abstract ClauseComponent GetChild(int i);
        public abstract string Name { get; set; }

    }
}
