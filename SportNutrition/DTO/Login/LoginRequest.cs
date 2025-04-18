namespace SportNutrition.DTO.Login
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    // DTO para la respuesta de autenticación con información adicional del usuario
    public class LoginResponse
    {
        public string Email { get; set; }
        public int UserTypeId { get; set; } // Tipo de usuario
        public bool IsAuthenticated { get; set; }
    }
}
