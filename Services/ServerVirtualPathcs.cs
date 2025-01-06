using Microsoft.AspNetCore.Hosting.Server;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace PestFree.Services
{
  public static class ServerVirtualPathcs
  {
    public static string? GetIISVirtualPath(this WebApplication app)
    {
      IServer iServer = app.Services.GetRequiredService<IServer>();
      return iServer.GetIISVirtualPath();
    }

    public static string? GetIISVirtualPath(this IServer server)
    {
      PropertyInfo? pi = server.GetType().GetProperty("VirtualPath");
      return (pi?.GetValue(server) as string)?.ToLower();
    }
  }
}
