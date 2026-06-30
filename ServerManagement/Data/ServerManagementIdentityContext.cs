using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ServerManagementIdentityContext(DbContextOptions<ServerManagementIdentityContext> options) : IdentityDbContext<ServerManagement.Data.ApplicationUser>(options)
{
}
