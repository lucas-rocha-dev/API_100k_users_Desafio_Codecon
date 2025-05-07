using Codecon_API_100k_users.Data;

namespace Codecon_API_100k_users.Dto
{
    public class TeamInsightsDto
    {
        public  string Nome { get; set; }
        public  int TotalMembros { get; set; }
        public int TotalLideres { get; set; }
        public int ProjetosConcluidos { get; set; }
        public  double PorcMembrosAtivos { get; set; }

    }
}
