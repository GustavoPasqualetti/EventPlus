using apiweb.Event.Context;
using apiweb.Event.Domains;
using apiweb.Event.Interfaces;
using apiweb.Event.Utils;

namespace apiweb.Event.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public UsuarioRepository()
        {
            _eventContext = new EventContext();
        }


        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario.
                    Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        TiposUsuario = new TiposUsuario
                        {
                            Titulo = u.TiposUsuario.Titulo
                        }
                    }).FirstOrDefault(u => u.IdUsuario == id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            usuario.Senha = Criptografia.GerarHash(usuario.Senha);

            _eventContext.Usuario.Add(usuario);

            _eventContext.SaveChanges();
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,
                        TiposUsuario = new TiposUsuario
                        {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TiposUsuario!.Titulo
                        }
                    }).FirstOrDefault(u => u.Email == email)!;


                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Usuario usuarioBuscado = _eventContext.Usuario.FirstOrDefault(u => u.IdUsuario == id);

            _eventContext.Usuario.Remove(usuarioBuscado);

            _eventContext.SaveChanges();
        }

        public void Atualizar(Guid id, Usuario usuario)
        {
            Usuario buscado = _eventContext.Usuario.Find(id);
            if (buscado != null)
            {
                buscado.Nome = usuario.Nome;
                buscado.Email= usuario.Email;
                buscado.Senha= usuario.Senha;
            }
            _eventContext.Usuario.Update(usuario);
            _eventContext.SaveChanges();
        }
    }
}
