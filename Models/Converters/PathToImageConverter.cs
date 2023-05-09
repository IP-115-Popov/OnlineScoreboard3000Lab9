using Avalonia.Data.Converters;
using Avalonia.Platform;
using Avalonia;
using System;
using System.Globalization;
using System.Reflection;
using Avalonia.Media.Imaging;

namespace OnlineScoreboard3000.Models.Converters
{
    public class PathToImageConverter : IValueConverter
    {
        public static PathToImageConverter Instance = new PathToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            value = value switch
            {
               "Алроса" => "Assets\\Image\\ZF.jpg",
                "S7 Airlines" => "Assets\\Image\\S7.jpg",
                "Якутия" => "Assets\\Image\\yakutia.png",
                "SCAT Airlines" => "Assets\\Image\\scat.png",
                "Южный ветер" => "Assets\\Image\\southwind.png",
                "Победа" => "Assets\\Image\\pobeda.png",
                "Россия" => "Assets\\Image\\Rossiya.png",
                _ => null
            };

            if (value is string rawUri && targetType.IsAssignableFrom(typeof(Bitmap)))
            {
                Uri uri;

                // Allow for assembly overrides
                if (rawUri.StartsWith("avares://"))
                {
                    uri = new Uri(rawUri);
                }
                else
                {
                    string assemblyName = Assembly.GetEntryAssembly().GetName().Name;
                    uri = new Uri($"avares://{assemblyName}/{rawUri}");
                }

                var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
                var asset = assets.Open(uri);

                return new Bitmap(asset);
            }
            return null;
            //throw new NotSupportedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
