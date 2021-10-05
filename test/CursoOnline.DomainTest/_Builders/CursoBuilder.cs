using System;
using System.Collections.Generic;
using System.Text;

namespace CursoOnline.DomainTest._Builders
{
    public class CursoBuilder
    {
        private string _nome = "JavaScript Avançado";
        private string _descricao = "Descricao";
        private double _cargaHoraria = (double)120;
        private PublicoAlvo _publicoAlvo = PublicoAlvo.Estudante;
        private double _valor = 500;

        public static CursoBuilder Novo()
        {
            return new CursoBuilder();
        }

        public CursoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public CursoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public CursoBuilder ComCarcaHoraria(double cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder ComPublicAlvo(PublicoAlvo publicoAlvo)
        {
            _publicoAlvo = publicoAlvo;
            return this;
        }

        public CursoBuilder ComValor(double valor)
        {
            _valor = valor;
            return this;
        }

        public Curso Build()
        {
            return new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valor);
        }
    }
}
