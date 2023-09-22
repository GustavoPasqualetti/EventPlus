using apiweb.Event.Domains;

namespace apiweb.Event.Interfaces
{
    public interface IPresencasEventoRepository
    {
        void Cadastrar(PresencasEvento presencasEvento);

        List<PresencasEvento> Listar();

        void Deletar(Guid id);

        List<PresencasEvento> ListarMinhas(Guid id);

    }
}
