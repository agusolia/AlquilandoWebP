using System;
using Microsoft.EntityFrameworkCore;
using AL.Aplicacion.Entidades;
using AL.Aplicacion.Interfaces;
namespace AL.Repositorios;

public class AlojamientoRepositorio:IAlojamientoRepositorio
{
    //Caso de uso alojamiento ALTA
    public void Agregar(Alojamiento e){
        
        using(var db=new EntidadesContext()){  
            db.Add(e);
            db.SaveChanges();
        }
    }

    //Caso de uso alojamiento BAJA
    public void Eliminar(Alojamiento e){
        using(var db=new EntidadesContext()){  
            var expediente = db.Alojamientos.Where(t => t.Id == e.Id).SingleOrDefault();
            if(expediente != null){
                 db.Remove(expediente);
                 db.SaveChanges();
        }
        }
    }

    //Caso de uso Consulta por Id
    public Alojamiento? ObtenerPorId(int id){
        using(var db=new EntidadesContext()){  
            var expediente = db.Alojamientos.Where(t => t.Id == id).SingleOrDefault();
            return expediente;
        }
    }
    public List<Alojamiento> ListarAlojamientosConSusReservas()
    {
        using(var db = new EntidadesContext()){
            return db.Alojamientos.Include(a => a.Reservas).ToList();
        }
    } 

    
    //Caso de uso consulta TODOS
    public List<Alojamiento> ObtenerTodos(){
        using (var db=new EntidadesContext()){
            List<Alojamiento> resultado = db.Alojamientos.ToList();
            return resultado;  
        }
    }


    //Caso de uso alojamiento MODIFICACION
    public void Modificar(Alojamiento e){
        using(var db=new EntidadesContext()){  
            db.Alojamientos.Update(e);
            db.SaveChanges();
        }
    }
}
