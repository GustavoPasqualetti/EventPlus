using apiweb.Event.Context;
using apiweb.Event.Domains;
using apiweb.Event.Interfaces;

namespace apiweb.Event.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        public EventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, Evento evento)
        {
            Evento buscado = _eventContext.Evento.Find(id);

            if (buscado != null)
            {
                buscado.NomeEvento = evento.NomeEvento;
                buscado.DataEvento = evento.DataEvento;
                buscado.Descricao = evento.Descricao;
            }
            _eventContext.Evento.Update(buscado);
            _eventContext.SaveChanges();
        }

        public Evento BuscarPorId(Guid id)
        {
            return _eventContext.Evento.FirstOrDefault(e => e.IdEvento == id);
        }

        public void Cadastrar(Evento evento)
        {
            _eventContext.Evento.Add(evento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Evento eventoBuscado = _eventContext.Evento.FirstOrDefault(e => e.IdEvento == id);

            _eventContext.Evento.Remove(eventoBuscado);

            _eventContext.SaveChanges(); 
        }

        public List<Evento> Listar()
        {
            return _eventContext.Evento.ToList();
        }
    }
}
