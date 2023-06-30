using FDocmanInter;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;


namespace FinalDocMan
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class DocService : IDocService
    {
        public string put;
        public string constPut;
        public string DeleteLetter(string id)
        {
            string o = "vse ok";
            using(Codd db = new Codd())
            {
                try
                {
                    Letter p = db.Letter.FirstOrDefault(k => k.Name == id);
                    db.Letter.Remove(p);
                    db.SaveChanges();
                }
                catch
                {
                    o = "ne ok";
                }
                return o;
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
            string fmt = "dd.MM.yyyy H:mm:ss";
            User u = new User();
            using (Codd db = new Codd())
            {
                
                list = (from p in db.Letter
                        where p.Name == id
                        select p).ToList();
                var lol = Convert.ToByte(list[0].To);
                u = db.User.FirstOrDefault(l => l.ID == lol);
            }
            list1.Add(list[0].Name);
            list1.Add(list[0].Description);
            list1.Add(list[0].From);
            list1.Add(list[0].Recieved.ToString(fmt));
            list1.Add(Convert.ToDateTime(list[0].Expiration).ToString(fmt));
            list1.Add(list[0].Path);
            list1.Add(u.Login);
            list1.Add(Convert.ToString(list[0].ID));
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

        private byte boba(string nam)
        {
            using (Codd db = new Codd())
            {
                User user = new User();
                user.Login = nam;
                user.Unit = "кефир";
                db.User.Add(user);
                db.SaveChanges();
                user = db.User.FirstOrDefault(l => l.Login == nam);
                return user.ID;
            }
        }
        public void NewLetter(List<object> lett)
        {
            byte ids;
            User aa = new User();
            using (Codd db = new Codd())
            {
                string llll = Convert.ToString(lett[3]);
                aa = db.User.FirstOrDefault(d => d.Login == llll);
            }
                if (aa is null)
            {
                ids = boba(Convert.ToString(lett[3]));
            }
            else
            {
                using (Codd db = new Codd())
                {
                    string u = Convert.ToString(lett[3]);
                    var o = db.User.FirstOrDefault(h => h.Login == u);
                    ids = o.ID;
                }
            }
            Letter letter = new Letter();
            letter.Name = Convert.ToString(lett[0]);
            letter.Description = Convert.ToString(lett[1]);
            letter.From = Convert.ToString(lett[2]);
            letter.To = ids;
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

        public string UpdateLetter(List<string> lett)
        {
            string q = "no mist";

            try
            {

                using (Codd db = new Codd())
                {
                    var k = db.User.FirstOrDefault(o => o.Login == lett[3]);
                    var let = db.Letter.FirstOrDefault(o => o.ID == Convert.ToInt32(lett[6]));
                    Letter newlet = new Letter();
                    newlet.Name = lett[0];
                    newlet.Description = lett[1];
                    newlet.From = lett[2];
                    newlet.To = k.ID;
                    newlet.Recieved = Convert.ToDateTime(lett[4]);
                    newlet.Expiration = Convert.ToDateTime(lett[5]);
                    newlet.Status = let.Status;
                    newlet.Answer = let.Answer;
                    newlet.Path = let.Path;
                    db.Letter.Remove(let); db.SaveChanges();
                    db.Letter.Add(newlet); db.SaveChanges();
                    //_ = db.Database.ExecuteSqlCommand($"UPDATE [Letter] set Name='{lett[0]}', Description='{lett[1]}', From='{lett[2]}', To={Convert.ToInt32(k.ID)}, Recieved='{lett[4]}', Expiration='{lett[5]}' where ID={Convert.ToInt32(lett[6])}");

                }
            }
            catch
            {
                q = "mist";
            }
            return q;
        }

        public List<string> GetUsers()
        {
            List<string> list = new List<string>();
            using (Codd db = new Codd())
            {
                list = (from p in db.User
                        select p.Login).ToList();
            }
            return list;
        }

        public void NewUse(List<string> use)
        {
            using(Codd db = new Codd())
            {
                User user = new User();
                user.Login = use[0];
                user.Unit = use[1];
                db.User.Add(user);
                db.SaveChanges();
            }
        }

        public void DeleteUser(string nam)
        {
            using(Codd db = new Codd())
            {
                var a = db.User.FirstOrDefault(l => l.Login== nam);
                db.User.Remove(a);
                db.SaveChanges();
            }
        }

        public void SetPath(string path)
        {
            int o = 0;
            constPut = path;
            //"\\26.181.252.32\Users\Public"
            for(int i = path.Length-1;i>=0;i--)
            {
                if (path[i] == '\\')
                {
                    o = i; break;
                }
            }
            put = path.Remove(o, path.Length - o);
        }

        public string ReturnPath()
        {
            
                return put;
            
        }

        public string ReturnPut()
        {
            return constPut;
        }
    }
}
