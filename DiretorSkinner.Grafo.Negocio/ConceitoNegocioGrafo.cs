using DiretorSkinner.Grafo.Interface;
using DiretorSkinner.Tranporte;
using DiretorSkinner.Util.Acesso.Graphos;
using System.Collections.Generic;
using System.Linq;

namespace DiretorSkinner.Grafo.Negocio
{
    public partial class DiretorSkinnerNegocioGrafo : IDiretorSkinnerNegocioGrafo
    {
        public List<ConceitoDto> ListarConceitos()
        {
            var graphClient = ConexaoGrafo.GetConnection();
            List<ConceitoDto> list = graphClient.Cypher.Match($"(e:{typeof(ConceitoDto).Name})")
                                     .Return(e => e.As<ConceitoDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;

        }

        public ConceitoDto ListarConceito(int id)
        {
            var graphClient = ConexaoGrafo.GetConnection();
            ConceitoDto conceito = graphClient.Cypher.Match($"(e:{typeof(ConceitoDto).Name})")
                                     .Where<ConceitoDto>(e => e.Id == id)
                                     .Return(e => e.As<ConceitoDto>())
                                     .Results
                                     .SingleOrDefault();

            graphClient.Dispose();

            return conceito;
        }

        public void SalvarConceito(ConceitoDto conceito)
        {
            var graphClient = ConexaoGrafo.GetConnection();

            if (conceito.Id > 0)
            {

                graphClient.Cypher.Match($"(e:{typeof(ConceitoDto).Name})")
                                         .Where<ConceitoDto>(e => e.Id == conceito.Id)
                                         .Set("e = {model}")
                                         .WithParam("model", conceito)
                                         .Return(e => e.As<ConceitoDto>())
                                         .Results
                                         .Single();
            }
            else
            {
                graphClient.Cypher.Create($"(e:{typeof(ConceitoDto).Name} {{model}})")
                                         .WithParam("model", conceito)
                                         .Return(e => e.As<ConceitoDto>())
                                         .Results
                                         .Single();
            }

            graphClient.Dispose();

        }

        public void DeletarConceito(ConceitoDto conceito)
        {
            var graphClient = ConexaoGrafo.GetConnection();

            graphClient.Cypher.Match($"(e:{typeof(ConceitoDto).Name})")
                              .Where<ConceitoDto>(e => e.Id == conceito.Id)
                              .DetachDelete("e")
                              .ExecuteWithoutResults();

            graphClient.Dispose();
        }
    }
}
