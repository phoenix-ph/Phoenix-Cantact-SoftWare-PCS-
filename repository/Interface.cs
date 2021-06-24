using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace contact
{
    interface Interface
    {
        DataTable SelectAll();
        DataTable SelectRow(int ContactID);
        DataTable Search(string KeyWord);
        bool Insert(string name, string family, string mobail, string email, int age, string address,string country,string nationality,string nationalitycode);
        bool Update(int ContactID, string name, string family, string mobail, string email, int age, string address, string country, string nationality, string nationalitycode);
        bool Delete(int ContactID);
       
    }
}
