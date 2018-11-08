using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiretorSkinner.Dados.Gerador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiretorSkinner.Dados.Gerador.Tests
{
    [TestClass()]
    public class PessoaGeradorTests
    {
        [TestMethod()]
        public void gerarPessoaTipoPessoaTest()
        {
            PessoaGerador x = new PessoaGerador();
            x.gerarPessoaTipoPessoa();
            Assert.Fail();
        }
    }
}