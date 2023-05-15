using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HostsGenerator.Application.Entities
{
    [Index("Domain", IsUnique = true, Name = "Domain_Index")]
    public class HostItem
    {
        public int Id { get; set; }

        // unique
        [MaxLength(50)]
        public string Domain { get; init; }

        [MaxLength(255)]
        public string? Description { get; set; }

        public bool IsEnabled { get; set; } = true;

        public HostItem(string domain)
        {
            Domain = domain;
        }

    }
}
