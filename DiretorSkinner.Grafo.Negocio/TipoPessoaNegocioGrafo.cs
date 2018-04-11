using DiretorSkinner.Grafo.Interface;
using DiretorSkinner.Tranporte;
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
            List<TipoPessoaDto> list = graphClient.Cypher.Match($"(e:{typeof(PessoaDto).Name})")
                                     .Return(e => e.As<TipoPessoaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public TipoPessoaDto ListarTipoPessoa(int id)
        {
            var graphClient = ConexaoGrafo.GetConnection();
            TipoPessoaDto tipoPessoa = graphClient.Cypher.Match($"(e:{typeof(TipoPessoaDto).Name})")
                                     .Where<TipoPessoaDto>(e => e.Id == id)
                                     .Return(e => e.As<TipoPessoaDto>())
                                     .Results
                                     .SingleOrDefault();

            graphClient.Dispose();

            return tipoPessoa;
        }

        public List<TipoPessoaDto> ListarTipoPessoaPorPessoa(PessoaDto pessoa)
        {
            var graphClient = ConexaoGrafo.GetConnection();
            List<TipoPessoaDto> list = graphClient.Cypher.Match($"(e:{typeof(PessoaDto).Name})")
                                     .Where<PessoaDto>(e => e.Id == pessoa.Id)
                                     .Return(e => e.As<TipoPessoaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public void SalvarTipoPessoa(TipoPessoaDto tipoPessoa)
        {
            var graphClient = ConexaoGrafo.GetConnection();

            if (tipoPessoa.Id > 0)
            {

                graphClient.Cypher.Match($"(e:{typeof(TipoPessoaDto).Name})")
                                         .Where<TipoPessoaDto>(e => e.Id == tipoPessoa.Id)
                                         .Set("e = {model}")
                                         .WithParam("model", tipoPessoa)
                                         .Return(e => e.As<TipoPessoaDto>())
                                         .Results
                                         .Single();
            }
            else
            {
                graphClient.Cypher.Create($"(e:{typeof(TipoPessoaDto).Name} {{model}})")
                                         .WithParam("model", tipoPessoa)
                                         .Return(e => e.As<TipoPessoaDto>())
                                         .Results
                                         .Single();
            }

            graphClient.Dispose();
        }

        public void DeletarTipoPessoa(TipoPessoaDto tipoPessoa)
        {
            var graphClient = ConexaoGrafo.GetConnection();

            graphClient.Cypher.Match($"(e:{typeof(TipoPessoaDto).Name})")
                              .Where<TipoPessoaDto>(e => e.Id == tipoPessoa.Id)
                              .DetachDelete("e")
                              .ExecuteWithoutResults();

            graphClient.Dispose();
        }
    }
}
