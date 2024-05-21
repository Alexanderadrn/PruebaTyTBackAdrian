using DataBase;
using Microsoft.EntityFrameworkCore;
using PruebaTTBack.ViewModels;

namespace PruebaTTBack.Service
{
    public class UsuarioService : IUsuario
    {
        PruebaContext _context;

        public UsuarioService(PruebaContext context)
        {
            _context = context;
        }

        public  List<CatalogoDto> ObtenerCargos()
        {
            List<CatalogoDto> Lista = new List<CatalogoDto>();

            var consulta = _context.Cargos.ToList();
            foreach (var item in consulta)            {
                CatalogoDto cargo = new CatalogoDto
                {
                    Descripcion = item.nombre,
                    ID = item.id
                };
                Lista.Add(cargo);
            }

            return Lista;
        }

        public List<CatalogoDto> ObtenerDepartamentos()
        {
            List<CatalogoDto> Lista = new List<CatalogoDto>();

            var consulta = _context.Departamentos.ToList();
            foreach (var item in consulta)
            {
                CatalogoDto departamento = new CatalogoDto
                {
                    Descripcion = item.nombre,
                    ID = item.id
                };
                Lista.Add(departamento);
            }

            return Lista;
        }

        public List<UsuariosDto> ObtenerUsuarios()
        {
            List<UsuariosDto> usuariosDto = new List<UsuariosDto>();
            var consulta = (from usuarios in _context.Users
                             join departamentos in _context.Departamentos
                             on usuarios.idDepartamento equals departamentos.id
                             join cargo in _context.Cargos
                             on usuarios.idCargo equals cargo.id
                             where  usuarios.estado == true
                             select new 
                             {
                                 usuarios.id,
                                 usuarios.primerNombre,
                                 usuarios.segundoNombre,
                                 usuarios.primerApellido,
                                 usuarios.segundoApellido,
                                 Estado = usuarios.estado,
                                 Email = usuarios.Correo,
                                 Usuario = usuarios.usuario,
                                 idCargo = cargo.id,
                                 NombreCargo = cargo.nombre,
                                 idDeparameto = departamentos.id,
                                 NombreDepartamento = departamentos.nombre
                                
                             }
                             ).ToList();
            foreach (var item in consulta)
            {
                UsuariosDto persona = new UsuariosDto
                {
                    Id = item.id,
                    PrimerNombre = item.primerNombre,
                    SegundoNombre = item.segundoNombre,
                    PrimerApellido = item.primerApellido,
                    SegundoApellido = item.segundoApellido,
                    NombreCargo = item.NombreCargo,
                    IdCargo = item.idCargo,
                    IdDepartamento = item.idDeparameto,
                    NombreDepartamento = item.NombreDepartamento,
                    Estado = item.Estado, 
                    Email = item.Email,
                    Usuario = item.Usuario
                };
                usuariosDto.Add(persona);
            }


            return usuariosDto;
        }

        public ResponseDto CrearUsuario(CrearUsuariosDto usuarioDto)
        {
            ResponseDto respuesta = new ResponseDto();
            try
            {
                var existe = _context.Users.Where(user => user.usuario == usuarioDto.Usuario).Any();
                if (!existe)
                {
                    Users user = new Users
                    {
                        primerApellido = usuarioDto.PrimerApellido,
                        segundoApellido = usuarioDto.SegundoApellido,
                        primerNombre = usuarioDto.PrimerNombre,
                        segundoNombre = usuarioDto.SegundoNombre,
                        idDepartamento = usuarioDto.IdDepartamento,
                        idCargo = usuarioDto.IdCargo,
                        usuario = usuarioDto.Usuario,
                        estado = true,
                        Correo = usuarioDto.Email
                    };
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    respuesta.Ejecutado = true;
                    respuesta.Mensaje = "Usuario registrado correctamente";

                }
                else
                {
                    respuesta.Ejecutado = false;
                    respuesta.Mensaje = "Usuario ya existe";
                }
            }
            catch (Exception ex)
            {

                respuesta.Ejecutado = false;
                respuesta.Mensaje = $"Ocurrio un error: {ex.Message}" ;
            }
           

            return respuesta;
        }

        public ResponseDto BorrarUsuario(int usuarioId)
        {
            ResponseDto respuesta = new ResponseDto();
            try
            {
                var existe = _context.Users.Where(user => user.id == usuarioId && user.estado == true).FirstOrDefault();
                if (existe != null)
                {
                    existe.estado = false;
                    
                    _context.SaveChanges();
                    respuesta.Ejecutado = true;
                    respuesta.Mensaje = "Usuario Eliminado correctamente";

                }
                else
                {
                    respuesta.Ejecutado = false;
                    respuesta.Mensaje = "Usuario no existe";
                }
            }
            catch (Exception ex)
            {

                respuesta.Ejecutado = false;
                respuesta.Mensaje = $"Ocurrio un error: {ex.Message}";
            }


            return respuesta;
        }

        public ResponseDto ActualizarUsuario(ActualizarUsuariosDto usuarioDto)
        {
            ResponseDto respuesta = new ResponseDto();
            try
            {
                var existe = _context.Users.Where(user => user.id == usuarioDto.Id &&  user.estado == true).FirstOrDefault();
                if (existe != null)
                {
                    existe.primerApellido = usuarioDto.PrimerApellido;
                    existe.primerNombre = usuarioDto.PrimerNombre;
                    existe.segundoNombre = usuarioDto.SegundoNombre;
                    existe.segundoApellido = usuarioDto.SegundoApellido;
                    existe.Correo = usuarioDto.Email;
                    existe.idCargo= usuarioDto.IdCargo;
                    existe.idDepartamento=usuarioDto.IdDepartamento;
                    existe.usuario=usuarioDto.Usuario;

                    _context.SaveChanges();
                    respuesta.Ejecutado = true;
                    respuesta.Mensaje = "Usuario actualizado correctamete";

                }
                else
                {
                    respuesta.Ejecutado = false;
                    respuesta.Mensaje = "Usuario no existe";
                }
            }
            catch (Exception ex)
            {

                respuesta.Ejecutado = false;
                respuesta.Mensaje = $"Ocurrio un error: {ex.Message}";
            }


            return respuesta;
        }
    }
}
