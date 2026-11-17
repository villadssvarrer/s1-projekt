enum SpaceType {
    Default,
    Initialize,
    Machine,
}

class Space : Node {
    readonly Meal? meal;
    readonly string? alias;
    readonly SpaceType type;

    public Space(string name, string? alias = null, SpaceType type = SpaceType.Default) : base(name) {
        this.alias = alias;
        this.type = type;
    }

    public Space(Meal meal) : base(meal.GetName()) {
        this.meal = meal;
    }

    public SpaceType GetSpaceType() {
        return type;
    }

    public Meal? GetMeal() {
        return meal;
    }

    public bool HasMeal() {
        return meal != null;
    }

    public void Connect(Space other) {
        other.AddEdge(alias ?? name.ToLower(), this);
    }

    public void Welcome() {
        Console.WriteLine($"Du er nu ved {name}");
    }

    public void ShowExits() {
        Console.WriteLine();
        Console.WriteLine("Udgange:");

        foreach (string exit in edges.Keys) {
            Console.WriteLine($" - {exit}");
        }
    }

    public override Space? FollowEdge(string direction) {
        return base.FollowEdge(direction) as Space;
    }
}