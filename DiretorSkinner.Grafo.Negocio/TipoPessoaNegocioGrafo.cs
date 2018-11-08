using DiretorSkinner.Grafo.Interface;
using DiretorSkinner.Grafo.Tranporte;
using DiretorSkinner.Util.Acesso.Graphos;
using System.Collections.Generic;
using System.Linq;

namespace DiretorSkinner.Grafo.Negocio
{
    public partial class DiretorSkinnerNegocioGrafo : IDiretorSkinnerNegocioGrafo
    {
        public List<TipoPessoaDto> ListarTiposPessoa()
        {
            var graphClient = ConexaoGrafo.GetConnection();
            List<TipoPessoaDto> list = graphClient.Cypher.Match($"(tipoPessoa:TipoPessoa)")
                                     .Return(tipoPessoa => tipoPessoa.As<TipoPessoaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public TipoPessoaDto ListarTipoPessoa(int id)
        {
            var graphClient = ConexaoGrafo.GetConnection();
            TipoPessoaDto tipoPessoaDto = graphClient.Cypher.Match($"(tipoPessoa:TipoPessoa)")
                                     .Where<TipoPessoaDto>(tipoPessoa => tipoPessoa.Id == id)
                                     .Return(tipoPessoa => tipoPessoa.As<TipoPessoaDto>())
                                     .Results
                                     .SingleOrDefault();

            graphClient.Dispose();

            return tipoPessoaDto;
        }

        public List<TipoPessoaDto> ListarTipoPessoaPorPessoa(PessoaDto pessoa)
        {
            var graphClient = ConexaoGrafo.GetConnection();
            List<TipoPessoaDto> list = graphClient.Cypher.Match($"(tipoPessoa:TipoPessoa)")
                                     .Where<TipoPessoaDto>(tipoPessoa => tipoPessoa.Id == pessoa.Id)
                                     .Return(tipoPessoa => tipoPessoa.As<TipoPessoaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public void SalvarTipoPessoa(TipoPessoaDto tipoPessoaDto)
        {
            var graphClient = ConexaoGrafo.GetConnection();

            if (tipoPessoaDto.Id > 0)
            {

                graphClient.Cypher.Match($"(tipoPessoa:TipoPessoa)")
                                         .Where<TipoPessoaDto>(e => e.Id == tipoPessoaDto.Id)
                                         .Set("pessoa.Nome = {Nome}")
                                         .Set("pessoa.Codigo = {Codigo}")
                                         .WithParam("Nome", tipoPessoaDto.Nome)
                                         .WithParam("Codigo", tipoPessoaDto.Codigo)
                                         .ExecuteWithoutResults();
            }
            else
            {
                tipoPessoaDto.Id = graphClient.Cypher.Match($"(tipoPessoa:TipoPessoa)")
                                         .Return(() => Neo4jClient.Cypher.Return.As<int>("MAX(tipoPessoa.Id)"))
                                         .Results
                                         .SingleOrDefault() + 1;

                graphClient.Cypher.Create("(tipoPessoa:TipoPessoa{ Nome: {Nome}, Codigo: {Codigo} , Id: {Id} } )")
                                         .WithParam("Nome", tipoPessoaDto.Nome)
                                         .WithParam("Codigo", tipoPessoaDto.Codigo)
                                         .WithParam("Id", tipoPessoaDto.Id)
                                         .ExecuteWithoutResults();
            }

            graphClient.Dispose();
        }

        public void DeletarTipoPessoa(TipoPessoaDto tipoPessoaDto)
        {
            var graphClient = ConexaoGrafo.GetConnection();

            graphClient.Cypher.Match($"(tipoPessoa:TipoPessoa)")
                              .Where<TipoPessoaDto>(tipoPessoa => tipoPessoa.Id == tipoPessoaDto.Id)
                              .DetachDelete("tipoPessoa")
                              .ExecuteWithoutResults();

            graphClient.Dispose();
        }
    }
}
