using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Enumerations;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Internal.Operative.Constants;

public static class ConfigurationConstants
{
    public readonly static PublicPolicyKind[] AVAILABLE_PUBLIC_POLICY_KINDS = 
    [
        PublicPolicyKind.Municipal,
        PublicPolicyKind.Provincial,
        PublicPolicyKind.Territorial
,       PublicPolicyKind.National
    ];
}
