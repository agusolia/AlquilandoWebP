using System;
using AL.Aplicacion.Entidades;
namespace AL.Aplicacion.Interfaces;

public interface IUsuarioRepositorio
{
    public int Agregar(Usuario u);
    public void Eliminar (Usuario u);
    public List<Usuario> ListarTodos();
    public void ModificarTarjeta (Usuario u);
    public Usuario? ObtenerPorId(int id);
    public Usuario? IniciarSesion(string correo);
    public bool BuscarPorCorreoElectronico(string correo);
}
