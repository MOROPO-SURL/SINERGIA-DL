namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Common.Models;

public class PaginateQueryResultModel<T>
{
    public T[] Items { get; set; } = [];

    public int Page { get; set; }

    public bool HasNext { get; set; }

    public bool HasPrevious { get; set; }

    public int MaxPageCount { get; set; }

    public int Limit { get; set; }
}
