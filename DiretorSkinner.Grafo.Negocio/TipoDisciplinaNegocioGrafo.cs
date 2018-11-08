using DiretorSkinner.Grafo.Interface;
using DiretorSkinner.Grafo.Negocio.Nodes;
using DiretorSkinner.Grafo.Tranporte;
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
            List<TipoDisciplinaDto> list = graphClient.Cypher.Match($"(tipoDisciplina:TipoDisciplina)")
                                     .Return(tipoDisciplina => tipoDisciplina.As<TipoDisciplinaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public TipoDisciplinaDto ListarTipoDisciplina(int id)
        {
            var graphClient = ConexaoGrafo.GetConnection();
            TipoDisciplinaDto tipoDisciplinaDto = graphClient.Cypher.Match($"(tipoDisciplina:TipoDisciplina)")
                                     .Where<TipoDisciplinaDto>(tipoDisciplina => tipoDisciplina.Id == id)
                                     .Return(tipoDisciplina => tipoDisciplina.As<TipoDisciplinaDto>())
                                     .Results
                                     .SingleOrDefault();

            graphClient.Dispose();

            return tipoDisciplinaDto;
        }

        public void SalvarTipoDisciplina(TipoDisciplinaDto tipoDisciplinaDto)
        {
            var graphClient = ConexaoGrafo.GetConnection();

            if (tipoDisciplinaDto.Id > 0)
            {

                graphClient.Cypher.Match("(tipoDisciplina:TipoDisciplina)")
                                         .Where<TipoDisciplinaDto>(tipoDisciplina => tipoDisciplina.Id == tipoDisciplinaDto.Id)
                                         .Set("tipoDisciplina.Nome = {Nome}")
                                         .Set("tipoDisciplina.Codigo = {Codigo}")
                                         .WithParam("Nome", tipoDisciplinaDto.Nome)
                                         .WithParam("Codigo", tipoDisciplinaDto.Codigo)
                                         .ExecuteWithoutResults();
            }
            else
            {
                tipoDisciplinaDto.Id = graphClient.Cypher.Match($"(tipoDisciplina:TipoDisciplina)")
                         .Return(() => Neo4jClient.Cypher.Return.As<int>("MAX(tipoDisciplina.Id)"))
                         .Results
                         .SingleOrDefault() + 1;

                graphClient.Cypher.Create("(tipoDisciplina:TipoDisciplina { Nome: {Nome}, Codigo: {Codigo} , Id: {Id} })")
                                         .WithParam("Nome", tipoDisciplinaDto.Nome)
                                         .WithParam("Codigo", tipoDisciplinaDto.Codigo)
                                         .WithParam("Id", tipoDisciplinaDto.Id)
                                         .ExecuteWithoutResults();
            }

            graphClient.Dispose();
        }

        public void DeletarTipoDisciplina(TipoDisciplinaDto tipoDisciplinaDto)
        {
            var graphClient = ConexaoGrafo.GetConnection();

            graphClient.Cypher.Match($"(tipoDisciplina:TipoDisciplina)")
                              .Where<PessoaDto>(tipoDisciplina => tipoDisciplina.Id == tipoDisciplinaDto.Id)
                              .DetachDelete("tipoDisciplina")
                              .ExecuteWithoutResults();

            graphClient.Dispose();
        }
    }
}
