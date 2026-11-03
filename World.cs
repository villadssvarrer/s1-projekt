/* World class for modeling the entire in-game world
 */

class World {
  
  Space entry;
  
  public World () {
    
    // Creates the spaces in the world.

    Space entry    = new Space("Entry");

    Space corridor = new Space("Corridor");
      
    //Breakfast room, and its two connected rooms

    Space breakfast     = new Space("Room1");
  
    Space broom1      = new Space("Room1-1");
  
    Space broom2      = new Space("Room1-2");
  
    //Lunch room, and its two connected rooms

    Space lunch     = new Space("Room2");
    
    Space lroom1      = new Space("Room2-1");
    
    Space lroom2      = new Space("Room2-2");
    
    //Dinner room, and its two connected rooms

    Space dinner    = new Space("Room3");
    
    Space droom1      = new Space("Room3-1");
    
    Space droom2      = new Space("Room3-2");
    
    //Outside

    Space outside  = new Space("Outside");
    

  // Connects spaces together with edges

    entry.AddEdge("door", corridor);
    
    corridor.AddEdge("door", breakfast);
    
    breakfast.AddEdge("north", broom1);
    
    breakfast.AddEdge("south", broom2);
    
    broom1 .AddEdge("door", lunch);
    
    broom2 .AddEdge("door", lunch);
    
    lunch.AddEdge("north", lroom1);
    
    lunch.AddEdge("south", lroom2);
    
    lroom1 .AddEdge("door", dinner);
    
    lroom2 .AddEdge("door", dinner);
    
    dinner.AddEdge("north", droom1);
    
    dinner.AddEdge("south", droom2);
    
    droom1 .AddEdge("door", outside);
    
    droom2 .AddEdge("door", outside);
    
    outside.AddEdge("door", entry);
    


    this.entry = entry;
  }
  
  public Space GetEntry () {
    return entry;
  }
}

