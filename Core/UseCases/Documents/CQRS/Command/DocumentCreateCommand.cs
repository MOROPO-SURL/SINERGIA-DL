namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Documents.CQRS.Command;

public record class DocumentCreateCommand(string Name, string ContentType, byte[] ContentData, string? About = null);