using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Infrastructure
{
    public class PersonRepository : IBaseReposiroty<PersonModel>
    {
        public PersonModel GetByName(string name)
        {
            using (var context = new Context())
            {
                string[] _name = name.Split();
                var item = PersonMapper.Map(context.Person.FirstOrDefault(x => x.Last_name == _name[0] && x.First_name == _name[1] && x.Middle_name == _name[2]));
                return item;
            }
        }

        public PersonModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = PersonMapper.Map(context.Person.FirstOrDefault(x => x.ID == id));
                return item;
            }
        }

        public List<PersonModel> GetList()
        {
            using (Context context = new Context())
            {
                return PersonMapper.Map(context.Person.ToList());
            }
        }

        public PersonModel Update(PersonModel person)
        {
            using (var context = new Context())
            {
                int countP = context.Person.ToList().Count;
                int countU = context.User.ToList().Count;

                context.Person.AddOrUpdate(PersonMapper.Map(person));
                context.User.AddOrUpdate(PersonMapper.Map(person).User);
                
                if (context.Person.ToList().Count != countP && context.User.ToList().Count != countU)
                {
                    Delete(context.Person.Last().ID);
                    return null;
                }
                else
                {
                    context.SaveChanges();
                    return new PersonModel();
                }
            }
        }

        public PersonModel Delete(long id)
        {
            using (var context = new Context())
            {
                if (context.Person.Remove(PersonMapper.Map(GetById(id))) == null)
                {
                    return null;
                }
                else
                {
                    context.SaveChanges();
                    return new PersonModel();
                }
            }
        }

        public PersonModel Add(PersonModel personModel)
        {
            using (var context = new Context())
            {
                Person person = PersonMapper.Map(personModel);

                if (context.Person.Add(person) == null)
                {
                    return null;
                }
                else
                {
                    context.SaveChanges();
                    return new PersonModel();
                }

            }
        }
    }
}