namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Document.CQRS.Command;

public sealed record DocumentCreateRequestModel(Guid Id, string Name, byte[] ContentData, string ContentType, string? About = null);