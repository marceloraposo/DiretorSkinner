using DiretorSkinner.Grafo.Interface;
using DiretorSkinner.Grafo.Tranporte;
using DiretorSkinner.Util.Acesso.Graphos;
using System.Collections.Generic;
using System.Linq;

namespace DiretorSkinner.Grafo.Negocio
{
    public partial class DiretorSkinnerNegocioGrafo : IDiretorSkinnerNegocioGrafo
    {
        public List<PessoaPorConceitoDto> ListarPessoaPorTodosConceitos()
        {
            var graphClient = ConexaoGrafo.Client;

            //List<PessoaPorConceitoDto> list = graphClient.Cypher.Match($"(pessoa:Pessoa), (salaDeAula:SalaDeAula), (conceito:Conceito)")
            //                         .OptionalMatch("(pessoa:Pessoa)-[esta:ESTA]->(salaDeAula:SalaDeAula)")
            //                         .Where(" pessoa.Id = salaDeAula.PessoaId and salaDeAula.Nota > conceito.Minimo and salaDeAula.Nota <= conceito.Maximo ")
            //                         .With(" pessoa,conceito,{ media: avg(salaDeAula.Nota) } as media_pessoa")
            //                         .With(" conceito, { Id: pessoa.Id, Codigo: pessoa.Codigo, Nome: pessoa.Nome, Media: media_pessoa.media, ConceitoId: conceito.Id, ConceitoNome: conceito.Nome} as pessoa")
            //                         .Where(" pessoa.Media > conceito.Minimo and pessoa.Media <= conceito.Maximo ")
            //                         .Return(pessoa => pessoa.As<PessoaPorConceitoDto>())
            //                         .Results
            //                         .ToList();

            List<PessoaPorConceitoDto> list = graphClient.Cypher.Match($"(pessoa:Pessoa), (salaDeAula:SalaDeAula), (conceito:Conceito)")
                                     .Where(" pessoa.Id = salaDeAula.PessoaId and salaDeAula.Nota > conceito.Minimo and salaDeAula.Nota <= conceito.Maximo ")
                                     .With(" { Media: avg(salaDeAula.Nota), Id: pessoa.Id, Codigo: pessoa.Codigo, Nome: pessoa.Nome } as pessoa")
                                     .Match(" (conceito:Conceito)")
                                     .Where(" pessoa.Media > conceito.Minimo and pessoa.Media <= conceito.Maximo ")
                                     .With(" { Media: pessoa.Media, Id: pessoa.Id, Codigo: pessoa.Codigo, Nome: pessoa.Nome, ConceitoId: conceito.Id, ConceitoNome: conceito.Nome } as pessoa ")
                                     .Return(pessoa => pessoa.As<PessoaPorConceitoDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }

        public List<PessoaPorConceitoDto> ListarPessoaPorConceito(int id)
        {
            var graphClient = ConexaoGrafo.Client;

            //List<PessoaPorConceitoDto> list = graphClient.Cypher.Match($"(pessoa:Pessoa), (salaDeAula:SalaDeAula), (conceito:Conceito)")
            //                         .OptionalMatch("(pessoa:Pessoa)-[esta:ESTA]->(salaDeAula:SalaDeAula)")
            //                         .Where(" pessoa.Id = salaDeAula.PessoaId and salaDeAula.Nota > conceito.Minimo and salaDeAula.Nota <= conceito.Maximo ")
            //                         .With("pessoa,conceito,{ media: avg(salaDeAula.Nota) } as media_pessoa")
            //                         .With(" { Id: pessoa.Id, Codigo: pessoa.Codigo, Nome: pessoa.Nome, Media: media_pessoa.media, ConceitoId: conceito.Id, ConceitoNome: conceito.Nome} as pessoa")
            //                         .Where(" pessoa.Media > conceito.Minimo and pessoa.Media <= conceito.Maximo ")
            //                         .Where<PessoaPorConceitoDto>(pessoa => pessoa.Id == id)
            //                         .Return(pessoa => pessoa.As<PessoaPorConceitoDto>())
            //                         .Results
            //                         .ToList();

            List<PessoaPorConceitoDto> list = graphClient.Cypher.Match($"(pessoa:Pessoa), (salaDeAula:SalaDeAula), (conceito:Conceito)")
                                     .Where(" pessoa.Id = salaDeAula.PessoaId and salaDeAula.Nota > conceito.Minimo and salaDeAula.Nota <= conceito.Maximo ")
                                     .With(" { Media: avg(salaDeAula.Nota), Id: pessoa.Id, Codigo: pessoa.Codigo, Nome: pessoa.Nome } as pessoa")
                                     .Match(" (conceito:Conceito)")
                                     .Where(" pessoa.Media > conceito.Minimo and pessoa.Media <= conceito.Maximo ")
                                     .With(" { Media: pessoa.Media, Id: pessoa.Id, Codigo: pessoa.Codigo, Nome: pessoa.Nome, ConceitoId: conceito.Id, ConceitoNome: conceito.Nome } as pessoa ")
                                     .Where<PessoaPorConceitoDto>(pessoa => pessoa.Id == id)
                                     .Return(pessoa => pessoa.As<PessoaPorConceitoDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;
        }
    }
}
