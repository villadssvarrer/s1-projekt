class World {
    private const int min_choices = 2;
    private const int max_choices = 5;

    private readonly Space entry;

    private World(Space entry) {
        this.entry = entry;
    }

    public static World? create() {
        Space start = new Space("Starten af verden", "start");
        Space registration = new Space("Registrering", "registrer", SpaceType.Initialize);
        Space breakfast = new Space("Morgenmad", "morgenmad");
        Space lunch = new Space("Frokost", "frokost");
        Space dinner = new Space("Aftensmad", "aftensmad");
        Space machine = new Space("Maskine", "maskine", SpaceType.Machine);

        registration.Connect(start);
        breakfast.Connect(registration);

        if (!add_meal_rooms("meals/breakfast.json", breakfast, lunch)) {
            return null;
        }
        
        if (!add_meal_rooms("meals/lunch.json", lunch, dinner)) {
            return null;
        }

        if (!add_meal_rooms("meals/dinner.json", dinner, machine)) {
            return null;
        }

        return new World(start);
    }

    private static bool add_meal_rooms(string path, Space from, Space to) {
        int count = Random.Shared.Next(min_choices, max_choices + 1);
        List<Meal> meals = new MealPool(path).GetRandom(count);

        if (meals.Count < min_choices) {
            return false;
        }

        foreach (Meal meal in meals) {
            Space room = new Space(meal);
            room.Connect(from);
            to.Connect(room);
        }
        
        return true;
    }

    public Space GetEntry() {
        return entry;
    }
}