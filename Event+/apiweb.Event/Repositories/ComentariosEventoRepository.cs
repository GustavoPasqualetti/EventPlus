using apiweb.Event.Context;
using apiweb.Event.Domains;
using apiweb.Event.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace apiweb.Event.Repositories
{
    public class ComentariosEventoRepository : IComentariosRepository
    {
        private readonly EventContext _eventContext;

        public ComentariosEventoRepository()
        {
            _eventContext = new EventContext();
        }
        public ComentariosEvento BuscarPorId(Guid id)
        {
            return _eventContext.ComentariosEvento.FirstOrDefault(e => e.IdComentario == id);
        }

        public void Cadastrar(ComentariosEvento comentario)
        {
            _eventContext.ComentariosEvento.Add(comentario);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            ComentariosEvento comentarioBuscado = _eventContext.ComentariosEvento.FirstOrDefault(e => e.IdComentario == id);

            _eventContext.ComentariosEvento.Remove(comentarioBuscado);

            _eventContext.SaveChanges();
        }

        public List<ComentariosEvento> Listar()
        {
            return _eventContext.ComentariosEvento.ToList();
        }
    }
}
