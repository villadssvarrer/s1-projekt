public class Human {
    // Attributes
    private uint Age; // years
    private uint Height; // cm
    private uint Weight; // kg
    private bool IsMale; 
    private readonly List<Meal> Meals = [];

    // Methods
    public void Initialize(uint Age, uint Height, uint Weight, bool IsMale) {
        this.Age = Age;
        this.Height = Height;
        this.Weight = Weight;
        this.IsMale = IsMale;
    }

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

    public static string InterpretBmi(double Bmi) {
        if (IsOverweight(Bmi)) {
            return "Overweight";
        }

        return "Normal weight";
    }

    public void AddInventory(Meal meal) {
        Meals.Add(meal);
    }

    public List<Meal> GetInventoryMeals() {
        return Meals;
    }
}