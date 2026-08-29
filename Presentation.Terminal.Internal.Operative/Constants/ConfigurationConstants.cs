using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Enumerations;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative.Constants;

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
