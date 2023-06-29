using FDocmanInter;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace FinalDocMan
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class DocService : IDocService
    {
        public void DeleteLetter(string id)
        {
            using(Codd db = new Codd())
            {
                try
                {

                Letter p = db.Letter.FirstOrDefault(k => k.Name == id);
                db.Letter.Remove(p);
                }
                catch
                {
                    
                }
            }
        }

        public List<string> GetAllLetters(int id)
        {
            using(Codd db = new Codd())
            {
                var list = new List<string>();
                list = (from p in db.Letter
                        where p.To == id
                       select p.Name).ToList();
                return list;
            }
        }

        public List<string> GetConcrLetter(string id)
        {
            var list1 = new List<string>();
            var list = new List<Letter>();
            string fmt = "yyyy-MM-dd HH:mm:ss";
            User u = new User();
            using (Codd db = new Codd())
            {
                
                list = (from p in db.Letter
                        where p.Name == id
                        select p).ToList();
                u = db.User.FirstOrDefault(l => l.ID == list[0].To);
            }
            list1.Add(list[0].Name);
            list1.Add(list[0].Description);
            list1.Add(list[0].From);
            list1.Add(list[0].Recieved.ToString(fmt));
            list1.Add(Convert.ToDateTime(list[0].Expiration).ToString(fmt));
            list1.Add(list[0].Path);
            list1.Add(u.Login);
            return list1;
        }

        public int GetIDToEnter(string login)
        {
            int a = -1;
            try
            {
                using (Codd db = new Codd())
                {
                    var use = db.User.FirstOrDefault(p => p.Login == login);
                    if (use != null)
                    {
                        if (use.Unit != "Приемная")
                        {
                            a = Convert.ToInt32(use.ID);
                        }
                        else return  a=0;
                    }
                    else return a=-1;
                }
            }
            catch
            {

            }
            return a;
            
        }

        public List<string> GetListOfLetters()
        {
            using (Codd db = new Codd())
            {
                var list = new List<string>();
                list = (from p in db.Letter
                        
                        select p.Name).ToList();
                return list;
            }
        }

        public Dictionary<string, int> GetUser()
        {
            Dictionary<string, int> a = new Dictionary<string, int>();
            List<User> b = new List<User>();
            using (Codd db = new Codd())
            {
                b = (from l in db.User
                     select l).ToList();
            }
            foreach(User pp in b)
            {
                a.Add(pp.Login, pp.ID);
            }
            return a;
        }

        public void NewLetter(List<object> lett)
        {
            Letter letter = new Letter();
            letter.Name = Convert.ToString(lett[0]);
            letter.Description = Convert.ToString(lett[1]);
            letter.From = Convert.ToString(lett[2]);
            letter.To = Byte.Parse(Convert.ToString(lett[3]));
            letter.Recieved = DateTime.Parse(Convert.ToString(lett[4]));
            letter.Expiration = DateTime.Parse(Convert.ToString(lett[5]));
            letter.Status = Convert.ToString(lett[6]);
            letter.Path= Convert.ToString(lett[7]);
            letter.Answer = Convert.ToString(lett[8]);
            using(Codd db = new Codd())
            {
                try
                {
                    db.Letter.Add(letter);
                    db.SaveChanges();
                }
                catch
                {

                }
            }
        }
    }
}
