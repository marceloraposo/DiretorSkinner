using DiretorSkinner.Grafo.Interface;
using DiretorSkinner.Grafo.Tranporte;
using DiretorSkinner.Util.Acesso.Graphos;
using System.Collections.Generic;
using System.Linq;

namespace DiretorSkinner.Grafo.Negocio
{
    public partial class DiretorSkinnerNegocioGrafo : IDiretorSkinnerNegocioGrafo
    {
        public List<QtdePessoaPorDisciplinaDto> ListarQtdePessoaPorTodasDisciplinas()
        {
            var graphClient = ConexaoGrafo.Client;

            List<QtdePessoaPorDisciplinaDto> list = graphClient.Cypher.Match($"(pessoa:Pessoa)")
                                     .OptionalMatch("(pessoa:Pessoa)-[esta:ESTA]->(salaDeAula:SalaDeAula)")
                                     .OptionalMatch("(disciplina:Disciplina)-[tem:TEM]->(salaDeAula:SalaDeAula)")
                                     .With(" disciplina,{ valor: count(salaDeAula.PessoaId) } as quantidade")
                                     .With(" quantidade, { DisciplinaId: disciplina.Id, DisciplinaNome: disciplina.Nome, Quantidade: quantidade.valor} as pessoa")
                                     .Return(pessoa => pessoa.As<QtdePessoaPorDisciplinaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public List<QtdePessoaPorDisciplinaDto> ListarQtdePessoaPorDisciplina(int id)
        {
            var graphClient = ConexaoGrafo.Client;

            List<QtdePessoaPorDisciplinaDto> list = graphClient.Cypher.Match($"(pessoa:Pessoa)")
                                     .OptionalMatch("(pessoa:Pessoa)-[esta:ESTA]->(salaDeAula:SalaDeAula)")
                                     .OptionalMatch("(disciplina:Disciplina)-[tem:TEM]->(salaDeAula:SalaDeAula)")
                                     .With(" disciplina,{ valor: count(salaDeAula.PessoaId) } as quantidade")
                                     .With(" quantidade, { DisciplinaId: disciplina.Id, DisciplinaNome: disciplina.Nome, Quantidade: quantidade.valor} as pessoa")
                                     .Where<QtdePessoaPorDisciplinaDto>(pessoa => pessoa.DisciplinaId == id)
                                     .Return(pessoa => pessoa.As<QtdePessoaPorDisciplinaDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }
    }
}
