
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Article
    {
        [Key]
        public int NumArticle { get; set; }
        public string Libelle { get; set; }
        public double PrixUnitaire { get; set; }
        public int QteStock { get; set; }
        public ICollection<Devis> Deviss { get; set; }

    }
}