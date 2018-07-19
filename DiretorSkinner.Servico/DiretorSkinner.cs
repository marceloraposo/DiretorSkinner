using System.Collections.Generic;
using DiretorSkinner.Tranporte;
using DiretorSkinner.Negocio;
using System;
using System.ServiceModel;

namespace DiretorSkinner.Servico
{
    [ServiceBehavior(
        AutomaticSessionShutdown = true,
        ConcurrencyMode = ConcurrencyMode.Single,
        InstanceContextMode = InstanceContextMode.Single,
        IncludeExceptionDetailInFaults = true,
        UseSynchronizationContext = true,
        ValidateMustUnderstand = true)]
    public class DiretorSkinner : IDiretorSkinner, IDisposable
    {
        DiretorSkinnerNegocio negocio = new DiretorSkinnerNegocio();

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

        public List<SalaDeAulaDto> ListarSalaDeAula(ConceitoDto conceito, DisciplinaDto disciplina, PessoaDto pessoa, TurmaDto turma)
        {
            return negocio.ListarSalaDeAula(conceito, disciplina, pessoa, turma);
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

        public void Dispose()
        {
            negocio = null;
        }
    }
}
