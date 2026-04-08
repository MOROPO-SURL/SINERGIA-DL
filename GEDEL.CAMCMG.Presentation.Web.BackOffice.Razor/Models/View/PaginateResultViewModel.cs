namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Models.View;

public class PaginateResultViewModel<T>
{
    public T[] Items { get; set; } = [];

    public int Page { get; set; }

    public bool HasNext { get; set; }

    public bool HasPrevious { get; set; }

    public int MaxPageCount { get; set; }

    public int Limit { get; set; }

    public string Action { get; set; } = null!;

    public object? Filter { get; set; }

    public IDictionary<string, string> RouteValues { get; set; } = null!;
}
