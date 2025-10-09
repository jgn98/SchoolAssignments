using System.IO.Pipes;

namespace Pr12_Persistens;

public class DataHandler
{
    private string dataFileName;

    public string DataFileName
    {
        get;
    }

    public DataHandler(string dataFileName)
    {
        DataFileName = dataFileName;
    }

    public void SavePerson(Person person)
    {
            using (StreamWriter sw = new StreamWriter(DataFileName))
            {
                sw.WriteLine(person.MakeTitle());
            }
    }

    public Person LoadPerson()
    {
        //Instancing all variables
        Person person = new Person("navn",DateTime.Now,0,false,0);
        string line;
        string[] part = new string[5];
            //Using StreamRead to read the line in the file
            using (StreamReader sr = new StreamReader(DataFileName))
            {
                line = sr.ReadLine();
            }
            //Splitting the line into 5 parts, each containing the person's information
            part = line.Split(';');
            person.Name = part[0];
            person.BirthDate = DateTime.Parse(part[1]);
            person.Height = double.Parse(part[2]);
            person.IsMarried = bool.Parse(part[3]);
            person.NoOfChildren = int.Parse(part[4]);
       
        return person;
    }

    public void SavePersons(Person[] persons)
    {
            //Using StreamWriter to write all Titles as a string, to the file
            using (StreamWriter sw = new StreamWriter(DataFileName))
            {
                for (int i = 0; i < persons.Length; i++)
                {
                    string title = persons[i].MakeTitle();
                    if (i == persons.Length - 1)
                    {
                        sw.Write(title);
                    }
                    else
                    {
                        sw.WriteLine(title);
                    }
                }
            }
    }
    

    public Person[] LoadPersons()
    {
        //Instancing all variables
        
        string[] part = new string[5];
        Person[] person = null;
        
            //Using StreamReader to read the entire file and split the lines using Environment.NewLine
            using (StreamReader sr = new StreamReader(DataFileName))
            {
                string[] lines = null;
                lines = sr.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                //Instanciating person variable with amount of lines
                person = new Person[lines.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    //Splitting each line into 5 parts, containing the person info
                    part = lines[i].Split(';');
                    //Creating a new person for each line found in file, and assigning the value from that line to the person
                    person[i]= new Person(part[0], DateTime.Parse(part[1]), double.Parse(part[2]), bool.Parse(part[3]), int.Parse(part[4]));
                }
            }
           
        return person;
    }
}
