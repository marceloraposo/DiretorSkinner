
using DiretorSkinner.Negocio;
using DiretorSkinner.Tranporte;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DiretorSkinner.Dados.Gerador
{
    class TurmaGerador
    {
        DiretorSkinnerNegocio negocio = new DiretorSkinnerNegocio();

        //public string gerarTurmas()
        //{
        //    List<PessoaDto> listPessoa = negocio.ListarPessoas();
        //    List<DisciplinaDto> listDisciplina = negocio.ListarDisciplinas();
        //    TurmaDto turmaDto; Random random;
        //    string ret = string.Empty;
        //    foreach (PessoaDto pessoaDto in listPessoa)
        //    {
        //        //sorteio de disciplinas
        //        random = new Random();

        //        //montando a turma
        //        turmaDto = new TurmaDto();
        //        turmaDto.PessoaId = pessoaDto.Id;
        //        turmaDto.Semestre = "2018.1";
        //        turmaDto.DisciplinaId = listDisciplina[random.Next(listDisciplina.FirstOrDefault().Id, listDisciplina.LastOrDefault().Id)].Id;

        //        ret = string.Format("{0}{1}insert into turma( PessoaId, DisciplinaId, Semestre) values({2}, {3}, '{4}'); ", ret, Environment.NewLine, turmaDto.PessoaId, turmaDto.DisciplinaId, turmaDto.Semestre);
        //        //negocio.SalvarTurma(turmaDto);
        //    }
        //    return ret;

        //}
    }
}
