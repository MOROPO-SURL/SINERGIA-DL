namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate.Intefaces;

public interface IPersistenceSignable
{
    string Signature { get; set; }

    object GetSignableEntityModel();
}
