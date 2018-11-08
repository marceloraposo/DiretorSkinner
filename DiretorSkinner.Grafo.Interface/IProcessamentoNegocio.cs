﻿using DiretorSkinner.Grafo.Tranporte;
using System.Collections.Generic;
using System.ServiceModel;

namespace DiretorSkinner.Grafo.Interface
{
    [ServiceKnownType(typeof(ProcessamentoDto))]
    public partial interface IDiretorSkinnerNegocioGrafo
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
        ProcessamentoDto CargaInserirDisciplina(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaAlterarDisciplina(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaExcluirDisciplina(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaSelecionarDisciplina(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaInserirSalaDeAula(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaAlterarSalaDeAula(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaExcluirSalaDeAula(int tamanho);

        [OperationContract]
        ProcessamentoDto CargaSelecionarSalaDeAula(int tamanho);
    }
}
