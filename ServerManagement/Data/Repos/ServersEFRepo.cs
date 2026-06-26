using Microsoft.EntityFrameworkCore;
using ServerManagement.Models;

namespace ServerManagement.Data.Repos
{
    public class ServersEFRepo : IServersEFRepo
    {
        private readonly IDbContextFactory<ServerManagementContext> contextFactory;

        public ServersEFRepo(IDbContextFactory<ServerManagementContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void AddServer(Server server)
        {
            using var context = contextFactory.CreateDbContext();
            context.Servers.Add(server);
            context.SaveChanges();
        }

        public List<Server> GetServers()
        {
            using var context = contextFactory.CreateDbContext();
            return context.Servers.ToList();
        }

        public List<Server> GetServersByCity(string cityName)
        {
            using var context = contextFactory.CreateDbContext();
            return context.Servers
                .Where(s => s.City != null &&
                    s.City.ToLower().IndexOf(cityName.ToLower()) >= 0)
                .ToList();
        }

        public Server? GetServerById(int id)
        {
            using var context = contextFactory.CreateDbContext();
            return context.Servers.Find(id);
        }

        public void UpdateServer(int serverId, Server server)
        {
            ArgumentNullException.ThrowIfNull(server);
            if (serverId != server.Id) return;

            using var context = contextFactory.CreateDbContext();
            var serverToUpdate = context.Servers.Find(serverId);
            if (serverToUpdate != null)
            {
                serverToUpdate.Name = server.Name;
                serverToUpdate.City = server.City;
                serverToUpdate.IsOnline = server.IsOnline;
                context.SaveChanges();
            }
        }

        public void DeleteServer(int serverId)
        {
            using var context = contextFactory.CreateDbContext();
            var serverToDelete = context.Servers.Find(serverId);
            if (serverToDelete != null)
            {
                context.Servers.Remove(serverToDelete);
                context.SaveChanges();
            }
        }

        public List<Server> SearchServers(string serverFilters)
        {
            using var context = contextFactory.CreateDbContext();
            return context.Servers
                .Where(s => s.Name != null &&
                    s.Name.ToLower().IndexOf(serverFilters.ToLower()) >= 0)
                .ToList();
        }
    }
}
