namespace Superheroes.Domain.Entities
{
    public class Superhero
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public int PowerLevel { get; set; } 
        public string ImagePath { get; set; } = string.Empty; 

        public ICollection<Ability> Abilities { get; set; } = []; 
    }
}
