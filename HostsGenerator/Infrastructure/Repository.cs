using HostsGenerator.Application.Entities;

namespace HostsGenerator.Infrastructure
{
    public static class Repository
    {
        public static IList<HostItem> HostItems =
            new List<HostItem>() {
                new HostItem("url1.com") { Description = "name 1"},
                new HostItem("url222.com") { Description = "name 222"},
                new HostItem("url3.com") { Description = "name 3"},
                new HostItem("url4444.com"),
                new HostItem("url555.com") { Description = "name 555"}
            };

    }
}
