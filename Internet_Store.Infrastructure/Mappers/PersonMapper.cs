using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Infrastructure
{
    internal static class PersonMapper
    {
        public static PersonModel Map(Person entity)
        {
            PersonModel viewModel = new PersonModel()
            {
                ID = entity.ID,
                Last_name = entity.Last_name,
                First_name = entity.First_name,
                Middle_name = entity.Middle_name,
                Gender = entity.Gender == "м" ? "мужской" : "женский",
                Birthday = entity.Birthday == new DateTime() ? "" : entity.Birthday.Day.ToString() + '.' + entity.Birthday.Month.ToString() + '.' + entity.Birthday.Year.ToString(),
                Number_phone = entity.Number_phone,
                Email = entity.Email,
                DiscountID = entity.DiscountID,
                User = entity.User                
            };
            return viewModel;
        }
        public static List<PersonModel> Map(List<Person> entities)
        {
            var viewModels = entities.Select(i => Map(i)).ToList();
            return viewModels;
        }
        public static Person Map(PersonModel entity)
        { 
            DateTime ConvertData()
            {
                int[] birthD = entity.Birthday.Split('.').ToList().Select(i => Convert.ToInt32(i)).ToArray();
                try
                {
                    if (DateTime.UtcNow.Year - birthD[2] > 150 || DateTime.UtcNow.Year - birthD[2] < 0) throw new ArgumentOutOfRangeException(); 
                    return new DateTime(birthD[2], birthD[1], birthD[0]);
                }
                catch
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            Person model = new Person()
            {
                ID = entity.ID,
                Last_name = entity.Last_name,
                First_name = entity.First_name,
                Middle_name = entity.Middle_name,
                Gender = entity.Gender == "мужской" ? "м" : "ж",
                Birthday = entity.Birthday == "" ? new DateTime() : ConvertData(),
                Number_phone = Regex.IsMatch(entity.Number_phone, @"\+7\s?[\(]{0,1}9[0-9]{2}[\)]{0,1}\s?\d{3}[-]{0,1}\d{2}[-]{0,1}\d{2}") == true ? entity.Number_phone : throw new Exception("Number_Phone"),
                Email = entity.Email == "" ? "" : Regex.IsMatch(entity.Email, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$") == true ? entity.Email : throw new Exception("Email"),
                DiscountID = entity.DiscountID,
                User = entity.User
            };
            return model;
        }
        public static List<Person> Map(List<PersonModel> entities)
        {
            var models = entities.Select(i => Map(i)).ToList();
            return models;
        }
    }
}
