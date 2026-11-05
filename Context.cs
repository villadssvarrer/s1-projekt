using System.Xml;

class Context {
    Space current;
    Human human;
    bool done = false;

    public Context(Space entry) {
        current = entry;
    }

    public Space GetCurrent() {
        return current;
    }

    public Human GetHuman() {
        return human;
    }

    public bool IsInitialized() {
        return human != null;
    }

    public void Transition(string direction) {
        Space next = current.FollowEdge(direction);

        if (next == null) {
            Console.WriteLine("You are confused, and walk in a circle looking for '" + direction + "'.");
            return;
        }

        current = next;

        if (!current.HasMeal()) {
            current.Welcome();
        }

        if (current.GetName() == "Examination room" && !IsInitialized()) {
            InitializeHuman();
        }

        PickupMeal(current);

        if (current.GetName() == "Machine") {
            Machine.PrintResults(human);
            MakeDone();
        }
        else {
            current.ShowExits();
        }
    }

    private void PickupMeal(Space current) {
        if (!IsInitialized() || !current.HasMeal()) {
            return;
        }

        Meal meal = current.GetMeal();
        string MealName = meal.GetName();

        Console.WriteLine("You picked the " + MealName + " meal");

        string ErrorString = "You must choose a positive whole number, try again.";

        while (true) {
            Console.WriteLine("How many grams do you want to eat?");

            if (!int.TryParse(Console.ReadLine(), out int grams) || grams <= 0) {
                Console.WriteLine(ErrorString);
                continue;
            }

            Console.WriteLine("How many calories do you think is in the meal?");

            if (!int.TryParse(Console.ReadLine(), out int CalorieGuess) || CalorieGuess <= 0) {
                Console.WriteLine(ErrorString);
                continue;
            }

            meal.AddMealSize(grams);
            meal.AddCalorieGuess(CalorieGuess);
            human.AddInventory(meal);
            break;
        }

        Console.WriteLine("Added " + MealName + " to inventory");
    }

    private void InitializeHuman() {
        Console.WriteLine("Please answer a few questions.");

        Console.Write("Age: ");
        uint age = uint.Parse(Console.ReadLine());

        Console.Write("Height (cm): ");
        uint height = uint.Parse(Console.ReadLine());

        Console.Write("Weight (kg): ");
        uint weight = uint.Parse(Console.ReadLine());

        Console.Write("Male? (y/n): ");
        bool isMale = Console.ReadLine().ToLower() == "y";

        human = new Human();
        human.Initialize(age, height, weight, isMale);

        double bmi = human.GetBmi();

        Console.WriteLine("BMI: " + bmi.ToString("F1"));
        Console.WriteLine(Human.InterpretBmi(bmi));

        if (Human.IsOverweight(bmi)) {
            Console.WriteLine("You are overweight, we recommend being under your daily calorie intake.");
        }
    }

    public void MakeDone() {
        done = true;
    }

    public bool IsDone() {
        return done;
    }
}