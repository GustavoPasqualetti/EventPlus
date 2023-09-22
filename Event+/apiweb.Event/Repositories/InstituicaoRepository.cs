using apiweb.Event.Context;
using apiweb.Event.Domains;
using apiweb.Event.Interfaces;

namespace apiweb.Event.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _eventContext;

        public InstituicaoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Atualizar(Guid id, Instituicao instituicao)
        {
            Instituicao buscado = _eventContext.Instituicao.Find(id);
            if (buscado != null)
            {
                buscado.NomeFantasia = instituicao.NomeFantasia;
                buscado.Endereco= instituicao.Endereco;
                buscado.CNPJ= instituicao.CNPJ;
            }
            _eventContext.Instituicao.Update(instituicao);
            _eventContext.SaveChanges();
        }

        public Instituicao BuscarPorId(Guid id)
        {
            return _eventContext.Instituicao.FirstOrDefault(i => i.IdInstituicao == id);
        }

        public void Cadastrar(Instituicao instituicao)
        {
            _eventContext.Instituicao.Add(instituicao);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Instituicao instituicaoBuscada = _eventContext.Instituicao.FirstOrDefault(i => i.IdInstituicao == id);

            _eventContext.Instituicao.Remove(instituicaoBuscada);

            _eventContext.SaveChanges();
        }

        public List<Instituicao> Listar()
        {
            return _eventContext.Instituicao.ToList();
        }
    }
}
