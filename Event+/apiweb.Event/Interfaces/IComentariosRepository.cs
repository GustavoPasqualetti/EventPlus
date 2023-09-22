using apiweb.Event.Domains;

namespace apiweb.Event.Interfaces
{
    public interface IComentariosRepository 
    {
        void Cadastrar(ComentariosEvento comentario);

        List<ComentariosEvento> Listar();

        void Deletar(Guid id);

        ComentariosEvento BuscarPorId(Guid id);
    }
}
