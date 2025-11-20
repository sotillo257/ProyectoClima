namespace ClassLibrary1.Recursos
{
    public class PokemonPageList
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Result> results { get; set; }
    }
    public class Result
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
