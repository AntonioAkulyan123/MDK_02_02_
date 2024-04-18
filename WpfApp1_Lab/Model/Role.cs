using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1_Lab.Model
{
    public class Role
    {

        public int Id { get; set; }
        public string NameRole { get; set; }
        public Role() { }
        public Role(int id, string nameRole)
        {
            this.Id = id;
            this.NameRole = nameRole;
        }
        public Role ShallowCopy()
        {
            return (Role)this.MemberwiseClone();
        }
    }
}
