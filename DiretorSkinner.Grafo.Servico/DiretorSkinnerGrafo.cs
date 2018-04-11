using System.Collections.Generic;
using DiretorSkinner.Tranporte;
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

        public List<TurmaDto> ListarTurmas()
        {
            return negocio.ListarTurmas();
        }

        public List<TurmaDto> ListarTurmaPorPessoa(PessoaDto pessoa)
        {
            return negocio.ListarTurmaPorPessoa(pessoa);
        }

        public List<TurmaDto> ListarTurmaPorDisciplina(DisciplinaDto disciplina)
        {
            return negocio.ListarTurmaPorDisciplina(disciplina);
        }

        public List<TurmaDto> ListarTurmaPorConceito(ConceitoDto conceito)
        {
            return negocio.ListarTurmaPorConceito(conceito);
        }

        public List<TurmaDto> ListarTurma(ConceitoDto conceito, DisciplinaDto disciplina, PessoaDto pessoa)
        {
            return negocio.ListarTurma(conceito, disciplina, pessoa);
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
