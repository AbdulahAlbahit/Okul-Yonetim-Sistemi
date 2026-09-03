namespace Application.DetailDto
{
    public class TokenResponseDto
    {
        public string Token { get; set; }
        public string Role { get; set; }
        public string GirisNo { get; set; }
        public bool IsFirstLogin { get; set; }
        public int? OgrenciId { get; set; }
        public int? PersonelId { get; set; }
    }
}
