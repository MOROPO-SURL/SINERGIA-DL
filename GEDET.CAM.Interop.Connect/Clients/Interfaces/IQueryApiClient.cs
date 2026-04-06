using MOROPO.GEDET.CAM.Interop.Contracts.Models.Common;

namespace MOROPO.GEDET.CAM.Interop.Connect.Clients.Interfaces;

public interface IQueryApiClient<TId, TBasicDtoModel, TDetailDtoModel>
{
    public abstract Task<int> CountAsync();

    public abstract Task<TDetailDtoModel> GetAsync(TId id);

    public abstract Task<TBasicDtoModel[]> GetAllAsync();

    public abstract Task<PaginateResultModel<TBasicDtoModel>> GetPageAsync(int page, int limit);
}
