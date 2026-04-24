using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Clients.Interfaces;

public interface IQueryApiClient<TId, TBasicDtoModel, TDetailDtoModel>
{
    public abstract Task<int> CountAsync();

    public abstract Task<TDetailDtoModel> GetAsync(TId id);

    public abstract Task<TDetailDtoModel[]> GetAllAsync();

    public abstract Task<PaginateResultModel<TBasicDtoModel>> GetPageAsync(int page, int limit);
}
