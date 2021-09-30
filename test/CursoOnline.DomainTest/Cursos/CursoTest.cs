using ExpectedObjects;
using System;
using Xunit;

namespace CursoOnline.DomainTest
{
    public class CursoTest
    {
        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = "JavaScript Avan�ado",
                CargaHoraria = (double)120,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)500
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeInvalido(string nomeInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "JavaScript Avan�ado",
                CargaHoraria = (double)120,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)500
            };

            var message = Assert.Throws<ArgumentException>(() =>
                new Curso(nomeInvalido, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor))
                .Message;
            Assert.Equal("Nome inv�lido", message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            var cursoEsperado = new
            {
                Nome = "JavaScript Avan�ado",
                CargaHoraria = (double)120,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)500
            };

            var message = Assert.Throws<ArgumentException>(() =>
                new Curso(cursoEsperado.Nome, cargaHorariaInvalida, cursoEsperado.PublicoAlvo, cursoEsperado.Valor))
                .Message;
            Assert.Equal("Carga hor�ria inv�lida", message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaValorMenorQue1(double valorInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "JavaScript Avan�ado",
                CargaHoraria = (double)120,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)500
            };

            var message = Assert.Throws<ArgumentException>(() =>
                new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, valorInvalido))
                .Message;
            Assert.Equal("Valor inv�lido", message);
        }
    }

    public enum PublicoAlvo
    {
        Estudante,
        Universitario,
        Empregado,
        Empreendedor
    }

    public class Curso
    {
        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome inv�lido");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga hor�ria inv�lida");

            if (valor < 1)
                throw new ArgumentException("Valor inv�lido");

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }
    }
}
