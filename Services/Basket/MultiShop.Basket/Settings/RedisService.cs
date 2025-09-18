using StackExchange.Redis;

namespace MultiShop.Basket.Settings;

public class RedisService
{
    private readonly string _host;
    private readonly int _port;

    private ConnectionMultiplexer _connection;
    public RedisService( string host ,int port)
    {
        _port = port;
        _host = host;
    }
    
    public void Connect()=>_connection = ConnectionMultiplexer.Connect($"{_host}:{_port}");

    public IDatabase GetDb(int db=1)=>_connection.GetDatabase(0);
  
}