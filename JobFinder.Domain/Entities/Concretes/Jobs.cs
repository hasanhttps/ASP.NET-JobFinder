using JobFinder.Domain.Entities.Abstracts;

namespace JobFinder.Domain.Entities.Concretes;
public class Jobs : BaseEntity {

    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public string Name { get; set; }
    public string? Desc { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }
    public string? Gender { get; set; }
    public string? Region { get; set; }
    public string? Location { get; set; }
    public string? Schedule { get; set; }
    public string? Education { get; set; }
    public string? StateType { get; set; }
    public string Experience { get; set; }
    public int VacantionCode { get; set; }
    public string VacantionUrl { get; set; }
    public string? EntryProcess { get; set; }
    public string ProfileDemand { get; set; }
    public DateTime? ExpireDateTime { get; set; }
    public bool AcceptNotCompleteCv { get; set; }
    public bool AcceptAppealFromRetired { get; set; }

    // Foreign Key Ids

    public string UserId { get; set; }
    public int CategoryId { get; set; }

    // Navigation Property

    public virtual AppUser User { get; set; }
    public virtual Categories Category { get; set; }
}