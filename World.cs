class World {
    private Space entry;

    public World() {
        Space start = new Space("Starten af verden", "start");
        Space registration = new Space("Registrering", "registrer", SpaceType.Initialize);

        Space breakfast = new Space("Morgenmad", "morgenmad");
        Space broom1 = new Space(new Meal("Bacon og æg", 280));
        Space broom2 = new Space(new Meal("Pandekager", 230));

        Space lunch = new Space("Frokost", "frokost");
        Space lroom1 = new Space(new Meal("Kyllingesandwich", 250));
        Space lroom2 = new Space(new Meal("Cæsarsalat", 150));

        Space dinner = new Space("Aftensmad", "aftensmad");
        Space droom1 = new Space(new Meal("Lasagne", 180));
        Space droom2 = new Space(new Meal("Margherita pizza", 220));

        Space machine = new Space("Maskine", "maskine", SpaceType.Machine);

        registration.Connect(start);
        breakfast.Connect(registration);

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
        machine.Connect(droom1);
        machine.Connect(droom2);

        entry = start;
    }

    public Space GetEntry() {
        return entry;
    }
}