namespace HostsGenerator.Application.Entities
{
    public class HostItem
    {
        public string Url { get; init; }
        public string? Name { get; init; }
        public bool IsEnabled { get; init; } = true;

        public HostItem(string url)
        {
            Url = url;
        }

    }
}
