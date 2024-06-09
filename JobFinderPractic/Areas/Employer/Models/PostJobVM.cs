using JobFinder.Domain.Entities.Concretes;

namespace JobFinderPractic.Areas.Employer.Models;

public class PostJobVM {

    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public string Name { get; set; }
    public string? Desc { get; set; }
    public string? Region { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }
    public string? Gender { get; set; }
    public int CategoryId { get; set; }
    public string? Schedule { get; set; }
    public string? Location { get; set; }
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
    public ICollection<Categories>? Categories { get; set; }
}
