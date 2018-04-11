using DiretorSkinner.Tranporte;
using System.Collections.Generic;
using System.ServiceModel;

namespace DiretorSkinner.Grafo.Interface
{
    [ServiceKnownType(typeof(TipoPessoaDto))]
    public partial interface IDiretorSkinnerNegocioGrafo
    {
        [OperationContract]
        List<TipoPessoaDto> ListarTiposPessoa();

        [OperationContract]
        TipoPessoaDto ListarTipoPessoa(int id);

        [OperationContract]
        List<TipoPessoaDto> ListarTipoPessoaPorPessoa(PessoaDto pessoa);

        [OperationContract]
        void SalvarTipoPessoa(TipoPessoaDto tipoPessoa);

        [OperationContract]
        void DeletarTipoPessoa(TipoPessoaDto tipoPessoa);
    }
}
