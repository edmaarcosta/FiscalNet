﻿using FiscalNET.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalNet.Implementacoes.Icms
{
    class Icms30 : IIcms
    {
        private decimal AliqInterest { get; set; }
        private decimal AliqInterna { get; set; }
        private decimal ValorIpi { get; set; }
        private decimal DespesasAcessorias { get; set; }
        private decimal ValorFrete { get; set; }
        private decimal MVA { get; set; }
        private decimal ValorProduto { get; set; }
        private decimal ValorSeguro { get; set; }

        public Icms30(decimal aliqInterest,
            decimal aliqInterna, decimal valorIpi, decimal despesasAcessorias,
            decimal valorFrete, decimal mva, decimal valorProduto,
            decimal valorSeguro)
        {
            this.AliqInterest = aliqInterest;
            this.AliqInterna = aliqInterna;
            this.ValorIpi = valorIpi;
            this.DespesasAcessorias = despesasAcessorias;
            this.ValorFrete = valorFrete;
            this.MVA = mva;
            this.ValorProduto = valorProduto;
            this.ValorSeguro = valorSeguro;
        }
        public bool PossuiIcmsProprio
        {
            get
            {
                return false;
            }
        }

        public bool PossuiIcmsST
        {
            get
            {
                return true;
            }
        }

        public bool PossuiRedBCIcmsProprio
        {
            get
            {
                return false;
            }
        }

        public bool PossuiRedBCIcmsST
        {
            get
            {
                return false;
            }
        }

        public decimal BaseIcms()
        {
            /*
             * Base do ICMS Inter = (Valor do produto +
             *  Frete +
             *   Seguro + 
             *   Outras Despesas Acessórias – Descontos)
             * */

            decimal resultado = (ValorProduto +
                ValorFrete +
                ValorSeguro +
                DespesasAcessorias);
            return resultado;
        }

        public decimal ValorIcms()
        {
            decimal baseIcmsProprio = BaseIcms();
            decimal resultado = (AliqInterest / 100 * baseIcmsProprio);
            return resultado;
        }

        public decimal BaseIcmsST()
        {
            /*
            * (Valor do produto +
            *  Valor do IPI +
            *  Frete + 
            *  Seguro +
            *  Outras Despesas Acessórias – Descontos) * (1+(%MVA / 100))
            * */

            decimal resultado = ((ValorProduto +
                ValorIpi +
                ValorFrete +
                ValorSeguro +
                DespesasAcessorias) * (1 + (MVA / 100)));

            return resultado;
        }

        public decimal ValorIcmsST()
        {
            /* ksakjadlkasnlkdnlsak
            * (Base do ICMS ST * (Alíquota do ICMS Intra / 100)) – Valor do ICMS Inter
            * */

            decimal icmsProprio = ValorIcms();
            decimal resultado = (BaseIcmsST() * (AliqInterna / 100)) - icmsProprio;
            return resultado;
        }

        public decimal PercRedBaseIcms()
        {
            throw new NotImplementedException();
        }

        public decimal PercRedBaseIcmsST()
        {
            throw new NotImplementedException();
        }                

        public decimal ValorRedBaseIcms()
        {
            throw new NotImplementedException();
        }

        public decimal ValorRedBaseIcmsST()
        {
            throw new NotImplementedException();
        }
    }
}