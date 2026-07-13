namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command;

public record class ImageCreateCommand(string ContentType, byte[] ContentData, string? About = null);