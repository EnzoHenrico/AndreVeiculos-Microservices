using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee : Person
    {
        public readonly string Select =
            " select ([Documnet], [PositionId], [CommissionValue], [Commission], [Name], [BirthDate], [AddressId], [Phone], [Email]) from Employee ";

        public readonly string SelectById =
            " select ([Documnet], [PositionId], [CommissionValue], [Commission],[Name], [BirthDate], [AddressId], [Phone], [Email]) from Employee where [Document] = @Document";

        public readonly string InsertOne =
            " insert into Employee values([Documnet], [PositionId], [CommissionValue], [Commission],[Name], [BirthDate], [AddressId], [Phone], [Email]) ";

        public readonly string UpdateById =
            " update Employee set [PositionId] = @PositionId, [CommissionValue] = @CommissionValue, [Commission] = @Commission,[Name] = @Name, [BirthDate] = @BirthDate, [AddressId] = @AddressId, [Phone] = @Phone, [Email] = @Email where [Document] = @Document ";

        public readonly string DeleteById =
            " delete from Employee where [Document] = @Document ";
        
        public Position Position { get; set; }
        public Decimal CommissionValue { get; set; }
        public Decimal Commission { get; set; }
    }
}
