using DiretorSkinner.Grafo.Interface;
using DiretorSkinner.Grafo.Negocio.Nodes;
using DiretorSkinner.Tranporte;
using System.Collections.Generic;
using System;
using DiretorSkinner.Util.Acesso.Graphos;
using System.Linq;

namespace DiretorSkinner.Grafo.Negocio
{
    public partial class DiretorSkinnerNegocioGrafo : IDiretorSkinnerNegocioGrafo
    {

        public List<TipoDisciplinaDto> ListarTiposDisciplina()
        {
            var graphClient = ConexaoGrafo.GetConnection();
            List<TipoDisciplinaDto> list = graphClient.Cypher.Match($"(e:{typeof(TipoDisciplinaDto).Name})")
                                     .Return(e => e.As<TipoDisciplinaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public TipoDisciplinaDto ListarTipoDisciplina(int id)
        {
            var graphClient = ConexaoGrafo.GetConnection();
            TipoDisciplinaDto tipoDisciplina = graphClient.Cypher.Match($"(e:{typeof(TipoDisciplinaDto).Name})")
                                     .Where<TipoDisciplinaDto>(e => e.Id == id)
                                     .Return(e => e.As<TipoDisciplinaDto>())
                                     .Results
                                     .SingleOrDefault();

            graphClient.Dispose();

            return tipoDisciplina;
        }

        public void SalvarTipoDisciplina(TipoDisciplinaDto tipoDisciplina)
        {
            var graphClient = ConexaoGrafo.GetConnection();

            if (tipoDisciplina.Id > 0)
            {

                graphClient.Cypher.Match($"(e:{typeof(TipoDisciplinaDto).Name})")
                                         .Where<TipoDisciplinaDto>(e => e.Id == tipoDisciplina.Id)
                                         .Set("e = {model}")
                                         .WithParam("model", tipoDisciplina)
                                         .Return(e => e.As<TipoDisciplinaDto>())
                                         .Results
                                         .Single();
            }
            else
            {
                graphClient.Cypher.Create($"(e:{typeof(TipoDisciplinaDto).Name} {{model}})")
                                         .WithParam("model", tipoDisciplina)
                                         .Return(e => e.As<TipoDisciplinaDto>())
                                         .Results
                                         .Single();
            }

            graphClient.Dispose();
        }

        public void DeletarTipoDisciplina(TipoDisciplinaDto tipoDisciplina)
        {
            var graphClient = ConexaoGrafo.GetConnection();

            graphClient.Cypher.Match($"(e:{typeof(TipoDisciplinaDto).Name})")
                              .Where<TipoDisciplinaDto>(e => e.Id == tipoDisciplina.Id)
                              .DetachDelete("e")
                              .ExecuteWithoutResults();

            graphClient.Dispose();
        }
    }
}
