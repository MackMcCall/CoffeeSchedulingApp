namespace CoffeeSchedulingApp.Models.CoffeeModelsRepos
{
    public class Coffee
    {
        public int CoffeeID { get; set; }
        public string Roaster { get; set; }
        public string Producer { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Variety { get; set; }
        public string Process { get; set; }
        public DateTime RoastDate { get; set; }
        public int DaysRestNeeded { get; set; }
        public bool ReadyToDrink { get; set; }
        public double Grams { get; set; }
    }
}
