namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Document.CQRS.Command;

public sealed record DocumentCreateRequestModel(Guid Id, string Name, byte[] ContentData, string ContentType, string? About = null);