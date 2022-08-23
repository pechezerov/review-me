using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ReviewMe.WebAPI.DataAccess;
using ReviewMe.WebAPI.Infrastructure;
using ReviewMe.WebAPI.Model;

namespace ReviewMe.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;
        private readonly IOptions<AppSettings> _options;

        public WeatherController(ILogger<WeatherController> logger, IOptions<AppSettings> options)
        {
            _logger = logger;
            _options = options;
        }

        /// <summary>
        /// Возвращает краткий прогноз погоды
        /// </summary>
        [HttpGet("GetForecastShort")]
        public WeatherForecast GetShortForecst(DateTime t, string city, CancellationToken ct = default)
        {
            // Проверяем аргументы
            if (t == null)
            {
                _logger.LogError("t is null");
                throw new Exception("t is null");
            }

            if (city == null)
            {
                _logger.LogError("name is null");
                throw new Exception("name is null");
            }

            // Проверяем доступен ли город для прогноза
            // (доступны не все города)
            try
            {
                CheckCityName(city);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "check city");
                throw;
            }

            // Запрашиваем данные из БД
            var repo = new WeatherRepository(_options);
            return repo.GetWeatherForecast(t, city, ct).Result;
        }

        /// <summary>
        /// Возвращает подробный прогноз погоды (по часам)
        /// </summary>
        [HttpGet("GetForecastFull")]
        public WeatherForecast GetFullForecast(DateTime t, string city, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Проверяет, доступен ли город для прогноза
        /// </summary>
        private void CheckCityName(string cityName)
        {
            var cityNames = new[] 
            {
                "Москва",
                "Санкт-Петербург",
                "Новосибирск",
                "Екатеринбург",
                "Нижний",
                "Новгород",
                "Казань",
                "Челябинск",
                "Омск",
                "Самара",
                "Ростов-на-Дону",
                "Уфа",
                "Красноярск",
                "Пермь",
                "Воронеж",
                "Волгоград",
                "Краснодар",
                "Саратов",
                "Тюмень",
                "Тольятти",
                "Ижевск",
                "Барнаул",
                "Иркутск",
                "Ульяновск",
                "Хабаровск",
                "Ярославль",
                "Владивосток",
                "Махачкала",
                "Томск",
                "Оренбург",
                "Кемерово",
                "Новокузнецк",
                "Рязань",
                "Астрахань",
                "Набережные",
                "Челны",
                "Пенза",
                "Липецк"
            };

            if (!cityNames.Contains(cityName))
                throw new Exception("city is unsupported");
        }
    }
}