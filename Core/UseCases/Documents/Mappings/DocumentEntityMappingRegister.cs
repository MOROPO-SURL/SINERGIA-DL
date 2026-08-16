using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Documents.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DocumentAggregate;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.DocumentAggregate.Values;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Documents.Mappings;

internal sealed class DocumentEntityMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<DocumentId, Guid>()
            .MapWith(src => src.Value);

        config.NewConfig<Document, DocumentBasicDto>()
            .Map(dest => dest.Extension, src => MimeTypes.MimeTypeMap.GetExtension(src.ContentType))
            .Map(dest => dest, src => src);
    }
}