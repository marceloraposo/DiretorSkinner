using DiretorSkinner.Grafo.Interface;
using DiretorSkinner.Grafo.Negocio.Nodes;
using DiretorSkinner.Tranporte;
using DiretorSkinner.Util.Acesso.Graphos;
using System.Collections.Generic;
using System.Linq;

namespace DiretorSkinner.Grafo.Negocio
{
    public partial class DiretorSkinnerNegocioGrafo : IDiretorSkinnerNegocioGrafo
    {
        public List<PessoaDto> ListarPessoas()
        {
            var graphClient = ConexaoGrafo.GetConnection();
            List<PessoaDto> list = graphClient.Cypher.Match($"(e:{typeof(PessoaDto).Name})")
                                     .Return(e => e.As<PessoaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public List<PessoaDto> ListarPessoasPesquisa(string filtro)
        {
            var graphClient = ConexaoGrafo.GetConnection();
            List<PessoaDto> list = graphClient.Cypher.Match($"(e:{typeof(PessoaDto).Name})")
                                     .Where<PessoaDto>(e => e.Apelido.Contains(filtro) || e.Codigo.Contains(filtro) || e.Nome.Contains(filtro))
                                     .Return(e => e.As<PessoaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public List<PessoaDto> ListarPessoaPorTipo(TipoPessoaDto tipoPessoaDto)
        {
            var graphClient = ConexaoGrafo.GetConnection();
            List<PessoaDto> list = graphClient.Cypher.Match($"(e:{typeof(PessoaDto).Name})")
                                     .Where<PessoaDto>(e => e.TipoPessoas.Any(tp => tp.Id == tipoPessoaDto.Id))
                                     .Return(e => e.As<PessoaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public PessoaDto ListarPessoa(int id)
        {
            var graphClient = ConexaoGrafo.GetConnection();
            PessoaDto pessoa = graphClient.Cypher.Match($"(e:{typeof(PessoaDto).Name})")
                                     .Where<PessoaDto>(e => e.Id == id)
                                     .Return(e => e.As<PessoaDto>())
                                     .Results
                                     .SingleOrDefault();

            graphClient.Dispose();

            return pessoa;
        }

        public PessoaDto ListarPessoaPorApelido(string apelido)
        {
            var graphClient = ConexaoGrafo.GetConnection();
            PessoaDto pessoa = graphClient.Cypher.Match($"(e:{typeof(PessoaDto).Name})")
                                     .Where<PessoaDto>(e => e.Apelido.Equals(apelido))
                                     .Return(e => e.As<PessoaDto>())
                                     .Results
                                     .SingleOrDefault();

            graphClient.Dispose();

            return pessoa;
        }

        public PessoaDto ListarPessoaPorCodigo(string codigo)
        {
            var graphClient = ConexaoGrafo.GetConnection();
            PessoaDto pessoa = graphClient.Cypher.Match($"(e:{typeof(PessoaDto).Name})")
                                     .Where<PessoaDto>(e => e.Codigo.Equals(codigo))
                                     .Return(e => e.As<PessoaDto>())
                                     .Results
                                     .SingleOrDefault();

            graphClient.Dispose();

            return pessoa;
        }

        public void SalvarPessoa(PessoaDto pessoa)
        {
            DeletarPessoaTipoPessoa(pessoa);
            SalvarPessoaTipoPessoa(pessoa);

            var graphClient = ConexaoGrafo.GetConnection();

            if (pessoa.Id > 0)
            {

                graphClient.Cypher.Match($"(e:{typeof(PessoaDto).Name})")
                                         .Where<PessoaDto>(e => e.Id == pessoa.Id)
                                         .Set("e = {model}")
                                         .WithParam("model", pessoa)
                                         .Return(e => e.As<PessoaDto>())
                                         .Results
                                         .Single();
            }
            else
            {
                graphClient.Cypher.Create($"(e:{typeof(PessoaDto).Name} {{model}})")
                                         .WithParam("model", pessoa)
                                         .Return(e => e.As<PessoaDto>())
                                         .Results
                                         .Single();
            }

            graphClient.Dispose();
        }

        public void SalvarPessoaTipoPessoa(PessoaDto pessoa)
        {
        }

        public void DeletarPessoa(PessoaDto pessoa)
        {
            DeletarPessoaTipoPessoa(pessoa);

            var graphClient = ConexaoGrafo.GetConnection();

            graphClient.Cypher.Match($"(e:{typeof(PessoaDto).Name})")
                              .Where<PessoaDto>(e => e.Id == pessoa.Id)
                              .DetachDelete("e")
                              .ExecuteWithoutResults();

            graphClient.Dispose();
        }

        public void DeletarPessoaTipoPessoa(PessoaDto pessoa)
        {
        }
    }
}
