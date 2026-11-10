public class Machine {
    public static void PrintResults(Human human) {
        List<Meal> meals = human.GetInventoryMeals();
        uint calorieNeed = human.GetCalorieNeed();

        int TotalCalories = 0;
        int TotalPoints = 0;
        int maxPossiblePoints = meals.Count * Meal.MaxPoints;

        Console.WriteLine();
        Console.WriteLine("[Resultater]");

        foreach (Meal meal in meals) {
            int calories = meal.TotalCalories();
            int points = meal.CalculatePoints();

            TotalCalories += calories;
            TotalPoints += points;

            Console.WriteLine($"{meal.GetName()}: {calories} kcal | {points}/{Meal.MaxPoints} point");
        }

        Console.WriteLine();
        Console.WriteLine($"Samlet indtag: {TotalCalories} kcal");
        Console.WriteLine($"Dagligt behov: {calorieNeed} kcal");

        int difference = (int)calorieNeed - TotalCalories;

        if (difference > 0) {
            Console.WriteLine($"Du er {difference} kcal under dit daglige behov.");
        }
        else if (difference < 0) {
            Console.WriteLine($"Du er {Math.Abs(difference)} kcal over dit daglige behov.");
        }
        else {
            Console.WriteLine("Du er præcis på dit daglige behov.");
        }

        Console.WriteLine();
        Console.WriteLine($"Samlet point: {TotalPoints}/{maxPossiblePoints}");
    }
}