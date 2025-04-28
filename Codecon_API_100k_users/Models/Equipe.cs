namespace Codecon_API_100k_users.Data
{
    public class Equipe
    {
        public string Nome { get; set; }
        public bool Lider { get; set; }
        public List<Projetos> Projetos { get; set; }
    }
}
