using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Sale
    {
        public readonly string Select =
            " select ([id], [CarPlate], [SaleDate], [SaleValue], [CustomerDocument], [EmployeeDocument], [PaymentId]) from Sale ";

        public readonly string SelectById =
            " select ([id], [CarPlate], [SaleDate], [SaleValue], [CustomerDocument], [EmployeeDocument], [PaymentId]) from Sale where [id] = @id";

        public readonly string InsertOne =
            " insert into Sale values([id], [CarPlate], [SaleDate], [SaleValue], [CustomerDocument], [EmployeeDocument], [PaymentId]) ";

        public readonly string UpdateById =
            " update Sale set [CarPlate] = @CarPlate, [SaleDate] = @SaleDate, [SaleValue] = @SaleValue, [CustomerDocument] = @CustomerDocument, [EmployeeDocument] = @EmployeeDocument, [PaymentId] = @PaymentId where [id] = @id ";

        public readonly string DeleteById =
            " delete from Sale where [id] = @id ";
        
        public int Id { get; set; }
        public Car Car { get; set; }
        public DateTime SaleDate { get; set; }
        public Decimal SaleValue { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public Payment Payment { get; set; }
    }
}
