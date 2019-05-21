using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class BusinessEntity
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public States _State
        {
            get { return _State; }
            set { _State = value; }
        }
        public enum States
        {
            Delete,
            New,
            Modified,
            Unmodified
        };
    }
    
}
