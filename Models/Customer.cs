using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer : Person
    {
        public readonly string Select =
            " select ([Documnet], [Income], [PDFDocument],[Name], [BirthDate], [AddressId], [Phone], [Email]) from Customer ";

        public readonly string SelectById =
            " select ([Documnet], [Income], [PDFDocument],[Name], [BirthDate], [AddressId], [Phone], [Email]) from Customer where [Document] = @Document";

        public readonly string InsertOne =
            " insert into Customer values([Documnet], [Income], [PDFDocument],[Name], [BirthDate], [AddressId], [Phone], [Email]) ";

        public readonly string UpdateById =
            " update Customer set [Income] = @Income, [PDFDocument] = @PDFDocument, [Name] = @Name, [BirthDate] = @BirthDate, [AddressId] = @AddressId, [Phone] = @Phone, [Email] = @Email where [Document] = @Document ";

        public readonly string DeleteById =
            " delete from Customer where [Document] = @Document ";
        
        public Decimal Income { get; set; }
        public string PDFDocument { get; set; }
    }
}
