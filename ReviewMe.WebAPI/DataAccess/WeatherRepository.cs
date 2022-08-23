using Npgsql;
using Dapper;
using Microsoft.Extensions.Options;
using ReviewMe.WebAPI.Model;
using ReviewMe.WebAPI.Infrastructure;

namespace ReviewMe.WebAPI.DataAccess
{
    public class WeatherRepository
    {
        private readonly AppSettings _options;

        public WeatherRepository(IOptions<AppSettings> options)
        {
            _options = options.Value;
        }

        protected async Task<NpgsqlConnection> CreateConnectionAsync(CancellationToken ct)
        {
            var connection = new NpgsqlConnection(_options.ConnectionString);
            await connection.OpenAsync(ct);
            return connection;
        }

        /// <summary>
        /// Возвращает прогноза погоды для указанного города на указанный день
        /// </summary>
        public async Task<WeatherForecast> GetWeatherForecast(DateTime t, string name, CancellationToken ct)
        {
            using var conn = await CreateConnectionAsync(ct);

            var sql = $@"
                SELECT *
                FROM weather_forecasts w
                JOIN cities c ON c.id = w.city_id
                WHERE c.name = {name}
                AND w.date = '{t.ToString("yyyy-MM-dd")}'";

            return await conn.QuerySingleOrDefaultAsync<WeatherForecast>(sql);
        }
    }
}