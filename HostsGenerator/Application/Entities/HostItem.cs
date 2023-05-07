namespace HostsGenerator.Application.Entities
{
    public class HostItem
    {
        public string Domain { get; init; }
        public string? Name { get; init; }
        public bool IsEnabled { get; init; } = true;

        public HostItem(string domain)
        {
            Domain = domain;
        }

    }
}
