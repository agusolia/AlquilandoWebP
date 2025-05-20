using System;
using AL.Aplicacion.Entidades;
using AL.Aplicacion.Interfaces;
using AL.Aplicacion.Excepciones; 
using AL.Aplicacion.Enumerativos;
namespace AL.Aplicacion.CasosDeUso;

public class UsuarioAlta(IUsuarioRepositorio _repositorio, ITarjetaRepositorio _repoTarjeta,IUsuarioValidador _validador): UsuarioCasoDeUso(_repositorio)
{

    public void Ejecutar(Usuario usuario, Tarjeta t)
    {
        String mensajeError;
        
        if (_validador.Validar(usuario, out mensajeError))
        {
            if (t == null)
            {
                mensajeError += "Debe completar los datos de la tarjeta.\n";
            }
            else
            {
                usuario.TarjetaId = _repoTarjeta.Agregar(t);
                int id = Repositorio.Agregar(usuario);

                if (id == 1)
                {
                    Repositorio.AsignarRol(usuario.Id, RolUsuario.Administrador);
                }
                else
                {
                    Repositorio.AsignarRol(usuario.Id, RolUsuario.Usuario);
                } 
            }
 
        }
        else
        {
            throw new ValidacionException(mensajeError);
        }
    }
}
