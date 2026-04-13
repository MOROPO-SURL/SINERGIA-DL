namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate.Intefaces;

public interface IPersistenceSignable
{
    string Signature { get; set; }

    object GetSignableEntityModel();
}
