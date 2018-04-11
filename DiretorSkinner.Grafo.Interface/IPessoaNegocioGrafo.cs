using DiretorSkinner.Tranporte;
using System.Collections.Generic;
using System.ServiceModel;

namespace DiretorSkinner.Grafo.Interface
{
    [ServiceKnownType(typeof(PessoaDto))]
    public partial interface IDiretorSkinnerNegocioGrafo
    {
        [OperationContract]
        List<PessoaDto> ListarPessoas();

        [OperationContract]
        List<PessoaDto> ListarPessoasPesquisa(string filtro);

        [OperationContract]
        List<PessoaDto> ListarPessoaPorTipo(TipoPessoaDto tipoPessoa);

        [OperationContract]
        PessoaDto ListarPessoa(int id);

        [OperationContract]
        PessoaDto ListarPessoaPorApelido(string apelido);

        [OperationContract]
        PessoaDto ListarPessoaPorCodigo(string codigo);

        [OperationContract]
        void SalvarPessoa(PessoaDto pessoa);

        [OperationContract]
        void DeletarPessoa(PessoaDto pessoa);
    }
}
