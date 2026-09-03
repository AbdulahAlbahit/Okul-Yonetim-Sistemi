namespace Application.DetailDto
{
    public class OgrenciSinavDetailDto
    {
        public int Ogrenci_Sinav_Id { get; set; }
        public float Not { get; set; }
        
        public string? OgrenciAdSoyad { get; set; }
        public string? DersAdi { get; set; }
        public string? HocaAdi { get; set; }
        public string? SinavType { get; set; }
    }
}
