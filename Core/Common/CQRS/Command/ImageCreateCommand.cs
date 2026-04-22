namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.CQRS.Command;

public record class ImageCreateCommand(string ContentType, byte[] Content, string? About = null);