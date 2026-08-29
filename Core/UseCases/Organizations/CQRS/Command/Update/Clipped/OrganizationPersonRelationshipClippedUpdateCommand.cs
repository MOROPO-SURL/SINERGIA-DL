namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Command.Update.Clipped;

public sealed class OrganizationPersonRelationshipClippedUpdateCommand
{
    public Guid PersonId { get; set; }

    public bool IsRepresentative { get; set; }
}
