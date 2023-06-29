using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FDocmanInter
{
    // ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IDocService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IDocService
    {
        [OperationContract]
        int GetIDToEnter(string login);

        [OperationContract]
        List<string> GetListOfLetters();

        [OperationContract]
        List<string> GetAllLetters(int id);

        [OperationContract]
        List<string> GetConcrLetter(string id);

        [OperationContract]
        Dictionary<string, int> GetUser();

        [OperationContract]
        void NewLetter(List<object> lett);

        [OperationContract]
        void DeleteLetter(string id);
    }
}
//public partial class Letter
//{
//    public int ID { get; set; }
//    public string Name { get; set; }
//    public string Description { get; set; }
//    public string From { get; set; }
//    public Nullable<byte> To { get; set; }
//    public System.DateTime Recieved { get; set; }
//    public Nullable<System.DateTime> Expiration { get; set; }
//    public string Status { get; set; }
//    public string Path { get; set; }
//    public string Answer { get; set; }

//    public virtual User User { get; set; }
//}

//public partial class User
//{
//    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//    public User()
//    {
//        this.Letter = new HashSet<Letter>();
//    }

//    public byte ID { get; set; }
//    public string Login { get; set; }
//    public string Unit { get; set; }

//    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//    public virtual ICollection<Letter> Letter { get; set; }
//}