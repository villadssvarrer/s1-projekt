class Space : Node {
    Meal meal;
    string alias;

    public Space(string name, string alias = null) : base(name) {
        this.alias = alias;
    }

    public Space(Meal meal) : base(meal.GetName()) {
        this.meal = meal;
    }

    public Meal GetMeal() {
        return meal;
    }

    public bool HasMeal() {
        return meal != null;
    }

    public void Connect(Space other) {
        other.AddEdge(alias ?? name.ToLower(), this);
    }

    public void Welcome() {
        Console.WriteLine("You are now at " + name);
    }

    public void ShowExits() {
        Console.WriteLine("Current exits are:");

        foreach (string exit in edges.Keys) {
            Console.WriteLine(" - " + exit);
        }
    }
    
    public override Space FollowEdge(string direction) {
        return (Space)base.FollowEdge(direction);
    }
}