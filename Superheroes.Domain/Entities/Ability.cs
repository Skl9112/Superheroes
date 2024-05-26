namespace Superheroes.Domain.Entities
{
    public class Ability
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public int PowerLevel { get; set; } 
        public int SuperheroId { get; set; }
        public Superhero Superhero { get; set; } = null!;
    }
}
