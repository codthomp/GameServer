namespace SharedLibrary
{
    public class Player
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public int Health {get; set;}

        // public Player(Player player) {
        //     Id = player.Id;
        //     Name = player.Name;
        //     Health = player.Health;
        // }
    }

    // public class Player
    // {
    //     public int Id {get{ return Id;} set{Id = value;}}
    //     public string? Name {get{ return Name;} set{Name = value.ToString();}}
    //     public int Health {get{ return Health;} set{Health = value;}}
    // }
}