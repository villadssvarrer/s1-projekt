public class Human {
    // Attributes
    private uint Age; // years
    private uint Height; // cm
    private uint Weight; // kg
    private bool IsMale; 
    public readonly Inventory inventory = new Inventory();

    // Constructor
    public Human(uint age, uint height, uint weight, bool male) {
        Age = age;
        Height = height;
        Weight = weight;
        IsMale = male;
    }
    
    // Methods
    public uint GetCalorieNeed() {
        double bmr; // Basal metabolic rate

        if (IsMale) {
            bmr = (10.0 * Weight) + (6.25 * Height) - (5.0 * Age) + 5.0;
        }
        else {
            bmr = (10.0 * Weight) + (6.25 * Height) - (5.0 * Age) - 161.0;
        }

        // Adjust for daily activity (easy to moderate)
        bmr *= 1.5;

        return (uint)bmr;
    }

    public double GetBmi() {
        double heightMeters = Height / 100.0;
        return Weight / Math.Pow(heightMeters, 2);
    }

    public static bool IsOverweight(double Bmi) {
        return Bmi >= 25.0;
    }

    public static string InterpretBmi(double bmi) {
        if (IsOverweight(bmi)) {
            return "Overvægtig";
        }

        return "Normalvægt";
    }

    public void PrintMeals() {
        foreach (Meal meal in inventory.GetMeals()) {
            int calories = meal.TotalCalories();
            string name = meal.GetName();
            Console.WriteLine($"{name}: {calories} kcal");
        }
    }

    public bool PrintCards() {
        List<InfoCard> cards = inventory.GetCards();

        if (cards.Count == 0) {
            return false;
        }

        foreach (InfoCard card in cards){
            string title = card.GetTitle();
            string text = card.GetInformation();
            Console.WriteLine($"{title}: {text}");
        }

        return true;
    }

    public void PrintProfile() {
        Console.WriteLine("Dine oplysninger er:");
        Console.WriteLine();

        Console.WriteLine("Din vægt er: " + Weight + " kg");
        Console.WriteLine("Din højde er: " + Height + " cm");
        
        Console.WriteLine("Du er en " + (IsMale ? "mand" : "kvinde"));
        Console.WriteLine("Dit bmi: " + GetBmi().ToString("F1"));
        Console.WriteLine("Du er " + InterpretBmi(GetBmi()));
        Console.WriteLine("Du skal spise " + GetCalorieNeed() + " kcal om dagen");
    }
}