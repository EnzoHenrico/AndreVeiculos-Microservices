using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTO;

namespace Models
{
    public class Address
    {
        public static readonly string Select =
            " select [Id], [AddressName], [Zip], [Neighborhood], [AddressType], [Complement], [Number], [Fu], [City] from Address ";

        public static readonly string SelectById =
            " select [Id], [AddressName], [Zip], [Neighborhood], [AddressType], [Complement], [Number], [Fu], [City] from Address where [Id] = @Id ";

        public static readonly string InsertOne =
            " insert into Address values(@AddressName, @Zip, @Neighborhood, @AddressType, @Complement, @Number, @Fu, @City) ";

        public static readonly string UpdateById =
            " update Address set [AddressName]= @AddressName, [Zip] = @Zip, [Neighborhood] = @Neighborhood, [AddressType] = @AddressType, [Complement] = @Complement, [Number] = @Number, [Fu] = @Fu, [City] = @City where [Id] = @Id ";

        public static readonly string DeleteById =
            " delete from Adrress where [Id] = @Id ";
        
        public int Id { get; set; } // API CORREIOS
        public string? AddressName { get; set; } // API CORREIOS -> Logradouro
        public string Zip { get; set; } // API CORREIOS 
        public string Neighborhood { get; set; } // API CORREIOS  
        public string AddressType { get; set; } // API CORREIOS ->  Rua ou avenida (street or avenue)
        public string Complement { get; set; } // REQUESITO
        public int Number { get; set; } //  REQUESITO
        public string Fu { get; set; } // API CORREIOS -> (UF - Unidade Federativa)
        public string City { get; set; } // API CORREIOS 

        public Address()
        {
        }

        public Address(AddressDTO dto)
        {
            Zip = dto.Zip;
            Complement = dto.Complement;
            Number = dto.Number;
        }
    }
}
