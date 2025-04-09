namespace Disaheim;

public class Utility
{



    public double LowQualityValue { get; set; } = 12.5;
    public double MediumQualityValue { get; set; } = 20;
    public double HighQualityValue { get; set; } = 27.5;

    public double CourseHourValue { get; set; } = 875.0;


    Utility() {
    }

    public double GetValueOfMerchandise(Merchandise merchandise)
    {
        double Price = 0;
        if (merchandise is Amulet amulet)
        {
            
            switch (amulet.Quality)
            {
                case Level.low:
                    Price = LowQualityValue;
                    break;
                case Level.medium:
                    Price = MediumQualityValue;
                    break;
                case Level.high:
                    Price = HighQualityValue;
                    break;
            }
        }
        if (merchandise is Book book)
        {
            Price = book.Price;
        }
        return Price;
    }


    public double GetValueOfCourse(Course course)
    {
        int Mod = course.DurationInMinutes % 60;
        double Price = 0;
        if (Mod == 0)
        {
            Price = CourseHourValue * (course.DurationInMinutes / 60);
        }
        else if (Mod > 0)
        {
            Price = CourseHourValue * ((course.DurationInMinutes / 60) + 1);
            
        }
        return Price;
    }
}