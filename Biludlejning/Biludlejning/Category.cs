namespace Biludlejning;

public abstract class Category
{
    protected char _id;
    protected string _title;
    protected string _description;
    protected double _price;

    protected Category(char id)
    {
        _id = id;
        switch (id)
        {
            case 'A':
                _title = "Økonomi";
                _description = "Bla bla bla";
                _price = 0.5;
                break;
            case 'B':
                _title = "Mellemklasse";
                _description = "Bla bla bla";
                _price = 1;
                break;
            case 'C':
                _title = "Luksus";
                _description = "Bla bla bla";
                _price = 2;
                break;
        }
    }
}