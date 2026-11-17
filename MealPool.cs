public class MealPool {
    private readonly List<Meal> remaining;

    public MealPool(string path) {
        remaining = MealParser.Load(path);
    }

    public Meal? GetRandom() {
        if (remaining.Count == 0) {
            return null;
        }

        int index = Random.Shared.Next(remaining.Count);
        Meal meal = remaining[index];
        remaining.RemoveAt(index);
        return meal;
    }

    public List<Meal> GetRandom(int count) {
        List<Meal> meals = [];

        while (meals.Count < count) {
            Meal? meal = GetRandom();

            if (meal is null) {
                break;
            }
            
            meals.Add(meal);
        }

        return meals;
    }
}