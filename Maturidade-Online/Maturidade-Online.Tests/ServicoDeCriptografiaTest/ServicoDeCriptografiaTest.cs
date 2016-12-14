using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maturidade_Online.Dominio.Infraestrutura;
using Maturidade_Online.Infraestrutura;

namespace Maturidade_Online.Tests.ServicoDeCriptografiaTest
{
    [TestClass]
    public class ServicoDeCriptografiaTest
    {

        [TestMethod]
        public void CriptografarSenhaComMD5()
        {
            var servico = new ServicoDeCriptografia();

            string senhaSemCriptografia = "crescer";

            string senhaCriptografada =
                servico.Criptografar(senhaSemCriptografia);

            Assert.AreEqual("6f1d81c734062fe646d96eb97dfd1d9c", senhaCriptografada);

        }

        [TestMethod]
        public void CriptografarSenhaComMD5DandoErro()
        {

            var servico = new ServicoDeCriptografia();

            string senhaSemCriptografia = "magia";
            string senhaCriptografada =
                servico.Criptografar(senhaSemCriptografia);

            //Criptografia correta: 98ce3010caf21876324addaf1a0f4aa2
            //Diferença está no ultimo caracter
            Assert.AreNotEqual("98ce3010caf21876324addaf1a0f4aa1", senhaCriptografada);

        }
    }
}
