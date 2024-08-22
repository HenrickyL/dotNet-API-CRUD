using StudentApi.Data;
using StudentApi.Models;

namespace StudentApi.Services;

public class CohortService
{
    private readonly IUnitOfWork _unitOfWork;

    public CohortService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Cohort>> GetAllCohortsAsync()
    {
        return await _unitOfWork.Cohorts.GetAllAsync();
    }

    public async Task<Cohort?> GetCohortByIdAsync(string id)
    {
        return await _unitOfWork.Cohorts.GetByIdAsync(Guid.Parse(id));
    }

    public async Task AddCohortAsync(Cohort cohort)
    {
        await _unitOfWork.Cohorts.AddAsync(cohort);
    }

    public async Task UpdateCohortAsync(string id, Cohort cohort)
    {
        await _unitOfWork.Cohorts.UpdateAsync(cohort);
    }

    public async Task RemoveCohortAsync(string id)
    {

        var cohort = await _unitOfWork.Cohorts.GetByIdAsync(new Guid(id));
        await _unitOfWork.Cohorts.RemoveAsync(cohort);
    }
}
