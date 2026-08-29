namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.CQRS.Command;

public record class ImageCreateCommand(string ContentType, byte[] ContentData, string? About = null);