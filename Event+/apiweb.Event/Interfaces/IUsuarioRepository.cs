using apiweb.Event.Domains;

namespace apiweb.Event.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailESenha(string Email, string Senha);

        void Deletar(Guid id);

        void Atualizar(Guid id, Usuario usuario);
    }
}
