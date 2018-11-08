
using DiretorSkinner.Grafo.Negocio;
using DiretorSkinner.Negocio;
using DiretorSkinner.Tranporte;
using System.Collections.Generic;

namespace DiretorSkinner.Dados.Gerador
{
    public class PessoaGerador
    {
        DiretorSkinnerNegocio negocio = new DiretorSkinnerNegocio();
        DiretorSkinnerNegocioGrafo negocioGrafo = new DiretorSkinnerNegocioGrafo();

        public void gerarPessoaTipoPessoa()
        {
            List<PessoaDto> listPessoa = negocio.ListarPessoasPesquisa("raposo");
            int tipoPessoaId;

            foreach (PessoaDto pessoaDto in listPessoa)
            {

                if (pessoaDto.Id % 20 == 0 && pessoaDto.Id % 500 != 0)
                    tipoPessoaId = 2;
                else if (pessoaDto.Id % 500 == 0)
                    tipoPessoaId = 3;
                else
                    tipoPessoaId = 1;

                pessoaDto.TipoPessoas.Add(new TipoPessoaDto() { Id = tipoPessoaId });

                negocioGrafo.SalvarPessoa(pessoaDto);
            }
        }
    }
}
