namespace ApiPeliculasEFCore.Servicios
{
    public interface IservicioUsuario
    {
        string ObtenerUsuarioId();
    }

    public class ServicioUsuario : IservicioUsuario
    {
        public string ObtenerUsuarioId()
        {
            return "Felipe";
        }
    }
}
