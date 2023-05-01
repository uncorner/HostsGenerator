using System.ComponentModel.DataAnnotations;

namespace HostsGenerator.Presenation.Models
{
    public class HostItemForm
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string Url { get; set; } = string.Empty;

        public bool IsEnabled { get; set; }

    }
}
