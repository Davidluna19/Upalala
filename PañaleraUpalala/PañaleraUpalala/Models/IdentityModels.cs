using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PañaleraUpalala.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("UpalalaConnection_Db", throwIfV1Schema: false)
        {
        }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Talle> Talles { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<LineasCompra> LineasCompras { get; set; }
        public DbSet<LineasVenta> LineasVentas { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<PañaleraUpalala.Models.ProductoCreateView> ProductoCreateViews { get; set; }


        //public System.Data.Entity.DbSet<PañaleraUpalala.Models.ProductoCreateView> ProductoCreateViews { get; set; }

        //public System.Data.Entity.DbSet<PañaleraUpalala.Models.CompraCreateView> CompraCreateViews { get; set; }
    }
}