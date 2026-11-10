public class Human {
    // Attributes
    private uint Age; // years
    private uint Height; // cm
    private uint Weight; // kg
    private bool IsMale; 
    private readonly List<Meal> Meals = [];

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
}