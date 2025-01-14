using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreMvcSavingAppStateUsingSession.Models
{
    public class TestModel
    {
        List<string> sessionsList = new List<string>();

        public void AddSessionToList(string v) => sessionsList.Add(v); 
        public int UsersCount => sessionsList.Count;
    }
}
