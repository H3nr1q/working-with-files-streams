using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace Aula7.Model
{
    public class Livro
    {
        // [Name("titulo")]
        public string Titulo { get; set; }
        // [Name("autor")]
        public string  Autor { get; set; }
        // [Name("preço")]
        // [CultureInfo("pt-br")]
        public double Preco { get; set; }
        // [Name("lançamento")]
        // [Format("dd/MM/yyyy")]
        public DateOnly Lancamento { get; set; }
    }
}