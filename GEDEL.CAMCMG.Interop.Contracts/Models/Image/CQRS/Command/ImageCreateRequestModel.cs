namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.CQRS.Command;

public sealed record ImageCreateRequestModel(Guid Id, byte[] ContentData, string ContentType, string? About = null);