using System;
using AL.Aplicacion.Entidades;
using AL.Aplicacion.Interfaces;
using AL.Aplicacion.Excepciones; 
namespace AL.Aplicacion.CasosDeUso;

public class UsuarioAlta(IUsuarioRepositorio _repositorio,IUsuarioValidador _validador): UsuarioCasoDeUso(_repositorio)
{

    public void Ejecutar(Usuario usuario)
    {
        String mensajeError;
        if(_validador.Validar(usuario,out mensajeError)){  
            int id = Repositorio.Agregar(usuario);

           
            if (id==1)
            {
                //El administrador tendría id 1
            }
            else
            {
 
            }
        }
        else{
            throw new ValidacionException(mensajeError);
        }
    }
}
