namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Command.Create.Clipped;

public sealed class OrganizationPersonRelationshipClippedCreateCommand
{
    public Guid PersonId { get; set; }

    public bool IsRepresentative { get; set; }
}
