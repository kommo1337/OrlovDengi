//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrlovKursovaya.DataFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        public int ClientId { get; set; }
        public string FIO { get; set; }
        public int ClientPassport { get; set; }
        public string ClientAdress { get; set; }
        public System.DateTime ClientDateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int RemontId { get; set; }
    
        public virtual Remont Remont { get; set; }
    }
}
