class Context {
    Space current;
    Human? human;
    bool running = true;

    public Context(Space entry) {
        current = entry;
    }

    public Space GetCurrent() {
        return current;
    }

    public void Transition(string direction) {
        Space? next = current.FollowEdge(direction);

        if (next == null) {
            Console.WriteLine($"Ukendt retning: '{direction}'.");
            return;
        }

        current = next;

        if (!current.HasMeal()) {
            current.Welcome();
        }

        if (current.GetSpaceType() == SpaceType.Initialize && human == null) {
            InitializeHuman();
        }

        PickupMeal(current);

        if (current.GetSpaceType() == SpaceType.Machine) {
            if (human != null) {
                Machine.PrintResults(human);
            }
            
            Stop();
        }
        else {
            current.ShowExits();
        }
    }

    private void PickupMeal(Space current) {
        if (human == null || !current.HasMeal()) {
            return;
        }

        Meal? meal = current.GetMeal();

        if (meal == null) {
            return;
        }

        string MealName = meal.GetName();

        Console.WriteLine($"Du valgte {MealName}");

        string ErrorString = "Du skal indtaste et positivt heltal, prøv igen.";

        while (true) {
            Console.WriteLine("Hvor mange gram vil du spise?");

            if (!int.TryParse(Console.ReadLine(), out int Grams) || Grams <= 0) {
                Console.WriteLine(ErrorString);
                continue;
            }

            Console.WriteLine("Hvor mange kalorier tror du der er i måltidet?");

            if (!int.TryParse(Console.ReadLine(), out int CalorieGuess) || CalorieGuess <= 0) {
                Console.WriteLine(ErrorString);
                continue;
            }

            meal.AddMealSize(Grams);
            meal.AddCalorieGuess(CalorieGuess);
            human.AddInventory(meal);
            break;
        }

        Console.WriteLine($"Tilføjede {MealName} til inventar");
    }

    private static uint ReadUint(string prompt) {
        while (true) {
            Console.Write(prompt);
            if (uint.TryParse(Console.ReadLine() ?? "", out uint value)) {
                return value;
            }
            Console.WriteLine("Du skal indtaste et positivt heltal, prøv igen.");
        }
    }

    private void InitializeHuman() {
        Console.WriteLine();
        Console.WriteLine("Besvar venligst nogle spørgsmål.");
        Console.WriteLine();
        
        uint Age = ReadUint("Alder: ");
        uint Height = ReadUint("Højde (cm): ");
        uint Weight = ReadUint("Vægt (kg): ");

        Console.Write("Mand? (j/n): ");
        string answer = Console.ReadLine() ?? "";
        bool IsMale = answer.Equals("j", StringComparison.OrdinalIgnoreCase);

        human = new Human(Age, Height, Weight, IsMale);

        double Bmi = human.GetBmi();

        Console.WriteLine($"BMI: {Bmi:F1}");
        Console.WriteLine(Human.InterpretBmi(Bmi));

        if (Human.IsOverweight(Bmi)) {
            Console.WriteLine("Du er overvægtig, vi anbefaler at holde dig under dit daglige kalorieindtag.");
        }
    }

    public void Stop() {
        running = false;
    }

    public bool IsActive() {
        return running;
    }
}