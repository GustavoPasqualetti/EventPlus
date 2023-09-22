using apiweb.Event.Context;
using apiweb.Event.Domains;
using apiweb.Event.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace apiweb.Event.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly EventContext _eventContext;

        public TiposUsuarioRepository()
        {
            _eventContext = new EventContext();
        }


        public TiposUsuario BuscarPorId(Guid id)
        {
            return _eventContext.TiposUsuario.FirstOrDefault(u => u.IdTipoUsuario == id);
        }

        public void Cadastrar(TiposUsuario tipoUsuario)
        {
            _eventContext.TiposUsuario.Add(tipoUsuario);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposUsuario tiposUsuarioBuscado = _eventContext.TiposUsuario.FirstOrDefault(e => e.IdTipoUsuario == id);

            _eventContext.TiposUsuario.Remove(tiposUsuarioBuscado);

            _eventContext.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return _eventContext.TiposUsuario.ToList();
        }
    }
}
