namespace Bridgeway.Test.Acceptance.Brokers.Options;

/*
    These options are ignored by JSON Placeholder API, 
    aslong as they don't have pagination features implemented.
*/
public class GetTodoOptions : BaseOptions, IUrlEncoded
{
    public int Page { get; set; }

    public int Limit { get; set; }
}
