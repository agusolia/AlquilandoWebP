using System;
using AL.Aplicacion.Entidades;
using AL.Aplicacion.Interfaces;

namespace AL.Aplicacion.Servicios
{
    public class ServicioPago : IServicioPago
    {
        public bool ValidarPago(Tarjeta tarjeta)
        {
            if (tarjeta == null || string.IsNullOrWhiteSpace(tarjeta.Numero))
            {
                return false;
            }
            
            //Verifica fecha de vencimiento

            if (!DateTime.TryParse(tarjeta.FechaVencimiento, out DateTime fechaVencimiento))
            {
                return false;
            }
            if (fechaVencimiento < DateTime.Now)
            {
                return false;
            }
            //Simulación de saldo suficiente: último dígito par -> con saldo)
            char ultimoCaracter = tarjeta.Numero.Last();
            if (char.IsDigit(ultimoCaracter))
            {
                int ultimoDigito = int.Parse(ultimoCaracter.ToString());
                return ultimoDigito % 2 == 0;
            }
            return false;
        }
    }
}