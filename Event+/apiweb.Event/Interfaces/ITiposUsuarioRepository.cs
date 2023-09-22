using apiweb.Event.Domains;

namespace apiweb.Event.Interfaces
{
    public interface ITiposUsuarioRepository
    {
        void Cadastrar(TiposUsuario tipoUsuario);

        void Deletar(Guid id);

        List<TiposUsuario> Listar();   

        TiposUsuario BuscarPorId(Guid id);
       
    }
}
