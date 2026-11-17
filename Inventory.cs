
public class Inventory {
    private readonly List<Meal> meals = [];
    private readonly List<InfoCard> cards = [];

    public void AddMeal(Meal meal) {
        meals.Add(meal);
    }

    public void AddCard(InfoCard card) {
        cards.Add(card);
    }

    public List<Meal> GetMeals() {
        return meals;
    }

    public List<InfoCard> GetCards() {
        return cards;
    }
}