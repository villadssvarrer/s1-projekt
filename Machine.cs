public class Machine {
    // Methods
    public void GetInformation(Human human) {

    }

    public void GetMealInformation(Human human) {
        List<Meal> Meals = human.GetInventoryMeals();

        foreach (Meal meal in Meals) {
            Console.WriteLine(string.Format("[{0}]", meal.GetName()));
        }
    }
}