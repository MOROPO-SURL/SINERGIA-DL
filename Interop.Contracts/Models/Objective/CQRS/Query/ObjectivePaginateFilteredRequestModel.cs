namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Objective.CQRS.Query;

public record ObjectivePaginateFilteredRequestModel(int Page, int Limit, string Parameter);