using FluentValidation;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.DevelopmentActorProfile.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Models.Page.Abstractions;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.PDL.Models.Page;

public sealed class DevelopmentActorProfileConfigurationPageModel : AbstractConfigurationPageModel<SRLDevelopmentActorProfileDetailDtoModel, SRLDevelopmentActorProfileDetailDtoModel>
{
    public DevelopmentActorProfileConfigurationPageModel(SRLDevelopmentActorProfileDetailDtoModel? model, Action<SRLDevelopmentActorProfileDetailDtoModel> successCallbackAction, IValidator validator) : base(model, successCallbackAction, validator)
    {
    }

    protected override Task<SRLDevelopmentActorProfileDetailDtoModel> PerformCreationAsync()
    {
        throw new NotImplementedException();
    }

    protected override Task<SRLDevelopmentActorProfileDetailDtoModel> PerformEditionAsync()
    {
        throw new NotImplementedException();
    }
}
