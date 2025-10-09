using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurtigBiludlejning.Models
{
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
                    _title = "Lille Bil";
                    _description = "Kompakt og brændstoføkonomiske biler, ideelle til bykørsel og korte ture, eks. Toyota Aygo, Hyndai i10";
                    _price = 246;
                    break;
                case 'B':
                    _title = "Mellemklasse Bil";
                    _description = "Større end økonomi biler, mere komfortable og med flere funktioner. Velegnede til længere ture, eks. Golf, Ford Focus, og Toyota Corolla";
                    _price = 331;
                    break;
                case 'C':
                    _title = "Luksus Bil";
                    _description = "Premium køretøjer med avancerede funktioner og luksuriøst interior. Eks. Mercedes E klasse, BMW 5 serie, og Audi A6";
                    _price = 569;
                    break;
            }
        }
    }
}
