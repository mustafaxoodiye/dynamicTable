namespace DynamicHeaders_api.Entities;

public class SubHeadConfig
{
    public int Id { get; set; }
    public string SubHeadId { get; set; }
    public List<SubHeadMetaData> MetaData { get; set; }=[];
}

public class SubHeadMetaData
{
    public string Key { get; set; }
    public string DisplayName { get; set; }
    public string Type { get; set; }
}