namespace App.Host
{
    /// <summary>
    /// Example.
    /// TODO: Remove
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Gets or sets the forecast date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Gets or sets the temperature in C.
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// Gets the temperature in F.
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// Gets or sets the textual summary of the forecast.
        /// </summary>
        public string? Summary { get; set; }
    }
}
