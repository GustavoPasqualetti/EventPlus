using apiweb.Event.Domains;

namespace apiweb.Event.Interfaces
{
    public interface IInstituicaoRepository
    {
        void Cadastrar(Instituicao instituicao);

        void Deletar(Guid id);

        List<Instituicao> Listar();

        Instituicao BuscarPorId(Guid id);

        void Atualizar(Guid id, Instituicao instituicao);
    }
}
