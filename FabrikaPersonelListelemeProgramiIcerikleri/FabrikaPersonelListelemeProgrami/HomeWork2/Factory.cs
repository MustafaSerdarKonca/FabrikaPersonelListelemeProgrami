using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Factory
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public List<Personel> Staff { get; set; } //aggregation

        public void AddStaff(Personel prs)
        {
            Staff.Add(prs);
        }
        public void RemoveStaff(ulong personelNo)
        {
            foreach (Personel prs in Staff)
            {
                 
                if (personelNo == prs.PersonelNo)
                {
                    Staff.Remove(prs);
                }
            }
        }

        public string ListStaff(int i)
        {
            Personel forListPersonel = Staff[i];

            string personelInfo = i+1 + ") Personel No: " + forListPersonel.PersonelNo + "\n" +
                                    "  \nDepartment: " + forListPersonel.Department +
                                    "  \nTurkey ID No: " + forListPersonel.IDInformation.TrIDNo +
                                    "  \nName: " + forListPersonel.IDInformation.Name +
                                    "  \nLast Name: " + forListPersonel.IDInformation.LastName +
                                    "  \nSex: " + forListPersonel.IDInformation.Sex +
                                    "  \nPlace of Birth: " + forListPersonel.IDInformation.PlaceofBirth;
            return personelInfo;
        }
        
	
    }
}
