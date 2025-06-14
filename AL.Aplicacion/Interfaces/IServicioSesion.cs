using System;
using AL.Aplicacion.Enumerativos;

namespace AL.Aplicacion.Interfaces;

public interface IServicioSesion
{
    public int Id { get; set; }
    public RolUsuario Rol { get; set; }
    public event Action? OnChange;
    public Task<bool> Loggin(string email, string contraseña);
    public Task Logout();
    public Task LogoutAsync();
    public Task InicializarUsuarioAsync();
    public Task<T> GetValue<T>(string key);

}
