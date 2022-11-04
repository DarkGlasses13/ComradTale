namespace Database
{
    public struct Stat
    {
        public string Title { get; private set; }
        public int Value { get; private set; }

        [Newtonsoft.Json.JsonConstructor]
        public Stat(string title, int value)
        {
            Title = title;
            Value = value;
        }
    }
}
