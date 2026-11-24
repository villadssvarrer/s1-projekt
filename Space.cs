enum SpaceType {
    Default,
    Initialize,
    Machine,
}

class Space : Node {
    readonly Meal? meal;
    InfoCard? card;

    readonly string? alias;
    readonly SpaceType type;

    public Space(
        string name,
        string? alias = null,
        SpaceType type = SpaceType.Default,
        InfoCard? card = null
    ) : base(name) {
        this.alias = alias;
        this.type = type;
        this.card = card;
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

    public bool HasCard() {
        return card != null;
    }

    public InfoCard? TakeCard() {
        if (card == null) {
            return null;
        }

        InfoCard taken = card;
        card = null;
        return taken;
    }

    public void Connect(Space other) {
        other.AddEdge(alias ?? name.ToLower(), this);
    }

    public void Welcome() {
        Console.WriteLine($"Du er nu ved {name}");

        if (HasCard()) {
            Console.WriteLine("Der et infokort i dette rum, husk samle det op ved brug af 'saml' kommandoen");
        }
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