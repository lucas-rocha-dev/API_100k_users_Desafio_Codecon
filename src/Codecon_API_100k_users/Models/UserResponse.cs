namespace Codecon_API_100k_users.Data
{
    public class UserResponse<T>
    {
        public  T? Dados { get; set; }
        public long tempoMs { get; set; } = 0;
    }
}
