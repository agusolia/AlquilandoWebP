using System;
using AL.Aplicacion.Entidades;
using AL.Aplicacion.Interfaces;
using AL.Aplicacion.Excepciones; 
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
                int idT = _repoTarjeta.Agregar(t);
                usuario.Tarjeta = t;
                usuario.TarjetaId = idT;
                int id = Repositorio.Agregar(usuario);

                if (id == 1)
                {
                    //El administrador tendría id 1
                }
                else
                {

                } 
            }
 
        }
        else
        {
            throw new ValidacionException(mensajeError);
        }
    }
}
