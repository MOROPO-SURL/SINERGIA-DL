namespace MOROPO.GEDET.CAM.Core.Common.Query.Abstractions;

public abstract class AbstractPaginateQuery<T>
{
    public T[] Items { get; set; } = [];

    public int Page { get; set; }

    public bool HasNext { get; set; }

    public bool HasPrevious { get; set; }

    public int MaxPageCount { get; set; }

    public int Limit { get; set; }
}
