using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Common.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.OrganizationKind.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Organization.DTOs;

public record OrganizationDetailDtoModel(
  Guid Id,
  string Name,
  bool IsEnabled,
  bool IsArchived,
  int Priority,
  OrganizationKindBasicDtoModel Kind,
  EmailAddressDetailDtoModel[] EmailAddresses,
  PhoneNumberDetailDtoModel[] PhoneNumbers,
  PostalAddressDetailDtoModel[] PostalAddresses,
  WebSiteAddressDetailDtoModel[] WebSiteAddresses,
  string? Alias = null,
  string? About = null,
  ImageBasicDtoModel? Image = null);
