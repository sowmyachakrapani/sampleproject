using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnergyOnlineBusinessLogic.Items
{
    public class Employee
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string JobTitle { get; set; }
        private string _salary = string.Empty;

        public string Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
            }
        }

        public Employee()
        {
        }

        public Employee(string sal)
        {
            this.Name = string.Empty;
            this.ID = string.Empty;
            this.JobTitle = string.Empty;
            this.Salary = string.Format("{0:$#,##0}", int.Parse(sal));
        }
    }

}