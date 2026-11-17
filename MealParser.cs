using System.Text.Json;

public static class MealParser {
    private record MealData(string name, int calories_per_100g);

    public static List<Meal> Load(string path) {
        List<Meal> meals = [];

        try {
            string text = File.ReadAllText(path);
            List<MealData>? items = JsonSerializer.Deserialize<List<MealData>>(text);

            if (items is null) {
                return meals;
            }

            foreach (MealData item in items) {
                Meal meal = new Meal(item.name, item.calories_per_100g);
                meals.Add(meal);
            }
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
            meals.Clear();
        }

        return meals;
    }
}