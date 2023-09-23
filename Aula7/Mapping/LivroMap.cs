using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Aula7.Model;
using CsvHelper.Configuration;

namespace Aula7.Mapping
{
    public class LivroMap : ClassMap<Livro>
    {
        public LivroMap()
        {
            Map(x => x.Titulo).Name("titulo");
            Map(x => x.Preco)
                .Name("preço")
                .TypeConverterOption
                .CultureInfo(CultureInfo.GetCultureInfo("pt-BR"));
            Map(x => x.Autor).Name("autor");
            Map(x => x.Lancamento)
                .Name("lançamento")
                .TypeConverterOption
                .Format(new [] {"dd/MM/yyyy"});
        }
    }
}