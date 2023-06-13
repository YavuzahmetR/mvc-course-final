using System.ComponentModel.DataAnnotations;

namespace AgricultureUI.Models
{
    public class ServiceViewModel
    {
        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "Başlık Boş Geçilemez!")]
        public string Title { get; set; }

        [Display(Name ="Görsel Yolu")]
        [Required(ErrorMessage ="Görsel Yolu Boş Geçilemez")]
        public string Image { get; set; }

        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "Açıklama Boş Geçilemez")]
        public string Description { get; set; }
    }
}
