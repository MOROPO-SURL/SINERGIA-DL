using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Bridges;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Configurations;

internal class ProgramExecutionProyectProgramObjetiveBridgeEntityTypeConfiguration// : IEntityTypeConfiguration<ProgramExecutionProyectProgramObjetiveBridge>
{
    //private const string TABLE_NAME = "programexecutionproyect_programobjetive_bridges";

    //public void Configure(EntityTypeBuilder<ProgramExecutionProyectProgramObjetiveBridge> builder)
    //{
    //    builder.ToTable(TABLE_NAME);

    //    builder.HasKey(bridge => new { bridge.MainId, bridge.LinkedId });

    //    builder.HasOne(bridge => bridge.Main).WithMany(entity => entity.ProgramObjetiveBridges).HasForeignKey(bridge => bridge.MainId).OnDelete(DeleteBehavior.Cascade);
    //    builder.HasOne(bridge => bridge.Linked).WithMany().HasForeignKey(bridge => bridge.LinkedId).OnDelete(DeleteBehavior.Cascade);
    //}
}
