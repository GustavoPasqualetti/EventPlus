using apiweb.Event.Context;
using apiweb.Event.Domains;
using apiweb.Event.Interfaces;

namespace apiweb.Event.Repositories
{
    public class PresencasEventoRepository : IPresencasEventoRepository
    {
        private readonly EventContext _eventContext;

        public PresencasEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Cadastrar(PresencasEvento presencasEvento)
        {
            _eventContext.PresencasEvento.Add(presencasEvento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            PresencasEvento presencaBuscada = _eventContext.PresencasEvento.FirstOrDefault(e => e.IdPresenca == id);

            _eventContext.Remove(presencaBuscada);

            _eventContext.SaveChanges();
        }

        public List<PresencasEvento> Listar()
        {
            return _eventContext.PresencasEvento.ToList();
        }

        public List<PresencasEvento> ListarMinhas(Guid id)
        {
            return _eventContext.PresencasEvento.Where(e => e.IdUsuario == id).ToList();
        }
    }
}
