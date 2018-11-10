using System.Collections.Generic;
using DiretorSkinner.Grafo.Tranporte;
using DiretorSkinner.Grafo.Negocio;
using System;
using System.ServiceModel;

namespace DiretorSkinner.Grafo.Servico
{
    [ServiceBehavior(
        AutomaticSessionShutdown = true,
        ConcurrencyMode = ConcurrencyMode.Single,
        InstanceContextMode = InstanceContextMode.Single,
        IncludeExceptionDetailInFaults = true,
        UseSynchronizationContext = true,
        ValidateMustUnderstand = true)]
    public class DiretorSkinnerGrafo : IDiretorSkinnerGrafo, IDisposable
    {
        DiretorSkinnerNegocioGrafo negocio = new DiretorSkinnerNegocioGrafo();

        public void DeletarConceito(ConceitoDto conceito)
        {
            negocio.DeletarConceito(conceito);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public List<ConceitoDto> ListarConceitos()
        {
            return negocio.ListarConceitos();
        }

        public ConceitoDto ListarConceito(int id)
        {
            return negocio.ListarConceito(id);
        }

        public void SalvarConceito(ConceitoDto conceito)
        {
            negocio.SalvarConceito(conceito);
        }

        public List<DisciplinaDto> ListarDisciplinas()
        {
            return negocio.ListarDisciplinas();
        }

        public List<DisciplinaDto> ListarDisciplinaPorTipo(TipoDisciplinaDto tipoDisciplina)
        {
            return negocio.ListarDisciplinaPorTipo(tipoDisciplina);
        }

        public DisciplinaDto ListarDisciplina(int id)
        {
            return negocio.ListarDisciplina(id);
        }

        public void SalvarDisciplina(DisciplinaDto disciplina)
        {
            negocio.SalvarDisciplina(disciplina);
        }

        public void DeletarDisciplina(DisciplinaDto disciplina)
        {
            negocio.DeletarDisciplina(disciplina);
        }

        public List<PessoaDto> ListarPessoas()
        {
            return negocio.ListarPessoas();
        }

        public List<PessoaDto> ListarPessoasPesquisa(string filtro)
        {
            return negocio.ListarPessoasPesquisa(filtro);
        }

        public List<PessoaDto> ListarPessoaPorTipo(TipoPessoaDto tipoPessoa)
        {
            return negocio.ListarPessoaPorTipo(tipoPessoa);
        }

        public PessoaDto ListarPessoa(int id)
        {
            return negocio.ListarPessoa(id);
        }

        public PessoaDto ListarPessoaPorApelido(string apelido)
        {
            return negocio.ListarPessoaPorApelido(apelido);
        }

        public PessoaDto ListarPessoaPorCodigo(string codigo)
        {
            return negocio.ListarPessoaPorCodigo(codigo);
        }

        public void SalvarPessoa(PessoaDto pessoa)
        {
            negocio.SalvarPessoa(pessoa);
        }

        public void DeletarPessoa(PessoaDto pessoa)
        {
            negocio.DeletarPessoa(pessoa);
        }

        public List<TipoDisciplinaDto> ListarTiposDisciplina()
        {
            return negocio.ListarTiposDisciplina();
        }

        public TipoDisciplinaDto ListarTipoDisciplina(int id)
        {
            return negocio.ListarTipoDisciplina(id);
        }

        public void SalvarTipoDisciplina(TipoDisciplinaDto tipoDisciplina)
        {
            negocio.SalvarTipoDisciplina(tipoDisciplina);
        }

        public void DeletarTipoDisciplina(TipoDisciplinaDto tipoDisciplina)
        {
            negocio.DeletarTipoDisciplina(tipoDisciplina);
        }

        public List<TipoPessoaDto> ListarTiposPessoa()
        {
            return negocio.ListarTiposPessoa();
        }

        public TipoPessoaDto ListarTipoPessoa(int id)
        {
            return negocio.ListarTipoPessoa(id);
        }

        public List<TipoPessoaDto> ListarTipoPessoaPorPessoa(PessoaDto pessoa)
        {
            return negocio.ListarTipoPessoaPorPessoa(pessoa);
        }

        public void SalvarTipoPessoa(TipoPessoaDto tipoPessoa)
        {
            negocio.SalvarTipoPessoa(tipoPessoa);
        }

        public void DeletarTipoPessoa(TipoPessoaDto tipoPessoa)
        {
            negocio.DeletarTipoPessoa(tipoPessoa);
        }

        public List<SalaDeAulaDto> ListarSalasDeAula()
        {
            return negocio.ListarSalasDeAula();
        }

        public SalaDeAulaDto ListarSalaDeAula(int id)
        {
            return negocio.ListarSalaDeAula(id);
        }

        public List<SalaDeAulaDto> ListarSalaDeAulaPorPessoa(PessoaDto pessoa)
        {
            return negocio.ListarSalaDeAulaPorPessoa(pessoa);
        }

        public List<SalaDeAulaDto> ListarSalaDeAulaPorDisciplina(DisciplinaDto disciplina)
        {
            return negocio.ListarSalaDeAulaPorDisciplina(disciplina);
        }

        public List<SalaDeAulaDto> ListarSalaDeAulaPorConceito(ConceitoDto conceito)
        {
            return negocio.ListarSalaDeAulaPorConceito(conceito);
        }

        public List<SalaDeAulaDto> ListarSalaDeAulaPorTurma(TurmaDto turma)
        {
            return negocio.ListarSalaDeAulaPorTurma(turma);
        }

        public List<SalaDeAulaDto> ListarSalaDeAulaPorFiltros(ConceitoDto conceito, DisciplinaDto disciplina, PessoaDto pessoa, TurmaDto turma)
        {
            return negocio.ListarSalaDeAulaPorFiltros(conceito, disciplina, pessoa, turma);
        }

        public void SalvarSalaDeAula(SalaDeAulaDto turma)
        {
            negocio.SalvarSalaDeAula(turma);
        }

        public void DeletarSalaDeAula(SalaDeAulaDto turma)
        {
            negocio.DeletarSalaDeAula(turma);
        }

        public List<TurmaDto> ListarTurmas()
        {
            return negocio.ListarTurmas();
        }

        public void SalvarTurma(TurmaDto turma)
        {
            negocio.SalvarTurma(turma);
        }

        public void DeletarTurma(TurmaDto turma)
        {
            negocio.DeletarTurma(turma);
        }

        public List<PessoaPorConceitoDto> ListarPessoaPorTodosConceitos()
        {
            return negocio.ListarPessoaPorTodosConceitos();
        }

        public List<PessoaPorConceitoDto> ListarPessoaPorConceito(int id)
        {
            return negocio.ListarPessoaPorConceito(id);
        }

        public ProcessamentoDto CargaInserirConceito(int tamanho)
        {
            return negocio.CargaInserirConceito(tamanho);
        }

        public ProcessamentoDto CargaAlterarConceito(int tamanho)
        {
            return negocio.CargaAlterarConceito(tamanho);
        }

        public ProcessamentoDto CargaExcluirConceito(int tamanho)
        {
            return negocio.CargaExcluirConceito(tamanho);
        }

        public ProcessamentoDto CargaSelecionarConceito(int tamanho)
        {
            return negocio.CargaSelecionarConceito(tamanho);
        }

        public ProcessamentoDto CargaRelatorioConceito(int tamanho)
        {
            return negocio.CargaRelatorioConceito(tamanho);
        }

        public ProcessamentoDto CargaInserirDisciplina(int tamanho)
        {
            return negocio.CargaInserirDisciplina(tamanho);
        }

        public ProcessamentoDto CargaAlterarDisciplina(int tamanho)
        {
            return negocio.CargaAlterarDisciplina(tamanho);
        }

        public ProcessamentoDto CargaExcluirDisciplina(int tamanho)
        {
            return negocio.CargaExcluirDisciplina(tamanho);
        }

        public ProcessamentoDto CargaSelecionarDisciplina(int tamanho)
        {
            return negocio.CargaSelecionarDisciplina(tamanho);
        }

        public ProcessamentoDto CargaRelatorioDisciplina(int tamanho)
        {
            return negocio.CargaRelatorioDisciplina(tamanho);
        }

        public ProcessamentoDto CargaInserirSalaDeAula(int tamanho)
        {
            return negocio.CargaInserirSalaDeAula(tamanho);
        }

        public ProcessamentoDto CargaAlterarSalaDeAula(int tamanho)
        {
            return negocio.CargaAlterarSalaDeAula(tamanho);
        }

        public ProcessamentoDto CargaExcluirSalaDeAula(int tamanho)
        {
            return negocio.CargaExcluirSalaDeAula(tamanho);
        }

        public ProcessamentoDto CargaSelecionarSalaDeAula(int tamanho)
        {
            return negocio.CargaSelecionarSalaDeAula(tamanho);
        }

        public ProcessamentoDto CargaRelatorioSalaDeAula(int tamanho)
        {
            return negocio.CargaRelatorioSalaDeAula(tamanho);
        }

        public List<RepetenciaDeDisciplinaPorTipoPessoaDto> ListarRepetenciaPorTodosTipos()
        {
            return negocio.ListarRepetenciaPorTodosTipos();
        }

        public List<RepetenciaDeDisciplinaPorTipoPessoaDto> ListarRepetenciaPorTipo(int id)
        {
            return negocio.ListarRepetenciaPorTipo(id);
        }

        public List<QtdePessoaPorDisciplinaDto> ListarQtdePessoaPorTodasDisciplinas()
        {
            return negocio.ListarQtdePessoaPorTodasDisciplinas();
        }

        public List<QtdePessoaPorDisciplinaDto> ListarQtdePessoaPorDisciplina(int id)
        {
            return negocio.ListarQtdePessoaPorDisciplina(id);
        }

        public void Dispose()
        {
            negocio = null;
        }
    }
}
