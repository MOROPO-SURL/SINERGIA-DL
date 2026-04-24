using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Enumerations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.PublicPolicy.DTOs;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Models.View;

public record PublicPolicyGroupViewModel(PublicPolicyKind Kind, PublicPolicyDetailDtoModel[] Items);
