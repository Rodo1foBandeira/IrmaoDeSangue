using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IrmaoDeSangue.Business;

namespace IrmaoDeSangue.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var _processarAgendamento = new ProcessarAgendamentoBusiness();

            _processarAgendamento.Processar();
        }
    }
}
