namespace ReviewMe.WebAPI.Model
{
    /// <summary>
    /// Прогноз погоды в отдельном взятом месте в фиксированный момент времени
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Температура, в градусах Цельсия
        /// </summary>
        public int Temperature { get; set; }

        /// <summary>
        /// Тип погоды (для значка)
        /// </summary>
        public Weather Weather { get; set; }
    }

    /// <summary>
    /// Типы погоды.
    /// </summary>
    public enum Weather
    {
        // нет прогноза
        None,

        // снегопад
        Snow,

        // дождь
        Rain,

        // туман
        Tuman,

        // облачно
        Clouds,

        // ясно
        Sunny,

        // ветер 1-2 м/с
        Windy_1_2,

        // ветер 2-5 м/с
        Windy_2_5,

        // ветер 5-10 м/с
        Windy_5_10,

        // ветер 10-20 м/с
        Windy_10_20
    }
}