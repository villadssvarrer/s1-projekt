/* World class for modeling the entire in-game world
 */

class World {
  
  Space entry;
  
  public World () {
    
    // Creates the spaces in the world.
    Space entry = new Space("Entry");
    Space corridor = new Space("Corridor");
      
    //Breakfast room, and its two connected rooms
    Space breakfast = new Space("Room1");
    Space broom1 = new Space("Room1-1");
    Space broom2 = new Space("Room1-2");
  
    //Lunch room, and its two connected rooms
    Space lunch = new Space("Room2");
    Space lroom1 = new Space("Room2-1");
    Space lroom2 = new Space("Room2-2");
    
    //Dinner room, and its two connected rooms
    Space dinner = new Space("Room3");
    Space droom1 = new Space("Room3-1");
    Space droom2 = new Space("Room3-2");
    
    //Outside
    Space outside = new Space("Outside");
    

  // Connects spaces together with edges

    entry.AddEdge("door", corridor); //connects entry to corridor
    
    corridor.AddEdge("door", breakfast); //connects corridor to breakfast room

    breakfast.AddEdge("north", broom1); //connects breakfast room to broom1
    
    breakfast.AddEdge("south", broom2); //connects breakfast room to broom2
    
    broom1 .AddEdge("door", lunch); // connects broom1 to lunch room
    
    broom2 .AddEdge("door", lunch); // connects broom2 to lunch room
    
    lunch.AddEdge("north", lroom1); // connects lunch room to lroom1
    
    lunch.AddEdge("south", lroom2); // connects lunch room to lroom2
    
    lroom1 .AddEdge("door", dinner); // connects lroom1 to dinner room
    
    lroom2 .AddEdge("door", dinner); // connects lroom2 to dinner room
    
    dinner.AddEdge("north", droom1); // connects dinner room to droom1
    
    dinner.AddEdge("south", droom2); // connects dinner room to droom2
    
    droom1 .AddEdge("door", outside); // connects droom1 to outside
    
    droom2 .AddEdge("door", outside); // connects droom2 to outside
    
    outside.AddEdge("door", entry); // connects outside to entry
    


    this.entry = entry;
  }
  
  public Space GetEntry () {
    return entry;
  }
}

