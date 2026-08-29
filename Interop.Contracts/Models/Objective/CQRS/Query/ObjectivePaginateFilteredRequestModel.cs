namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Objective.CQRS.Query;

public record ObjectivePaginateFilteredRequestModel(int Page, int Limit, string Parameter);