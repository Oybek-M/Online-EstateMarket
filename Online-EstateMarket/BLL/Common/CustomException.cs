namespace Online_EstateMarket.BLL.Common;

public class CustomException(string key, string message)
    : Exception(message)
{
    public string Key { get; } = key;
}
