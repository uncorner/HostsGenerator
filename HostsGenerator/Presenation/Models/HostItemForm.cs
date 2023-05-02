using System.ComponentModel.DataAnnotations;

namespace HostsGenerator.Presenation.Models
{
    public class HostItemForm
    {
        [StringLength(50, ErrorMessage = "Слишком много символов")]
        public string? Name { get; set; }

        // TODO [Remote]
        [Required(ErrorMessage = "Введите адрес URL")]
        [Url(ErrorMessage = "Некорректный адрес URL")]
        [StringLength(255, ErrorMessage = "Слишком много символов")]
        public string Url { get; set; } = string.Empty;

        public bool IsEnabled { get; set; } = true;

    }
}
