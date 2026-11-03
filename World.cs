class World {
    private Space entry;

    public World() {
        Space start = new Space("Beginning of the world", "start");
        Space exam_room = new Space("Examination room", "exam");

        Space breakfast = new Space("Breakfast", "breakfast");
        Space broom1 = new Space(new Meal("bacon and eggs", 280));
        Space broom2 = new Space(new Meal("pancakes", 230));

        Space lunch = new Space("Lunch", "lunch");
        Space lroom1 = new Space(new Meal("Chicken Sandwich", 250));
        Space lroom2 = new Space(new Meal("Caesar salad", 150));

        Space dinner = new Space("Dinner", "dinner");
        Space droom1 = new Space(new Meal("Lasagna", 180));
        Space droom2 = new Space(new Meal("Margherita pizza", 220));

        Space outside = new Space("Outside", "outside");

        exam_room.Connect(start);
        breakfast.Connect(exam_room);

        broom1.Connect(breakfast);
        broom2.Connect(breakfast);
        lunch.Connect(broom1);
        lunch.Connect(broom2);

        lroom1.Connect(lunch);
        lroom2.Connect(lunch);
        dinner.Connect(lroom1);
        dinner.Connect(lroom2);

        droom1.Connect(dinner);
        droom2.Connect(dinner);
        outside.Connect(droom1);
        outside.Connect(droom2);
        start.Connect(outside);

        entry = start;
    }

    public Space GetEntry() {
        return entry;
    }
}