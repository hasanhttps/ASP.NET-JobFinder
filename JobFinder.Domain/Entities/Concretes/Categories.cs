using JobFinder.Domain.Entities.Abstracts;

namespace JobFinder.Domain.Entities.Concretes;

public class Categories : BaseEntity {

    public string CategoryName { get; set; }

    // Navigation Property

    public virtual ICollection<Jobs> Jobs { get; set; }
}
