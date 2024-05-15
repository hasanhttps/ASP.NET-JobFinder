using JobFinder.Domain.Entities.Abstracts;

namespace JobFinder.Domain.Entities.Concretes;
public class Jobs : BaseEntity {

    public string Title {  get; set; }
    public string StateType { get; set; }
    public string WorkingSchedule { get; set; }
    public string StandartEntranceProccess { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public string VacancyCode { get; set; }
    public string VacancyUrl { get; set; }
    public string ProfileRequierments { get; set; }
    public DateTime ExpireDateTime { get; set; }

    // Foreign Key Ids

    public int AppUserId { get; set; }
}