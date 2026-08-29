using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command.Interfaces;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Command.Unarchive;

public record OrganizationUnarchiveCommand(Guid Id) : IUnarchiveCommand<Guid>;