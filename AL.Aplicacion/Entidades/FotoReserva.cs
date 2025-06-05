namespace AL.Aplicacion.Entidades
{
    public class FotoReserva
    {
        public int Id { get; set; }

        public int ReservaId { get; set; }

        public string RutaFoto { get; set; } = string.Empty;

        public Reserva Reserva { get; set; } = null!;
    }
}