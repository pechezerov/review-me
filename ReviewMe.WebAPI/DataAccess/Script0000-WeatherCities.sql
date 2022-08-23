-- создаём таблицу с городами
CREATE TABLE IF NOT EXISTS cities
(
    id                  serial PRIMARY KEY,
    name                text NOT NULL,
);

-- создаём таблицу с прогнозами погоды 
-- пока что частота прогнозов осуществляется раз в сутки, поэтому регистрируется только дата,
-- позже будет добавлен столбец с временем
CREATE TABLE IF NOT EXISTS weather_forecasts
(
    id                  serial PRIMARY KEY,
    city_id             int NOT NULL,
    date                date NOT NULL,
    weather_type        int NOT NULL,
);

ALTER TABLE weather_forecasts ADD CONSTRAINT weather_forecasts_cities_fk
FOREIGN KEY (city_id) REFERENCES cities(id) ON DELETE CASCADE;
