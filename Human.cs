using System.Security.Cryptography;

public class Human {
    // Attributes
    private uint Age; // years
    private uint Height; // cm
    private uint Weight; // kg
    private bool IsMale; 
    private readonly List<Meal> Meals = [];
    private readonly List<InfoCard> Cards = [];

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

    public void AddInventory(Meal meal) {
        Meals.Add(meal);
    }

    public List<Meal> GetInventoryMeals() {
        return Meals;
    }

    public void AddInventoryInfoCard (InfoCard card) {
        Cards.Add(card);
    }

    public List<InfoCard> GetInventoryInfoCard() {
        return Cards;
    }

    public void ShowFoodProfile() {
        foreach (Meal meal in Meals) {
            int calories = meal.TotalCalories();
            string name = meal.GetName();
            Console.WriteLine($"{name}: {calories} kcal");
        }
    }

    public void InfoCardProfile() {
        foreach (InfoCard card in Cards){
            string title = card.GetTitle();
            string text = card.GetInformation();
            Console.WriteLine($"{title}: {text}");
        }
    }
}