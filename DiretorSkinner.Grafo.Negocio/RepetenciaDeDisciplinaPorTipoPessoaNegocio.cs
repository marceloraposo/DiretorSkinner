using DiretorSkinner.Grafo.Interface;
using DiretorSkinner.Grafo.Tranporte;
using DiretorSkinner.Util.Acesso.Graphos;
using System.Collections.Generic;
using System.Linq;

namespace DiretorSkinner.Grafo.Negocio
{
    public partial class DiretorSkinnerNegocioGrafo : IDiretorSkinnerNegocioGrafo
    {
        public List<RepetenciaDeDisciplinaPorTipoPessoaDto> ListarRepetenciaPorTodosTipos()
        {
            var graphClient = ConexaoGrafo.Client;

            List<RepetenciaDeDisciplinaPorTipoPessoaDto> list = graphClient.Cypher.Match($"(pessoa:Pessoa), (salaDeAula:SalaDeAula), (conceito:Conceito),(disciplina:Disciplina)")
                                     //.OptionalMatch("(pessoa:Pessoa)-[esta:ESTA]->(salaDeAula:SalaDeAula)")
                                     //.OptionalMatch("(disciplina:Disciplina)-[tem:TEM]->(salaDeAula:SalaDeAula)")
                                     .OptionalMatch("(pessoa:Pessoa)-[PessoaPertenceTipoPessoa:PESSOA_PERTENCE_TIPO_PESSOA]->(tipoPessoa:TipoPessoa)")
                                     .Where(" pessoa.Id = salaDeAula.PessoaId and salaDeAula.Nota > conceito.Minimo and salaDeAula.Nota <= conceito.Maximo and disciplina.Id = salaDeAula.DisciplinaId ")
                                     .With(" salaDeAula,pessoa,conceito,disciplina,tipoPessoa,{ qtd: count(salaDeAula.Semestre) } as repetencia ")
                                     .With(" repetencia, { PessoaId: pessoa.Id, PessoaNome: pessoa.Nome, TipoPessoaId: tipoPessoa.Id, TipoPessoaNome: tipoPessoa.Nome, ConceitoNome: conceito.Nome, DisciplinaNome: disciplina.Nome} as pessoa")
                                     .Where("repetencia.qtd > 1 ")
                                     .Return(pessoa => pessoa.As<RepetenciaDeDisciplinaPorTipoPessoaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public List<RepetenciaDeDisciplinaPorTipoPessoaDto> ListarRepetenciaPorTipo(int id)
        {
            var graphClient = ConexaoGrafo.Client;

            List<RepetenciaDeDisciplinaPorTipoPessoaDto> list = graphClient.Cypher.Match($"(pessoa:Pessoa), (salaDeAula:SalaDeAula), (conceito:Conceito),(tipoPessoa:TipoPessoa)")
                         .OptionalMatch("(pessoa:Pessoa)-[esta:ESTA]->(salaDeAula:SalaDeAula)")
                         .OptionalMatch("(disciplina:Disciplina)-[tem:TEM]->(salaDeAula:SalaDeAula)")
                         .OptionalMatch("(pessoa:Pessoa)-[PessoaPertenceTipoPessoa:PESSOA_PERTENCE_TIPO_PESSOA]->(tipoPessoa:TipoPessoa)")
                         .Where(" pessoa.Id = salaDeAula.PessoaId and salaDeAula.Nota > conceito.Minimo and salaDeAula.Nota <= conceito.Maximo and disciplina.Id = salaDeAula.DisciplinaId ")
                         .With("pessoa,conceito,disciplina,tipoPessoa,{ qtd: count(salaDeAula.Semestre) } as repetencia")
                         .With(" repetencia, { PessoaId: pessoa.Id, PessoaNome: pessoa.Nome, TipoPessoaId: tipoPessoa.Id, TipoPessoaNome: tipoPessoa.Nome, ConceitoNome: conceito.Nome, DisciplinaNome: disciplina.Nome} as pessoa")
                         .Where("repetencia.qtd > 1")
                         .Where<RepetenciaDeDisciplinaPorTipoPessoaDto>(pessoa => pessoa.PessoaId == id)
                         .Return(pessoa => pessoa.As<RepetenciaDeDisciplinaPorTipoPessoaDto>())
                         .Results
                         .ToList();

            graphClient.Dispose();

            return list;
        }
    }
}
