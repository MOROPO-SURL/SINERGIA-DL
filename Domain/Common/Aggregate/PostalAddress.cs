namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Common.Aggregate;

public record PostalAddress(string Street, string? Number = null, string? Context = null, int? ZipCode = null, string? Name = null);