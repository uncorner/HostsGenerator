using HostsGenerator.Application.Entities;

namespace HostsGenerator.Infrastructure
{
    public static class Repository
    {
        public static IList<HostItem> HostItems =
            new List<HostItem>() {
                new HostItem("https://url1.com") { Name = "name 1"},
                new HostItem("https://url222.com") { Name = "name 222"},
                new HostItem("https://url3.com") { Name = "name 3"},
                new HostItem("https://url4444.com"),
                new HostItem("https://url555.com") { Name = "name 555"}
            };

    }
}
