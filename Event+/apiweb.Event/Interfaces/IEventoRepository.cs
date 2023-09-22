using apiweb.Event.Domains;

namespace apiweb.Event.Interfaces
{
    public interface IEventoRepository
    {
        void Cadastrar(Evento evento);

        void Deletar(Guid id);

        List<Evento> Listar();

        Evento BuscarPorId(Guid id);

        public void Atualizar(Guid id, Evento evento);

    }
}
