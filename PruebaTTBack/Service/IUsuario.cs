using PruebaTTBack.ViewModels;

namespace PruebaTTBack.Service
{
    public interface IUsuario
    {
        public List<CatalogoDto> ObtenerDepartamentos();
        public List<CatalogoDto> ObtenerCargos();
        public List<UsuariosDto> ObtenerUsuarios();

        public ResponseDto CrearUsuario(CrearUsuariosDto usuarioDto);
        public ResponseDto BorrarUsuario(int usuarioId);
        public ResponseDto ActualizarUsuario(ActualizarUsuariosDto usuarioDto);
    }
}
