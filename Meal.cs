public class Meal {
    // Attributes
    private string Name;
    private int CaloriesPer100g;
    private int SizeGrams;
    private int CalorieGuess;

    public const int MinPoints = 1;
    public const int MaxPoints = 5;
    public const int PointPenaltyKcal = 50;

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

        int actual = CaloriesPer100g * SizeGrams / 100;
        int difference = Math.Abs(actual - CalorieGuess);
        return Math.Max(MinPoints, MaxPoints - (difference / PointPenaltyKcal));
    }

    public int TotalCalories() {
        if (SizeGrams <= 0) {
            return 0;
        }

        return CaloriesPer100g * SizeGrams / 100;
    }
}