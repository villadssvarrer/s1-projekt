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
        current.Welcome();

        if (current.GetName() == "Examination room" && !IsInitialized()) {
            InitializeHuman();
        }

        current.ShowExits();
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