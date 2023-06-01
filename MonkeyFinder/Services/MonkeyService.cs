using System.Net.Http.Json;

namespace MonkeyFinder.Services
{
	public class MonkeyService
	{
		HttpClient httpClinet;
		public MonkeyService()
		{
			this.httpClinet = new HttpClient();
		}

		List<Monkey> monkeyList;
		public async Task<List<Monkey>> GetMonkeys()
		{
			if(monkeyList?.Count > 0) return monkeyList;

			var url = "https://montemagno.com/monkeys.json";

			var response = await httpClinet.GetAsync(url);

			if(response.IsSuccessStatusCode)
			{
				monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
			}

			return monkeyList;
		}
	}
}
