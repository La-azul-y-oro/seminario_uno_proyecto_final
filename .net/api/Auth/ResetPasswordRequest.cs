namespace api.Auth
{
    public class ResetPasswordRequest
    {
        public required string Token { get; set; }
        public required string NewPassword { get; set; }
    }
}