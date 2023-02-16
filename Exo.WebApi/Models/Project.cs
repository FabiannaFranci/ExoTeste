namespace Exo.WebApi.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public bool Terminado { get; set; }
        public DateTime DataInicio { get; set; }

        public string? Area { get; set; }
    }
}
