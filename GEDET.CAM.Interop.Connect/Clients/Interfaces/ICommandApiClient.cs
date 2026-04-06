namespace MOROPO.GEDET.CAM.Interop.Connect.Clients.Interfaces;

public interface ICommandApiClient<TId, TCreateRequestModel, TUpdateRequestModel, TDetailDtoModel>
{
    public Task<TDetailDtoModel> AddAsync(TCreateRequestModel model);

    public Task<TDetailDtoModel> UpdateAsync(TUpdateRequestModel model);

    public Task DeleteAsync(TId id);
}
