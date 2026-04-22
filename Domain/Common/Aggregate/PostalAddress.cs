namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Common.Aggregate;

public record PostalAddress(string Street, string? Number = null, string? Context = null, int? ZipCode = null, string? Name = null);