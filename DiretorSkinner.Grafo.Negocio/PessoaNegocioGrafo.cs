using DiretorSkinner.Grafo.Interface;
using DiretorSkinner.Grafo.Tranporte;
using DiretorSkinner.Util.Acesso.Graphos;
using System.Collections.Generic;
using System.Linq;

namespace DiretorSkinner.Grafo.Negocio
{
    public partial class DiretorSkinnerNegocioGrafo : IDiretorSkinnerNegocioGrafo
    {
        public List<PessoaDto> ListarPessoas()
        {
            var graphClient = ConexaoGrafo.Client;

            var list = graphClient.Cypher.Match($"(pessoa:Pessoa), (tipoPessoa:TipoPessoa)")
                                     .OptionalMatch("(pessoa:Pessoa)-[PessoaPertenceTipoPessoa:PESSOA_PERTENCE_TIPO_PESSOA]->(tipoPessoa: TipoPessoa)")
                                     .With("pessoa,tipoPessoa,{ qtd: count(PessoaPertenceTipoPessoa) } as pptp")
                                     .With(" pessoa,{ Id: tipoPessoa.Id, Codigo: tipoPessoa.Codigo, Nome: tipoPessoa.Nome, Selecionado: pptp.qtd > 0} as TipoPessoas")
                                     .With(" {Id: pessoa.Id, Nome: pessoa.Nome, Codigo: pessoa.Codigo, Apelido: pessoa.Apelido,TipoPessoas: collect(TipoPessoas)} as pessoa")
                                     .Return(pessoa => pessoa.As<PessoaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public List<PessoaDto> ListarPessoasPesquisa(string filtro)
        {
            var graphClient = ConexaoGrafo.Client;

            var list = graphClient.Cypher.Match($"(pessoa:Pessoa), (tipoPessoa:TipoPessoa)")
                                     .Where<PessoaDto>(pessoa => pessoa.Apelido.ToLower().Contains(filtro.ToLower()) || pessoa.Codigo.ToLower().Contains(filtro.ToLower()) || pessoa.Nome.ToLower().Contains(filtro.ToLower()))
                                     .OptionalMatch("(pessoa:Pessoa)-[PessoaPertenceTipoPessoa:PESSOA_PERTENCE_TIPO_PESSOA]->(tipoPessoa: TipoPessoa)")
                                     .With("pessoa,tipoPessoa,{ qtd: count(PessoaPertenceTipoPessoa) } as pptp")
                                     .With(" pessoa,{ Id: tipoPessoa.Id, Codigo: tipoPessoa.Codigo, Nome: tipoPessoa.Nome, Selecionado: pptp.qtd > 0} as TipoPessoas")
                                     .With(" {Id: pessoa.Id, Nome: pessoa.Nome, Codigo: pessoa.Codigo, Apelido: pessoa.Apelido,TipoPessoas: collect(TipoPessoas)} as pessoa")
                                     .Return(pessoa => pessoa.As<PessoaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

             return list;
        }

        public List<PessoaDto> ListarPessoaPorTipo(TipoPessoaDto tipoPessoaDto)
        {
            var graphClient = ConexaoGrafo.Client;

            var list = graphClient.Cypher.Match($"(pessoa:Pessoa), (tipoPessoa:TipoPessoa)")
                                     .Where<PessoaDto>(pessoa => pessoa.TipoPessoas.Any(tipoPessoa => tipoPessoa.Id == tipoPessoaDto.Id))
                                     .OptionalMatch("(pessoa:Pessoa)-[PessoaPertenceTipoPessoa:PESSOA_PERTENCE_TIPO_PESSOA]->(tipoPessoa: TipoPessoa)")
                                     .With("pessoa,tipoPessoa,{ qtd: count(PessoaPertenceTipoPessoa) } as pptp")
                                     .With(" pessoa,{ Id: tipoPessoa.Id, Codigo: tipoPessoa.Codigo, Nome: tipoPessoa.Nome, Selecionado: pptp.qtd > 0} as TipoPessoas")
                                     .With(" {Id: pessoa.Id, Nome: pessoa.Nome, Codigo: pessoa.Codigo, Apelido: pessoa.Apelido,TipoPessoas: collect(TipoPessoas)} as pessoa")
                                     .Return(pessoa => pessoa.As<PessoaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public PessoaDto ListarPessoa(int id)
        {
            var graphClient = ConexaoGrafo.Client;
            PessoaDto pessoaDto = graphClient.Cypher.Match($"(pessoa:Pessoa)")
                                     .Where<PessoaDto>(pessoa => pessoa.Id == id)
                                     .Return(pessoa => pessoa.As<PessoaDto>())
                                     .Results
                                     .SingleOrDefault();

            graphClient.Dispose();

            return pessoaDto;
        }

        public PessoaDto ListarPessoaPorApelido(string apelido)
        {
            var graphClient = ConexaoGrafo.Client;
            PessoaDto pessoaDto = graphClient.Cypher.Match($"(pessoa:Pessoa)")
                                     .Where<PessoaDto>(pessoa => pessoa.Apelido == apelido)
                                     .Return(pessoa => pessoa.As<PessoaDto>())
                                     .Results
                                     .SingleOrDefault();

            graphClient.Dispose();

            return pessoaDto;
        }

        public PessoaDto ListarPessoaPorCodigo(string codigo)
        {
            var graphClient = ConexaoGrafo.Client;

            PessoaDto pessoaDto = graphClient.Cypher.Match($"(pessoa:Pessoa), (tipoPessoa:TipoPessoa)")
                                     .Where<PessoaDto>(pessoa => pessoa.Codigo.ToLower() == codigo.ToLower())
                                     .OptionalMatch("(pessoa:Pessoa)-[PessoaPertenceTipoPessoa:PESSOA_PERTENCE_TIPO_PESSOA]->(tipoPessoa: TipoPessoa)")
                                     .With("pessoa,tipoPessoa,{ qtd: count(PessoaPertenceTipoPessoa) } as pptp")
                                     .With(" pessoa,{ Id: tipoPessoa.Id, Codigo: tipoPessoa.Codigo, Nome: tipoPessoa.Nome, Selecionado: pptp.qtd > 0} as TipoPessoas")
                                     .With(" {Id: pessoa.Id, Nome: pessoa.Nome, Codigo: pessoa.Codigo, Apelido: pessoa.Apelido,TipoPessoas: collect(TipoPessoas)} as pessoa")
                                     .Return(pessoa => pessoa.As<PessoaDto>())
                                     .Results
                                     .SingleOrDefault();

            graphClient.Dispose();

            return pessoaDto;
        }

        public void SalvarPessoa(PessoaDto pessoaDto)
        {
            var graphClient = ConexaoGrafo.Client;

            if (pessoaDto.Id > 0)
            {

                graphClient.Cypher.Match("(pessoa:Pessoa)")
                                         .Where<PessoaDto>(pessoa => pessoa.Id == pessoaDto.Id)
                                         .Set("pessoa.Nome = {Nome}")
                                         .Set("pessoa.Codigo = {Codigo}")
                                         .Set("pessoa.Apelido = {Apelido}")
                                         .WithParam("Nome", pessoaDto.Nome)
                                         .WithParam("Codigo", pessoaDto.Codigo)
                                         .WithParam("Apelido", pessoaDto.Apelido)
                                         .ExecuteWithoutResults();
            }
            else
            {

                pessoaDto.Id = graphClient.Cypher.Match($"(pessoa:Pessoa)")
                                         .Return(() => Neo4jClient.Cypher.Return.As<int>("MAX(pessoa.Id)"))
                                         .Results
                                         .SingleOrDefault() + 1;

                graphClient.Cypher.Create("(pessoa:Pessoa{ Nome: {Nome}, Codigo: {Codigo} , Apelido: {Apelido}, Id: {Id} } )")
                                         .WithParam("Nome", pessoaDto.Nome)
                                         .WithParam("Codigo", pessoaDto.Codigo)
                                         .WithParam("Apelido", pessoaDto.Apelido)
                                         .WithParam("Id", pessoaDto.Id)
                                         .ExecuteWithoutResults();
            }

            DeletarPessoaTipoPessoa(pessoaDto);
            SalvarPessoaTipoPessoa(pessoaDto);

            graphClient.Dispose();
        }

        public void SalvarPessoaTipoPessoa(PessoaDto pessoaDto)
        {
            var graphClient = ConexaoGrafo.Client;

            foreach (var item in pessoaDto.TipoPessoas)
            {
                graphClient.Cypher.Match("(pessoa:Pessoa)", "(tipoPessoa:TipoPessoa)")
                                        .Where<PessoaDto>(pessoa => pessoa.Id == pessoaDto.Id)
                                        .AndWhere<TipoPessoaDto>(tipoPessoa => tipoPessoa.Id == item.Id)
                                        .Create("(pessoa)-[PessoaPertenceTipoPessoa:PESSOA_PERTENCE_TIPO_PESSOA]->(tipoPessoa)")
                                        .ExecuteWithoutResults();
            }

            graphClient.Dispose();
        }

        public void DeletarPessoa(PessoaDto pessoaDto)
        {
            DeletarPessoaTipoPessoa(pessoaDto);

            var graphClient = ConexaoGrafo.Client;

            graphClient.Cypher.Match($"(pessoa:Pessoa)")
                              .Where<PessoaDto>(pessoa => pessoa.Id == pessoaDto.Id)
                              .DetachDelete("pessoa")
                              .ExecuteWithoutResults();

            graphClient.Dispose();
        }

        public void DeletarPessoaTipoPessoa(PessoaDto pessoaDto)
        {
            var graphClient = ConexaoGrafo.Client;

            foreach (var item in pessoaDto.TipoPessoas)
            {
                graphClient.Cypher.Match("(pessoa)-[PessoaPertenceTipoPessoa:PESSOA_PERTENCE_TIPO_PESSOA]->(tipoPessoa)")
                                        .Where<PessoaDto>(pessoa => pessoa.Id == pessoaDto.Id)
                                        .Delete("PessoaPertenceTipoPessoa")
                                        .ExecuteWithoutResults();
            }

            graphClient.Dispose();
        }
    }
}
