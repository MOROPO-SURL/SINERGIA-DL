namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Organizations.CQRS.Command.Update.Clipped;

public sealed class OrganizationPersonRelationshipClippedUpdateCommand
{
    public Guid PersonId { get; set; }

    public bool IsRepresentative { get; set; }
}
