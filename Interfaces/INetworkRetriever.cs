public interface INetworkRetriever
{
	T GetFromApi<T>(string url);	
}
