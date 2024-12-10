using educae.comunicacao.domain.Entities;
using EstartandoDevsCore.ValueObjects;

namespace educae.comunicacao.app.ViewModels;
public class ComunicadoViewModel
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Imagem { get; set; }
    public DateTime DataExpiracao { get; set; }
        public static ComunicadoViewModel Mapear (Comunicado comunicado)
        {
            return new ComunicadoViewModel ()
            {
            Titulo = comunicado.titulo,
            Descricao = comunicado.descricaol,
            Imagem = comunicado.imagem,
            DataExpiracao =comunicado.dataExpiracao
            };
        }
}