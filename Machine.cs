public class Machine {
    static public void PrintResults(Human human) {
        if (human == null) {
            return;
        }

        List<Meal> meals = human.GetInventoryMeals();
        uint calorieNeed = human.GetCalorieNeed();

        int TotalCalories = 0;
        int TotalPoints = 0;
        int maxPossiblePoints = meals.Count * Meal.MaxPoints;

        foreach (Meal meal in meals) {
            int calories = meal.TotalCalories();
            int points = meal.CalculatePoints();

            TotalCalories += calories;
            TotalPoints += points;

            Console.WriteLine(string.Format("{0}: {1} kcal | {2}/{3} points", meal.GetName(), calories, points, Meal.MaxPoints));
        }

        int difference = (int)calorieNeed - TotalCalories;

        if (difference > 0) {
            Console.WriteLine("You are " + difference + " kcal under maintenance.");
        }
        else if (difference < 0) {
            Console.WriteLine("You are " + difference + " kcal over maintenance.");
        }
        else {
            Console.WriteLine("You are on target with your kcal intake.");
        }

        Console.WriteLine(string.Format("Total points: {0}/{1}", TotalPoints, maxPossiblePoints));
    }
}