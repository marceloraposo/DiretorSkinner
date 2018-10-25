using DiretorSkinner.Interface;
using DiretorSkinner.Negocio.Entidades;
using DiretorSkinner.Tranporte;
using DiretorSkinner.Util.Acesso;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace DiretorSkinner.Negocio
{
    public partial class DiretorSkinnerNegocio : IDiretorSkinnerNegocio
    {
        public List<PessoaPorConceitoDto> ListarPessoaPorTodosConceitos()
        {
            List<PessoaPorConceitoDto> list = new List<PessoaPorConceitoDto>();
            PessoaPorConceito PessoaPorConceito;
            SQLiteCommand cmd = new SQLiteCommand("select * from PessoaPorConceito");
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                PessoaPorConceito = new PessoaPorConceito();
                PessoaPorConceito.Id = item.ToInteger("Id");
                PessoaPorConceito.Nome = item.ToString("Nome");
                PessoaPorConceito.Conceito = item.ToString("conceito");
                list.Add(PessoaPorConceito.ToDto());
            }

            return list;
        }

        public List<PessoaPorConceitoDto> ListarPessoaPorConceito(int id)
        {
            List<PessoaPorConceitoDto> list = new List<PessoaPorConceitoDto>();
            PessoaPorConceito PessoaPorConceito;
            SQLiteCommand cmd = new SQLiteCommand("select * from PessoaPorConceito");
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                PessoaPorConceito = new PessoaPorConceito();
                PessoaPorConceito.Id = item.ToInteger("Id");
                PessoaPorConceito.Nome = item.ToString("Nome");
                PessoaPorConceito.Conceito = item.ToString("conceito");
                list.Add(PessoaPorConceito.ToDto());
            }

            return list;
        }
    }
}
