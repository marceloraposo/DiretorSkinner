using DiretorSkinner.Interface;
using DiretorSkinner.Negocio.Entidades;
using DiretorSkinner.Tranporte;
using DiretorSkinner.Util.Acesso;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DiretorSkinner.Negocio
{
    public partial class DiretorSkinnerNegocio : IDiretorSkinnerNegocio
    {
        public List<PessoaPorConceitoDto> ListarPessoaPorTodosConceitos()
        {
            List<PessoaPorConceitoDto> list = new List<PessoaPorConceitoDto>();
            PessoaPorConceito PessoaPorConceito;
            SqlCommand cmd = new SqlCommand("SELECT id,codigo,nome,media,(select cc.Id from conceito cc where media > cc.Minimo and media <= cc.Maximo) conceitoid,(select cc.Nome from conceito cc where media > cc.Minimo and media <= cc.Maximo) conceitonome FROM (SELECT p.id,p.codigo,p.nome,AVG(sda.nota) AS media FROM saladeaula sda,pessoa p,conceito c WHERE p.id = sda.pessoaid AND sda.nota >= c.minimo AND   sda.nota <= c.maximo GROUP BY p.nome, p.codigo, p.codigo,p.id ) x");
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                PessoaPorConceito = new PessoaPorConceito();
                PessoaPorConceito.Id = item.ToInteger("Id");
                PessoaPorConceito.Codigo = item.ToString("Codigo");
                PessoaPorConceito.Nome = item.ToString("Nome");
                PessoaPorConceito.Media = item.ToDecimal("Media");
                PessoaPorConceito.Conceito = new Conceito();
                PessoaPorConceito.Conceito.Id = item.ToInteger("conceitoId");
                PessoaPorConceito.Conceito.Nome = item.ToString("conceitoNome");
                list.Add(PessoaPorConceito.ToDto());
            }

            return list;
        }

        public List<PessoaPorConceitoDto> ListarPessoaPorConceito(int id)
        {
            List<PessoaPorConceitoDto> list = new List<PessoaPorConceitoDto>();
            PessoaPorConceito PessoaPorConceito;
            SqlCommand cmd = new SqlCommand("SELECT id,codigo,nome,media,(select cc.Id from conceito cc where media > cc.Minimo and media <= cc.Maximo) conceitoid,(select cc.Nome from conceito cc where media > cc.Minimo and media <= cc.Maximo) conceitonome FROM (SELECT p.id,p.codigo,p.nome,AVG(sda.nota) AS media FROM saladeaula sda,pessoa p,conceito c WHERE p.id = sda.pessoaid AND sda.nota >= c.minimo AND   sda.nota <= c.maximo GROUP BY p.nome, p.codigo, p.codigo,p.id ) x where x.conceitoid = @conceitoId");
            List<SqlParameter>  pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("conceitoId",id));
            cmd.Parameters.AddRange(pars.ToArray());
            DataSet ds = Conexao.ExecutarDataSet(cmd);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                PessoaPorConceito = new PessoaPorConceito();
                PessoaPorConceito.Id = item.ToInteger("Id");
                PessoaPorConceito.Codigo = item.ToString("Codigo");
                PessoaPorConceito.Nome = item.ToString("Nome");
                PessoaPorConceito.Media = item.ToDecimal("Media");
                PessoaPorConceito.Conceito = new Conceito();
                PessoaPorConceito.Conceito.Id = item.ToInteger("conceitoId");
                PessoaPorConceito.Conceito.Nome = item.ToString("conceitoNome");
                list.Add(PessoaPorConceito.ToDto());
            }

            return list;
        }
    }
}
