public class Meal {
    // Attributes
    private string Name;
    private int CaloriesPer100g;
    private int SizeGrams;
    private int CalorieGuess;

    public const int MinPoints = 1;
    public const int MaxPoints = 5;
    public const int PointPenaltyPercent = 10;

    // Constructor
    public Meal(string Name, int CaloriesPer100g) {
        this.Name = Name;
        this.CaloriesPer100g = CaloriesPer100g;
    }

    // Methods
    public string GetName() {
        return Name;
    }

    public void AddMealSize(int Grams) {
        if (Grams <= 0) {
            return;
        }

        SizeGrams = Grams;
    }

    public void AddCalorieGuess(int Guess) {
        if (Guess <= 0) {
            return;
        }

        CalorieGuess = Guess;
    }

    public int CalculatePoints() {
        if (SizeGrams <= 0 || CalorieGuess <= 0) {
            return 0;
        }

        int actual = TotalCalories();
        if (actual == 0) {
            return 0;
        }

        int errorPercent = Math.Abs(actual - CalorieGuess) * 100 / actual;
        int penalty = errorPercent / PointPenaltyPercent;
        return Math.Max(MinPoints, MaxPoints - penalty);
    }

    public int TotalCalories() {
        if (SizeGrams <= 0) {
            return 0;
        }

        return CaloriesPer100g * SizeGrams / 100;
    }
}