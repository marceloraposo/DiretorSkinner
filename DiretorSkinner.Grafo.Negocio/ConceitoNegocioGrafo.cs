using DiretorSkinner.Grafo.Interface;
using DiretorSkinner.Grafo.Tranporte;
using DiretorSkinner.Util.Acesso.Graphos;
using System.Collections.Generic;
using System.Linq;

namespace DiretorSkinner.Grafo.Negocio
{
    public partial class DiretorSkinnerNegocioGrafo : IDiretorSkinnerNegocioGrafo
    {
        public List<ConceitoDto> ListarConceitos()
        {
            var graphClient = ConexaoGrafo.Client;
            List<ConceitoDto> list = graphClient.Cypher.Match($"(conceito:Conceito)")
                                     .Return(conceito => conceito.As<ConceitoDto>())
                                     .Results
                                     .ToList();

            graphClient.Dispose();

            return list;

        }

        public ConceitoDto ListarConceito(int id)
        {
            var graphClient = ConexaoGrafo.Client;
            ConceitoDto conceitoDto = graphClient.Cypher.Match($"(conceito:Conceito)")
                                     .Where<ConceitoDto>(conceito => conceito.Id == id)
                                     .Return(e => e.As<ConceitoDto>())
                                     .Results
                                     .SingleOrDefault();

            graphClient.Dispose();

            return conceitoDto;
        }

        public void SalvarConceito(ConceitoDto conceitoDto)
        {
            var graphClient = ConexaoGrafo.Client;

            if (conceitoDto.Id > 0)
            {
                graphClient.Cypher.Match("(conceito:Conceito)")
                                         .Where<ConceitoDto>(conceito => conceito.Id == conceitoDto.Id)
                                         .Set("conceito.Nome = {Nome}")
                                         .Set("conceito.Codigo = {Codigo}")
                                         .Set("conceito.Aprovado = {Aprovado}")
                                         .Set("conceito.Minimo = {Minimo}")
                                         .Set("conceito.Maximo = {Maximo}")
                                         .WithParam("Nome", conceitoDto.Nome)
                                         .WithParam("Codigo", conceitoDto.Codigo)
                                         .WithParam("Aprovado", conceitoDto.Aprovado)
                                         .WithParam("Minimo", conceitoDto.Minimo)
                                         .WithParam("Maximo", conceitoDto.Maximo)
                                         .ExecuteWithoutResults();
            }
            else
            {

                conceitoDto.Id = graphClient.Cypher.Match($"(conceito:Conceito)")
                                         .Return(() => Neo4jClient.Cypher.Return.As<int>("MAX(conceito.Id)"))
                                         .Results
                                         .SingleOrDefault() + 1;

                graphClient.Cypher.Create("(conceito:Conceito{ Nome: {Nome}, Codigo: {Codigo} , Aprovado: {Aprovado},Minimo: {Minimo},Maximo: {Maximo}, Id: {Id} } )")
                                         .WithParam("Nome", conceitoDto.Nome)
                                         .WithParam("Codigo", conceitoDto.Codigo)
                                         .WithParam("Aprovado", conceitoDto.Aprovado)
                                         .WithParam("Minimo", conceitoDto.Minimo)
                                         .WithParam("Maximo", conceitoDto.Maximo)
                                         .WithParam("Id", conceitoDto.Id)
                                         .ExecuteWithoutResults();
            }

            graphClient.Dispose();

        }

        public void DeletarConceito(ConceitoDto conceitoDto)
        {
            var graphClient = ConexaoGrafo.Client;

            graphClient.Cypher.Match($"(conceito:Conceito)")
                              .Where<PessoaDto>(conceito => conceito.Id == conceitoDto.Id)
                              .DetachDelete("conceito")
                              .ExecuteWithoutResults();

            graphClient.Dispose();
        }

    }
}
