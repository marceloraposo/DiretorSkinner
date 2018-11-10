using DiretorSkinner.Tranporte;
using System.Collections.Generic;
using System.ServiceModel;

namespace DiretorSkinner.Interface
{
    [ServiceKnownType(typeof(ProcessamentoDto))]
    public partial interface IDiretorSkinnerNegocio
    {

        [OperationContract]
        ProcessamentoDto CargaInserirConceito(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaAlterarConceito(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaExcluirConceito(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaSelecionarConceito(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaRelatorioConceito(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaInserirDisciplina(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaAlterarDisciplina(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaExcluirDisciplina(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaSelecionarDisciplina(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaRelatorioDisciplina(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaInserirSalaDeAula(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaAlterarSalaDeAula(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaExcluirSalaDeAula(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaSelecionarSalaDeAula(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaRelatorioSalaDeAula(int tamanho);
    }
}
