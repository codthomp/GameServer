namespace SharedLibrary;

    public class Hero
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public int Level {get; set;}

        public int Health {get; set;}
        public int Attack {get; set;}
        public int Defense {get; set;}

        public User User { get; set; }
    }