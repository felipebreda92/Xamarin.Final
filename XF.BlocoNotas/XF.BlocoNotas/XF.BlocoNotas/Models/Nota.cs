using System.ComponentModel;
using SQLite;

namespace XF.BlocoNotas.Models
{
    [Table("Anotacoes")]
    public class Nota
    {
        [PrimaryKey,AutoIncrement]
        [DefaultValue(0)]
        public int Id { get; set; }

        [NotNull]
        [DefaultValue("")]
        public string Titulo { get; set; }

        [DefaultValue("")]
        public string Dados { get; set; }

        [NotNull]
        [DefaultValue(false)]
        public bool Favorito { get; set; }



    }
}
